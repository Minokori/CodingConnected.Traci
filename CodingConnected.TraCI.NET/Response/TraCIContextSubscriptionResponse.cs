using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Response;

public class TraCIContextSubscriptionResponse(string objectId, byte responseCode, byte contextDomain, int variableCount, int objectCount)
    : ISubscriptionResponse
    {
    public IEnumerable<object> Responses => VariableSubscriptionByObjectId.Values;

    internal Dictionary<string, TraCIVariableSubscriptionResponse> VariableSubscriptionByObjectId { get; init; } = [];

    /// <summary>
    /// the type of objects in the addressed object's surrounding to ask values from. <para/>
    /// For more information please visit https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription
    /// </summary>
    internal byte ContextDomain { get; } = contextDomain;

    /// <summary>
    /// The number of objects in range. (the objects are of type of the ContextDomain).
    /// </summary>
    internal int ObjectCount { get; } = objectCount;
    public byte ResponseCode { get; init; } = responseCode;
    public int VariableCount { get; init; } = variableCount;
    public string ObjectId { get; init; } = objectId;

    public bool IsVariableSubscriptionResponse => false;

    }

