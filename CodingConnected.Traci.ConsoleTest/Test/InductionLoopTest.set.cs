namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class InductionLoopTest
    {
    private static dynamic OverrideTimeSinceDetection(TraciClient client) => client.InductionLoop.OverrideTimeSinceDetection("e1_0", 100);
    }
