using System.Text;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;
using static CodingConnected.TraCI.NET.Helpers.TraCIDataConverter;

namespace CodingConnected.TraCI.NET;

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






    #region IAnswerFromSUMO

    byte IAnswerFromSumo.Variable => Content[0];
    int IAnswerFromSumo.SumoIdLength =>
        BitConverter.ToInt32(Content.Skip(1).Take(4).Reverse().ToArray());

    string IAnswerFromSumo.SumoId =>
        Encoding.ASCII.GetString(
            Content.Skip(1 + 4).Take(((IAnswerFromSumo)this).SumoIdLength).ToArray()
        );
    byte IAnswerFromSumo.ReturnType =>
        Content.Skip(5 + ((IAnswerFromSumo)this).SumoIdLength).First();
    ITraCIType IAnswerFromSumo.Value
        {
        get
            {
            var (obj, bytes) = GetValueFromTypeAndArray(
                ((IAnswerFromSumo)this).ReturnType,
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


