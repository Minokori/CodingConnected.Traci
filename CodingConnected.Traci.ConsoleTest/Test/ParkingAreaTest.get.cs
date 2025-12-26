namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class ParkingAreaTest
    {

    private static dynamic GetEndPosition(TraciClient client) => client.ParkingArea.GetEndPosition("ParkAreaA");

    private static dynamic GetLaneId(TraciClient client) => client.ParkingArea.GetLaneId("ParkAreaA");

    private static dynamic GetName(TraciClient client) => client.ParkingArea.GetName("ParkAreaA");

    private static dynamic GetStartPosition(TraciClient client) => client.ParkingArea.GetStartPosition("ParkAreaA");

    private static dynamic GetVehicleCount(TraciClient client) => client.ParkingArea.GetVehicleCount("ParkAreaA");

    private static dynamic GetVehicleIds(TraciClient client) => client.ParkingArea.GetVehicleIds("ParkAreaA");

    private static dynamic GetAcceptedBadges(TraciClient client) => client.ParkingArea.GetAcceptedBadges("ParkAreaA");
    }
