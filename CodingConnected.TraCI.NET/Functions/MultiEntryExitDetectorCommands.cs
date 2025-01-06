using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public class MultiEntryExitDetectorCommands(ITCPConnectService tcpService, ICommandService helper) : TraCICommandsBase(tcpService, helper)
    {
    /// <summary>
    /// Returns a list of all objects in the network.
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded objects.
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles that have been within the named multi-entry/multi-exit detector within the
    /// last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepVehicleNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mean speed in m/s of vehicles that have been within the named multi-entry/multi-exit detector
    /// within the last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that have been within the named multi-entry/multi-exit detector in the
    /// last simulation step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLastStepVehicleIds(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, id);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which were halting during the last time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepHaltingNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER, id);
        return ((TraCIInteger)result.Value).Value;
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(
            beginTime,
            endTime,
            objectId,
            TraCIConstants.CMD_SUBSCRIBE_MULTIENTRYEXIT_VARIABLE,
            ListOfVariablesToSubsribeTo
        );
        }
    }
