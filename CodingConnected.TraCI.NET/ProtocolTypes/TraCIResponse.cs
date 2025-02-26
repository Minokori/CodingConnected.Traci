using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.ProtocolTypes.TraCIResultExtension;

namespace CodingConnected.TraCI.NET.ProtocolTypes;
public abstract class TraCISubscriptionResponse(TraciString objectId, TraciByte variableCount)
    {
    public byte Identifier { get; set; }
    public TraciString ObjectId { get; init; } = objectId;
    public virtual TraciByte VariableCount { get; init; } = variableCount;
    public List<TraciSubscriptionResponseUnit> Responses { get; } = [];

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
        TraCIVariableSubscriptionResponse result = new(objectId, variableCount);
        for (var i = 0; i < variableCount; i++)
            {
            (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
            result.Responses.Add(response);
            }
        return new(result, bytes);
        }

    public override TraciSubscriptionResponseUnit this[int index] => Responses![index];

    private TraCIVariableSubscriptionResponse(TraciString objectId, TraciByte variableCount) : base(objectId, variableCount)
        {
        }

    }

public class TraCIContextSubscriptionResponse : TraCISubscriptionResponse
    {
    public TraciByte ContextDomain { get; }
    public TraciInteger ObjectCount { get; }
    public List<TraciString> ObjectVariableIds { get; } = [];

    public static new Tuple<TraCIContextSubscriptionResponse, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var objectId, bytes) = TraciString.FromBytes(bytes);
        (var contextDomain, bytes) = TraciByte.FromBytes(bytes);
        (var variableCount, bytes) = TraciByte.FromBytes(bytes);
        (var objectCount, bytes) = TraciInteger.FromBytes(bytes);

        TraCIContextSubscriptionResponse result = new(objectId, variableCount, contextDomain, objectCount);
        for (var m = 0; m < objectCount; m++)
            {
            (var objectVariableId, bytes) = TraciString.FromBytes(bytes);
            result.ObjectVariableIds.Add(objectVariableId);
            for (var n = 0; n < variableCount; n++)
                {
                (var response, bytes) = TraciSubscriptionResponseUnit.FromBytes(bytes);
                result.Responses.Add(response);
                }
            }
        return new(result, bytes);
        }

    public override TraciSubscriptionResponseUnit this[int index] => index >= Responses.Count ? throw new IndexOutOfRangeException($"given index: {index}, but this object only has {Responses.Count} items.") : Responses[index];

    public TraciSubscriptionResponseUnit this[int objectIndex, int variableIndex] =>
        (objectIndex, variableIndex) switch
            {
                _ when objectIndex >= ObjectCount || variableIndex >= VariableCount => throw new IndexOutOfRangeException(),
                _ => Responses[(objectIndex * VariableCount.Value) + variableIndex],
                };


    private TraCIContextSubscriptionResponse(TraciString objectId, TraciByte variableCount, TraciByte contextDomain, TraciInteger objectCount) : base(objectId, variableCount)
        {
        ContextDomain = contextDomain;
        ObjectCount = objectCount;
        }
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

        TraciSubscriptionResponseUnit result = new(Id, Status, Identifier, Value);
        return new(result, bytes);
        }


    private TraciSubscriptionResponseUnit(TraciByte variableId, TraciByte variableStatus, TraciByte variableIdentifier, ITraciType value)
        {
        VariableId = variableId;
        VariableStatus = variableStatus;
        VariableIdentifier = variableIdentifier;
        Value = value;
        }
    }
