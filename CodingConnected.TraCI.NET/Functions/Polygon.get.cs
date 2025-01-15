using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Polygon
    {
    /// <summary>
    /// Returns a list of ids of all polygons
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of polygons
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the (abstract) type of the polygon
    /// </summary>
    /// <param name="polygonId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getType"/>
    /// </remarks>
    public string GetType(string polygonId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_TYPE, polygonId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the color of this polygon (rgba)
    /// </summary>
    /// <param name="polygonId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getColor"/>
    /// </remarks>
    public Tuple<int, int, int, int> GetColor(string polygonId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_COLOR, polygonId);
        var color = (Color)result.Value;
        return new(color.R.Value, color.G.Value, color.B.Value, color.A.Value);
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of this polygon
    /// </summary>
    /// <param name="polygonId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getShape"/>
    /// </remarks>
    public DataTypes.Polygon GetShape(string polygonId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_SHAPE, polygonId);
        return (DataTypes.Polygon)result.Value;
        }

    /// <summary>
    /// Returns whether this polygon is filled (1) or not (0)
    /// </summary>
    /// <param name="polygonId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getFilled"/>
    /// </remarks>
    public bool GetFilled(string polygonId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_FILL, polygonId);
        return ((TraCIUByte)result.Value).Value == 1;
        }

    /// <summary>
    /// Returns the line width for drawing unfilled polygon
    /// </summary>
    /// <param name="polygonId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-getLineWidth"/>
    /// </remarks>
    public double GetLineWidth(string polygonId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POLYGON_VARIABLE, TraCIConstants.VAR_WIDTH, polygonId);
        return ((TraCIDouble)result.Value).Value;
        }
    }
