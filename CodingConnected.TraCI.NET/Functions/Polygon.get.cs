using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier.Get;
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return ((TraciStringList)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.ID_COUNT, "ignored");
        return ((TraciInteger)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.VAR_TYPE, polygonId);
        return ((TraciString)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.VAR_COLOR, polygonId);
        var color = (Color)result.Data;
        return new(color.R, color.G, color.B, color.A);
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.VAR_SHAPE, polygonId);
        return (DataTypes.Polygon)result.Data;
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.VAR_FILL, polygonId);
        return ((TraciUnsignedByte)result.Data).Value == 1;
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
        var result = _helper.ExecuteGetCommand(POLYGON_VARIABLE, TraciConstants.VAR_WIDTH, polygonId);
        return ((TraciDouble)result.Data).Value;
        }
    }
