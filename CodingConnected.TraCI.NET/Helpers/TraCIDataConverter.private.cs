using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
    private static TraCISubscriptionResponse ToSimStepResponse(this TraCIResult traciResult)
        {
        // extract number of subscriptions
        var commandType = traciResult.Identifier >> 4;
        // 0xeX => VariableType Subscription Content
        // 0x9X => Object Context Subscription Content
        switch (commandType)
            {
            case 0x0e:
                    {
                    var (response, leftBytes) = VariableSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraCISubscriptionResponse)response;
                    }
            case 0x09:
                    {
                    var (response, leftBytes) = ContextSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraCISubscriptionResponse)response;
                    }
            default:
                throw new NotImplementedException();
            }
        }


    }
