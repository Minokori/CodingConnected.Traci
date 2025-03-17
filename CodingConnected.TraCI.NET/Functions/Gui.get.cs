using static CodingConnected.Traci.Constants.CommandIdentifier;
namespace CodingConnected.Traci.Functions;

public partial class Gui
    {
    /// <summary>
    /// the current zoom level (in %)
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <returns>the current zoom factor</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-getZoom/">
    /// </remarks>
    public double GetZoom(string viewId = "View #0")
        {
        var result = _helper.ExecuteGetCommand(Get.GUI_VARIABLE, TraciConstants.VAR_VIEW_ZOOM, viewId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// the center of the currently visible part of the net
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <returns>the x and y offset of the center of the current view.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-getOffset">
    /// </remarks>
    public (double x, double y) GetOffset(string viewId = "View #0")
        {
        var result = _helper.ExecuteGetCommand(Get.GUI_VARIABLE, TraciConstants.VAR_VIEW_OFFSET, viewId);
        var p = (Position2D)result.Data;
        return new(p.X, p.Y);
        }

    /// <summary>
    /// the visualization scheme used (e.g. "standard" or "real world")
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <returns>the name of the current coloring scheme</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-getSchema">
    /// </remarks>

    public string GetSchema(string viewId = "View #0")
        {
        var result = _helper.ExecuteGetCommand(Get.GUI_VARIABLE, TraciConstants.VAR_VIEW_SCHEMA, viewId);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    /// the lower left and the upper right corner of the visible network
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <returns>the coordinates of the lower left and the upper right corner of the currently visible view.the coordinates of the lower left and the upper right corner of the currently visible view.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-getBoundary">
    /// </remarks>

    public Tuple<Tuple<double, double>, Tuple<double, double>> GetBoundary(string viewId = "View #0")
        {
        var result = _helper.ExecuteGetCommand(Get.GUI_VARIABLE, TraciConstants.VAR_VIEW_BOUNDARY, viewId);
        var polygon = (Polygon)result.Data;
        return new(new(polygon[0].X, polygon[0].Y), new(polygon[1].X, polygon[1].Y));
        }

    /// <summary>
    /// Whether a view with the given ID exists
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-hasView">
    /// </remarks>

    public bool HasView(string viewId = "View #0")
        {
        // TODO: Check if this is the correct way to get the value
        var result = _helper.ExecuteGetCommand(Get.GUI_VARIABLE, TraciConstants.VAR_HAS_VIEW, viewId);
        return ((TraciInteger)result.Data) == 1;
        }
    }
