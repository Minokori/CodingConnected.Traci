using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET.Types;

/// <summary>
/// Please refer to  https://sumo.dlr.de/wiki/TraCI/Object_Variable_Subscription
/// </summary>
public class VariableSubscriptionEventArgs(
    string objectId,
    int variableCount,
    List<TraciSubscriptionResponseUnit> responseByVariableCode) : SubscriptionEventArgs(objectId, variableCount)
    {
    public List<TraciSubscriptionResponseUnit> ResponseByVariableCode { get; set; } = responseByVariableCode;
    }

