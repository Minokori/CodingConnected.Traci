using CodingConnected.Traci.Functions;
using CodingConnected.Traci.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.Traci;

public partial class TraciClient
    {
    public ITraciEventService EventService => Services.GetRequiredService<ITraciEventService>();
    public Control Control => Services.GetRequiredService<Control>();

    public InductionLoop InductionLoop => Services.GetRequiredService<InductionLoop>();

    public LaneAreaDetector LaneAreaDetector => Services.GetRequiredService<LaneAreaDetector>();

    public MultiEntryExitDetector MultiEntryExitDetector => Services.GetRequiredService<MultiEntryExitDetector>();

    public Lane Lane => Services.GetRequiredService<Lane>();

    public TrafficLight TrafficLight => Services.GetRequiredService<TrafficLight>();

    public Vehicle Vehicle => Services.GetRequiredService<Vehicle>();

    public Person Person => Services.GetRequiredService<Person>();

    public VehicleType VehicleType => Services.GetRequiredService<VehicleType>();

    public Route Route => Services.GetRequiredService<Route>();

    public POI POI => Services.GetRequiredService<POI>();

    public PolygonFunctions Polygon => Services.GetRequiredService<PolygonFunctions>();

    public Junction Junction => Services.GetRequiredService<Junction>();

    public Edge Edge => Services.GetRequiredService<Edge>();

    public Simulation Simulation => Services.GetRequiredService<Simulation>();

    public Gui Gui => Services.GetRequiredService<Gui>();

    public RouteProbe RouteProbe => Services.GetRequiredService<RouteProbe>();

    public VariableSpeedSign VariableSpeedSign => Services.GetRequiredService<VariableSpeedSign>();

    public BusStop BusStop => Services.GetRequiredService<BusStop>();

    public ParkingArea ParkingArea => Services.GetRequiredService<ParkingArea>();

    public Calibrator Calibrator => Services.GetRequiredService<Calibrator>();

    public ChargingStation ChargingStation => Services.GetRequiredService<ChargingStation>();
    }