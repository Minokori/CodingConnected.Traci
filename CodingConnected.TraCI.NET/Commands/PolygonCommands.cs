using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class PolygonCommands(ITcpService tcpService, ICommandHelperService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    #region Protected Override Methods
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_POLYGON_CONTEXT;

    #endregion Protected Override Methods

    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all polygons
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of polygons
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.ID_COUNT);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the (abstract) type of the polygon
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetType(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_TYPE);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the color of this polygon
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Color GetColor(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_COLOR);
        return (Color)result.Value;
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of this polygon
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Polygon GetShape(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_SHAPE);
        return (Polygon)result.Value;
        }

    /// <summary>
    /// Returns whether this polygon is filled (1) or not (0)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool GetFilled(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_FILL);
        return ((TraCIUByte)result.Value).Value == 1;
        }

    /// <summary>
    /// Sets the polygon's type to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="typeId"></param>
    /// <returns></returns>
    public bool SetType(string id, string typeId)
        {
        var tmp = new TraCIString() { Value = typeId };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POLYGON_VARIABLE, TraCIConstants.VAR_TYPE, tmp);
        }

    /// <summary>
    /// Sets the polygon's color to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public bool SetColor(string id, Color color)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POLYGON_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the polygon's shape to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="polygon"></param>
    /// <returns></returns>
    public bool SetShape(string id, Polygon polygon)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POLYGON_VARIABLE, TraCIConstants.VAR_SHAPE, polygon);
        }

    /// <summary>
    /// Marks that the polygon shall be filled if the value is !=0.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filled"></param>
    /// <returns></returns>
    public bool SetFilled(string id, byte filled)
        {
        var tmp = new TraCIByte() { Value = filled };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POLYGON_VARIABLE, TraCIConstants.VAR_FILL, tmp);
        }

    /// <summary>
    /// Adds the defined Polygon
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="color"></param>
    /// <param name="filled"></param>
    /// <param name="layer"></param>
    /// <param name="shape"></param>
    /// <returns></returns>
    public bool Add(string id, string name, Color color, bool filled, int layer, Polygon shape)
        {
        var tmp = new TraCICompoundObject
        {
            new TraCIString() { Value = name },
            color,
            new TraCIUByte() { Value = filled == false ? (byte)0 : (byte)1 },
            new TraCIInteger() { Value = layer },
            shape,
        };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POLYGON_VARIABLE, TraCIConstants.ADD, tmp);
        }

    /// <summary>
    /// Removes the defined Polygon
    /// </summary>
    /// <param name="id"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public bool Remove(string id, int layer)
        {
        var tmp = new TraCIInteger() { Value = layer };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_POLYGON_VARIABLE, TraCIConstants.REMOVE, tmp);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_POLYGON_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }

