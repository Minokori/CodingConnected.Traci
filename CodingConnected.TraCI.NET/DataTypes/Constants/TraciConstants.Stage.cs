namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    public static class Stage
        {

        // person / container stopping
        public const byte STAGE_WAITING_FOR_DEPART = 0x00;

        // person / container stopping
        public const byte STAGE_WAITING = 0x01;

        // person walking / container transshipping
        public const byte STAGE_WALKING = 0x02;

        // person riding / container being transported
        public const byte STAGE_DRIVING = 0x03;
        }
    }
