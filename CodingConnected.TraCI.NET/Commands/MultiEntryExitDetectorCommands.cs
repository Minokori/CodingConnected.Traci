using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class MultiEntryExitDetectorCommands(ITcpService tcpService, ICommandHelperService helper) : TraCICommandsBase(tcpService, helper)
    {
    /// <summary>
    /// Returns a list of all objects in the network.
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded objects.
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.ID_COUNT);
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
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
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
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED);
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
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which were halting during the last time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepHaltingNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
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
