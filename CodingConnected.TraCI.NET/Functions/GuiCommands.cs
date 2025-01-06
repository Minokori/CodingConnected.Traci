using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public class GuiCommands(ITCPConnectService tcpService, ICommandService helper) : TraCICommandsBase(tcpService, helper)
    {
    /// <summary>
    /// determines whether graphical capabilities exist
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool HasView(string id)
        {
        // TODO: Check if this is the correct way to get the value
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_HAS_VIEW, id);
        return ((TraCIByte)result.Value).Value == 1;
        }

    /// <summary>
    /// the current zoom level (in %)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetZoom(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_ZOOM, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// the center of the currently visible part of the net
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Tuple<double, double> GetOffset(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_OFFSET, id);
        var p = (Position2D)result.Value;
        return new(p.X.Value, p.Y.Value);
        }

    /// <summary>
    /// the visualization scheme used (e.g. "standard" or "real world")
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetSchema(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_SCHEMA, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// the lower left and the upper right corner of the visible network
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Polygon GetBoundary(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_BOUNDARY, id);
        return (Polygon)result.Value;
        }

    /// <summary>
    /// 	Sets the current zoom level in %
    /// </summary>
    /// <param name="id"></param>
    /// <param name="zoom"></param>
    /// <returns></returns>
    public bool SetZoom(string id, double zoom)
        {
        var tmp = new TraCIDouble { Value = zoom };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_ZOOM, tmp);
        }

    /// <summary>
    /// Moves the center of the visible network to the given position
    /// </summary>
    /// <param name="id"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool SetOffset(string id, Position2D position)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_OFFSET, position);
        }

    /// <summary>
    /// Sets the visualization scheme (e.g. "standard")
    /// </summary>
    /// <param name="id"></param>
    /// <param name="schema"></param>
    /// <returns></returns>
    public bool SetSchema(string id, string schema)
        {
        var tmp = new TraCIString { Value = schema };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_SCHEMA, tmp);
        }

    /// <summary>
    /// Moves the center of the visible network to the given position
    /// </summary>
    /// <param name="id"></param>
    /// <param name="boundaryBox"></param>
    /// <returns></returns>
    public bool SetBoundary(string id, Polygon boundaryBox)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_VIEW_BOUNDARY, boundaryBox);
        }

    /// <summary>
    /// Save a screenshot to the given file
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    public bool Screenshot(string id, string filename)
        {
        var tmp = new TraCIString { Value = filename };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_SCREENSHOT, tmp);
        }

    /// <summary>
    /// tracks the given vehicle in the GUI
    /// </summary>
    /// <param name="id"></param>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    public bool TrackVehicle(string id, string vehicleId)
        {
        var tmp = new TraCIString { Value = vehicleId };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_GUI_VARIABLE, TraCIConstants.VAR_TRACK_VEHICLE, tmp);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_GUI_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    }
