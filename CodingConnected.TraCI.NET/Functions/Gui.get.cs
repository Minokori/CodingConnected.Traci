using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_ZOOM, viewId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// the center of the currently visible part of the net
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <returns>the x and y offset of the center of the current view.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-getOffset">
    /// </remarks>
    public Tuple<double, double> GetOffset(string viewId = "View #0")
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_OFFSET, viewId);
        var p = (Position2D)result.Value;
        return new(p.X.Value, p.Y.Value);
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_SCHEMA, viewId);
        return ((TraCIString)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_BOUNDARY, viewId);
        var polygon = (Polygon)result.Value;
        return new(new(polygon[0].X.Value, polygon[0].Y.Value), new(polygon[1].X.Value, polygon[1].Y.Value));
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_HAS_VIEW, viewId);
        return ((TraCIByte)result.Value).Value == 1;
        }
    }
