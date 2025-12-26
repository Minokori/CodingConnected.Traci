namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class InductionLoopTest
    {
    private static dynamic GetIdList(TraciClient client) => client.InductionLoop.GetIdList();

    private static dynamic GetPosition(TraciClient client) => client.InductionLoop.GetPosition("e1_0");

    private static dynamic GetLaneId(TraciClient client) => client.InductionLoop.GetLaneId("e1_0");

    private static dynamic GetIdCount(TraciClient client) => client.InductionLoop.GetIdCount();

    private static dynamic GetLastStepVehicleNumber(TraciClient client) => client.InductionLoop.GetLastStepVehicleNumber("e1_0");

    private static dynamic GetLastStepMeanSpeed(TraciClient client) => client.InductionLoop.GetLastStepMeanSpeed("e1_0");

    private static dynamic GetLastStepVehicleIds(TraciClient client) => client.InductionLoop.GetLastStepVehicleIds("e1_0");


    private static dynamic GetLastStepOccupancy(TraciClient client) => client.InductionLoop.GetLastStepOccupancy("e1_0");

    private static dynamic GetLastStepMeanLength(TraciClient client) => client.InductionLoop.GetLastStepMeanLength("e1_0");

    private static dynamic GetTimeSinceDetection(TraciClient client) => client.InductionLoop.GetTimeSinceDetection("e1_0");

    private static dynamic GetVehicleData(TraciClient client) => client.InductionLoop.GetVehicleData("e1_0");

    private static dynamic GetIntervalOccupancy(TraciClient client) => client.InductionLoop.GetIntervalOccupancy("e1_0");

    private static dynamic GetIntervalMeanSpeed(TraciClient client) => client.InductionLoop.GetIntervalMeanSpeed("e1_0");

    private static dynamic GetIntervalVehicleNumber(TraciClient client) => client.InductionLoop.GetIntervalVehicleNumber("e1_0");

    private static dynamic GetIntervalVehicleIds(TraciClient client) => client.InductionLoop.GetIntervalVehicleIds("e1_0");

    private static dynamic GetLastIntervalOccupancy(TraciClient client) => client.InductionLoop.GetLastIntervalOccupancy("e1_0");

    private static dynamic GetLastIntervalMeanSpeed(TraciClient client) => client.InductionLoop.GetLastIntervalMeanSpeed("e1_0");

    private static dynamic GetLastIntervalVehicleNumber(TraciClient client) => client.InductionLoop.GetLastIntervalVehicleNumber("e1_0");

    private static dynamic GetLastIntervalVehicleIds(TraciClient client) => client.InductionLoop.GetLastIntervalVehicleIds("e1_0");
    }
