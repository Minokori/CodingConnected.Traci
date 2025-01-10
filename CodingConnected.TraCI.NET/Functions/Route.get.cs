using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
public partial class Route
    {
    /// <summary>
    /// Returns a list of ids of all currently loaded routes  (the given route ID is ignored)
    /// </summary>
    /// <returns>a list of all objects in the network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._route.html#RouteDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_ROUTE_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded routes
    /// </summary>
    /// <returns>the number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._route.html#RouteDomain-getIDCount"/>
    /// </remarks>

    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_ROUTE_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of the edges this route covers
    /// </summary>
    /// <param name="routeId"></param>
    /// <returns>a list of all edges in the route.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._route.html#RouteDomain-getEdges"/>
    /// </remarks>
    public List<string> GetEdges(string routeId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_ROUTE_VARIABLE, TraCIConstants.VAR_EDGES, routeId);
        return ((TraCIStringList)result.Value).Value;
        }
    }
