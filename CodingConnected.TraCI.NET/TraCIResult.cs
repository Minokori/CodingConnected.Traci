using System.Text;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;
using static CodingConnected.TraCI.NET.Helpers.TraCIDataConverter;

namespace CodingConnected.TraCI.NET;

/// <summary>
/// 从 TCP 传回来的基本数据结构
/// </summary>
public class TraCIResult : IStatusResponse, IAnswerFromSUMO
    {
    /// <summary>
    /// The length of the content
    /// </summary>
    public int ContentLength { get; set; }

    /// <summary>
    /// The identifier of the command
    /// </summary>
    public byte Identifier { get; set; }

    /// <summary>
    /// The response content(excludes length and identifier)
    /// </summary>
    public byte[] Content { get; set; }

    #region IStatusResponse
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
    #endregion





    #region IAnswerFromSUMO

    byte IAnswerFromSUMO.Variable => Content[0];
    int IAnswerFromSUMO.SumoIdLength =>
        BitConverter.ToInt32(Content.Skip(1).Take(4).Reverse().ToArray());

    string IAnswerFromSUMO.SumoId =>
        Encoding.ASCII.GetString(
            Content.Skip(1 + 4).Take(((IAnswerFromSUMO)this).SumoIdLength).ToArray()
        );
    byte IAnswerFromSUMO.ReturnType =>
        Content.Skip(5 + ((IAnswerFromSUMO)this).SumoIdLength).First();
    ITraCIType IAnswerFromSUMO.Value
        {
        get
            {
            var (obj, bytes) = GetValueFromTypeAndArray(
                ((IAnswerFromSUMO)this).ReturnType,
                Content.Skip(6)
            );
            return bytes.Any() ? throw new Exception("Not all bytes were consumed") : obj;
            }
        }
    #endregion
    }

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#status_response"/>
/// </summary>
public interface IStatusResponse
    {
    public ResultCode Result { get; }
    public int DescriptionLength { get; }
    public string Description { get; }
    }

/// <summary>
/// <see href="https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo"/>
/// </summary>
public interface IAnswerFromSUMO
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
