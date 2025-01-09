﻿using CodingConnected.TraCI.NET.Functions;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public IEventService EventService => services.GetRequiredService<IEventService>();
    public ControlCommands Control => services.GetRequiredService<ControlCommands>();

    public InductionLoopCommands InductionLoop => services.GetRequiredService<InductionLoopCommands>();

    public LaneAreaDetector LaneAreaDetector => services.GetRequiredService<LaneAreaDetector>();

    public MultiEntryExitDetectorCommands MultiEntryExitDetector => services.GetRequiredService<MultiEntryExitDetectorCommands>();

    public LaneCommands Lane => services.GetRequiredService<LaneCommands>();

    public TrafficLightCommands TrafficLight => services.GetRequiredService<TrafficLightCommands>();

    public VehicleCommands Vehicle => services.GetRequiredService<VehicleCommands>();

    public PersonCommands Person => services.GetRequiredService<PersonCommands>();

    public VehicleType VehicleType => services.GetRequiredService<VehicleType>();

    public RouteCommands Route => services.GetRequiredService<RouteCommands>();

    public POICommands POI => services.GetRequiredService<POICommands>();

    public PolygonCommands Polygon => services.GetRequiredService<PolygonCommands>();

    public JunctionCommands Junction => services.GetRequiredService<JunctionCommands>();

    public EdgeCommands Edge => services.GetRequiredService<EdgeCommands>();

    public SimulationCommands Simulation => services.GetRequiredService<SimulationCommands>();

    public Gui Gui => services.GetRequiredService<Gui>();

    }