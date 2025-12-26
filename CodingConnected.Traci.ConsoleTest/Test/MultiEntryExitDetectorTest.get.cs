namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class MultiEntryExitDetectorTest
    {

    private static dynamic GetIdList(TraciClient client) => client.MultiEntryExitDetector.GetIdList();


    private static dynamic GetIdCount(TraciClient client) => client.MultiEntryExitDetector.GetIdCount();

    private static dynamic GetEntryLanes(TraciClient client) => client.MultiEntryExitDetector.GetEntryLanes("e3_0");

    private static dynamic GetExitLanes(TraciClient client) => client.MultiEntryExitDetector.GetExitLanes("e3_0");

    private static dynamic GetEntryPositions(TraciClient client) => client.MultiEntryExitDetector.GetEntryPositions("e3_0");

    private static dynamic GetExitPositions(TraciClient client) => client.MultiEntryExitDetector.GetExitPositions("e3_0");

    private static dynamic GetLastStepVehicleNumber(TraciClient client) => client.MultiEntryExitDetector.GetLastStepVehicleNumber("e3_0");

    private static dynamic GetLastStepMeanSpeed(TraciClient client) => client.MultiEntryExitDetector.GetLastStepMeanSpeed("e3_0");

    private static dynamic GetLastStepVehicleIds(TraciClient client) => client.MultiEntryExitDetector.GetLastStepVehicleIds("e3_0");

    private static dynamic GetLastStepHaltingNumber(TraciClient client) => client.MultiEntryExitDetector.GetLastStepHaltingNumber("e3_0");

    private static dynamic GetLastIntervalMeanTravelTime(TraciClient client) => client.MultiEntryExitDetector.GetLastIntervalMeanTravelTime("e3_0");

    private static dynamic GetLastIntervalMeanHaltsPerVehicle(TraciClient client) => client.MultiEntryExitDetector.GetLastIntervalMeanHaltsPerVehicle("e3_0");

    private static dynamic GetLastIntervalMeanTimeLoss(TraciClient client) => client.MultiEntryExitDetector.GetLastIntervalMeanTimeLoss("e3_0");

    private static dynamic GetLastIntervalVehicleSum(TraciClient client) => client.MultiEntryExitDetector.GetLastIntervalVehicleSum("e3_0");
    }
