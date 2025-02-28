namespace CodingConnected.TraCI.NET.Constants;
public enum RemoveReason : byte
    {
    /// <summary>
    /// vehicle started teleport
    /// </summary>
    TELEPORT = 0x00,

    /// <summary>
    /// vehicle removed while parking
    /// </summary>
    PARKING = 0x01,

    /// <summary>
    /// vehicle arrived
    /// </summary>
    ARRIVED = 0x02,

    /// <summary>
    /// vehicle was vaporized
    /// </summary>
    VAPORIZED = 0x03,

    /// <summary>
    /// vehicle finished route during teleport
    /// </summary>
    TELEPORT_ARRIVED = 0x04,
    }
