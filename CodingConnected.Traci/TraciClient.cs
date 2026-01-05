using System.Diagnostics;
using CodingConnected.Traci.Functions;
using CodingConnected.Traci.Services;

namespace CodingConnected.Traci;

public sealed partial class TraciClient
    {
    public TraciClient(
            ISumoConnectService sumoConnectService,
            ITraciCommandService traciCommandService,
            ITraciEventService traciEventService
        )
        {
        // get services
        SumoConnectService = sumoConnectService;
        TraciCommandService = traciCommandService;
        TraciEventService = traciEventService;
        // init functions
        Simulation = new(SumoConnectService, TraciCommandService);
        Control = new(SumoConnectService, TraciCommandService, TraciEventService);
        InductionLoop = new(SumoConnectService, TraciCommandService);
        LaneAreaDetector = new(SumoConnectService, TraciCommandService);
        MultiEntryExitDetector = new(SumoConnectService, TraciCommandService);
        Lane = new(SumoConnectService, TraciCommandService);
        TrafficLight = new(SumoConnectService, TraciCommandService);
        Vehicle = new(SumoConnectService, TraciCommandService, Simulation);
        Person = new(SumoConnectService, TraciCommandService);
        VehicleType = new(SumoConnectService, TraciCommandService);
        Route = new(SumoConnectService, TraciCommandService);
        POI = new(SumoConnectService, TraciCommandService);
        Polygon = new(SumoConnectService, TraciCommandService);
        Junction = new(SumoConnectService, TraciCommandService);
        Edge = new(SumoConnectService, TraciCommandService);
        Gui = new(SumoConnectService, TraciCommandService);
        BusStop = new(SumoConnectService, TraciCommandService);
        Calibrator = new(SumoConnectService, TraciCommandService);
        ChargingStation = new(SumoConnectService, TraciCommandService);
        ParkingArea = new(SumoConnectService, TraciCommandService);
        Rerouter = new(SumoConnectService, TraciCommandService);
        RouteProbe = new(SumoConnectService, TraciCommandService);
        VariableSpeedSign = new(SumoConnectService, TraciCommandService);
        }

    #region private services
    private ISumoConnectService SumoConnectService { get; init; }
    private ITraciCommandService TraciCommandService { get; init; }
    private ITraciEventService TraciEventService { get; init; }
    #endregion

    #region public functions
    public BusStop BusStop { get; init; }
    public Calibrator Calibrator { get; init; }
    public ChargingStation ChargingStation { get; init; }
    public Control Control { get; init; }
    public Edge Edge { get; init; }
    public Gui Gui { get; init; }
    public InductionLoop InductionLoop { get; init; }
    public Junction Junction { get; init; }
    public Lane Lane { get; init; }
    public LaneAreaDetector LaneAreaDetector { get; init; }
    public MultiEntryExitDetector MultiEntryExitDetector { get; init; }
    public ParkingArea ParkingArea { get; init; }
    public Person Person { get; init; }
    public POI POI { get; init; }
    public PolygonFunctions Polygon { get; init; }
    public Rerouter Rerouter { get; init; }
    public Route Route { get; init; }
    public RouteProbe RouteProbe { get; init; }
    public Simulation Simulation { get; init; }
    public TrafficLight TrafficLight { get; init; }
    public VariableSpeedSign VariableSpeedSign { get; init; }
    public Vehicle Vehicle { get; init; }
    public VehicleType VehicleType { get; init; }
    #endregion

    public string SumoFile { get; set; } = string.Empty;
    public int Port { get; set; } = 2000;

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task<(int traciApiVersion, string sumoVersion)> ConnectAsync(
        string hostname,
        int port
    ) =>
        await SumoConnectService
            .ConnectAsync(hostname, port)
            .ContinueWith(
                _ => Control.GetVersion(),
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default
            )
            .ContinueWith(
                versionTask => versionTask.Result,
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default
            )
            .ConfigureAwait(false);


    public async Task<(int traciApiVersion, string sumoVersion)> Start(
    string? sumoFile = null,
    int? port = null,
    bool gui = true,
    bool quit = true
)
        {
        SumoFile = sumoFile ?? SumoFile;
        Port = port ?? Port;
        var args =
            $"-c {SumoFile}"
            + $" --remote-port {Port}"
            + $" {(gui ? " --start " : " ")}"
            + $" {(quit ? " --quit-on-end " : " ")}"
            + $" --num-clients 1";
        var sumoExecutable = gui ? "sumo-gui" : "sumo";
        using Process sumoProcess = new()
            {
            StartInfo = new()
                {
                Arguments = args,
                FileName = sumoExecutable, // The executable for the sumo
                UseShellExecute = true,
                },
            };
        _ = sumoProcess.Start();
        var (versionId, versionString) = await ConnectAsync("127.0.0.1", Port)
            .ConfigureAwait(false);
        return (versionId, versionString);
        }

    public List<TraciResult> SendCommand(TraciCommand traciCommand) => SumoConnectService.SendMessage(traciCommand);
    }

