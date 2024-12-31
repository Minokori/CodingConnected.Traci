namespace CodingConnected.TraCI.NET.Response;

public interface IResponse
    {
    string ErrorMessage { get; set; }

    byte Identifier { get; set; }

    byte? ResponseIdentifier { get; set; }

    ResultCode Result { get; set; }

    /// <summary>
    /// The VariableType type
    /// </summary>
    byte? VariableType { get; set; }

    T GetContentAs<T>();
    }

/// <summary>
/// Represents a response to a subscription request. Contains Object VariableType Subscription and Object Context Subscription.<para/>
/// <list type="bullet">
/// <item>Object VariableType Subscription refers to https://sumo.dlr.de/wiki/TraCI/Object_Variable_Subscription</item>
/// <item>Object Context Subscription refers to https://sumo.dlr.de/docs/TraCI/Object_Context_Subscription.html</item>
/// </list>
/// </summary>
public interface ISubscriptionResponse
    {
    byte ResponseCode { get; init; }
    int VariableCount { get; init; }
    string ObjectId { get; init; }
    IEnumerable<object> Responses { get; }
    bool IsVariableSubscriptionResponse { get; }
    }
