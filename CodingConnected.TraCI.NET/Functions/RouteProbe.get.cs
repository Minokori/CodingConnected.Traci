using System.Collections.Generic;
using CodingConnected.TraCI.NET.DataTypes;

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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_ROUTEPROBE_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_ROUTEPROBE_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }
    }
