using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier.Get;
namespace CodingConnected.TraCI.NET.Functions;
public partial class Junction
    {
    /// <summary>
    /// Returns a list of ids of all junctions within the scenario
    /// (the given Junction ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of junctions within the scenario
    /// (the given Junction ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.ID_COUNT, "ignored");
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns the position of the named junction [m,m] or[m,m,m]
    /// </summary>
    /// <param name="junctionId"></param>
    /// <param name="includeZ"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getPosition"/>
    /// </remarks>
    public Tuple<double, double, double> GetPosition(string junctionId, bool includeZ = false)
        {
        var result = _helper.ExecuteGetCommand(
            JUNCTION_VARIABLE,
            includeZ ? TraciConstants.VAR_POSITION3D : TraciConstants.VAR_POSITION,
            junctionId
        );

        switch (includeZ)
            {
            case true:
                {
                var position3D = (Position3D)result.Data;
                return new(position3D.X, position3D.Y, position3D.Z);
                }
            case false:
                {
                var position2D = (Position2D)result.Data;
                return new(position2D.X, position2D.Y, TraciConstants.INVALID_DOUBLE_VALUE);
                }
            }
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of the named junction
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getShape"/>
    /// </remarks>
    public List<Tuple<double, double>> GetShape(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.VAR_SHAPE, junctionId);
        var polygon = (DataTypes.Polygon)result.Data;

        return [.. polygon.Select(i => new Tuple<double, double>(i.X, i.Y))];
        }

    /// <summary>
    /// Returns the ids of all incoming edges
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getIncomingEdges"/>
    /// </remarks>
    public List<string> GetIncomingEdges(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.INCOMING_EDGES, junctionId);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the ids of all outgoing edges
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getOutgoinggEdges"/>
    /// </remarks>
    public List<string> GetOutgoingEdges(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.OUTGOING_EDGES, junctionId);
        return ((TraciStringList)result.Data).Value;
        }
    }
