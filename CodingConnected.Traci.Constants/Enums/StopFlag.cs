namespace CodingConnected.Traci.Constants;

#pragma warning disable CA1711 // 标识符应采用正确的后缀
#pragma warning disable CA1027 // 用 FlagsAttribute 标记枚举
public enum StopFlag : int
    {
    Default = 0x00,
    Parking = 0x01,
    Triggered = 0x02,
    ContainerTriggered = 0x04,
    BusStop = 0x08,
    ContainerStop = 0x10,
    ChargingStation = 0x20,
    ParkingArea = 0x40,
    }
