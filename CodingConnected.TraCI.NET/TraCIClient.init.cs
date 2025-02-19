﻿using CodingConnected.TraCI.NET.Functions;
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
        servicesbuilder.AddSingleton<Simulation>();
        servicesbuilder.AddSingleton<Control>();
        servicesbuilder.AddSingleton<InductionLoop>();
        servicesbuilder.AddSingleton<LaneAreaDetector>();
        servicesbuilder.AddSingleton<MultiEntryExitDetector>();
        servicesbuilder.AddSingleton<Lane>();
        servicesbuilder.AddSingleton<TrafficLight>();
        servicesbuilder.AddSingleton<Vehicle>();
        servicesbuilder.AddSingleton<Person>();
        servicesbuilder.AddSingleton<VehicleType>();
        servicesbuilder.AddSingleton<Route>();
        servicesbuilder.AddSingleton<POI>();
        servicesbuilder.AddSingleton<Polygon>();
        servicesbuilder.AddSingleton<Junction>();
        servicesbuilder.AddSingleton<Edge>();
        servicesbuilder.AddSingleton<Gui>();
        servicesbuilder.AddSingleton<BusStop>();
        servicesbuilder.AddSingleton<Calibrator>();
        servicesbuilder.AddSingleton<ChargingStation>();
        servicesbuilder.AddSingleton<ParkingArea>();
        servicesbuilder.AddSingleton<Rerouter>();
        servicesbuilder.AddSingleton<RouteProbe>();
        servicesbuilder.AddSingleton<VariableSpeedSign>();
        services = servicesbuilder.BuildServiceProvider();
        }

    }

