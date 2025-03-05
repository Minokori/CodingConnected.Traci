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
    /// This method will return junctions ids and inner sumo object ids, which begin with ":".<para/>
    /// if you want to get only junction ids, remember to filter the result.<para/>
    /// see <see href=""/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.ID_LIST, "");
        return (TraciStringList)result.Data;
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
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.ID_COUNT, "");
        return (TraciInteger)result.Data;
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
    public (double x, double y, double z) GetPosition(string junctionId, bool includeZ = false)
        {
        var result = _helper.ExecuteGetCommand(
            JUNCTION_VARIABLE,
            includeZ ? TraciConstants.VAR_POSITION3D : TraciConstants.VAR_POSITION,
            junctionId
        );
        return includeZ ? (Position3D)result.Data : (Position2D)result.Data;
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of the named junction
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getShape"/>
    /// </remarks>
    public List<(double x, double y)> GetShape(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(JUNCTION_VARIABLE, TraciConstants.VAR_SHAPE, junctionId);
        var polygon = (DataTypes.Polygon)result.Data;
        return [.. polygon];
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
        return (TraciStringList)result.Data;
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
        return (TraciStringList)result.Data;
        }
    }
