using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Lane
    {
    /// <summary>
    /// 	Sets the given classes as classes allowed on the lane.
    /// </summary>
    /// <param name="laneId"></param>
    /// <param name="allowedClasses"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-setAllowed"/>
    /// </remarks>
    public bool SetAllowed(string laneId, List<string> allowedClasses)
        {
        return _helper.ExecuteSetCommand(
            laneId,
            TraCIConstants.CMD_SET_LANE_VARIABLE,
            TraCIConstants.LANE_ALLOWED,
            new TraCIStringList() { Value = allowedClasses }
        );
        }

    /// <summary>
    /// Sets the given classes as classes not allowed on the lane.
    /// </summary>
    /// <param name="laneId"></param>
    /// <param name="disallowedClasses"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-setDisallowed"/>
    /// </remarks>
    public bool SetDisallowed(string laneId, List<string> disallowedClasses)
        {
        return _helper.ExecuteSetCommand(
            laneId,
            TraCIConstants.CMD_SET_LANE_VARIABLE,
            TraCIConstants.LANE_DISALLOWED,
            new TraCIStringList() { Value = disallowedClasses }
        );
        }

    /// <summary>
    /// Sets the given classes as classes allowed to change to the left/right neighbor lane.
    /// </summary>
    /// <param name="laneId"></param>
    /// <param name="allowedClasses"></param>
    /// <param name="direction">(left=1, right=-1)</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-setChangePermissions"/>
    /// </remarks>
    public bool SetChangePermission(string laneId, List<string> allowedClasses, int direction)
        {
        var tmp = new TraCICompoundObject
        {
            new TraCIStringList { Value = allowedClasses },
            new TraCIByte { Value = (byte)direction },
        };
        return _helper.ExecuteSetCommand(laneId, TraCIConstants.CMD_SET_LANE_VARIABLE, TraCIConstants.LANE_CHANGES, tmp);
        }

    /// <summary>
    /// 	Sets the given value as the lane's new length [m].
    /// </summary>
    /// <param name="laneId"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-setLength"/>
    /// </remarks>
    public bool SetLength(string laneId, double length)
        {
        var tmp = new TraCIDouble() { Value = length };
        return _helper.ExecuteSetCommand(laneId, TraCIConstants.CMD_SET_LANE_VARIABLE, TraCIConstants.VAR_LENGTH, tmp);
        }

    /// <summary>
    /// 	Sets the given value as the new maximum velocity allowed on the lane [m/s].
    /// </summary>
    /// <param name="laneId"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-setMaxSpeed"/>
    /// </remarks>
    public bool SetMaxSpeed(string laneId, double speed)
        {
        var tmp = new TraCIDouble() { Value = speed };
        return _helper.ExecuteSetCommand(laneId, TraCIConstants.CMD_SET_LANE_VARIABLE, TraCIConstants.VAR_MAXSPEED, tmp);
        }
    }
