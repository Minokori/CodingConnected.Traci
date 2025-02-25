namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    public static class StopFlag
        {
        public const byte DEFAULT = 0x00;
        public const byte PARKING = 0x01;
        public const byte TRIGGERED = 0x02;
        public const byte CONTAINER_TRIGGERED = 0x04;
        public const byte BUS_STOP = 0x08;
        public const byte CONTAINER_STOP = 0x10;
        public const byte CHARGING_STATION = 0x20;
        public const byte PARKING_AREA = 0x40;
        }
    }
