using System.Text;
using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.ProtocolTypes;

public partial class TraciResult
    {
    ResultCode IStatusResponse.Result => (ResultCode)Content[0];
    int IStatusResponse.DescriptionLength => BitConverter.ToInt32(Content.Skip(1).Take(4).ToArray());

    string IStatusResponse.Description => Encoding.ASCII.GetString([.. Content.Skip(1 + 4).Take(((IStatusResponse)this).DescriptionLength)]);
    }

/// <summary>
/// 显式实现的接口，用于将 <see cref="TraciResult"/> 解析为 status response<para/>
/// <u>由于并非所有TraciResult都可以被解释为 status response（通常仅第一条TraciResult应被解释为 status response），该接口将被显示实现</u>
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#status_response"/>
/// </remarks>
public interface IStatusResponse
    {
    /// <summary>
    /// result of the command. success or failure.
    /// </summary>
    ResultCode Result { get; }

    /// <summary>
    /// description of the status response.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// length of the description bytes.
    /// </summary>
    internal int DescriptionLength { get; }
    }
