using System.Text;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET;

/// <summary>
/// 显式实现的接口，用于将 <see cref="TraCIResult"/> 解析为 Traci status response
/// </summary>
/// <remarks>
/// <see href="https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo"/>
/// </remarks>
public interface IAnswerFromSumo
    {

    internal int SumoIdLength { get; }

    /// <summary>
    /// Variable and SUMO ID repeat the values from the command.
    /// </summary>
    public byte Variable { get; }

    /// <summary>
    /// Variable and SUMO ID repeat the values from the command.
    /// </summary>
    public string SumoId { get; }
    public byte ReturnType { get; }

    public ITraCIType Value { get; }
    }


public partial class TraCIResult
    {
    /// <summary>
    /// result of the command
    /// </summary>
    ResultCode IStatusResponse.Result => (ResultCode)Content[0];

    /// <summary>
    /// length of the description
    /// </summary>
    int IStatusResponse.DescriptionLength => BitConverter.ToInt32(Content.Take(4).ToArray());

    /// <summary>
    /// description of the result
    /// </summary>
    string IStatusResponse.Description =>
        Encoding.ASCII.GetString(
            Content.Skip(1 + 4).Take(((IStatusResponse)this).DescriptionLength).ToArray()
        );
    }
