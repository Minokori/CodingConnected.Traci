namespace TracCI.NET.UsageExample.Test;
public partial class RouteTest
    {

    private static dynamic GetIdList(TraciClient client) => client.Route.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.Route.GetIdCount();

    private static dynamic GetEdges(TraciClient client)
        {
        var routeId = client.Route.GetIdList().FirstOrDefault();
        return client.Route.GetEdges(routeId);
        }

    }
