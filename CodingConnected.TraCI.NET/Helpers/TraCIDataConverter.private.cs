using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
    private static TraCISubscriptionResponse ToSimStepResponse(this TraCIResult traciResult)
        {
        var commandType = traciResult.Identifier >> 4;


        switch (commandType)
            {
            case 0x0e:// 0xeX => VariableType Subscription Content
                    {
                    var (response, leftBytes) = VariableSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraCISubscriptionResponse)response;
                    }
            case 0x09:// 0x9X => Object Context Subscription Content
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
