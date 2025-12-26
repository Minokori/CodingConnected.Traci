namespace CodingConnected.Traci.Constants;

// TODO why short not sbyte?
// TODO why same value?
[Flags]
public enum Arrival : short
    {
    LANE_CURRENT = -0x02,
    SPEED_CURRENT = LANE_CURRENT,
    POS_RANDOM = LANE_CURRENT,
    POS_MAX = -0x03,
    }

