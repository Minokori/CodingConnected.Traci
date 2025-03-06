using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier.Get;

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
        var result = _helper.ExecuteGetCommand(ROUTE_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return (TraciStringList)result.Data;
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
        var result = _helper.ExecuteGetCommand(ROUTE_VARIABLE, TraciConstants.ID_COUNT, "ignored");
        return (TraciInteger)result.Data;
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
        var result = _helper.ExecuteGetCommand(ROUTE_VARIABLE, TraciConstants.VAR_EDGES, routeId);
        return (TraciStringList)result.Data;
        }
    }
