namespace CodingConnected.TraCI.NET.Constants;

public enum RoutingMode : int
    {
    /// <summary>
    /// use custom weights if available, fall back to loaded weights and then to free-flow speed
    /// </summary>
    DEFAULT = 0x00,

    /// <summary>
    /// use aggregated travel times from device.rerouting
    /// </summary>
    AGGREGATED = 0x01,

    /// <summary>
    /// use loaded efforts
    /// </summary>
    EFFORT = 0x02,

    /// <summary>
    /// use combined costs
    /// </summary>
    COMBINED = 0x03,
    }
