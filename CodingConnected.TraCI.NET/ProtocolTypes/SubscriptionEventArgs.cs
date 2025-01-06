namespace CodingConnected.TraCI.NET.ProtocolTypes;

public class SubscriptionEventArgs(string objectId, int variableCount) : EventArgs
    {
    public string ObjectId { get; } = objectId;

    /// <summary>
    /// The number of returned variables that were subscribed.
    /// </summary>
    public int VariableCount { get; } = variableCount;

    /// <summary>
    /// The responses must be cast to the right type in order to be used.
    /// </summary>
    public IEnumerable<TraciSubscriptionResponseUnit> Responses { get; set; }

    public int Length => Responses != null ? Responses.Count() : 0;
    }

/// <summary>
/// Please refer to  https://sumo.dlr.de/wiki/TraCI/Object_Variable_Subscription
/// </summary>
public class VariableSubscriptionEventArgs(string objectId, int variableCount) : SubscriptionEventArgs(objectId, variableCount) { }

/// <summary>
/// Please refer to  https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription
/// </summary>
public class ContextSubscriptionEventArgs(string objectId, byte contextDomain, int variableCount, int objectCount)
    : SubscriptionEventArgs(objectId, variableCount)
    {
    /// <summary>
    /// the type of objects in the addressed object's surrounding to ask values from. <para/>
    /// For more information please visit https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription
    /// </summary>
    public byte ContextDomain { get; } = contextDomain;

    /// <summary>
    /// The number of objects in range. (the objects are of type of the ContextDomain).
    /// </summary>
    public int ObjectCount { get; } = objectCount;
    }
