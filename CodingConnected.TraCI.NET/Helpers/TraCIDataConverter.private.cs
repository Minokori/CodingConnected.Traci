using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;
using static System.BitConverter;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
    private static TraCISubscriptionResponse GetDataFromSimStepResponse(TraCIResult traciResult)
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
                    if (leftBytes.Any())
                        {
                        throw new Exception("GetDataFromSimStepResponse not all consumed");
                        }
                    return response;
                    }
            case 0x09:
                    {
                    var (response, leftBytes) = ContextSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    if (leftBytes.Any())
                        {
                        throw new Exception("GetDataFromSimStepResponse not all consumed");
                        }
                    return response;
                    }
            default:
                throw new NotImplementedException();
            }
        }

    private static byte[] GetMessagesBytes(IEnumerable<TraCICommand> commands)
        {
        List<List<byte>> cmessages = [];
        foreach (var c in commands)
            {
            List<byte> cmessage = [];
            if (c.Contents == null)
                {
                cmessage.Add(2); // no contents: only length self and id => 2
                }
            else if ((c.Contents.Length + 2) <= 255)
                {
                cmessage.Add((byte)(c.Contents.Length + 2));
                }
            else
                {
                cmessage.Add(0);
                cmessage.AddRange(GetBytes(c.Contents.Length + 6).Reverse());
                }
            cmessage.Add(c.Identifier);
            if (c.Contents != null)
                {
                cmessage.AddRange(c.Contents);
                }
            cmessages.Add(cmessage);
            }
        var totlength = cmessages.Select(x => x.Count).Sum() + 4;
        List<byte> totmessage = [.. GetBytes(totlength).Reverse()];
        cmessages.ForEach(x => totmessage.AddRange(x));
        return [.. totmessage];
        }
    }
