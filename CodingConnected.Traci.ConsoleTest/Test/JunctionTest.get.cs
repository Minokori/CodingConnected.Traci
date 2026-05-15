namespace CodingConnected.Traci.ConsoleTest.Test;
public partial class JunctionTest
    {
    private static dynamic GetIdList(this TraciClient client) => client.Junction.GetIdList();


    private static dynamic GetIdCount(this TraciClient client) => client.Junction.GetIdCount();

    private static dynamic GetPosition(this TraciClient client) => client.Junction.GetPosition("B10", true);

    private static dynamic GetShape(this TraciClient client) => client.Junction.GetShape("B10");

    private static dynamic GetIncomingEdges(this TraciClient client) => client.Junction.GetIncomingEdges("B10");

    private static dynamic GetOutgoingEdges(this TraciClient client) => client.Junction.GetOutgoingEdges("B10");
    }
