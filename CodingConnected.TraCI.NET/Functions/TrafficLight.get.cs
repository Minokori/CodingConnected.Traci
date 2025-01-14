using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class TrafficLight
    {
    /// <summary>
    /// 	Returns a list of ids of all traffic lights within the scenario 
    /// 	(the given Traffic Lights ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the number of traffic lights within the scenario 
    /// 	(the given Traffic Lights ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getIDList"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the named tl's state as a tuple of light definitions from
    /// rugGyYoO, for red, yed-yellow, green, yellow, off, where lower case letters mean that the stream
    /// has to decelerate.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getRedYellowGreenState"/>
    /// </remarks>
    public string GetRedYellowGreenState(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_RED_YELLOW_GREEN_STATE, tlsId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the default total duration of the currently active phase in seconds; To obtain the remaining
    /// duration use (<see cref="GetNextSwitch"/> - <see cref="Simulation.GetTime"/>); to obtain the spent duration subtract the
    /// remaining from the total duration
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getPhaseDuration"/>
    /// </remarks>
    public double GetPhaseDuration(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_PHASE_DURATION, tlsId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of lanes which are controlled by the named traffic light.<para/
    /// Returns at least one entry for every element of the phase state (signal index)
    /// </summary>
    /// <param name="tlsID"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getControlledLanes"/>
    /// </remarks>
    public List<string> GetControlledLanes(string tlsID)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_CONTROLLED_LANES, tlsID);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the links controlled by the traffic light, sorted by the signal index and described by giving
    /// the incoming, outgoing, and via lane.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getControlledLinks"/>
    /// </remarks>
    public List<ControlledLinks> GetControlledLinks(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_CONTROLLED_LINKS, tlsId);
        return ((TraCICompoundObject)result.Value).ToControlledLinks();
        }

    /// <summary>
    /// Returns the index of the current phase in the current program
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getPhase"/>
    /// </remarks>

    public int GetPhase(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_CURRENT_PHASE, tlsId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the tlsId of the current program
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getProgram"/>
    /// </remarks>
    public string GetProgram(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_CURRENT_PROGRAM, tlsId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of Logic objects.<para/>
    /// Each Logic encodes a traffic light program for the given tlsID.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getAllProgramLogics"/>
    /// </remarks>
    public List<TrafficLightLogic> GetCompleteRedYellowGreenDefinition(string tlsId)
        {
        var result = (TraCICompoundObject)_helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_COMPLETE_DEFINITION_RYG, tlsId);
        return result.ToTrafficLightLogics();
        }

    /// <summary>
    /// Returns the assumed time (in seconds) at which the tls changes the phase. Please note
    /// that the time to switch is not relative to current simulation step (the result returned
    /// by the query will be absolute time, counting from simulation start); to obtain relative
    /// time, one needs to subtract current simulation time from the result returned by this
    /// query. Please also note that the time may vary in the case of actuated/adaptive traffic lights
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getNextSwitch"/>
    /// </remarks>
    public double GetNextSwitch(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_NEXT_SWITCH, tlsId);
        return ((TraCIDouble)result.Value).Value;
        }


    /// <summary>
    /// Returns the time spent in the current phase (in seconds)
    /// </summary>
    /// <param name="tlsId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getSpentDuration"/>
    /// </remarks>
    public double GetSpentDuration(string tlsId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_SPENT_DURATION, tlsId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of vehicles that occupy the subsequent rail signal block
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="linkIndex"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getBlockingVehicles"/>
    /// </remarks>
    public List<string> GetBlockingVehicles(string tlsId, int linkIndex)
        {
        var tmp = new TraCIInteger { Value = linkIndex };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_BLOCKING_VEHICLES, tlsId, tmp);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of vehicles that are approaching the same rail signal block
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="linkIndex"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getRivalVehicles"/>
    /// </remarks>
    public List<string> GetRivalVehicles(string tlsId, int linkIndex)
        {
        var tmp = new TraCIInteger { Value = linkIndex };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_RIVAL_VEHICLES, tlsId, tmp);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    ///  Returns the ids of vehicles that are approaching the same rail signal block with higher priority
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="linkIndex"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-getPriorityVehicles"/>
    /// </remarks>
    public List<string> GetPriorityVehicles(string tlsId, int linkIndex)
        {
        var tmp = new TraCIInteger { Value = linkIndex };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_TL_VARIABLE, TraCIConstants.TL_PRIORITY_VEHICLES, tlsId, tmp);
        return ((TraCIStringList)result.Value).Value;
        }
    }
