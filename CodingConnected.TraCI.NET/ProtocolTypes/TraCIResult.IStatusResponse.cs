using System.Text;
using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;
namespace CodingConnected.TraCI.NET.ProtocolTypes;

public partial class TraCIResult
    {
    ResultCode IStatusResponse.Result => (ResultCode)Content[0];
    int IStatusResponse.DescriptionLength => BitConverter.ToInt32(Content.Take(4).ToArray());

    string IStatusResponse.Description =>
        Encoding.ASCII.GetString(
            Content.Skip(1 + 4).Take(((IStatusResponse)this).DescriptionLength).ToArray()
        );
    }

/// <summary>
/// 显式实现的接口，用于将 <see cref="TraCIResult"/> 解析为 status response
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#status_response"/>
/// </remarks>
public interface IStatusResponse
    {
    /// <summary>
    /// result of the command. success or failure.
    /// </summary>
    public ResultCode Result { get; }

    /// <summary>
    /// description of the status response.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// length of the description bytes.
    /// </summary>
    internal int DescriptionLength { get; }
    }
