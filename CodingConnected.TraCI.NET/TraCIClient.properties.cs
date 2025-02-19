﻿using CodingConnected.TraCI.NET.Functions;
using CodingConnected.TraCI.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public IEventService EventService => services.GetRequiredService<IEventService>();
    public Control Control => services.GetRequiredService<Control>();

    public InductionLoop InductionLoop => services.GetRequiredService<InductionLoop>();

    public LaneAreaDetector LaneAreaDetector => services.GetRequiredService<LaneAreaDetector>();

    public MultiEntryExitDetector MultiEntryExitDetector => services.GetRequiredService<MultiEntryExitDetector>();

    public Lane Lane => services.GetRequiredService<Lane>();

    public TrafficLight TrafficLight => services.GetRequiredService<TrafficLight>();

    public Vehicle Vehicle => services.GetRequiredService<Vehicle>();

    public Person Person => services.GetRequiredService<Person>();

    public VehicleType VehicleType => services.GetRequiredService<VehicleType>();

    public Route Route => services.GetRequiredService<Route>();

    public POI POI => services.GetRequiredService<POI>();

    public Polygon Polygon => services.GetRequiredService<Polygon>();

    public Junction Junction => services.GetRequiredService<Junction>();

    public Edge Edge => services.GetRequiredService<Edge>();

    public Simulation Simulation => services.GetRequiredService<Simulation>();

    public Gui Gui => services.GetRequiredService<Gui>();

    }