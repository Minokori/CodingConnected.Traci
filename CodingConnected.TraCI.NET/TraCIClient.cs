using CodingConnected.TraCI.NET.ProtocolTypes;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CodingConnected.TraCI.NET;

/// <summary>
/// A simple )and yet incomplete) client-side implementation of TraCI, for using SUMO
/// with .NET applications.
/// </summary>
public partial class TraCIClient : IDisposable
    {
    private ITCPConnectService TcpSerivce => services.GetRequiredService<ITCPConnectService>();
    private readonly ServiceProvider services;




    #region Public Methods

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task<Tuple<int, string>> ConnectAsync(string hostname, int port) => await TcpSerivce.ConnectAsync(hostname, port)
            .ContinueWith(_ => Control.GetVersion())
            .ContinueWith(versionTask => versionTask.Result);


    public bool Connect(string hostname, int port) => TcpSerivce.Connect(hostname, port);

    #endregion // Public Methods



    public List<TraciResult> SendMessage(TraCICommand command) => TcpSerivce.SendMessage(command);



    }

