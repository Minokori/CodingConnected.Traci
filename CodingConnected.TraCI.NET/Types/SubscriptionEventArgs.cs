namespace CodingConnected.TraCI.NET.Types;

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
    public IEnumerable<object> Responses { get; set; }

    public int Length
        {
        get
            {
            return Responses != null ? Responses.Count() : 0;
            }
        }
    }

