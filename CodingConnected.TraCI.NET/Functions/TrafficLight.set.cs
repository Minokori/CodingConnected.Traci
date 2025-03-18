namespace CodingConnected.Traci.Functions;

public partial class TrafficLight
    {
    /// <summary>
    /// Sets the named tl's state as <u>a tuple of</u> light definitions from rRgGyYuoO, for red, red-yellow, green, yellow, off,
    /// where lower case letters mean that the stream has to decelerate
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="state"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-setRedYellowGreenState"/>
    /// </remarks>
    public bool SetRedYellowGreenState(string tlsId, string state)
        {
        var tmp = new TraciString(state);
        return _helper.ExecuteSetCommand(
            Set.SIM_VARIABLE,
            TraciConstants.TL_RED_YELLOW_GREEN_STATE,
            tlsId,
            tmp
        );
        }

    /// <summary>
    /// Sets the state for the given tls and link index. The state must be <u>one of</u> rRgGyYoOu for red, red-yellow, green, yellow, off, where lower case letters mean that the stream has to decelerate.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="tlsLinkIndex"> is shown in the GUI when setting the appropriate junction visualization option</param>
    /// <param name="state"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-setLinkState"/>
    /// </remarks>

    public bool SetLinkState(string tlsId, int tlsLinkIndex, string state)
        {
        var fullState = GetRedYellowGreenState(tlsId);
        return tlsLinkIndex < fullState.Length
            && SetRedYellowGreenState(
                tlsId,
                string.Concat(
                    fullState.AsSpan(0, tlsLinkIndex),
                    state,
                    fullState.AsSpan(tlsLinkIndex + 1)
                )
            );
        }

    /// <summary>
    /// Sets the phase of the traffic light to the given. The given index must be valid for the current
    /// programId of the traffic light, this means it must be between 0 and the number of phases known to
    /// the current programId of the tls - 1.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="index"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-setPhase"/>
    /// </remarks>
    public bool SetPhase(string tlsId, int index)
        {
        TraciInteger tmp = new(index);
        return _helper.ExecuteSetCommand(
            Set.SIM_VARIABLE,
            TraciConstants.TL_PHASE_INDEX,
            tlsId,
            tmp
        );
        }

    /// <summary>
    /// Switches the traffic light to the given programId. No WAUT algorithm is used, the programId is
    /// directly instantiated. The index of the traffic light stays the same as before.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="programId"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-setProgram"/>
    /// </remarks>
    public bool SetProgram(string tlsId, string programId)
        {
        TraciString tmp = new(programId);
        return _helper.ExecuteSetCommand(Set.SIM_VARIABLE, TraciConstants.TL_PROGRAM, tlsId, tmp);
        }

    /// <summary>
    /// Sets the remaining duration of the current phase in seconds.
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="phaseDuration"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-setPhaseDuration"/>
    /// </remarks>
    public bool SetPhaseDuration(string tlsId, double phaseDuration)
        {
        TraciDouble tmp = new(phaseDuration);
        return _helper.ExecuteSetCommand(
            Set.SIM_VARIABLE,
            TraciConstants.TL_PHASE_DURATION,
            tlsId,
            tmp
        );
        }

    /// <summary>
    /// Inserts a completely new program.<para/>
    /// Sets a new program for the given <paramref name="tlsId"/> from a <see cref="TrafficLightLogic"/> object.<para/>
    /// About logic, see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#Logic"/>
    /// </summary>
    /// <param name="tlsId"></param>
    /// <param name="logic"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._trafficlight.html#TrafficLightDomain-setProgramLogic"/>
    /// </remarks>
    public bool SetProgramLogic(string tlsId, TrafficLightLogic logic) =>
        _helper.ExecuteSetCommand(
            Set.SIM_VARIABLE,
            TraciConstants.TL_COMPLETE_PROGRAM_RYG,
            tlsId,
            logic
        );
    }
