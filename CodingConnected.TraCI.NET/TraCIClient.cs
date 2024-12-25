using System.Net.Sockets;
using System.Text;
using CodingConnected.TraCI.NET.Commands;
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
    #region Fields
    private ITcpService _tcpserivce { get => services.GetRequiredService<ITcpService>(); }

    private readonly ServiceProvider services;

    public IEventService EventService { get => services.GetRequiredService<IEventService>(); }

    // Commands
    private ControlCommands _control;
    private InductionLoopCommands _inductionLoop;
    private LaneAreaDetectorCommands _laneAreaDetector;
    private MultiEntryExitDetectorCommands _multiEntryExitDetector;
    private LaneCommands _lane;
    private TrafficLightCommands _trafficLight;
    private VehicleCommands _vehicle;
    private PersonCommands _person;
    private VehicleTypeCommands _vehicleType;
    private RouteCommands _route;
    private POICommands _POI;
    private PolygonCommands _polygon;
    private GuiCommands _gui;
    private JunctionCommands _junction;
    private EdgeCommands _edge;
    private SimulationCommands _simulation;

    #endregion // Fields



    #region Public Methods

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task ConnectAsync(string hostname, int port)
        {
        await _tcpserivce.ConnectAsync(hostname, port);
        }


    public bool Connect(string hostname, int port)
        {
        return _tcpserivce.Connect(hostname, port);
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
            .. TraCIDataConverter.GetTraCIBytesFromASCIIString(trafficLightId),
            TraCIConstants.TYPE_STRING,
            .. BitConverter.GetBytes(state.Length).Reverse(),
            .. Encoding.ASCII.GetBytes(state),
            ];

        command.Contents = [.. bytes];
        // ReSharper disable once UnusedVariable
        _ = SendMessage(command);
        }

    #endregion // Set Variable Methods

    #region Public Methods

    internal TraCIResult[] SendMessage(TraCICommand command)
        {
        var tcpClient = services.GetRequiredService<ITcpService>();
        return tcpClient.SendMessage(command);
        }

    #endregion // Public Methods
    public TraCIClient()
        {
        var servicesbuilder = new ServiceCollection();
        servicesbuilder.AddSingleton<ITcpService, TCPConnectService>();
        servicesbuilder.AddSingleton<ICommandHelperService, TraCICommandHelper>();
        servicesbuilder.AddSingleton<IEventService, EventService>();
        servicesbuilder.AddSingleton<ControlCommands>();
        servicesbuilder.AddSingleton<InductionLoopCommands>();
        servicesbuilder.AddSingleton<LaneAreaDetectorCommands>();
        servicesbuilder.AddSingleton<MultiEntryExitDetectorCommands>();
        servicesbuilder.AddSingleton<LaneCommands>();
        servicesbuilder.AddSingleton<TrafficLightCommands>();
        servicesbuilder.AddSingleton<VehicleCommands>();
        servicesbuilder.AddSingleton<PersonCommands>();
        servicesbuilder.AddSingleton<VehicleTypeCommands>();
        servicesbuilder.AddSingleton<RouteCommands>();
        servicesbuilder.AddSingleton<POICommands>();
        servicesbuilder.AddSingleton<PolygonCommands>();
        servicesbuilder.AddSingleton<JunctionCommands>();
        servicesbuilder.AddSingleton<EdgeCommands>();
        servicesbuilder.AddSingleton<SimulationCommands>();
        servicesbuilder.AddSingleton<GuiCommands>();
        services = servicesbuilder.BuildServiceProvider();
        }
    }

