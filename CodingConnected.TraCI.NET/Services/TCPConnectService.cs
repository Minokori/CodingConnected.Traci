using System.Net.Sockets;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Services;

internal class TCPConnectService : ITcpService
    {
    private TcpClient _client;
    private NetworkStream _stream;
    private readonly byte[] _receiveBuffer = new byte[32768];

    public TcpClient Client => _client;
    public NetworkStream Stream => _stream;

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task ConnectAsync(string hostname, int port)
        {
        _client = new TcpClient { ReceiveBufferSize = 32768, SendBufferSize = 32768 };
        while (!_client.Connected)
            {
            try
                {
                await _client.ConnectAsync(hostname, port);
                }
            catch (Exception)
                {
                Console.WriteLine("Failed to connect to SUMO server. Retrying in 0.05 second");
                await Task.Delay(50);
                }
            }

        _stream = _client.GetStream();
        }

    public bool Connect(string hostname, int port)
        {
        _client = new TcpClient { ReceiveBufferSize = 32768, SendBufferSize = 32768 };

        try
            {
            _client.Connect(hostname, port);
            }
        catch (Exception)
            {
            return false;
            }

        if (_client.Connected)
            {
            _stream = _client.GetStream();
            return true;
            }
        else
            {
            return false;
            }
        }

    public List<TraCIResult> SendMessage(TraCICommand command)
        {
        if (!_client.Connected)
            {
            return null;
            }

        //send message
        _client.Client.Send(command.ToMessageBytes());

        //read response
        try
            {
            var hasReadLength = _stream.Read(_receiveBuffer, 0, 32768);
            if (hasReadLength < 0)
                {
                // Read returns 0 if the client closes the connection
                throw new IOException();
                }

            // Totol Byte to read
            var totalLength = BitConverter.ToInt32(_receiveBuffer.Take(4).Reverse().ToArray(), 0);

            // push all byte to response
            List<byte> response = [.. _receiveBuffer.Take(hasReadLength).ToArray()];

            // if buffer is not enough to read all bytes, read until all bytes are read
            if (hasReadLength != totalLength)
                {
                while (hasReadLength < totalLength)
                    {
                    var innerLength = _stream.Read(_receiveBuffer, 0, 32768);
                    response.AddRange(_receiveBuffer.Take(innerLength).ToArray());
                    hasReadLength += innerLength;
                    }
                }
            return response.AsTraCIResults();
            }
        catch
            {
            return null;
            }
        }
    }
