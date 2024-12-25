using System.Collections.Generic;
using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET.Types
    {
    /// <summary>
    /// Please refer to  https://sumo.dlr.de/wiki/TraCI/Object_Variable_Subscription
    /// </summary>
    public class VariableSubscriptionEventArgs(
        string objectId,
        int variableCount,
        IReadOnlyDictionary<byte, IResponse> responseByVariableCode) : SubscriptionEventArgs(objectId, variableCount)
        {
        public IReadOnlyDictionary<byte, IResponse> ResponseByVariableCode { get; } = responseByVariableCode;
        }
    }
