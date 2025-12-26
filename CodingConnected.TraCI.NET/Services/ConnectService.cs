using System.Buffers;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Net.Sockets;

namespace CodingConnected.Traci.Services;

internal sealed class ConnectService : ITcpConnectService, IDisposable
    {
    private byte[] ReceiveBuffer { get; } = ArrayPool<byte>.Shared.Rent(8194);

    public TcpClient Client { get; } = new TcpClient();
    public NetworkStream? Stream { get; private set; }

    public async Task ConnectAsync(string hostname, int port)
        {
        while (!Client.Connected)
            {
            try
                {
                await Client.ConnectAsync(hostname, port).ConfigureAwait(false);
                }
            catch (SocketException)
                {
                await Task.Delay(50).ConfigureAwait(false);
                Debug.WriteLine("Retrying connection to SUMO in 0.05s ...");
                }
            }
        Stream = Client.GetStream();
        }

    public bool Connect(string hostname, int port)
        {
        try
            {
            Client.Connect(hostname, port);
            }
        catch (SocketException)
            {
            return false;
            }

        if (Client.Connected)
            {
            Stream = Client.GetStream();
            return true;
            }
        return false;
        }

    public IList<TraciResult> SendMessage(TraciCommand command)
        {
        if (Client is null || !Client.Connected || Stream is null)
            {
            return [];
            }

        // 1. 发送数据
        Stream.Write(command.ToMessageSpan());

        // 2. 读取头部 (4字节)
        Stream.ReadExactly(ReceiveBuffer, 0, 4);

        // 3. 解析长度 (高效零拷贝)
        int messageLength = BinaryPrimitives.ReadInt32BigEndian(ReceiveBuffer.AsSpan(0, 4));

        // 4. 读取剩余的消息体
        // totalLength 包含了头部的4字节，我们需要再读 (messageLength - 4)
        int bodyLength = messageLength - 4;
        if (bodyLength > 0)
            {
            // 从偏移量 4 开始，读取剩余所有字节
            Stream.ReadExactly(ReceiveBuffer, 4, bodyLength);
            }

        // 5. 解析结果
        return new ReadOnlySpan<byte>(ReceiveBuffer, 0, messageLength).AsTraciResults();
        }

    public void Dispose()
        {
        Client?.Close();
        Stream?.Dispose();
        ArrayPool<byte>.Shared.Return(ReceiveBuffer);
        }
    }
