namespace TracCI.NET.UsageExample.Test;
internal partial class PolygonTest
    {

    private static dynamic GetIdList(TraciClient client) => client.Polygon.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.Polygon.GetIdCount();

    private static dynamic GetType(TraciClient client) => client.Polygon.GetType("po_0");

    private static dynamic GetColor(TraciClient client) => client.Polygon.GetColor("po_0");

    private static dynamic GetShape(TraciClient client) => client.Polygon.GetShape("po_0");

    private static dynamic GetFilled(TraciClient client) => client.Polygon.GetFilled("po_0");

    private static dynamic GetLineWidth(TraciClient client) => client.Polygon.GetLineWidth("po_0");
    }
