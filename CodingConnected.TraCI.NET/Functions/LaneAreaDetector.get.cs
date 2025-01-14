using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class LaneAreaDetector
    {
    /// <summary>
    /// Returns a list of ids of all lane area detectors within the scenario
    /// (the given DetectorID is ignored)
    /// </summary>
    /// <returns> a list of ids of all lane area detectors </returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    ///Returns the number of lane area detectors within the scenario
    ///(the given DetectorID is ignored)
    /// </summary>
    /// <returns> the number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the starting position of the detector at its lane,
    /// counted from the lane's begin,
    /// in meters.
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the starting position of the detector measured from the beginning of the lane (m)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getPosition"/>
    /// </remarks>
    public double GetPosition(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_POSITION, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the length of the detector in meters.
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the length of the detector (m)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLength"/>
    /// </remarks>

    public double GetLength(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LENGTH, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the ID of the lane the detector is placed at.
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the detectorId of the lane the detector is on</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLaneID"/>
    /// </remarks>
    public string GetLaneId(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LANE_ID, detectorId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles
    /// that have been within the area detector
    /// within the last simulation step [#]
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the number of vehicles that were on the named detector within the last simulation step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLastStepVehicleNumber"/>
    /// </remarks>
    public int GetLastStepVehicleNumber(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER, detectorId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mean speed of vehicles
    /// that have been within the named area detector
    /// within the last simulation step [m/s].
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the current mean speed in m/s of vehicles that were on the named e2</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLastStepMeanSpeed"/>
    /// </remarks>
    public double GetLastStepMeanSpeed(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that have been within the detector in the last simulation step
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the list of ids of vehicles that were on the named detector in the last simulation step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLastStepVehicleIDs"/>
    /// </remarks>
    public List<string> GetLastStepVehicleIds(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, detectorId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the percentage of space the detector was occupied by a vehicle [%]
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the percentage of space the detector was occupied by a vehicle [%]</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLastStepMeanSpeed"/>
    /// </remarks>
    public double GetLastStepOccupancy(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which were halting during the last time step
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the number of vehicles which were halting during the last time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLastStepHaltingNumber"/>
    /// </remarks>
    public double GetLastStepHaltingNumber(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which were halting on the loop during the last time step
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the jam length in vehicles within the last simulation step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getLastStepVehicleNumber"/>
    /// </remarks>
    public int GetJamLengthVehicle(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.JAM_LENGTH_VEHICLE, detectorId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the jam in meters
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>he jam length in meters within the last simulation step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getJamLengthMeters"/>
    /// </remarks>
    public double GetJamLengthMeters(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.JAM_LENGTH_METERS, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the average percentage of the detector length
    /// that was occupied by a vehicle during the current interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>he jam length in meters within the last simulation step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalOccupancy"/>
    /// </remarks>
    public double GetIntervalOccupancy(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_INTERVAL_OCCUPANCY, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the average (time mean) speed of vehicles during the current interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the mean speed during the current interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getJamLengthMeters"/>
    /// </remarks>
    public double GetIntervalMeanSpeed(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_INTERVAL_SPEED, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles (or persons, if so configured)
    /// that passed the detector during the current interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns> the number of seen vehicles during the current interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalVehicleNumber"/>
    /// </remarks>
    public int GetIntervalVehicleNumber(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_INTERVAL_NUMBER, detectorId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum jam length in meters during the current interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the max jam length during the current interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getIntervalMaxJamLengthInMeters"/>
    /// </remarks>
    public double GetIntervalMaxJamLengthInMeters(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
            TraCIConstants.VAR_INTERVAL_MAX_JAM_LENGTH_METERS,
            detectorId
        );
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the average percentage of the detector length that was occupied by a vehicle during the previous interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>he jam length in meters within the last simulation step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastIntervalOccupancy"/>
    /// </remarks>
    public double GetLastIntetrvalOccupancy(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_OCCUPANCY, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the average (time mean) speed of vehicles during the previous interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns> the mean speed during the previous interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-getLastIntervalMeanSpeed"/>
    /// </remarks>
    public double GetLastIntervalMeanSpeed(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_SPEED, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles (or persons, if so configured)
    /// that passed the detector during the previous interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the number of seen vehicles during the previous interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getJamLengthMeters"/>
    /// </remarks>
    public int GetLastIntervalVehicleNumber(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LAST_INTERVAL_NUMBER, detectorId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum jam length in meters during the previous interval
    /// </summary>
    /// <param name="detectorId">E2 detector ID</param>
    /// <returns>the max jam length during the previous interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-getJamLengthMeters"/>
    /// </remarks>

    public double GetLastIntervalMaxJamLengthInMeters(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
            TraCIConstants.VAR_LAST_INTERVAL_MAX_JAM_LENGTH_METERS,
            detectorId
        );
        return ((TraCIDouble)result.Value).Value;
        }
    }
