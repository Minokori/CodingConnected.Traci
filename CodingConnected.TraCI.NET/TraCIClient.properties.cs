using CodingConnected.TraCI.NET.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    #region Properties

    public ControlCommands Control => services.GetRequiredService<ControlCommands>();

    public InductionLoopCommands InductionLoop => services.GetRequiredService<InductionLoopCommands>();

    public LaneAreaDetectorCommands LaneAreaDetector => services.GetRequiredService<LaneAreaDetectorCommands>();

    public MultiEntryExitDetectorCommands MultiEntryExitDetector => services.GetRequiredService<MultiEntryExitDetectorCommands>();

    public LaneCommands Lane => services.GetRequiredService<LaneCommands>();

    public TrafficLightCommands TrafficLight => services.GetRequiredService<TrafficLightCommands>();

    public VehicleCommands Vehicle => services.GetRequiredService<VehicleCommands>();

    public PersonCommands Person => services.GetRequiredService<PersonCommands>();

    public VehicleTypeCommands VehicleType => services.GetRequiredService<VehicleTypeCommands>();

    public RouteCommands Route => services.GetRequiredService<RouteCommands>();

    public POICommands POI => services.GetRequiredService<POICommands>();

    public PolygonCommands Polygon => services.GetRequiredService<PolygonCommands>();

    public JunctionCommands Junction => services.GetRequiredService<JunctionCommands>();

    public EdgeCommands Edge => services.GetRequiredService<EdgeCommands>();

    public SimulationCommands Simulation => services.GetRequiredService<SimulationCommands>();

    public GuiCommands Gui => services.GetRequiredService<GuiCommands>();

    #endregion // Properties
    }

