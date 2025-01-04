using CodingConnected.TraCI.NET.Types;
using static CodingConnected.TraCI.NET.Helpers.TraCIDataConverter;
namespace CodingConnected.TraCI.NET.Response;


/// <summary>
/// The status code of a TraCI command.
/// </summary>
public enum ResultCode : byte
    {
    /// <summary>
    /// success
    /// </summary>
    Success = 0x00,
    /// <summary>
    /// failed
    /// </summary>
    Failed = 0xff,
    /// <summary>
    /// command not implemented
    /// </summary>
    NotImplemented = 0x01
    }




public class TraCISubscriptionResponse
    {
    public byte Identifier { get; set; }
    public TraCIString ObjectId { get; set; }

    public virtual TraCIByte VariableCount { get; set; }
    public List<TraciSubscriptionResponseUnit> Responses { get; set; }
    /// <summary>
    /// TODO bytes 必须正好是一个完整的订阅响应，不能有多余的字节
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static Tuple<TraCISubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        throw new NotImplementedException();
        }

    }

public class VariableSubscriptionResponse : TraCISubscriptionResponse
    {

    public static new Tuple<VariableSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var objectId, bytes) = TraCIString.FromBytes(bytes);
        (var variableCount, bytes) = TraCIByte.FromBytes(bytes);
        VariableSubscriptionResponse result = new()
            {
            ObjectId = objectId,
            VariableCount = variableCount,
            Responses = []
            };
        for (var i = 0; i < result.VariableCount.Value; i++)
            {
            (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
            result.Responses.Add(response);
            }
        return new(result, bytes);
        }
    }



public class ContextSubscriptionResponse : TraCISubscriptionResponse
    {
    public TraCIByte ContextDomain { get; set; }
    public TraCIInteger ObjectCount { get; set; }

    public List<TraCIString> ObjectVariableIds { get; set; }
    public static new Tuple<ContextSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {

        (var objectId, bytes) = TraCIString.FromBytes(bytes);
        (var contextDomain, bytes) = TraCIByte.FromBytes(bytes);
        (var variableCount, bytes) = TraCIByte.FromBytes(bytes);
        (var objectCount, bytes) = TraCIInteger.FromBytes(bytes);

        ContextSubscriptionResponse result = new()
            {
            ObjectId = objectId,
            ContextDomain = contextDomain,
            VariableCount = variableCount,
            ObjectCount = objectCount,
            ObjectVariableIds = [],
            Responses = []
            };
        for (var m = 0; m < result.ObjectCount.Value; m++)
            {
            (var objectVariableId, bytes) = TraCIString.FromBytes(bytes);
            result.ObjectVariableIds.Add(objectVariableId);
            for (var n = 0; n < result.VariableCount.Value; n++)
                {
                (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
                result.Responses.Add(response);
                }
            }
        return new(result, bytes);
        }
    }





public class TraciSubscriptionResponseUnit
    {
    public TraCIByte VariableId { get; set; }
    public TraCIByte VariableStatus { get; set; }

    public TraCIByte VariableIdentifier { get; set; }

    public ITraCIType Value { get; set; }

    public static Tuple<TraciSubscriptionResponseUnit, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var Id, bytes) = TraCIByte.FromBytes(bytes);
        (var Status, bytes) = TraCIByte.FromBytes(bytes);
        (var Identifier, bytes) = TraCIByte.FromBytes(bytes);
        (var Value, bytes) = GetValueFromTypeAndArray(Identifier.Value, bytes);

        TraciSubscriptionResponseUnit result = new()
            {
            VariableId = Id,
            VariableStatus = Status,
            VariableIdentifier = Identifier,
            Value = Value
            };

        return new(result, bytes);
        }
    }

