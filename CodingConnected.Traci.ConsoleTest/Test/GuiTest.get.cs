namespace CodingConnected.Traci.ConsoleTest.Test;

public static partial class GuiTest
    {

    private static dynamic Zoom(TraciClient client) => client.Gui.GetZoom();

    private static dynamic GetOffset(TraciClient client) => client.Gui.GetOffset();

    private static dynamic GetSchema(TraciClient client) => client.Gui.GetSchema();

    private static dynamic GetBoundary(TraciClient client) => client.Gui.GetBoundary();

    private static dynamic HasView(TraciClient client) => client.Gui.HasView();
    }
