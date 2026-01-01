namespace CodingConnected.Traci.Constants;

#pragma warning disable CA1711 // 标识符应采用正确的后缀
public enum ArrivalFlag : int
    {
    None = 0x00,
    LaneCurrent = -0x02,
    SpeedCurrent = LaneCurrent,
    PositionRandom = LaneCurrent,
    PositionMax = -0x03,
    }

