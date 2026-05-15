namespace CodingConnected.Traci.Functions;

public partial class Rerouter
    {
    /// <summary>
    ///Returns a list of ids of all current RouteProbes (the given Rerouter ID is ignored)
    /// </summary>
    /// <returns>a list of all objects in the network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._routeprobe.html#RouteProbeDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = Helper.ExecuteGetCommand(GetVariable.Rerouter, TraciConstants.IdList, "ignored");
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// 	Returns the number of current RouteProbes (the given Rerouter ID is ignored)
    /// </summary>
    /// <returns>the number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._routeprobe.html#RouteProbeDomain-getIDCount"/>
    /// </remarks>

    public int GetIdCount()
        {
        var result = Helper.ExecuteGetCommand(GetVariable.Rerouter, TraciConstants.IdCount, "ignored");
        return (TraciInteger)result.Data;
        }
    }
