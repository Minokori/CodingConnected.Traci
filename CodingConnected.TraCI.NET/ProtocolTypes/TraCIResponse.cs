using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.ProtocolTypes.TraCIResultExtension;

namespace CodingConnected.TraCI.NET.ProtocolTypes;
public abstract class TraCISubscriptionResponse
    {
    public byte Identifier { get; set; }
    public TraciString ObjectId { get; set; }

    public virtual TraciByte VariableCount { get; set; }
    public List<TraciSubscriptionResponseUnit> Responses { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static Tuple<TraCISubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes) => throw new NotImplementedException();

    public abstract TraciSubscriptionResponseUnit this[int index] { get; }
    }

public class TraCIVariableSubscriptionResponse : TraCISubscriptionResponse
    {
    public static new Tuple<TraCIVariableSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var objectId, bytes) = TraciString.FromBytes(bytes);
        (var variableCount, bytes) = TraciByte.FromBytes(bytes);
        TraCIVariableSubscriptionResponse result = new()
            {
            ObjectId = objectId,
            VariableCount = variableCount,
            Responses = [],
            };
        for (var i = 0; i < result.VariableCount.Value; i++)
            {
            (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
            result.Responses.Add(response);
            }
        return new(result, bytes);
        }

    public override TraciSubscriptionResponseUnit this[int index] => Responses[index];
    }

public class TraCIContextSubscriptionResponse : TraCISubscriptionResponse
    {
    public TraciByte ContextDomain { get; set; }
    public TraciInteger ObjectCount { get; set; }
    public List<TraciString> ObjectVariableIds { get; set; }

    public static new Tuple<TraCIContextSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var objectId, bytes) = TraciString.FromBytes(bytes);
        (var contextDomain, bytes) = TraciByte.FromBytes(bytes);
        (var variableCount, bytes) = TraciByte.FromBytes(bytes);
        (var objectCount, bytes) = TraciInteger.FromBytes(bytes);

        TraCIContextSubscriptionResponse result = new()
            {
            ObjectId = objectId,
            ContextDomain = contextDomain,
            VariableCount = variableCount,
            ObjectCount = objectCount,
            ObjectVariableIds = [],
            Responses = [],
            };
        for (var m = 0; m < result.ObjectCount.Value; m++)
            {
            (var objectVariableId, bytes) = TraciString.FromBytes(bytes);
            result.ObjectVariableIds.Add(objectVariableId);
            for (var n = 0; n < result.VariableCount.Value; n++)
                {
                (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
                result.Responses.Add(response);
                }
            }
        return new(result, bytes);
        }

    public override TraciSubscriptionResponseUnit this[int index] => index >= Responses.Count ? null : Responses[index];

    public TraciSubscriptionResponseUnit this[int objectIndex, int variableIndex] =>
        (objectIndex, variableIndex) switch
            {
                _ when objectIndex >= ObjectCount.Value || variableIndex >= VariableCount.Value => null,
                _ => Responses[(objectIndex * VariableCount.Value) + variableIndex],
                };
    }

public class TraciSubscriptionResponseUnit
    {
    public TraciByte VariableId { get; set; }
    public TraciByte VariableStatus { get; set; }
    public TraciByte VariableIdentifier { get; set; }

    public ITraciType Value { get; set; }

    public static Tuple<TraciSubscriptionResponseUnit, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var Id, bytes) = TraciByte.FromBytes(bytes);
        (var Status, bytes) = TraciByte.FromBytes(bytes);
        (var Identifier, bytes) = TraciByte.FromBytes(bytes);
        (var Value, bytes) = GetValueFromTypeAndArray(Identifier.Value, bytes);

        TraciSubscriptionResponseUnit result = new()
            {
            VariableId = Id,
            VariableStatus = Status,
            VariableIdentifier = Identifier,
            Value = Value,
            };
        return new(result, bytes);
        }
    }
