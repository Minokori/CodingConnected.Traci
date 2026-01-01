namespace CodingConnected.Traci.Constants;

#pragma warning disable CA1711 // 标识符应采用正确的后缀

/// <summary>
/// Departure Flags (corresponding value from DepartDefinition, DepartLaneDefinition with a minus)
/// </summary>
public enum DepartureFlag
    {
    None = 0x00,
    Triggered = -0x01,
    ContainerTriggered = -0x02,
    SpeedRandom = ContainerTriggered,
    LaneRandom = ContainerTriggered,
    PositionRandom = ContainerTriggered,
    Now = -0x03,
    SpeedMax = Now,
    LaneFree = Now,
    PositionFree = Now,
    Split = -0x04,
    LaneAllowedFree = Split,
    PositionBase = Split,
    Begin = -0x05,
    LaneBestFree = Begin,
    PositionLast = Begin,
    LaneFirstAllowed = -0x06,
    PositionRandomFree = LaneFirstAllowed,
    }
