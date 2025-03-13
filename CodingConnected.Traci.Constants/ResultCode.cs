namespace CodingConnected.Traci.Constants;
/// <summary>
/// The status code of a TraCI command.
/// </summary>
public enum ResultCode : byte
    {
    /// <summary>
    /// success
    /// </summary>
    Success = 0x00,

    /// <summary>
    /// failed
    /// </summary>
    Failed = 0xff,

    /// <summary>
    /// command not implemented
    /// </summary>
    NotImplemented = 0x01,
    }

