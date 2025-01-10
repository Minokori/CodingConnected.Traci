using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
public partial class Route
    {
    /// <summary>
    /// Adds a new route; the route gets the given routeId and follows the given edges.
    /// </summary>
    /// <param name="routeId"></param>
    /// <param name="edges"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._route.html#RouteDomain-add"/>
    /// </remarks>
    public bool Add(string routeId, List<string> edges)
        {
        var tmp = new TraCIStringList { Value = edges };
        return _helper.ExecuteSetCommand(routeId, TraCIConstants.CMD_SET_ROUTE_VARIABLE, TraCIConstants.ADD, tmp);
        }
    }
