namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class POITest
    {

    private static dynamic GetIdList(TraciClient client) => client.POI.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.POI.GetIdCount();

    private static dynamic GetType(TraciClient client) => client.POI.GetType("poi_0");

    private static dynamic GetColor(TraciClient client) => client.POI.GetColor("poi_0");

    private static dynamic GetPosition(TraciClient client) => client.POI.GetPosition("poi_0");

    private static dynamic GetImageFile(TraciClient client) => client.POI.GetImageFile("poi_0");

    private static dynamic GetWidth(TraciClient client) => client.POI.GetWidth("poi_0");

    private static dynamic GetHeight(TraciClient client) => client.POI.GetHeight("poi_0");

    private static dynamic GetAngle(TraciClient client) => client.POI.GetAngle("poi_0");
    }
