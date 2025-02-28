namespace CodingConnected.TraCI.NET.Constants;

// TODO why short not sbyte?
// TODO why same value?
public enum DepartureFlag
    {
    TRIGGERED = -0x01,
    CONTAINER_TRIGGERED = -0x02,
    NOW = -0x03,

    SPEED_RANDOM = -0x02,
    SPEED_MAX = -0x03,

    LANE_RANDOM = -0x02,
    LANE_FREE = -0x03,
    LANE_ALLOWED_FREE = -0x04,
    LANE_BEST_FREE = -0x05,
    LANE_FIRST_ALLOWED = -0x06,

    POS_RANDOM = -0x02,
    POS_FREE = -0x03,
    POS_BASE = -0x04,
    POS_LAST = -0x05,
    POS_RANDOM_FREE = -0x06,
    }
