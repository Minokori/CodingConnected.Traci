using System.Diagnostics.CodeAnalysis;
using CodingConnected.Traci.Functions;
using CodingConnected.Traci.Services;
using Microsoft.Extensions.DependencyInjection;
#pragma warning disable CA1034 // 嵌套类型应不可见

namespace CodingConnected.Traci;

public static class TraciServiceCollectionExtension
    {
    extension(IServiceCollection services)
        {
        private IServiceCollection AddTraciClientFunctions()
            {
            return services
                .AddSingleton<Simulation>()
                .AddSingleton<Control>()
                .AddSingleton<InductionLoop>()
                .AddSingleton<LaneAreaDetector>()
                .AddSingleton<MultiEntryExitDetector>()
                .AddSingleton<Lane>()
                .AddSingleton<TrafficLight>()
                .AddSingleton<Vehicle>()
                .AddSingleton<Person>()
                .AddSingleton<VehicleType>()
                .AddSingleton<Route>()
                .AddSingleton<POI>()
                .AddSingleton<PolygonFunctions>()
                .AddSingleton<Junction>()
                .AddSingleton<Edge>()
                .AddSingleton<Gui>()
                .AddSingleton<BusStop>()
                .AddSingleton<Calibrator>()
                .AddSingleton<ChargingStation>()
                .AddSingleton<ParkingArea>()
                .AddSingleton<Rerouter>()
                .AddSingleton<RouteProbe>()
                .AddSingleton<VariableSpeedSign>();
            }

        public IServiceCollection AddSumoConnectService<
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T
        >()
            where T : class, ISumoConnectService, new() =>
            services.AddSingleton<ISumoConnectService, T>();

        public IServiceCollection AddDefaultSumoConnectService() =>
            services.AddSingleton<ISumoConnectService, ConnectService>();

        public IServiceCollection AddTraciCommandService<
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T
        >()
            where T : class, ITraciCommandService, new() =>
            services.AddSingleton<ITraciCommandService, T>();

        public IServiceCollection AddDefaultTraciCommandService() =>
            services.AddSingleton<ITraciCommandService, CommandService>();

        public IServiceCollection AddEventService<
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T
        >()
            where T : class, ITraciEventService, new() =>
            services.AddSingleton<ITraciEventService, T>();

        public IServiceCollection AddDefaultEventService() =>
            services.AddSingleton<ITraciEventService, EventService>();

        }
    }
