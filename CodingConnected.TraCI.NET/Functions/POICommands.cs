using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public class POICommands(ITCPConnectService tcpService, ICommandService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    #region Protected Override Methods
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_POI_CONTEXT;

    #endregion Protected Override Methods

    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all poi
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of pois
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the (abstract) type of the poi
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetType(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_TYPE, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the color of this poi
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Color GetColor(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_COLOR, id);
        return (Color)result.Value;
        }

    /// <summary>
    /// Returns the position of this poi
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position2D GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_POSITION, id);
        return (Position2D)result.Value;
        }

    /// <summary>
    /// Sets the PoI's type to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool SetType(string id, string type)
        {
        var tmp = new TraCIString() { Value = type };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_TYPE, tmp);
        }

    /// <summary>
    /// Sets the PoI's color to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public bool SetColor(string id, Color color)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the PoI's position to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="position2D"></param>
    /// <returns></returns>
    public bool SetPosition(string id, Position2D position2D)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_POSITION, position2D);
        }

    /// <summary>
    /// Adds the defined PoI
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="color"></param>
    /// <param name="layer"></param>
    /// <param name="position2D"></param>
    /// <returns></returns>
    public bool Add(string id, string name, Color color, int layer, Position2D position2D)
        {
        TraCICompoundObject tmp = [new TraCIString() { Value = name }, color, new TraCIInteger() { Value = layer }, position2D];
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.ADD, tmp);
        }

    /// <summary>
    /// Removes the defined PoI
    /// </summary>
    /// <param name="id"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public bool Remove(string id, int layer)
        {
        var tmp = new TraCIInteger() { Value = layer };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.REMOVE, tmp);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_POI_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }

