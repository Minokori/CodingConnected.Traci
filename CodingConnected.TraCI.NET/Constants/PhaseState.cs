namespace CodingConnected.TraCI.NET.Constants;

/// <summary>
/// phase state of traffic light, inherited from <see cref="byte"/>
/// </summary>
public enum PhaseState : byte
    {
    Red = 0x01,
    Yellow = 0x02,
    Green = 0x03,
    OffBlinking = 0x04,
    OffNotBlinking = 0x05,
    }
