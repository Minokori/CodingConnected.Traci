using static CodingConnected.Traci.ProtocolTypes.TraciResultExtension;

namespace CodingConnected.Traci.ProtocolTypes;

public abstract class TraciSubscriptionResponse(TraciString objectId, TraciByte variableCount)
    {
    public byte Identifier { get; set; }
    public TraciString ObjectId { get; init; } = objectId;
    public virtual TraciByte VariableCount { get; init; } = variableCount;
    public IList<TraciSubscriptionResponseUnit> Responses { get; } = [];
    public abstract TraciSubscriptionResponseUnit this[int index] { get; }
    }

public sealed class TraciVariableSubscriptionResponse : TraciSubscriptionResponse, IFromTraci<TraciVariableSubscriptionResponse>
    {
    public static TraciVariableSubscriptionResponse FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var objectId = TraciString.FromSpan(sourceBytes, out sourceBytes);
        var variableCount = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        TraciVariableSubscriptionResponse result = new(objectId, variableCount);
        for (var i = 0; i < variableCount.Value; i++)
            {
            var response = TraciSubscriptionResponseUnit.FromSpan(sourceBytes, out sourceBytes);
            result.Responses.Add(response);
            }
        remainingBytes = sourceBytes;
        return result;
        }

    public override TraciSubscriptionResponseUnit this[int index] => Responses![index];

    private TraciVariableSubscriptionResponse(TraciString objectId, TraciByte variableCount)
        : base(objectId, variableCount) { }
    }

public sealed class TraciContextSubscriptionResponse : TraciSubscriptionResponse, IFromTraci<TraciContextSubscriptionResponse>
    {
    public TraciByte ContextDomain { get; }
    public TraciInteger ObjectCount { get; }
    public IList<TraciString> ObjectVariableIds { get; } = [];


    public static TraciContextSubscriptionResponse FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var objectId = TraciString.FromSpan(sourceBytes, out sourceBytes);
        var contextDomain = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var variableCount = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var objectCount = TraciInteger.FromSpan(sourceBytes, out sourceBytes);
        TraciContextSubscriptionResponse result = new(
            objectId,
            variableCount,
            contextDomain,
            objectCount
        );
        for (var m = 0; m < objectCount.Value; m++)
            {
            var objectVariableId = TraciString.FromSpan(sourceBytes, out sourceBytes);
            result.ObjectVariableIds.Add(objectVariableId);
            for (var n = 0; n < variableCount.Value; n++)
                {
                var response = TraciSubscriptionResponseUnit.FromSpan(sourceBytes, out sourceBytes);
                result.Responses.Add(response);
                }
            }
        remainingBytes = sourceBytes;
        return result;
        }

    public override TraciSubscriptionResponseUnit this[int index] => Responses[index];

    public TraciSubscriptionResponseUnit this[int objectIndex, int variableIndex] =>
        Responses[(objectIndex * VariableCount.Value) + variableIndex];

    private TraciContextSubscriptionResponse(
        TraciString objectId,
        TraciByte variableCount,
        TraciByte contextDomain,
        TraciInteger objectCount
    )
        : base(objectId, variableCount)
        {
        ContextDomain = contextDomain;
        ObjectCount = objectCount;
        }
    }

public sealed class TraciSubscriptionResponseUnit : IFromTraci<TraciSubscriptionResponseUnit>
    {
    public TraciByte VariableId { get; set; }
    public TraciByte VariableStatus { get; set; }
    public TraciByte VariableIdentifier { get; set; }
    public ITraciType Value { get; set; }
    public static TraciSubscriptionResponseUnit FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var id = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var status = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var identifier = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var value = GetValueFromTypeAndSpan(identifier.Value, sourceBytes, out remainingBytes);
        return new(id, status, identifier, value);
        }

    private TraciSubscriptionResponseUnit(
        TraciByte variableId,
        TraciByte variableStatus,
        TraciByte variableIdentifier,
        ITraciType value
    )
        {
        VariableId = variableId;
        VariableStatus = variableStatus;
        VariableIdentifier = variableIdentifier;
        Value = value;
        }
    }
