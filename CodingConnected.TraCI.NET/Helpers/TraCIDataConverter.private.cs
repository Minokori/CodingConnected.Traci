using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;
using static System.BitConverter;
namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
    private static object GetDataFromSimStepResponse(TraCIResult r1)
        {
        List<object> returnList = [];
        var offset = 5;

        // extract number of subscriptions
        var revSubCount = r1.Content.Skip(offset).Take(4).Reverse().ToArray();
        var subCount = ToInt32(revSubCount);

        offset = 9;
        // extract the result of the subscriptions
        var subResult = r1.Content[offset++];


        // if subscription result is success
        if (subResult == 0)
            {
            for (var i = 0; i < subCount; i++)
                {
                // extract the length of the subscription
                var revSubLen = r1.Content.Skip(offset).Take(4).Reverse().ToArray();
                _ = ToInt32(revSubLen, 0);
                offset += 4;

                // Subscription
                var subResponseCode = r1.Content[offset++];

                var low = subResponseCode & 0x0F;
                var high = subResponseCode >> 4;

                // 0xeX => VariableType Subscription Content
                // 0x9X => Object Context Subscription Content
                if (high == 0x0e)
                    {
                    // extract the object id
                    offset = GetString(r1.Content, offset, out var objectId);

                    // extract the number of variables
                    var countVariables = r1.Content[offset++];

                    offset = CreateVariableSubscriptionResponse(
                        objectId,
                        r1,
                        subResponseCode,
                        countVariables,
                        offset,
                        out var subResponse
                    );

                    offset++;
                    returnList.Add(subResponse);
                    }
                else if (high == 0x09)
                    {
                    // extract the object id of the EGO object
                    offset = GetString(r1.Content, offset, out var objectId);

                    // extract the context domain the subscription happened under
                    var contextDomain = r1.Content[offset++];

                    // extract the number of variables that was returned for each object
                    var countVariables = r1.Content[offset++];

                    // extract the number of objects that are inside the context range
                    offset = GetInteger(r1.Content, offset, out var countObject);
                    var objectCount = countObject.Value;

                    TraCIContextSubscriptionResponse subContextResponse = new(
                        objectId.Value,
                        subResponseCode,
                        contextDomain,
                        countVariables,
                        objectCount
                    );

                    for (var objectNum = 0; objectNum < objectCount; objectNum++)
                        {
                        offset = GetString(r1.Content, offset, out var curObjectId);

                        offset = CreateVariableSubscriptionResponse(
                            curObjectId,
                            r1,
                            subResponseCode,
                            countVariables,
                            offset,
                            out var curSubResponse
                        );

                        subContextResponse.VariableSubscriptionByObjectId.Add(
                            curObjectId.Value,
                            curSubResponse
                        );
                        }
                    offset++;
                    returnList.Add(subContextResponse);
                    }
                }

            return returnList;
            }
        else
            {
            throw new NotImplementedException();
            }
        }

    private static int CreateVariableSubscriptionResponse(TraCIString objectId, TraCIResult r1, byte subResponseCode, byte countVariables, int offset, out TraCIVariableSubscriptionResponse variableSubscriptionResponce)
        {
        variableSubscriptionResponce = new TraCIVariableSubscriptionResponse(
            objectId.Value,
            countVariables,
            subResponseCode
        );

        for (var varNum = 0; varNum < countVariables; varNum++)
            {
            // extract variable identifier, status and datatype of the response
            var variable = r1.Content[offset++];
            var result = r1.Content[offset++];
            var datatype = r1.Content[offset++];

            // extract value by datatype
            offset += GetValueFromTypeAndArray(
                datatype,
                r1.Content.Skip(offset),
                out var contentAsObject
            );

            switch (datatype)
                {
                case TraCIConstants.POSITION_LON_LAT:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<LonLatPosition>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (LonLatPosition)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.POSITION_2D:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<Position2D>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (Position2D)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.POSITION_LON_LAT_ALT:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<LonLatAltPosition>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (LonLatAltPosition)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.POSITION_3D:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<Position3D>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (Position3D)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.POSITION_ROADMAP:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<RoadMapPosition>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (RoadMapPosition)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_BOUNDINGBOX:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<BoundaryBox>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (BoundaryBox)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_POLYGON:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<Polygon>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (Polygon)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_UBYTE:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<byte>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (byte)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_BYTE:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<byte>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (byte)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_INTEGER:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<int>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (int)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_FLOAT:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<float>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (float)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_DOUBLE:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<double>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (double)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_STRING:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<string>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (string)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_STRINGLIST:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<List<string>>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (List<string>)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_COLOR:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<Color>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (Color)contentAsObject,
                                }
                        );
                        break;
                        }
                case TraCIConstants.TYPE_TLPHASELIST:
                        {
                        throw new NotImplementedException(
                            "There is no handler for Traffic Light Phase List (ubyte identifier: 0x0D). Unclear definition of this datatyp. See http://sumo.dlr.de/wiki/TraCI/Protocol#Data_types"
                        );
                        }
                case TraCIConstants.TYPE_COMPOUND:
                        {
                        variableSubscriptionResponce.ResponseData.Add(
                            variable,
                            new TraCIResponse<TraCIObjects>
                                {
                                Identifier = subResponseCode,
                                VariableType = variable,
                                Result = (ResultCode)result,
                                Content = (TraCIObjects)contentAsObject,
                                }
                        );
                        break;
                        }
                default:
                        {
                        throw new ArgumentOutOfRangeException();
                        }
                }
            }

        return offset;
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
        //totmessage.AddRange(BitConverter.GetBytes('\n'));
        return [.. totmessage];
        }
    }
