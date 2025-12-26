namespace CodingConnected.Traci.ConsoleTest.Test;
public partial class LaneTest
    {

    private static bool SetAllowed(TraciClient client) => client.Lane.SetAllowed("O1N1_0", ["bus"]);

    private static bool SetDisallowed(TraciClient client) => client.Lane.SetDisallowed("O1N1_0", ["bus"]);

    private static bool SetChangePermission(TraciClient client) => client.Lane.SetChangePermission("O1N1_0", ["bus"], -1);

    private static bool SetLength(TraciClient client) => client.Lane.SetLength("O1N1_0", 100);

    private static bool SetMaxSpeed(TraciClient client) => client.Lane.SetMaxSpeed("O1N1_0", 100);

    }
