namespace CodingConnected.TraCI.NET.ProtocolTypes;

/// <summary>
/// 从 TCP 传回来的 bytes 解析得到的基本数据结构<para/>
/// basic data structure parsed from bytes returned from TCP
/// </summary>
public partial class TraciResult : IStatusResponse, IAnswerFromSumo
    {
    /// <summary>
    /// The length of the content bytes
    /// </summary>
    public int ContentLength { get; init; }

    /// <summary>
    /// The identifier of the command/result
    /// </summary>
    public byte Identifier { get; init; }

    /// <summary>
    /// The response content <b>(excludes length and identifier)</b>
    /// </summary>
    public byte[] Content { get; init; } = [];

    }
