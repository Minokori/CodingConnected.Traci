using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
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
        var tmp = new TraCIDouble() { Value = time };
        return _helper.ExecuteSetCommand(loopId, TraCIConstants.CMD_SET_INDUCTIONLOOP_VARIABLE, TraCIConstants.VAR_VIRTUAL_DETECTION, tmp);

        }
    }
