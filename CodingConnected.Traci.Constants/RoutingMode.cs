namespace CodingConnected.Traci.Constants;

[Flags]
public enum RoutingMode : int
    {
    /// <summary>
    /// use custom weights if available, fall back to loaded weights and then to free-flow speed
    /// </summary>
    DEFAULT = 0,

    /// <summary>
    /// use aggregated travel times from device.rerouting
    /// </summary>
    AGGREGATED = 1,

    /// <summary>
    /// use loaded efforts
    /// </summary>
    EFFORT = 0x02,

    /// <summary>
    /// use combined costs
    /// </summary>
    COMBINED = 0x03,
    }
/// <summary>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Routing.html#travel-time_values_for_routing"/>
/// </summary>
//public enum RoutingMode : int
//    {
//    Default = 0,
//    Aggregated = 1,
//    AggregatedCustom = 4,
//    IgnoreRerouterChanges = 8,
//    AggregatedAndIgnoringRerouterChanges = 9,
//    }
