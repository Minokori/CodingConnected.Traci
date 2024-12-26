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
        _client = new TcpClient
            {
            ReceiveBufferSize = 32768,
            SendBufferSize = 32768
            };
        await _client.ConnectAsync(hostname, port);
        _stream = _client.GetStream();
        }

    public bool Connect(string hostname, int port)
        {
        _client = new TcpClient
            {
            ReceiveBufferSize = 32768,
            SendBufferSize = 32768
            };

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

    public TraCIResult[] SendMessage(TraCICommand command)
        {
        if (!_client.Connected)
            {
            return null;
            }

        byte[] msg = command.ToMessageBytes();
        _client.Client.Send(msg);
        try
            {
            int bytesRead = _stream.Read(_receiveBuffer, 0, 32768);
            if (bytesRead < 0)
                {
                // Read returns 0 if the client closes the connection
                throw new IOException();
                }

            byte[] revLength = _receiveBuffer.Take(4).Reverse().ToArray();
            int totlength = BitConverter.ToInt32(revLength, 0);
            List<byte> response = [.. _receiveBuffer.Take(bytesRead).ToArray()];

            if (bytesRead != totlength)
                {
                while (bytesRead < totlength)
                    {
                    int innerBytesRead = _stream.Read(_receiveBuffer, 0, 32768);
                    response.AddRange(_receiveBuffer.Take(innerBytesRead).ToArray());
                    bytesRead += innerBytesRead;
                    }
                }
            //var response = _receiveBuffer.Take(bytesRead).ToArray();
            TraCIResult[] trresponse = response.ToTraCIResults();
            return trresponse?.Length > 0 ? trresponse : null;
            }
        catch
            {
            return null;
            }
        }
    }

