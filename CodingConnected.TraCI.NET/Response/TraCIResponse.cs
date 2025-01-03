using CodingConnected.TraCI.NET.Types;
using static CodingConnected.TraCI.NET.Helpers.TraCIDataConverter;
namespace CodingConnected.TraCI.NET.Response;

public enum ResultCode : byte
    {
    Success = 0x00,
    Failed = 0xff,
    NotImplemented = 0x01
    }




public class TraCISubscriptionResponse
    {
    public TraCIString ObjectID { get; set; }
    public byte Identifier { get; set; }
    public virtual TraCIByte VariableCount { get; set; }
    public List<TraciSubscriptionResponseUnit> Responses { get; set; }
    /// <summary>
    /// TODO bytes 必须正好是一个完整的订阅响应，不能有多余的字节
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static Tuple<TraCISubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var id, bytes) = TraCIString.FromBytes(bytes);
        TraCISubscriptionResponse result = new()
            {
            ObjectID = id,
            };
        return new(result, bytes);
        }

    }

public class VariableSubscriptionResponse : TraCISubscriptionResponse
    {

    new public static Tuple<VariableSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (TraCIByte variableCount, bytes) = TraCIByte.FromBytes(bytes);
        (var result, bytes) = TraCISubscriptionResponse.FromBytes(bytes);
        result.VariableCount = variableCount;
        for (var i = 0; i < result.VariableCount.Value; i++)
            {
            (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
            (result as VariableSubscriptionResponse).Responses.Add(response);
            }
        return new((VariableSubscriptionResponse)result, bytes);
        }
    }



public class ContextSubscriptionResponse : TraCISubscriptionResponse
    {
    public TraCIByte ContextDomain { get; set; }
    public TraCIByte ObjectCount { get; set; }

    public List<TraCIString> ObjectIds { get; set; }
    new public static Tuple<ContextSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (TraCIByte contextDomain, bytes) = TraCIByte.FromBytes(bytes);
        (TraCIByte variableCount, bytes) = TraCIByte.FromBytes(bytes);
        (TraCIByte objectCount, bytes) = TraCIByte.FromBytes(bytes);
        (var result, bytes) = TraCISubscriptionResponse.FromBytes(bytes);
        ((ContextSubscriptionResponse)result).ContextDomain = contextDomain;
        result.VariableCount = variableCount;
        ((ContextSubscriptionResponse)result).ObjectCount = objectCount;

        for (var n = 0; n < (result as ContextSubscriptionResponse).ObjectCount.Value; n++)
            {
            (var objectId, bytes) = TraCIString.FromBytes(bytes);
            (result as ContextSubscriptionResponse).ObjectIds.Add(objectId);
            for (var m = 0; m < result.VariableCount.Value; m++)
                {
                (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
                (result as ContextSubscriptionResponse).Responses.Add(response);
                }
            }
        return new((ContextSubscriptionResponse)result, bytes);
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

