namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class POITest
    {
    private static bool SetType(TraciClient client) => client.POI.SetType("poi_0", "DEFAULT");
    private static bool SetColor(TraciClient client) => client.POI.SetColor("poi_0", 255, 0, 0);

    private static bool SetPosition(TraciClient client) => client.POI.SetPosition("poi_0", 0, 0);

    private static bool SetImageFile(TraciClient client) => client.POI.SetImageFile("poi_0", "D:/Lenovo/Pictures/topBG.jpg");

    private static bool SetWidth(TraciClient client) => client.POI.SetWidth("poi_0", 10);

    private static bool SetHeight(TraciClient client) => client.POI.SetHeight("poi_0", 10);

    private static bool SetAngle(TraciClient client) => client.POI.SetAngle("poi_0", 90);

    private static bool Add(TraciClient client) => client.POI.Add("poi_1", 0, 0, 255, 0, 0, 255, "DEFAULT", 0);
    }

