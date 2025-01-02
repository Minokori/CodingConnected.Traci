using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Extensions;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class TrafficLightCommands(ITcpService tcpService, ICommandHelperService helper) : TraCICommandsBase(tcpService, helper)
    {
    #region Public Methods

    /// <summary>
    /// Returns a list of all objects in the network.
    /// </summary>
    /// <returns></returns>
    public TraCIResponse<List<string>> GetIdList()
        {
        return
            _helper.ExecuteGetCommand<List<string>>(

                "ignored",
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.ID_LIST);
        }

    /// <summary>
    /// Returns the number of currently loaded objects.
    /// </summary>
    /// <returns></returns>
    public TraCIResponse<int> GetIdCount()
        {
        return
            _helper.ExecuteGetCommand<int>(

                "ignored",
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.ID_COUNT);
        }

    /// <summary>
    /// Returns the named tl's state as a tuple of light definitions from
    /// rugGyYoO, for red, yed-yellow, green, yellow, off, where lower case letters mean that the stream
    /// has to decelerate.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<string> GetState(string id)
        {
        return
            _helper.ExecuteGetCommand<string>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_RED_YELLOW_GREEN_STATE);
        }

    /// <summary>
    /// Returns the default total duration of the currently active phase in seconds; To obtain the remaining
    /// duration use (getNextSwitch() - simulation.getTime()); to obtain the spent duration subtract the 
    /// remaining from the total duration
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<double> GetPhaseDuration(string id)
        {
        return
            _helper.ExecuteGetCommand<double>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_PHASE_DURATION);
        }

    /// <summary>
    /// Returns the list of lanes which are controlled by the named traffic light. Returns at least one entry 
    /// for every element of the phase state (signal index)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<List<string>> GetControlledLanes(string id)
        {
        return
            _helper.ExecuteGetCommand<List<string>>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_CONTROLLED_LANES);
        }

    /// <summary>
    /// Returns the links controlled by the traffic light, sorted by the signal index and described by giving 
    /// the incoming, outgoing, and via lane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<ControlledLinks> GetControlledLinks(string id)
        {
        var tmp = _helper.ExecuteGetCommand<TraCICompoundObject>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_CONTROLLED_LINKS);

        var controlledLinks = tmp.Content.ToControlledLinks();

        TraCIResponse<ControlledLinks> ret = new()
            {
            Content = controlledLinks,
            ErrorMessage = tmp.ErrorMessage,
            Identifier = tmp.Identifier,
            ResponseIdentifier = tmp.ResponseIdentifier,
            Result = tmp.Result,
            VariableType = tmp.VariableType
            };

        return ret;
        }

    /// <summary>
    /// Returns the index of the current phase in the current program
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<int> GetCurrentPhase(string id)
        {
        return
            _helper.ExecuteGetCommand<int>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_CURRENT_PHASE);
        }

    /// <summary>
    /// Returns the id of the current program
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<string> GetCurrentProgram(string id)
        {
        return
            _helper.ExecuteGetCommand<string>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_CURRENT_PROGRAM);
        }

    /// <summary>
    /// Returns the complete traffic light program, structure described under data types
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<TrafficCompleteLightProgram> GetCompleteDefinition(string id)
        {
        var tmp = _helper.ExecuteGetCommand<TraCICompoundObject>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_COMPLETE_DEFINITION_RYG);

        var tmp2 = tmp.Content.ToTrafficLightCompleteProgram();

        TraCIResponse<TrafficCompleteLightProgram> ret = new()
            {
            Content = tmp2,
            ErrorMessage = tmp.ErrorMessage,
            Identifier = tmp.Identifier,
            ResponseIdentifier = tmp.ResponseIdentifier,
            Result = tmp.Result,
            VariableType = tmp.VariableType
            };

        return ret;
        }

    /// <summary>
    /// Returns the assumed time (in seconds) at which the tls changes the phase. Please note
    /// that the time to switch is not relative to current simulation step (the result returned
    /// by the query will be absolute time, counting from simulation start); to obtain relative
    /// time, one needs to subtract current simulation time from the result returned by this 
    /// query. Please also note that the time may vary in the case of actuated/adaptive traffic lights
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResponse<double> GetNextSwitch(string id)
        {
        return
            _helper.ExecuteGetCommand<double>(

                id,
                TraCIConstants.CMD_GET_TL_VARIABLE,
                TraCIConstants.TL_NEXT_SWITCH);
        }

    /// <summary>
    /// Sets the phase definition to the given. Assumes the given string is a tuple of light definitions
    /// from rRgGyYoO, for red, green, yellow, off, where lower case letters mean that the stream has to 
    /// decelerate. After this call the program-ID of the traffic light will be set to "online" and the 
    /// state will be maintained until the next call of setRedYellowGreenState() or until setting another
    /// program with setProgram().
    /// </summary>
    /// <param name="id"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool SetRedYellowGreenState(string id, string state)
        {
        return _helper.ExecuteSetCommand<object, string>(

            id,
            TraCIConstants.CMD_SET_TL_VARIABLE,
            TraCIConstants.TL_RED_YELLOW_GREEN_STATE,
            state);
        }

    /// <summary>
    /// Sets the phase of the traffic light to the given. The given index must be valid for the current 
    /// program of the traffic light, this means it must be between 0 and the number of phases known to 
    /// the current program of the tls - 1.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="phaseIndex"></param>
    /// <returns></returns>
    public bool SetPhase(string id, int phaseIndex)
        {
        return _helper.ExecuteSetCommand<object, int>(

            id,
            TraCIConstants.CMD_SET_TL_VARIABLE,
            TraCIConstants.TL_PHASE_INDEX,
            phaseIndex);
        }

    /// <summary>
    /// Switches the traffic light to the given program. No WAUT algorithm is used, the program is 
    /// directly instantiated. The index of the traffic light stays the same as before.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="program"></param>
    /// <returns></returns>
    public bool SetProgram(string id, string program)
        {
        return _helper.ExecuteSetCommand<object, string>(

            id,
            TraCIConstants.CMD_SET_TL_VARIABLE,
            TraCIConstants.TL_PROGRAM,
            program);
        }

    /// <summary>
    /// Sets the remaining duration of the current phase in seconds.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="phaseDuration"></param>
    /// <returns></returns>
    public bool SetPhaseDuration(string id, double phaseDuration)
        {
        return _helper.ExecuteSetCommand<object, double>(

            id,
            TraCIConstants.CMD_SET_TL_VARIABLE,
            TraCIConstants.TL_PHASE_DURATION,
            phaseDuration);
        }

    /// <summary>
    /// Inserts a completely new program.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="program"></param>
    /// <returns></returns>
    public TraCIResponse<object> SetCompleteRedYellowGreenDefinition(string id, TrafficLightProgram program)
        {
        // TODO: move this to _helper.ExecuteSetCommand

        List<byte> bytes =
            [
            TraCIConstants.TL_COMPLETE_PROGRAM_RYG,
            .. id.ToTraCIBytes(),
            TraCIConstants.TYPE_COMPOUND, //value type compound
            .. (5 + (program.Phases.Count * 4)).ToTraCIBytes(), //item number
            TraCIConstants.TYPE_STRING, //value type string
            .. program.ProgramId.ToTraCIBytes(), //program ID
            TraCIConstants.TYPE_INTEGER, //value type integer
            .. 0.ToTraCIBytes(), //Type (always 0)
            TraCIConstants.TYPE_COMPOUND, //value type compound
            .. 0.ToTraCIBytes(),//Compound ContentLength (always 0!)
            TraCIConstants.TYPE_INTEGER, //value type integer
            .. program.PhaseIndex.ToTraCIBytes(), //Phase Index
            TraCIConstants.TYPE_INTEGER, //value type integer
            .. program.Phases.Count.ToTraCIBytes(),
            ]; //messageType (0x2c)

        foreach (var p in program.Phases)//Phases
            {
            bytes.Add(TraCIConstants.TYPE_DOUBLE); //value type integer
            bytes.AddRange(p.Duration.ToTraCIBytes()); //Duration[ms]
            bytes.Add(TraCIConstants.TYPE_DOUBLE); //value type integer
            bytes.AddRange(0.ToTraCIBytes()); //unused
            bytes.Add(TraCIConstants.TYPE_DOUBLE); //value type integer
            bytes.AddRange(0.ToTraCIBytes()); //unused
            bytes.Add(TraCIConstants.TYPE_STRING); //value type string
            bytes.AddRange(p.Definition.ToTraCIBytes()); //State (light/priority-tuple)
            }

        TraCICommand command = new()
            {
            Identifier = TraCIConstants.CMD_SET_TL_VARIABLE,
            Contents = [.. bytes]
            };

        var response = _tcpService.SendMessage(command);

#warning is the try catch necessary?
        try
            {
            return TraCIDataConverter.ExtractDataFromResults<object>(response, TraCIConstants.CMD_SET_TL_VARIABLE, TraCIConstants.TL_COMPLETE_PROGRAM_RYG);
            }
        catch
            {
            throw;
            }
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objectId">Id of the object to subscribe to. If you want to subscribe to id list or count, use "ignored" as object id</param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <param name="ListOfVariablesToSubsribeTo"></param>
    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(

            beginTime,
            endTime,
            objectId,
            TraCIConstants.CMD_SUBSCRIBE_TL_VARIABLE,
            ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
