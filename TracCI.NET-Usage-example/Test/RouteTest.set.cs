namespace TracCI.NET.UsageExample.Test;
public partial class RouteTest
    {

    private static bool Add(TraciClient client) => client.Route.Add("t", ["D12D13"]);
    }
