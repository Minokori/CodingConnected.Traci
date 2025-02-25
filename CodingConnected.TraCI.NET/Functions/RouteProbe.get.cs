using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Command.Get;

namespace CodingConnected.TraCI.NET.Functions;

public partial class RouteProbe
    {
    /// <summary>
    /// Returns a list of ids of all current RouteProbes(the given RouteProbe ID is ignored)    /// </summary>
    /// <returns>a list of all objects in the network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._routeprobe.html#RouteProbeDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(ROUTEPROBE_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of current RouteProbes (the given RouteProbe ID is ignored)
    /// </summary>
    /// <returns>the number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._routeprobe.html#RouteProbeDomain-getIDCount"/>
    /// </remarks>

    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(ROUTEPROBE_VARIABLE, TraciConstants.ID_COUNT, "ignored");
        return ((TraciInteger)result.Data).Value;
        }
    }
