namespace CodingConnected.Traci.ConsoleTest.Test;

public partial class SimulationTest
    {
    private static dynamic GetTime(TraciClient client) => client.Simulation.GetTime();

    private static dynamic GetLoadedNumber(TraciClient client) =>
        client.Simulation.GetLoadedNumber();

    private static dynamic GetLoadedIdList(TraciClient client) =>
        client.Simulation.GetLoadedIdList();

    private static dynamic GetDepartedNumber(TraciClient client) =>
        client.Simulation.GetDepartedNumber();

    private static dynamic GetDepartedIdList(TraciClient client) =>
        client.Simulation.GetDepartedIdList();

    private static dynamic GetStartingTeleportNumber(TraciClient client) =>
        client.Simulation.GetStartingTeleportNumber();

    private static dynamic GetStartingTeleportIdList(TraciClient client) =>
        client.Simulation.GetStartingTeleportIdList();

    private static dynamic GetEndingTeleportNumber(TraciClient client) =>
        client.Simulation.GetEndingTeleportNumber();

    private static dynamic GetEndingTeleportIdList(TraciClient client) =>
        client.Simulation.GetEndingTeleportIdList();

    private static dynamic GetArrivedNumber(TraciClient client) =>
        client.Simulation.GetArrivedNumber();

    private static dynamic GetArrivedIdList(TraciClient client) =>
        client.Simulation.GetArrivedIdList();

    private static dynamic GetNetBoundary(TraciClient client) => client.Simulation.GetNetBoundary();

    private static dynamic GetMinExpectedNumber(TraciClient client) =>
        client.Simulation.GetMinExpectedNumber();

    private static dynamic GetStopStartingVehiclesNumber(TraciClient client) =>
        client.Simulation.GetStopStartingVehiclesNumber();

    private static dynamic GetStopStartingVehiclesIdList(TraciClient client) =>
        client.Simulation.GetStopStartingVehiclesIdList();

    private static dynamic GetStopEndingVehicleNumber(TraciClient client) =>
        client.Simulation.GetStopEndingVehiclesNumber();

    private static dynamic GetStopEndingVehicleIdList(TraciClient client) =>
        client.Simulation.GetStopEndingVehiclesIdList();

    private static dynamic GetCollidingVehicleNumber(TraciClient client) =>
        client.Simulation.GetCollidingVehiclesNumber();

    private static dynamic GetCollidingVehicleIdList(TraciClient client) =>
        client.Simulation.GetCollidingVehiclesIdList();

    private static dynamic GetParkingStartingVehicleNumber(TraciClient client) =>
        client.Simulation.GetParkingStartingVehiclesNumber();

    private static dynamic GetParkingStartingVehicleIdList(TraciClient client) =>
        client.Simulation.GetParkingStartingVehiclesIdList();

    private static dynamic GetParkingEndingVehicleNumber(TraciClient client) =>
        client.Simulation.GetParkingEndingVehiclesNumber();

    private static dynamic GetParkingEndingVehicleIdList(TraciClient client) =>
        client.Simulation.GetParkingEndingVehiclesIdList();

    private static dynamic GetBusStopWaiting(TraciClient client) =>
        $"{nameof(client.Simulation.GetBusStopWaiting)} not tested yet.";

    private static dynamic GetBusStopWaitingCount(TraciClient client) =>
        $"{nameof(client.Simulation.GetBusStopWaitingIdList)} not tested yet.";

    private static dynamic GetDeltaT(TraciClient client) => client.Simulation.GetDeltaT();

    private static dynamic GetParameter(TraciClient client) =>
        client.Simulation.GetParameter("", "stats.vehicles.loaded");

    private static dynamic GetScale(TraciClient client) => client.Simulation.GetScale();

    private static dynamic GetOption(TraciClient client) => client.Simulation.GetOption("scale");

    private static dynamic Convert2D(TraciClient client) =>
        client.Simulation.Convert2D("D12D13", 0);

    private static dynamic Convert3D(TraciClient client) =>
        client.Simulation.Convert3D("D12D13", 0);

    private static dynamic ConvertGeo(TraciClient client) => client.Simulation.ConvertGeo(0, 0);

    private static dynamic GetDistanceRoad(TraciClient client) =>
        client.Simulation.GetDistanceRoad("D12D13", 0, "D12D13", 0);

    private static dynamic GetDistance2D(TraciClient client) =>
        client.Simulation.GetDistance2D(0, 1, 1, 0);

    private static dynamic FindRoute(TraciClient client) =>
        client.Simulation.FindRoute("D12D13", "D12D13");

    private static dynamic FindIntermodalRoute(TraciClient client) =>
        client.Simulation.FindIntermodalRoute("D12D13", "D12D13");

    private static dynamic GetCollisions(TraciClient client) => client.Simulation.GetCollisions();
    }
