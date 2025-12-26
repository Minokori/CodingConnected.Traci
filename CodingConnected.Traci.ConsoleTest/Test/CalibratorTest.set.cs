namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class CalibratorTest
    {
    private static dynamic SetFlow(TraciClient client) => client.Calibrator.SetFlow("ca_0", 0, 5, 10, 20, "SUMO_DEFAULT_TYPE", "always_right");
    }
