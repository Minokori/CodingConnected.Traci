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

public sealed class TraciVariableSubscriptionResponse : TraciSubscriptionResponse, ITraciParserable<TraciVariableSubscriptionResponse>
    {
    public static TraciVariableSubscriptionResponse Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var objectId = TraciString.Parse(source, out source);
        var variableCount = TraciByte.Parse(source, out source);
        TraciVariableSubscriptionResponse result = new(objectId, variableCount);
        for (var i = 0; i < variableCount.Value; i++)
            {
            var response = TraciSubscriptionResponseUnit.Parse(source, out source);
            result.Responses.Add(response);
            }
        remaining = source;
        return result;
        }

    public override TraciSubscriptionResponseUnit this[int index] => Responses![index];

    private TraciVariableSubscriptionResponse(TraciString objectId, TraciByte variableCount)
        : base(objectId, variableCount) { }
    }

public sealed class TraciContextSubscriptionResponse : TraciSubscriptionResponse, ITraciParserable<TraciContextSubscriptionResponse>
    {
    public TraciByte ContextDomain { get; }
    public TraciInteger ObjectCount { get; }
    public IList<TraciString> ObjectVariableIds { get; } = [];


    public static TraciContextSubscriptionResponse Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var objectId = TraciString.Parse(source, out source);
        var contextDomain = TraciByte.Parse(source, out source);
        var variableCount = TraciByte.Parse(source, out source);
        var objectCount = TraciInteger.Parse(source, out source);
        TraciContextSubscriptionResponse result = new(
            objectId,
            variableCount,
            contextDomain,
            objectCount
        );
        for (var m = 0; m < objectCount.Value; m++)
            {
            var objectVariableId = TraciString.Parse(source, out source);
            result.ObjectVariableIds.Add(objectVariableId);
            for (var n = 0; n < variableCount.Value; n++)
                {
                var response = TraciSubscriptionResponseUnit.Parse(source, out source);
                result.Responses.Add(response);
                }
            }
        remaining = source;
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

public sealed class TraciSubscriptionResponseUnit : ITraciParserable<TraciSubscriptionResponseUnit>
    {
    public TraciByte VariableId { get; set; }
    public TraciByte VariableStatus { get; set; }
    public TraciByte VariableIdentifier { get; set; }
    public ITraciType Value { get; set; }
    public static TraciSubscriptionResponseUnit Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var id = TraciByte.Parse(source, out source);
        var status = TraciByte.Parse(source, out source);
        var identifier = TraciByte.Parse(source, out source);
        var value = GetValueFromTypeAndSpan(identifier.Value, source, out remaining);
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
