namespace CodingConnected.Traci.Constants;

/// <summary>
/// phase state of traffic light/>
/// </summary>
public enum PhaseState : int
    {
    None = 0x00,
    Red = 0x01,
    Yellow = 0x02,
    Green = 0x03,
    OffBlinking = 0x04,
    OffNotBlinking = 0x05,
    }
