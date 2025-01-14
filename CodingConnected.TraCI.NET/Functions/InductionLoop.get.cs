using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class InductionLoop
    {
    /// <summary>
    /// Returns a list of ids of all induction loops within the scenario
    /// (the given Induction Loop ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the position of the induction loop at its lane,
    /// counted from the lane's begin, in meters.
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getPosition"/>
    /// </remarks>

    public double GetPosition(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_POSITION, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns the ID of the lane the induction loop is placed at.
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLaneID"/>
    /// </remarks>
    public string GetLaneId(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_LANE_ID, loopId);
        return ((TraCIString)result).Value;
        }

    /// <summary>
    /// Returns the number of induction loops within the scenario
    /// (the given Induction Loop ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the number of vehicles that were on the named induction loop within the last simulation step [#];
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// Note:This value corresponds to the nVehEntered measure of induction loops.<para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastStepVehicleNumber"/>
    /// </remarks>
    public int GetLastStepVehicleNumber(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER, loopId);
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the mean speed in m/s of vehicles that were on the named induction loop within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED, id);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns the mean speed of vehicles that were on the named induction loop within the last simulation step [m/s]
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastStepVehicleIDs"/>
    /// </remarks>
    public List<string> GetLastStepVehicleIds(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, loopId);
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the percentage of time the detector was occupied by a vehicle [%]
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastStepOccupancy"/>
    /// </remarks>
    public double GetLastStepOccupancy(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// The mean length of vehicles which were on the detector in the last step [m]
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastStepMeanLength"/>
    /// </remarks>
    public double GetLastStepMeanLength(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_LENGTH, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// 	The time since last detection [s]
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getTimeSinceDetection"/>
    /// </remarks>
    public double GetTimeSinceDetection(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_TIME_SINCE_DETECTION, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// A complex structure containing several information about vehicles which passed the detector
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getVehicleData"/>
    /// </remarks>
    public List<VehicleInformationPacket> GetVehicleData(string loopId)
        {
        var result = (TraCICompoundObject)
            _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_DATA, loopId);
        return result.ToVehicleInformationPackets();
        }

    /// <summary>
    /// The percentage of the time the detector was occupied by a vehicle during the current interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalOccupancy"/>
    /// </remarks>
    public double GetIntervalOccupancy(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_INTERVAL_OCCUPANCY, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// The average (time mean) speed of vehicles during the current interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalMeanSpeed"/>
    /// </remarks>
    public double GetIntervalMeanSpeed(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_INTERVAL_SPEED, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// The number of vehicles (or persons, if so configured) that passed the detector during the current interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalVehicleNumber"/>
    /// </remarks>
    public int GetIntervalVehicleNumber(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_INTERVAL_NUMBER, loopId);
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// The ids of vehicles (or persons, if so configured) that passed the detector during the current interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalVehicleIDs"/>
    /// </remarks>
    public List<string> GetIntervalVehicleIds(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_INTERVAL_IDS, loopId);
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// The percentage of the time the detector was occupied by a vehicle during the previous interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastIntervalOccupancy"/>
    /// </remarks>
    public double GetLastIntervalOccupancy(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_OCCUPANCY, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// The average (time mean) speed of vehicles during the previous interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastIntervalMeanSpeed"/>
    /// </remarks>
    public double GetLsatIntervalMeanSpeed(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_SPEED, loopId);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// The number of vehicles (or persons, if so configured) that passed the detector during the previous interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastIntervalVehicleNumber"/>
    /// </remarks>
    public int GetLsatIntervalVehiclNumber(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_NUMBER, loopId);
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// 	The ids of vehicles (or persons, if so configured) that passed the detector during the previous interval
    /// </summary>
    /// <param name="loopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastIntervalVehicleIDs"/>
    /// </remarks>
    public List<string> GetLastIntervalVehicleIds(string loopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_IDS, loopId);
        return ((TraCIStringList)result).Value;
        }
    }
