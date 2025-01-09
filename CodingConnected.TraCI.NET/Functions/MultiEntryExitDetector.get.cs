using System.Collections.Generic;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class MultiEntryExitDetector
    {
    /// <summary>
    /// Returns a list of ids of all multi-entry/multi-exit detectors within the scenario
    /// (the given DetectorID is ignored)
    /// </summary>
    /// <returns>a list of all objects in the network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of multi-entry/multi-exit detectors within the scenario
    /// (the given DetectorID is ignored)
    /// </summary>
    /// <returns>he number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of ids of the multi-entry/multi-exit detector's entry lanes
    /// (the given DetectorID is ignored)
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the list of positions of the detector's entry lanes.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getEntryLanes"/>
    /// </remarks>
    public List<string> GetEntryLanes(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.VAR_LANES, detectorId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of ids of the multi-entry/multi-exit detector's exit lanes
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>he list of ids of the detector's exit lanes</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getExitLanes"/>
    /// </remarks>
    public List<string> GetExitLanes(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.VAR_EXIT_LANES, detectorId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of lane positions (in meters) of the multi-entry/multi-exit detector's entry positions
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getEntryPositions"/>
    /// </remarks>
    public List<Tuple<Double, Double>> GetEntryPositions(string detectorId)
        {
        // TODO check if the return type is position2d or list of position2d
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.VAR_POSITION, detectorId);
        var positions = (TraCICompoundObject)result.Value;
        var list = positions.Select<ITraciType, Tuple<Double, Double>>(i =>
        {
            var position = (Position2D)i;
            return new(position.X.Value, position.Y.Value);
        });
        return list.ToList();
        }

    /// <summary>
    /// Returns a list of lane positions (in meters) of the multi-entry/multi-exit detector's exit positions
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the list of ids of the detector's exit lanes</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getExitPositions"/>
    /// </remarks>
    public List<Tuple<Double, Double>> GetExitPositions(string detectorId)
        {
        // TODO check if the return type is position2d or list of position2d
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.VAR_EXIT_POSITIONS, detectorId);
        var positions = (TraCICompoundObject)result.Value;
        var list = positions.Select<ITraciType, Tuple<Double, Double>>(i =>
        {
            var position = (Position2D)i;
            return new(position.X.Value, position.Y.Value);
        });
        return list.ToList();
        }

    /// <summary>
    /// Returns the number of vehicles that have been within the named multi-entry/multi-exit detector within the last simulation step [#]<para/>
    /// Note:
    /// If the interval length for the detector is equal to the timestep length,
    /// this value corresponds to the vehicleSumWithin measure of multi-entry/multi-exit detectors.
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the number of vehicles that have been within the named multi-entry/multi-exit detector within the last simulation step.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastStepVehicleNumber"/>
    /// </remarks>
    public int GetLastStepVehicleNumber(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER, detectorId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mean speed of vehicles that have been within the named multi-entry/multi-exit detector
    /// within the last simulation step [m/s]
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns> the mean speed in m/s of vehicles that have been within the named multi-entry/multi-exit detector within the last simulation step.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastStepMeanSpeed"/>
    /// </remarks>
    public double GetLastStepMeanSpeed(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that have been within the named multi-entry/multi-exit detector in the last simulation step
    /// </summary>
    /// <param name="detectorId">the list of ids of vehicles that have been within the named multi-entry/multi-exit detector in the last simulation step.</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastStepVehicleIDs"/>
    /// </remarks>
    public List<string> GetLastStepVehicleIds(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, detectorId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which were halting during the last time step
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the number of vehicles which were halting during the last time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastStepHaltingNumber"/>
    /// </remarks>
    public int GetLastStepHaltingNumber(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
            TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER,
            detectorId
        );
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the average travel time of vehicles that passed the detector in the last complete measurement interval
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the average travel time of vehicles that passed the detector in the previous completed measurement interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastIntervalMeanTravelTime"/>
    /// </remarks>
    public double GetLastIntervalMeanTravelTime(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
            TraCIConstants.VAR_LAST_INTERVAL_TRAVELTIME,
            detectorId
        );
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the average number of halts of vehicles that passed the detector in the last complete measurement interval
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the average number of halts of vehicles that passed the detector in the previous completed measurement interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastIntervalMeanHaltsPerVehicle"/>
    /// </remarks>
    public double GetLastIntervalMeanHaltsPerVehicle(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
            TraCIConstants.VAR_LAST_INTERVAL_MEAN_HALTING_NUMBER,
            detectorId
        );
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the average time loss of vehicles that passed the detector in the last complete measurement interval
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the average time loss of vehicles that passed the detector in the previous completed measurement interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastIntervalMeanTimeLoss"/>
    /// </remarks>
    public double GetLastIntervalMeanTimeLoss(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.VAR_TIMELOSS, detectorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles that passed the detector in the last complete measurement interval
    /// </summary>
    /// <param name="detectorId">detector (E3) Id</param>
    /// <returns>the number of vehicles that passed the detector in the previous completed measurement interval</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._multientryexit.html#MultiEntryExitDomain-getLastIntervalVehicleSum"/>
    /// </remarks>
    public int GetLastIntervalVehicleSum(string detectorId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
            TraCIConstants.VAR_LAST_INTERVAL_VEHICLE_NUMBER,
            detectorId
        );
        return ((TraCIInteger)result.Value).Value;
        }
    }
