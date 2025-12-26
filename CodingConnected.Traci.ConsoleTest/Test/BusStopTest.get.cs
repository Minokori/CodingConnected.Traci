namespace CodingConnected.Traci.ConsoleTest.Test;

internal partial class BusStopTest
    {
    private static dynamic GetEndPosition(this TraciClient client) => client.BusStop.GetEndPosition("busstop1");

    private static dynamic GetLaneId(this TraciClient client) => client.BusStop.GetLaneId("busstop1");

    private static dynamic GetName(this TraciClient client) => client.BusStop.GetName("busstop1");
    private static dynamic GetPersonCount(this TraciClient client) => client.BusStop.GetPersonCount("busstop1");


    private static dynamic GetPersonIds(this TraciClient client) => client.BusStop.GetPersonIds("busstop1");

    private static dynamic GetStartPosition(this TraciClient client) => client.BusStop.GetStartPosition("busstop1");
    private static dynamic GetVehicleCount(this TraciClient client) => client.BusStop.GetVehicleCount("busstop1");

    private static dynamic GetVehicleIds(this TraciClient client) => client.BusStop.GetVehicleIds("busstop1");


    }
