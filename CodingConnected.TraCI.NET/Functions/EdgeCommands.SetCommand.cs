using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class EdgeCommands
// https://sumo.dlr.de/docs/TraCI/Change_Edge_State.html
    {
    /// <summary>
    /// Adapt the travel time value (in s) used for (re-)routing for the given edge.<para/>
    /// When setting begin time and end time(in seconds),
    /// the changes only apply to that time range.Otherwise they apply all the time
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <param name="travelTimeValue"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-adaptTraveltime"/>
    /// </remarks>
    public bool AdaptTraveltime(string edgeId, int beginTime, int endTime, double travelTimeValue)
        {
        TraCICompoundObject tmp =
        [
            new TraCIInteger() { Value = beginTime },
            new TraCIInteger() { Value = endTime },
            new TraCIDouble() { Value = travelTimeValue },
        ];

        return _helper.ExecuteSetCommand(edgeId, TraCIConstants.CMD_SET_EDGE_VARIABLE, TraCIConstants.VAR_EDGE_TRAVELTIME, tmp);
        }

    /// <summary>
    /// Adapt the effort value used for (re-)routing for the given edge.<para/>
    /// When setting begin time and end time (in seconds),
    /// the changes only apply to that time range.Otherwise they apply all the time.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <param name="effortValue"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-setEffort"/>
    /// </remarks>
    public bool SetEffort(string edgeId, double effortValue, double beginTime, double endTime)
        {
        TraCICompoundObject tmp =
        [
            new TraCIDouble() { Value = beginTime },
            new TraCIDouble() { Value = endTime },
            new TraCIDouble() { Value = effortValue },
        ];

        return _helper.ExecuteSetCommand(edgeId, TraCIConstants.CMD_SET_EDGE_VARIABLE, TraCIConstants.VAR_EDGE_EFFORT, tmp);
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
        var tmp = new TraCIDouble() { Value = speed };
        return _helper.ExecuteSetCommand(edgeId, TraCIConstants.CMD_SET_EDGE_VARIABLE, TraCIConstants.VAR_MAXSPEED, tmp);
        }
    }
