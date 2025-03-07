namespace TracCI.NET.UsageExample.Test;
internal partial class ParkingAreaTest
    {
    private static dynamic SetAcceptedBadges
        (TraciClient client) => client.ParkingArea.SetAcceptedBadges("ParkAreaA", [""]);



    }
