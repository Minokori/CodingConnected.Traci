using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Gui
    {
    /// <summary>
    /// 	Sets the current zoom level in %.<para/>
    /// 	The view viewId that must be supplied is usually something like "View #0"
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="zoom">zoom factor to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-setZoom"/>
    /// </remarks>
    public bool SetZoom(string viewId, double zoom)
        {
        var tmp = new TraCIDouble { Value = zoom };
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_ZOOM, tmp);
        }

    /// <summary>
    /// Moves the center of the visible network to the given position
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="position">relative offset anchor to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-setOffset"/>
    /// </remarks>
    public bool SetOffset(string viewId, Position2D position)
        {
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_OFFSET, position);
        }

    /// <summary>
    /// Moves the center of the visible network to the given position
    /// </summary>
    /// <param name="viewId"></param>
    /// <param name="x">relative offset x anchor to set</param>
    /// <param name="y">relative offset y anchor to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-setOffset"/>
    /// </remarks>
    public bool SetOffset(string viewId, double x, double y)
        {
        Position2D position = new()
            {
            X = new() { Value = x },
            Y = new() { Value = y },
            };
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_OFFSET, position);
        }

    /// <summary>
    /// Sets the visualization scheme (e.g. "standard")
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="schemaName">coloring scheme to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-setSchema"/>
    /// </remarks>
    public bool SetSchema(string viewId, string schemaName)
        {
        var tmp = new TraCIString { Value = schemaName };
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_SCHEMA, tmp);
        }

    /// <summary>
    /// Sets the boundary of the visible network. <para/>
    /// If the window has a different aspect ratio than the given boundary,
    /// the view is expanded along one axis to meet the window aspect ratio and contain the given boundary.
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="boundaryBox">the boundary of the visible network to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-setBoundary"/>
    /// </remarks>
    public bool SetBoundary(string viewId, Polygon boundaryBox)
        {
        return boundaryBox.Count != 2
            ? throw new ArgumentException("The boundary box must contain exactly 2 points")
            : _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_BOUNDARY, boundaryBox);
        }

    /// <summary>
    /// Sets the boundary of the visible network. <para/>
    /// If the window has a different aspect ratio than the given boundary,
    /// the view is expanded along one axis to meet the window aspect ratio and contain the given boundary.
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="xMin">the minimum x value of the boundary</param>
    /// <param name="xMax">the maximum x value of the boundary</param>
    /// <param name="yMin">the minimum y value of the boundary</param>
    /// <param name="yMax">the maximum y value of the boundary</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-setBoundary"/>
    /// </remarks>
    public bool SetBoundary(string viewId, double xMin, double yMin, double xMax, double yMax)
        {
        Polygon boundaryBox =
        [
            new()
            {
                X = new() { Value = xMin },
                Y = new() { Value = yMin },
            },
            new()
            {
                X = new() { Value = xMax },
                Y = new() { Value = yMax },
            },
        ];
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_BOUNDARY, boundaryBox);
        }

    /// <summary>
    /// Save a screenshot to the given file.<para/>
    /// Save a screenshot for the given view to the given filename at the next call to simulationStep.<para/>
    /// The fileformat is guessed from the extension,
    /// the available formats differ from platform to platform but should at least
    /// <b><u>ps, svg and pdf</u></b>, on linux probably gif, png and jpg as well.<para/>
    /// Width and height of the image can be given as optional parameters.
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="filename">file to save the screenshot</param>
    /// <param name="width">width of the image</param>
    /// <param name="height">height of the image</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// In python traci module, the method has <paramref name="width"/> and <paramref name="height"/> parameters, which is not discribed in doucument below.
    /// if you meet any error, please make the boolean parameter <paramref name="useWidthHeight"/>  = false. <para/>
    /// Once we check <paramref name="width"/> and <paramref name="height"/> work well, we will remove the <paramref name="useWidthHeight"/> parameter.
    /// <para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-screenshot"/>
    /// </remarks>

    public bool Screenshot(string viewId, string filename, int width = -1, int height = -1, bool useWidthHeight = true)
        {
        // TODO check if width and height works well
        TraCICompoundObject tmp = [new TraCIString { Value = filename }, new TraCIInteger { Value = width }, new TraCIInteger { Value = height }];
        var tmp2 = new TraCIString { Value = filename };
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_SCREENSHOT, useWidthHeight ? tmp : tmp2);
        }

    /// <summary>
    /// tracks the given vehicle in the GUI.<para/>
    /// Start visually tracking the given vehicle on the given view.<para/>
    /// Stop tracking when an empty string is used as <paramref name="vehicleId"/>.
    /// </summary>
    /// <param name="viewId">given view ID</param>
    /// <param name="vehicleId"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._gui.html#GuiDomain-trackVehicle"/>
    /// </remarks>
    public bool TrackVehicle(string viewId, string vehicleId)
        {
        viewId = viewId is null ? "View #0" : viewId;
        var tmp = new TraCIString { Value = vehicleId };
        return _helper.ExecuteSetCommand(viewId, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_TRACK_VEHICLE, tmp);
        }
    }
