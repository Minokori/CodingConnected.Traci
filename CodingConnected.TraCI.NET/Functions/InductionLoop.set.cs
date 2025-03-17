namespace CodingConnected.Traci.Functions;
public partial class InductionLoop
    {
    /// <summary>
    /// Persistently overrides the measured time since detection with the given value. Setting a negative value resets the override.
    /// </summary>
    /// <param name="loopId"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._inductionloop.html#InductionLoopDomain-overrideTimeSinceDetection"/>
    /// </remarks>
    public bool OverrideTimeSinceDetection(string loopId, double time)
        {
        TraciDouble tmp = new(time);
        return _helper.ExecuteSetCommand(CommandIdentifier.Set.INDUCTIONLOOP_VARIABLE, TraciConstants.VAR_VIRTUAL_DETECTION, loopId, tmp);

        }
    }
