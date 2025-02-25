namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    /// <summary>
    /// vehicle started teleport
    /// </summary>
    public const byte TELEPORT = 0x00;

    /// <summary>
    /// vehicle removed while parking
    /// </summary>
    public const byte PARKING = 0x01;

    /// <summary>
    /// vehicle arrived
    /// </summary>
    public const byte ARRIVED = 0x02;

    /// <summary>
    /// vehicle was vaporized
    /// </summary>
    public const byte VAPORIZED = 0x03;

    /// <summary>
    /// vehicle finished route during teleport
    /// </summary>
    public const byte TELEPORT_ARRIVED = 0x04;
    }
