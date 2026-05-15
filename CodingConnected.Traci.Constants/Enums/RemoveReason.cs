namespace CodingConnected.Traci.Constants;

public enum RemoveReason : int
    {
    /// <summary>
    /// vehicle started teleport
    /// </summary>
    Teleport = 0x00,

    /// <summary>
    /// vehicle removed while parking
    /// </summary>
    Parking = 0x01,

    /// <summary>
    /// vehicle arrived
    /// </summary>
    Arrived = 0x02,

    /// <summary>
    /// vehicle was vaporized
    /// </summary>
    Varporized = 0x03,

    /// <summary>
    /// vehicle finished route during teleport
    /// </summary>
    TeleportArrived = 0x04,
    }
