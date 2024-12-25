using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Response;

public interface IResponse
    {
    string ErrorMessage { get; set; }

    byte Identifier { get; set; }

    byte? ResponseIdentifier { get; set; }

    ResultCode Result { get; set; }

    /// <summary>
    /// The Variable type
    /// </summary>
    byte? Variable { get; set; }

    T GetContentAs<T>();
    }

/// <summary>
/// Represents a response to a subscription request. Contains Object Variable Subscription and Object Context Subscription.<para/>
/// <list type="bullet">
/// <item>Object Variable Subscription refers to https://sumo.dlr.de/wiki/TraCI/Object_Variable_Subscription</item>
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
