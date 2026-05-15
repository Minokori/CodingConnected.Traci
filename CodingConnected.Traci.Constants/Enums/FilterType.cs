namespace CodingConnected.Traci.Constants;
/// <summary>
/// FILTER TYPES (for context subscription filters)
/// </summary>

public enum FilterType
    {
    /// <summary>
    /// Reset all filters
    /// </summary>
    None = 0x00,

    /// <summary>
    /// Filter by list of lanes relative to ego vehicle
    /// </summary>
    Lanes = 0x01,

    /// <summary>
    /// Exclude vehicles on opposite (and other) lanes from context subscription result
    /// </summary>
    NoOpposite = 0x02,

    /// <summary>
    /// Specify maximal downstream distance for vehicles in context subscription result
    /// </summary>
    DownstreamDistance = 0x03,

    /// <summary>
    /// Specify maximal upstream distance for vehicles in context subscription result
    /// </summary>
    UpstreamDistance = 0x04,

    /// <summary>
    /// Only return leader and follower on the specified lanes in context subscription result
    /// </summary>
    LeadFollow = 0x05,

    /// <summary>
    /// Only return leader and follower on ego and neighboring lane in context subscription result
    /// </summary>
    LCMANEUVER = 0x06,

    /// <summary>
    /// Only return foes on upcoming junction in context subscription result
    /// </summary>
    Turn = 0x07,

    /// <summary>
    /// Only return vehicles of the given vClass in context subscription result
    /// </summary>
    VClass = 0x08,

    /// <summary>
    /// Only return vehicles of the given vType in context subscription result
    /// </summary>
    VType = 0x09,
    }

