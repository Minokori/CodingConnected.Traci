namespace CodingConnected.Traci.ConsoleTest.Test;
public partial class RerouterTest
    {

    private static dynamic GetIdList(TraciClient client) => client.VariableSpeedSign.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.VariableSpeedSign.GetIdCount();
    }
