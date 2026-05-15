namespace CodingConnected.Traci.ConsoleTest.Test;

public partial class GuiTest
    {
    private static dynamic SetZoom(TraciClient client) => client.Gui.SetZoom("View #0", 0.5);

    private static dynamic SetOffset(TraciClient client) =>
        client.Gui.SetOffset("View #0", 0.5, 0.5);

    private static dynamic SetSchema(TraciClient client) => client.Gui.SetSchema("View #0", "standard");

    private static dynamic SetBoundary(TraciClient client) => client.Gui.SetBoundary("View #0", 0, 0, 1, 1);

    private static dynamic Screenshot(TraciClient client) => client.Gui.Screenshot("View #0", "screenshot.png");

    private static dynamic TrackVehicle(TraciClient client) => client.Gui.TrackVehicle("View #0", "v0");
    }
