namespace CodingConnected.Traci.Constants;
/// <summary>
/// FILTER TYPES (for context subscription filters)
/// </summary>

public enum FilterType
    {
    /// <summary>
    /// Reset all filters
    /// </summary>
    NONE = 0x00,

    /// <summary>
    /// Filter by list of lanes relative to ego vehicle
    /// </summary>
    LANES = 0x01,

    /// <summary>
    /// Exclude vehicles on opposite (and other) lanes from context subscription result
    /// </summary>
    NOOPPOSITE = 0x02,

    /// <summary>
    /// Specify maximal downstream distance for vehicles in context subscription result
    /// </summary>
    DOWNSTREAM_DIST = 0x03,

    /// <summary>
    /// Specify maximal upstream distance for vehicles in context subscription result
    /// </summary>
    UPSTREAM_DIST = 0x04,

    /// <summary>
    /// Only return leader and follower in context subscription result
    /// </summary>
    CF_MANEUVER = 0x05,

    /// <summary>
    /// Only return leader and follower on ego and neighboring lane in context subscription result
    /// </summary>
    LC_MANEUVER = 0x06,

    /// <summary>
    /// Only return foes on upcoming junction in context subscription result
    /// </summary>
    TURN_MANEUVER = 0x07,

    /// <summary>
    /// Only return vehicles of the given vClass in context subscription result
    /// </summary>
    VCLASS = 0x08,

    /// <summary>
    /// Only return vehicles of the given vType in context subscription result
    /// </summary>
    VTYPE = 0x09,
    }

