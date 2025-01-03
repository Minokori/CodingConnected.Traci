using System.Text;
using CodingConnected.TraCI.NET.Types;
using static CodingConnected.TraCI.NET.Helpers.TraCIDataConverter;

namespace CodingConnected.TraCI.NET;

public partial class TraCIResult
    {
    byte IAnswerFromSumo.Variable => Content[0];
    int IAnswerFromSumo.SumoIdLength =>
        BitConverter.ToInt32(Content.Skip(1).Take(4).Reverse().ToArray());

    string IAnswerFromSumo.SumoId =>
        Encoding.ASCII.GetString(
            Content.Skip(1 + 4).Take(((IAnswerFromSumo)this).SumoIdLength).ToArray()
        );
    byte IAnswerFromSumo.ReturnType =>
        Content.Skip(1 + 4 + ((IAnswerFromSumo)this).SumoIdLength).First();
    ITraCIType IAnswerFromSumo.Value
        {
        get
            {
            var (obj, bytes) = GetValueFromTypeAndArray(
                ((IAnswerFromSumo)this).ReturnType,
                Content.Skip(1 + 4 + ((IAnswerFromSumo)this).SumoIdLength + 1)
            );
            if (bytes.Any()) { Console.WriteLine($"Not all bytes were consumed {bytes}"); }

            return obj;
            }
        }
    }

/// <summary>
/// 显式实现的接口，用于将 <see cref="TraCIResult"/> 解析为 Traci answer
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

    /// <summary>
    /// traci data type of the value
    /// </summary>
    public byte ReturnType { get; }


    /// <summary>
    /// value of the variable
    /// </summary>
    public ITraCIType Value { get; }
    }
