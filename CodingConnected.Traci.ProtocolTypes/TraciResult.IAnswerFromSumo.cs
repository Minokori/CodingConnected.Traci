using System.Buffers.Binary;
using System.Diagnostics;
using System.Text;
using static CodingConnected.Traci.ProtocolTypes.TraciResultExtension;

namespace CodingConnected.Traci.ProtocolTypes;

public partial class TraciResult : IAnswerFromSumo
    {
    byte IAnswerFromSumo.Variable => Content[0];
    int IAnswerFromSumo.SumoIdLength => BinaryPrimitives.ReadInt32BigEndian(ContentSpan[1..5]);

    string IAnswerFromSumo.SumoId =>
        Encoding.ASCII.GetString(
            ContentSpan[
                (
                    1 /* remainBytes of Variable */
                    + 4 /* remainBytes of SumoIdLength */
                )..(1 + 4 + ((IAnswerFromSumo)this).SumoIdLength)
            ]
        );

    byte IAnswerFromSumo.ReturnType =>
        ContentSpan[
            1 /* remainBytes of Variable*/
                + 4 /* remainBytes of SumoIdLength*/
                + ((IAnswerFromSumo)this).SumoIdLength /* remainBytes of SumoId */
        ];

    ITraciType IAnswerFromSumo.Data
        {
        get
            {
            switch (((IAnswerFromSumo)this).Variable)
                {
                case TraciConstants.VAR_NEXT_STOPS2:
                    {
                    ReadOnlySpan<byte> span = ContentSpan[
                        (
                            1 /* remainBytes of Variable */
                            + 4 /* remainBytes of SumoIdLength */
                            + ((IAnswerFromSumo)this).SumoIdLength /* remainBytes of SumoId */
                            + 1 /* remainBytes of ReturnType: 0F */
                            + 4 /* an int*/
                            + 5
                        ) /*an int with type identifier*/
                        ..
                    ];
                    TraciCompoundObject result = [];
                    while (!span.IsEmpty)
                        {
                        var innerObject = GetValueFromTypeAndSpan(span[0], span[1..], out span);
                        result.Add(innerObject);
                        }
                    return result;
                    }
                default:
                    {
                    ReadOnlySpan<byte> span = Content;
                    var result = GetValueFromTypeAndSpan(
                        ((IAnswerFromSumo)this).ReturnType,
                        span[
                            (
                                1 /* remainBytes of Variable */
                                + 4 /* remainBytes of SumoIdLength */
                                + ((IAnswerFromSumo)this).SumoIdLength /* remainBytes of SumoId */
                                + 1
                            ) /* remainBytes of ReturnType */
                            ..
                        ],
                        out span
                    );
                    Debug.Assert(
                        span.IsEmpty,
                        $"[ERROR]: Not all bytes were consumed {span.ToArray()}"
                    );
                    return result;
                    }
                }
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
    /// traci data type of the value.Used to parse the data type,see <see cref="ITraciType.TypeIdentifier"/>.<para/>
    /// </summary>
    byte ReturnType { get; }

    /// <summary>
    /// value of the variable
    /// </summary>
    ITraciType Data { get; }
    }
