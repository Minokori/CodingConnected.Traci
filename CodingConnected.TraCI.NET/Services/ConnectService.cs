using System.Net.Sockets;
using CodingConnected.TraCI.NET.ProtocolTypes;

namespace CodingConnected.TraCI.NET.Services;

internal class ConnectService : ITCPConnectService
    {
    private readonly byte[] _receiveBuffer = new byte[32768];

    public TcpClient? Client { get; private set; }
    public NetworkStream? Stream { get; private set; }

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task ConnectAsync(string hostname, int port)
        {
        Client = new TcpClient { ReceiveBufferSize = 32768, SendBufferSize = 32768 };
        while (!Client.Connected)
            {
            try
                {
                await Client.ConnectAsync(hostname, port);
                }
            catch (Exception)
                {
                Console.WriteLine("Failed to connect to SUMO server. Retrying in 0.05 second");
                await Task.Delay(50);
                }
            }
        Stream = Client.GetStream();
        }

    public bool Connect(string hostname, int port)
        {
        Client = new TcpClient { ReceiveBufferSize = 32768, SendBufferSize = 32768 };

        try
            {
            Client.Connect(hostname, port);
            }
        catch (Exception)
            {
            return false;
            }

        if (Client.Connected)
            {
            Stream = Client.GetStream();
            return true;
            }
        else
            {
            return false;
            }
        }

    public List<TraciResult> SendMessage(TraCICommand command)
        {
        if (Client is null || !Client.Connected)
            {
            return [];
            }

        //send message
        Client.Client.Send(command.ToMessageBytes());

        //read responseBytes
        try
            {
            var hasReadLength = Stream!.Read(_receiveBuffer, 0, 32768);
            if (hasReadLength < 0)
                {
                // Read returns 0 if the client closes the connection
                throw new IOException();
                }

            // Totals Byte to read
            var totalLength = BitConverter.ToInt32([.. _receiveBuffer.Take(4).Reverse()], 0);

            // push all byte to responseBytes
            List<byte> responseBytes = [.. _receiveBuffer.Take(hasReadLength).ToArray()];

            // if buffer is not enough to read all bytes, read until all bytes are read
            if (hasReadLength != totalLength)
                {
                while (hasReadLength < totalLength)
                    {
                    var innerLength = Stream.Read(_receiveBuffer, 0, 32768);
                    responseBytes.AddRange([.. _receiveBuffer.Take(innerLength)]);
                    hasReadLength += innerLength;
                    }
                }
            return responseBytes.AsTraCIResults();
            }
        catch
            {
            return [];
            }
        }

    public void Dispose()
        {
        Client?.Close();
        Stream?.Dispose();
        }
    }
