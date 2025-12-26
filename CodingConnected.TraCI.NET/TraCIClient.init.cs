using CodingConnected.Traci.Functions;
using CodingConnected.Traci.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.Traci;

public partial class TraciClient
    {
    public TraciClient(string? sumoFilePath = null, int? port = null, bool enableDebug = false)
        {
        SumoFile = sumoFilePath ?? string.Empty;
        Port = port ?? 0;
        ServiceCollection servicesBuilder = new();
        _ = servicesBuilder.AddSingleton<IDebugService, DebugService>(i => new(enableDebug));
        _ = servicesBuilder.AddSingleton<ITcpConnectService, ConnectService>();
        _ = servicesBuilder.AddSingleton<ICommandService, CommandService>();
        _ = servicesBuilder.AddSingleton<IEventService, EventService>();
        _ = servicesBuilder.AddSingleton<Simulation>();
        _ = servicesBuilder.AddSingleton<Control>();
        _ = servicesBuilder.AddSingleton<InductionLoop>();
        _ = servicesBuilder.AddSingleton<LaneAreaDetector>();
        _ = servicesBuilder.AddSingleton<MultiEntryExitDetector>();
        _ = servicesBuilder.AddSingleton<Lane>();
        _ = servicesBuilder.AddSingleton<TrafficLight>();
        _ = servicesBuilder.AddSingleton<Vehicle>();
        _ = servicesBuilder.AddSingleton<Person>();
        _ = servicesBuilder.AddSingleton<VehicleType>();
        _ = servicesBuilder.AddSingleton<Route>();
        _ = servicesBuilder.AddSingleton<POI>();
        _ = servicesBuilder.AddSingleton<PolygonFunctions>();
        _ = servicesBuilder.AddSingleton<Junction>();
        _ = servicesBuilder.AddSingleton<Edge>();
        _ = servicesBuilder.AddSingleton<Gui>();
        _ = servicesBuilder.AddSingleton<BusStop>();
        _ = servicesBuilder.AddSingleton<Calibrator>();
        _ = servicesBuilder.AddSingleton<ChargingStation>();
        _ = servicesBuilder.AddSingleton<ParkingArea>();
        _ = servicesBuilder.AddSingleton<Rerouter>();
        _ = servicesBuilder.AddSingleton<RouteProbe>();
        _ = servicesBuilder.AddSingleton<VariableSpeedSign>();
        Services = servicesBuilder.BuildServiceProvider();
        }

    }

