using CodingConnected.TraCI.NET.Functions;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public TraCIClient()
        {
        ServiceCollection servicesbuilder = new();
        servicesbuilder.AddSingleton<ITCPConnectService, ConnectService>();
        servicesbuilder.AddSingleton<ICommandService, CommandService>();
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

