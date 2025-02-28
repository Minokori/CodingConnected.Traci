namespace CodingConnected.TraCI.NET.Constants;

public enum StopFlag : byte
    {
    DEFAULT = 0x00,
    PARKING = 0x01,
    TRIGGERED = 0x02,
    CONTAINER_TRIGGERED = 0x04,
    BUS_STOP = 0x08,
    CONTAINER_STOP = 0x10,
    CHARGING_STATION = 0x20,
    PARKING_AREA = 0x40,
    }

