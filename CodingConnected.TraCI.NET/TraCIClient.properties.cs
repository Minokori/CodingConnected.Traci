using CodingConnected.TraCI.NET.Functions;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public IEventService EventService => services.GetRequiredService<IEventService>();
    public ControlCommands Control => services.GetRequiredService<ControlCommands>();

    public InductionLoopCommands InductionLoop => services.GetRequiredService<InductionLoopCommands>();

    public LaneAreaDetector LaneAreaDetector => services.GetRequiredService<LaneAreaDetector>();

    public MultiEntryExitDetector MultiEntryExitDetector => services.GetRequiredService<MultiEntryExitDetector>();

    public LaneCommands Lane => services.GetRequiredService<LaneCommands>();

    public TrafficLight TrafficLight => services.GetRequiredService<TrafficLight>();

    public VehicleCommands Vehicle => services.GetRequiredService<VehicleCommands>();

    public Person Person => services.GetRequiredService<Person>();

    public VehicleType VehicleType => services.GetRequiredService<VehicleType>();

    public Route Route => services.GetRequiredService<Route>();

    public POICommands POI => services.GetRequiredService<POICommands>();

    public PolygonCommands Polygon => services.GetRequiredService<PolygonCommands>();

    public JunctionCommands Junction => services.GetRequiredService<JunctionCommands>();

    public EdgeCommands Edge => services.GetRequiredService<EdgeCommands>();

    public Simulation Simulation => services.GetRequiredService<Simulation>();

    public Gui Gui => services.GetRequiredService<Gui>();

    }