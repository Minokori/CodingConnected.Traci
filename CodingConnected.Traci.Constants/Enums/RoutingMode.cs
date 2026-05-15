namespace CodingConnected.Traci.Constants;

#pragma warning disable CA1008 // 枚举应具有零值
/// <summary>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Routing.html#travel-time_values_for_routing"/>
/// </summary>
[Flags]
public enum RoutingMode : int
    {
    /// <summary>
    /// use custom weights if available, fall back to loaded weights and then to free-flow speed
    /// </summary>
    Default = 0,

    /// <summary>
    /// use aggregated travel times from device.rerouting
    /// </summary>
    Aggregated = 1,

    /// <summary>
    /// use loaded efforts
    /// </summary>
    Effort = 0x02,

    /// <summary>
    /// use combined costs
    /// </summary>
    Combined = 0x03,

    /// <summary>
    /// use aggregated travel times from device.rerouting enriched with custom weights
    /// </summary>
    AggregatedCustom = 0x04,

    /// <summary>
    /// when this bit is set, routing does not consider temporary permission changes (i.e. from rerouters)<para/>
    /// note: can be combined with either one of the other modes (bitwise)<para/>
    /// this is also for <b>IgnoreRerouterChanges</b>
    /// </summary>
    IgnoreTransientPermissions = 0x08,
    AggregatedAndIgnoringRerouterChanges = 0x09,
    }
