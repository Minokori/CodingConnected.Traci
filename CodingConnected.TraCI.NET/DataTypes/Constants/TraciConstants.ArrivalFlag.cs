namespace CodingConnected.TraCI.NET.DataTypes;

public static partial class TraciConstants
    {
    // TODO why short not sbyte?
    public static class ArrivalFlag
        {
        public const short LANE_CURRENT = -0x02;
        public const short SPEED_CURRENT = -0x02;

        public const short POS_RANDOM = -0x02;
        public const short POS_MAX = -0x03;
        }
    }
