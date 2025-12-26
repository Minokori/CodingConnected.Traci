namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class LaneAreaDetectorTest
    {
    private static dynamic GetIdList(TraciClient client) => client.LaneAreaDetector.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.LaneAreaDetector.GetIdCount();

    private static dynamic GetPosition(TraciClient client) => client.LaneAreaDetector.GetPosition("e2_0");

    private static dynamic GetLength(TraciClient client) => client.LaneAreaDetector.GetLength("e2_0");

    private static dynamic GetLaneId(TraciClient client) => client.LaneAreaDetector.GetLaneId("e2_0");

    private static dynamic GetLastStepVehicleNumber(TraciClient client) => client.LaneAreaDetector.GetLastStepVehicleNumber("e2_0");

    private static dynamic GetLastStepMeanSpeed(TraciClient client) => client.LaneAreaDetector.GetLastStepMeanSpeed("e2_0");

    private static dynamic GetLastStepVehicleIds(TraciClient client) => client.LaneAreaDetector.GetLastStepVehicleIds("e2_0");
    private static dynamic GetLastStepOccupancy(TraciClient client) => client.LaneAreaDetector.GetLastStepOccupancy("e2_0");

    private static dynamic GetLastStepHaltingNumber(TraciClient client) => client.LaneAreaDetector.GetLastStepHaltingNumber("e2_0");

    private static dynamic GetJamLengthVehicle(TraciClient client) => client.LaneAreaDetector.GetJamLengthVehicle("e2_0");

    private static dynamic GetJamLengthMeters(TraciClient client) => client.LaneAreaDetector.GetJamLengthMeters("e2_0");

    private static dynamic GetIntervalOccupancy(TraciClient client) => client.LaneAreaDetector.GetIntervalOccupancy("e2_0");

    private static dynamic GetIntervalMeanSpeed(TraciClient client) => client.LaneAreaDetector.GetIntervalMeanSpeed("e2_0");

    private static dynamic GetIntervalVehicleNumber(TraciClient client) => client.LaneAreaDetector.GetIntervalVehicleNumber("e2_0");

    private static dynamic GetIntervalMaxJamLengthInMeters(TraciClient client) => client.LaneAreaDetector.GetIntervalMaxJamLengthInMeters("e2_0");

    private static dynamic GetLastIntervalOccupancy(TraciClient client) => client.LaneAreaDetector.GetLastIntervalOccupancy("e2_0");

    private static dynamic GetLastIntervalMeanSpeed(TraciClient client) => client.LaneAreaDetector.GetLastIntervalMeanSpeed("e2_0");

    private static dynamic GetLastIntervalVehicleNumber(TraciClient client) => client.LaneAreaDetector.GetLastIntervalVehicleNumber("e2_0");

    private static dynamic GetLastIntervalMaxJamLengthInMeters(TraciClient client) => client.LaneAreaDetector.GetLastIntervalMaxJamLengthInMeters("e2_0");
    }
