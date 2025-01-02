using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET.Types;

/// <summary>
/// Please refer to  https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription
/// </summary>
public class ContextSubscriptionEventArgs(
    string objectId,
   List<TraciSubscriptionResponseUnit> variableSubscriptionResponseByObjectId,
    byte contextDomain,
    int variableCount,
    int objectCount) : SubscriptionEventArgs(objectId, variableCount)
    {
    /// <summary>
    /// Get the variable subscription of the object by the id of the object.
    /// The object was inside the context range of the object this subscription happened under.
    /// </summary>
    public List<TraciSubscriptionResponseUnit> ResponseUnits { get; set; } = variableSubscriptionResponseByObjectId;

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

