using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CodingConnected.TraCI.NET;

/// <summary>
/// A simple )and yet incomplete) client-side implementation of TraCI, for using SUMO
/// with .NET applications.
/// </summary>
public partial class TraCIClient : IDisposable
    {
    private ITcpService TcpSerivce => services.GetRequiredService<ITcpService>();
    private readonly ServiceProvider services;




    #region Public Methods

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task<Tuple<int, string>> ConnectAsync(string hostname, int port)
        {
        return await TcpSerivce.ConnectAsync(hostname, port)
            .ContinueWith(_ => Control.GetVersion())
            .ContinueWith(versionTask => versionTask.Result);
        }


    public bool Connect(string hostname, int port)
        {
        return TcpSerivce.Connect(hostname, port);
        }

    #endregion // Public Methods

    #region Set Variable Methods

    /// <summary>
    /// Sets the state of all lights of a controlled junction
    /// </summary>
    /// <param name="trafficLightId">The id of the traffic light as set in SUMO</param>
    /// <param name="state">The state to set the traffic lights to, parsed as a string, as is 
    /// described here: http://sumo.dlr.de/wiki/TraCI/Change_Traffic_Lights_State </param>
    public void SetTrafficLightState(string trafficLightId, string state)
        {
        TraCICommand command = new() { Identifier = TraCIConstants.CMD_SET_TL_VARIABLE };
        List<byte> bytes =
            [
            TraCIConstants.TL_RED_YELLOW_GREEN_STATE,
            .. trafficLightId.ToTraCIBytes(),
            TraCIConstants.TYPE_STRING,
            .. BitConverter.GetBytes(state.Length).Reverse(),
            .. Encoding.ASCII.GetBytes(state),
            ];

        command.Contents = [.. bytes];
        _ = SendMessage(command);
        }

    #endregion // Set VariableType Methods

    #region Public Methods

    public List<TraCIResult> SendMessage(TraCICommand command) => TcpSerivce.SendMessage(command);

    #endregion // Public Methods
    }

