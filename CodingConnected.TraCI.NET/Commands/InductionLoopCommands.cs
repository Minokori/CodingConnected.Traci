using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class InductionLoopCommands(ITcpService tcpService, ICommandHelperService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    #region Protected Override Methods
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_INDUCTIONLOOP_CONTEXT;

    #endregion Protected Override Methods

    #region Public Methods

    /// <summary>
    /// Returns a list of all objects in the network.
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded objects.
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.ID_COUNT);
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the position measured from the beginning of the lane in meters.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_POSITION);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns the id of the lane the loop is on.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetLaneId(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_LANE_ID);
        return ((TraCIString)result).Value;
        }

    /// <summary>
    /// Returns the number of vehicles that were on the named induction loop within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepVehicleNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the mean speed in m/s of vehicles that were on the named induction loop within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that were on the named induction loop in the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLastStepVehicleIds(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the percentage of time the detector was occupied by a vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepOccupancy(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns the mean length in m of vehicles which were on the detector in the last step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanLength(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_LENGTH);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns the time in s since last detection.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetTimeSinceDetection(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE, TraCIConstants.LAST_STEP_TIME_SINCE_DETECTION);
        return ((TraCIDouble)result).Value;
        }

    /// <summary>
    /// Returns a complex structure containing several information about vehicles which passed the detector.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<object> GetVehicleData(string id)
        {
        // TODO: implement reading this data (http://sumo.dlr.de/wiki/TraCI/Induction_Loop_Value_Retrieval#Response_to_.22last_step.27s_vehicle_data.22_.280x17.29)
        throw new NotSupportedException("This method return complex data; TODO");
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(
            beginTime,
            endTime,
            objectId,
            TraCIConstants.CMD_SUBSCRIBE_INDUCTIONLOOP_VARIABLE,
            ListOfVariablesToSubsribeTo
        );
        }
    #endregion // Public Methods
    }
