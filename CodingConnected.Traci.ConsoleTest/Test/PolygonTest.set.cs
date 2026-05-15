namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class PolygonTest
    {
    private static bool SetType(TraciClient client) => client.Polygon.SetType("po_0", "DEFAULT");

    private static bool SetColor(TraciClient client) => client.Polygon.SetColor("po_0", 255, 0, 0, 255);

    private static bool SetShape(TraciClient client) => client.Polygon.SetShape("po_0", [(0, 0), (0, 5), (5, 5), (5, 0)]);

    private static bool SetFilled(TraciClient client) => client.Polygon.SetFilled("po_0", true);

    private static bool SetLineWidth(TraciClient client) => client.Polygon.SetLineWidth("po_0", 1);

    private static bool Add(TraciClient client) => client.Polygon.Add("po_1", "new", 255, 0, 0, 255, true, 1, [(0, 0), (0, 5), (5, 5), (5, 0)]);

    private static bool Remove(TraciClient client) => client.Polygon.Remove("po_0", 1);

    private static bool AddDynamics(TraciClient client) => client.Polygon.AddDynamics("po_1", timeSpan: [0, 255]);

    }
