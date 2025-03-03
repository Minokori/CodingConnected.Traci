using CodingConnected.TraCI.NET.Functions;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.TraCI.NET;

public partial class TraciClient
    {
    public TraciClient(string? sumoFilePath = null, int? port = null, bool enableDebug = false)
        {
        SumoFile = sumoFilePath ?? string.Empty;
        Port = port ?? 0;
        ServiceCollection servicesBuilder = new();
        servicesBuilder.AddSingleton<IDebugService, DebugService>(i => new(enableDebug));
        servicesBuilder.AddSingleton<ITCPConnectService, ConnectService>();
        servicesBuilder.AddSingleton<ICommandService, CommandService>();
        servicesBuilder.AddSingleton<IEventService, EventService>();
        servicesBuilder.AddSingleton<Simulation>();
        servicesBuilder.AddSingleton<Control>();
        servicesBuilder.AddSingleton<InductionLoop>();
        servicesBuilder.AddSingleton<LaneAreaDetector>();
        servicesBuilder.AddSingleton<MultiEntryExitDetector>();
        servicesBuilder.AddSingleton<Lane>();
        servicesBuilder.AddSingleton<TrafficLight>();
        servicesBuilder.AddSingleton<Vehicle>();
        servicesBuilder.AddSingleton<Person>();
        servicesBuilder.AddSingleton<VehicleType>();
        servicesBuilder.AddSingleton<Route>();
        servicesBuilder.AddSingleton<POI>();
        servicesBuilder.AddSingleton<Polygon>();
        servicesBuilder.AddSingleton<Junction>();
        servicesBuilder.AddSingleton<Edge>();
        servicesBuilder.AddSingleton<Gui>();
        servicesBuilder.AddSingleton<BusStop>();
        servicesBuilder.AddSingleton<Calibrator>();
        servicesBuilder.AddSingleton<ChargingStation>();
        servicesBuilder.AddSingleton<ParkingArea>();
        servicesBuilder.AddSingleton<Rerouter>();
        servicesBuilder.AddSingleton<RouteProbe>();
        servicesBuilder.AddSingleton<VariableSpeedSign>();
        services = servicesBuilder.BuildServiceProvider();




        }

    }

