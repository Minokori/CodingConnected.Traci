namespace TracCI.NET.UsageExample.Test;
internal partial class LaneAreaDetectorTest
    {
    private static dynamic OverrideVehicleNumber(TraciClient client) => client.LaneAreaDetector.OverrideVehicleNumber("e2_0", 100);
    }
