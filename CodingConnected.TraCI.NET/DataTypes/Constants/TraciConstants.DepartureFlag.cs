namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    // TODO why short not sbyte?
    public static class DepartureFlag
        {
        public const short TRIGGERED = -0x01;
        public const short CONTAINER_TRIGGERED = -0x02;
        public const short NOW = -0x03;

        public const short SPEED_RANDOM = -0x02;
        public const short SPEED_MAX = -0x03;

        public const short LANE_RANDOM = -0x02;
        public const short LANE_FREE = -0x03;
        public const short LANE_ALLOWED_FREE = -0x04;
        public const short LANE_BEST_FREE = -0x05;
        public const short LANE_FIRST_ALLOWED = -0x06;

        public const short POS_RANDOM = -0x02;
        public const short POS_FREE = -0x03;
        public const short POS_BASE = -0x04;
        public const short POS_LAST = -0x05;
        public const short POS_RANDOM_FREE = -0x06;
        }
    }
