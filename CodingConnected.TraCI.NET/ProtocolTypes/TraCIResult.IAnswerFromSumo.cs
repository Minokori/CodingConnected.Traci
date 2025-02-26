using System.Text;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.ProtocolTypes.TraCIResultExtension;

namespace CodingConnected.TraCI.NET.ProtocolTypes;

public partial class TraciResult : IAnswerFromSumo
    {
    byte IAnswerFromSumo.Variable => Content[0];
    int IAnswerFromSumo.SumoIdLength => BitConverter.ToInt32(Content.Skip(1).Take(4).Reverse().ToArray());

    string IAnswerFromSumo.SumoId =>
        Encoding.ASCII.GetString(
            [.. Content
                .Skip(
                    1 /* remainBytes of Variable */
                        + 4 /* remainBytes of SumoIdLength */
                )
                .Take(((IAnswerFromSumo)this).SumoIdLength)]
        );

    byte IAnswerFromSumo.ReturnType =>
        Content
            .Skip(
                1 /* remainBytes of Variable*/
                    + 4 /* remainBytes of SumoIdLength*/
                    + ((IAnswerFromSumo)this).SumoIdLength /* remainBytes of SumoId */
            )
            .First();

    ITraciType IAnswerFromSumo.Data
        {
        get
            {
            var (traciValue, remainBytes) = GetValueFromTypeAndArray(
                ((IAnswerFromSumo)this).ReturnType,
                Content.Skip(
                    1 /* remainBytes of Variable */
                        + 4 /* remainBytes of SumoIdLength */
                        + ((IAnswerFromSumo)this).SumoIdLength /* remainBytes of SumoId */
                        + 1 /* remainBytes of ReturnType */
                )
            );
            if (remainBytes.Any())
                {
                Console.WriteLine($"Not all bytes were consumed {remainBytes}");
                }
            return traciValue;
            }
        }
    }

/// <summary>
/// 显式实现的接口，用于将 <see cref="TraciResult"/> 解析为 Traci answer
/// </summary>
/// <remarks>
/// <see href="https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo"/>
/// </remarks>
public interface IAnswerFromSumo
    {
    internal int SumoIdLength { get; }

    /// <summary>
    /// Variable and SUMO ID repeat the values from the command.<para/>
    /// Used for checking if the response is for the correct command.
    /// </summary>
    byte Variable { get; }

    /// <summary>
    /// Variable and SUMO ID repeat the values from the command.<para/>
    /// Used for checking if the response is for the correct command.
    /// </summary>
    string SumoId { get; }

    /// <summary>
    /// traci data type of the value.Used to parse the data type,see <see cref="ITraciType.TYPE"/>.<para/>
    /// </summary>
    byte ReturnType { get; }

    /// <summary>
    /// value of the variable
    /// </summary>
    ITraciType Data { get; }
    }
