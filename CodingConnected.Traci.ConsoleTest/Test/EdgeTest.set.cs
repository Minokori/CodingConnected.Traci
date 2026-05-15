namespace CodingConnected.Traci.ConsoleTest.Test;
public partial class EdgeTest
    {

    private static dynamic AdaptTravelTime(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.AdaptTravelTime(edge, 0.0, 0.0, 1.0);
        }

    private static dynamic SetEffort(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.SetEffort(edge, 0.0, 0.0, 1.0);
        }

    private static dynamic SetMaxSpeed(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.SetMaxSpeed(edge, 0.0);
        }

    }
