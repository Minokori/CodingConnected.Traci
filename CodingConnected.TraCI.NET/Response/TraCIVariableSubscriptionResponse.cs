using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Response;

/// <summary>
/// Please refer to  https://sumo.dlr.de/wiki/TraCI/Object_Variable_Subscription
/// </summary>
public class TraCIVariableSubscriptionResponse(string objectId, int variableCount, byte responseCode) : ISubscriptionResponse
    {
    #region properties from Traci directly
    public string ObjectId { get; init; } = objectId;
    public int VariableCount { get; init; } = variableCount;
    /// <summary>
    /// key is the variable code, value is the response info
    /// </summary>
    internal Dictionary<byte, IResponse> ResponseData { get; } = [];
    #endregion


    #region Meta Information
    /// <summary>
    /// the domain of response. see <see cref="Constants.TraCIConstants"/>
    /// </summary>
    public byte ResponseCode { get; init; } = responseCode;
    #endregion


    #region properties to get inner data

    public IEnumerable<object> Responses
        {
        get => ResponseData.Values;
        }

    public bool IsVariableSubscriptionResponse => true;


    //TODO: indexer
    public IResponse this[byte index]
        {
        get => ResponseData[index];
        }
    #endregion



    }

