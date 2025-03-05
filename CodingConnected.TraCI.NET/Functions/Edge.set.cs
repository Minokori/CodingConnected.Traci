using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier;
namespace CodingConnected.TraCI.NET.Functions;

public partial class Edge
// https://sumo.dlr.de/docs/TraCI/Change_Edge_State.html
    {
    /// <summary>
    /// Inserts the information about the travel time of the named edge valid
    /// from begin time to end time into the global edge weights times container.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="travelTime"></param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-adaptTraveltime"/>
    /// </remarks>
    public bool AdaptTravelTime(string edgeId, double travelTime, double? beginTime = null, double? endTime = null)
        {
        TraciCompoundObject tmp = (beginTime, endTime) switch
            {
                (null, null) => [new TraciDouble(travelTime)],
                (null, _) or (_, null) => throw new ArgumentException($"Both {nameof(beginTime)} and {nameof(endTime)} must be specified"),
                _ => [new TraciDouble(beginTime.Value), new TraciDouble(endTime.Value), new TraciDouble(travelTime)],
                };
        return _helper.ExecuteSetCommand(Set.EDGE_VARIABLE, TraciConstants.VAR_EDGE_TRAVELTIME, edgeId, tmp);
        }

    /// <summary>
    /// Inserts the information about the effort of the named edge valid
    /// from begin travelTime to end travelTime into the global edge weights container.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <param name="effort"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-setEffort"/>
    /// </remarks>
    public bool SetEffort(string edgeId, double effort, double? beginTime = null, double? endTime = null)
        {
        TraciCompoundObject tmp = (beginTime, endTime) switch
            {
                (null, null) => [new TraciDouble(effort)],
                (null, _) or (_, null) => throw new ArgumentException($"Both {nameof(beginTime)} and {nameof(endTime)} must be specified"),
                _ => [new TraciDouble(beginTime.Value), new TraciDouble(endTime.Value), new TraciDouble(effort)],
                };

        return _helper.ExecuteSetCommand(Set.EDGE_VARIABLE, TraciConstants.VAR_EDGE_EFFORT, edgeId, tmp);
        }

    /// <summary>
    /// Set a new maximum speed (in m/s) for all lanes of the edge.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="speed"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-setMaxSpeed"/>
    /// </remarks>
    public bool SetMaxSpeed(string edgeId, double speed)
        {
        TraciDouble tmp = new(speed);
        return _helper.ExecuteSetCommand(Set.EDGE_VARIABLE, TraciConstants.VAR_MAXSPEED, edgeId, tmp);
        }
    }
