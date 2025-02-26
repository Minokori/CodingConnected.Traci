using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Command.Set;
namespace CodingConnected.TraCI.NET.Functions;

public partial class Polygon
    {
    /// <summary>
    /// Sets the shape's type to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="typeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-setType"/>
    /// </remarks>
    public bool SetType(string id, string typeId)
        {
        TraciString tmp = new(typeId);
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.VAR_TYPE, id, tmp);
        }

    /// <summary>
    /// Sets the shape's color to the given value
    /// </summary>
    /// <param name="polygonId"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-setColor"/>
    /// </remarks>
    public bool SetColor(string polygonId, int r, int g, int b, int a = 255)
        {
        Color color = new(r, g, b, a);
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.VAR_COLOR, polygonId, color);
        }

    /// <summary>
    /// Sets the shape's shape to the given value
    /// </summary>
    /// <param name="polygonId"></param>
    /// <param name="shape"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-setShape"/>
    /// </remarks>
    public bool SetShape(string polygonId, List<(double x, double y)> shape)
        {
        var polygon = (DataTypes.Polygon)shape
            .Select(p => new Position2D(p.x, p.y))
            .ToList();
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.VAR_SHAPE, polygonId, polygon);
        }

    /// <summary>
    /// Marks that the shape shall be filled if the value is !=0.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filled"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-setFilled"/>
    /// </remarks>
    public bool SetFilled(string id, bool filled)
        {
        TraciUnsignedByte tmp = new(filled == true ? (byte)1 : (byte)0);
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.VAR_FILL, id, tmp);
        }

    /// <summary>
    /// Sets drawing width for unfilled shape
    /// </summary>
    /// <param name="polygonId"></param>
    /// <param name="lineWidth"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-setLineWidth"/>
    /// </remarks>
    public bool SetLineWidth(string polygonId, double lineWidth)
        {
        TraciDouble tmp = new(lineWidth);
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.VAR_WIDTH, polygonId, tmp);
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
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-add"/>
    /// </remarks>
    public bool Add(string id, string name, Color color, bool filled, int layer, DataTypes.Polygon shape)
        {
        var tmp = new TraciCompoundObject
        {
            new TraciString(name),
            color,
            new TraciUnsignedByte(filled == false ?(byte) 0 :(byte) 1),
            new TraciInteger(layer) ,
            shape,
        };

        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.ADD, id, tmp);
        }

    /// <summary>
    /// Removes the defined Polygon
    /// </summary>
    /// <param name="id"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-remove"/>
    /// </remarks>
    public bool Remove(string id, int layer)
        {
        TraciInteger tmp = new(layer);
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.REMOVE, id, tmp);
        }

    /// <summary>
    /// Adds the specified dynamics for the Polygon
    /// </summary>
    /// <param name="polygonId">ID of the shape, upon which the specified dynamics shall act</param>
    /// <param name="trackedObjectId">ID of a SUMO traffic object, which shall be tracked by the shape</param>
    /// <param name="timeSpan"> list of time points for timing the animation keyframes (must start with element zero) If it has length zero, no animation is taken into account.</param>
    /// <param name="alphaSpan">list of alpha values to be attained at keyframes intermediate values areobtained by linear interpolation.Must have length equal to timeSpan, or zero if no alpha animation is desired.</param>
    /// <param name="looped">Whether the animation should restart when the last keyframe is reached. In that case the animation jumps to the first keyframe as soon as the last is reached.If looped==false, the controlled shape is removed as soon as the timeSpan elapses.</param>
    /// <param name="rotate">Whether, the shape should be rotated with the tracked object (only applies when such is given) The center of rotation is the object's position.</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._polygon.html#PolygonDomain-addDynamics"/>
    /// </remarks>
    public bool AddDynamics(
        string polygonId,
        string trackedObjectId = "",
        List<double>? timeSpan = null,
        List<double>? alphaSpan = null,
        bool looped = false,
        bool rotate = true
    )
        {
        var tmp = new TraciCompoundObject
        {
            new TraciString(trackedObjectId)  ,
            new TraCIDoubleList(timeSpan),
            new TraCIDoubleList(alphaSpan),
            new TraciUnsignedByte(looped == false ?(byte) 0 :(byte) 1),
            new TraciUnsignedByte(rotate == false ?(byte) 0 :(byte) 1),
        };
        return _helper.ExecuteSetCommand(POLYGON_VARIABLE, TraciConstants.VAR_ADD_DYNAMICS, polygonId, tmp);
        }
    }
