namespace CodingConnected.TraCI.NET.ProtocolTypes;

/// <summary>
/// 从 TCP 传回来的基本数据结构
/// </summary>
public partial class TraCIResult : IStatusResponse, IAnswerFromSumo
    {
    /// <summary>
    /// The length of the content bytes
    /// </summary>
    public int ContentLength { get; set; }

    /// <summary>
    /// The identifier of the command/result
    /// </summary>
    public byte Identifier { get; set; }

    /// <summary>
    /// The response content (excludes length and identifier)
    /// </summary>
    public byte[] Content { get; set; }
    }
