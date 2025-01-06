using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public class LaneAreaDetectorCommands(ITCPConnectService tcpService, ICommandService helper) : TraCICommandsBase(tcpService, helper)
    {
    #region Public Methods
    /// <summary>
    /// Returns a list of all objects in the network.
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded objects.
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the starting position of the detector measured from the beginning of the lane in meters.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_POSITION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the detector
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLength(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LENGTH, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the id of the lane the detector is on.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetLaneId(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.VAR_LANE_ID, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles that were on the named detector within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepVehicleNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the current mean speed in m/s of vehicles that were on the named e2.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that were on the named detector in the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLastStepVehicleIds(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, id);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the percentage of space the detector was occupied by a vehicle [%]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepOccupancy(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the jam length in meters within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetJamLengthMeters(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.JAM_LENGTH_METERS, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the jam length in vehicles within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetJamLengthVehicle(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANEAREA_VARIABLE, TraCIConstants.JAM_LENGTH_VEHICLE, id);
        return ((TraCIDouble)result.Value).Value;
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(
            beginTime,
            endTime,
            objectId,
            TraCIConstants.CMD_SUBSCRIBE_LANEAREA_VARIABLE,
            ListOfVariablesToSubsribeTo
        );
        }
    #endregion // Public Methods
    }

