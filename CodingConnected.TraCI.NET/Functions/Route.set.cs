using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Command.Set;
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
        TraciStringList tmp = new(edges);
        return _helper.ExecuteSetCommand(routeId, ROUTE_VARIABLE, TraciConstants.ADD, tmp);
        }
    }
