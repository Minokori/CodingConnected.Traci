using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {

    private static object GetDataFromSimStepResponse(TraCIResult r1)
        {
        List<object> returnList = [];
        int offset = 5;

        // extract number of subscriptions
        byte[] revSubCount = r1.Response.Skip(offset).Take(4).Reverse().ToArray();
        int subCount = BitConverter.ToInt32(revSubCount, 0);

        offset = 9;
        // extract the result of the subscriptions
        byte subResult = r1.Response[offset++];

        // if subscription result is success
        if (subResult == 0)
            {
            for (int i = 0; i < subCount; i++)
                {
                // extract the length of the subscription
                byte[] revSubLen = r1.Response.Skip(offset).Take(4).Reverse().ToArray();
                int len = BitConverter.ToInt32(revSubLen, 0);
                offset += 4;

                // Subscription
                byte subResponseCode = r1.Response[offset++];

                int low = subResponseCode & 0x0F;
                int high = subResponseCode >> 4;

                // 0xeX => Variable Subscription Response
                // 0x9X => Object Context Subscription Response
                if (high == 0x0e)
                    {
                    // extract the object id
                    offset = GetString(r1.Response, offset, out TraCIString objectId);

                    // extract the number of variables
                    byte countVariables = r1.Response[offset++];

                    offset = CreateVariableSubscriptionResponse(
                        objectId,
                        r1,
                        subResponseCode,
                        countVariables,
                        offset,
                        out TraCIVariableSubscriptionResponse subResponse
                    );

                    offset++;
                    returnList.Add(subResponse);
                    }
                else if (high == 0x09)
                    {
                    // extract the object id of the EGO object
                    offset = GetString(r1.Response, offset, out TraCIString objectId);

                    // extract the context domain the subscription happened under
                    byte contextDomain = r1.Response[offset++];

                    // extract the number of variables that was returned for each object
                    byte countVariables = r1.Response[offset++];

                    // extract the number of objects that are inside the context range
                    offset = GetInteger(r1.Response, offset, out TraCIInteger countObject);
                    int objectCount = countObject.Value;

                    TraCIContextSubscriptionResponse subContextResponse = new(
                        objectId.Value,
                        subResponseCode,
                        contextDomain,
                        countVariables,
                        objectCount
                    );

                    for (int objectNum = 0; objectNum < objectCount; objectNum++)
                        {
                        offset = GetString(r1.Response, offset, out TraCIString curObjectId);

                        offset = CreateVariableSubscriptionResponse(
                            curObjectId,
                            r1,
                            subResponseCode,
                            countVariables,
                            offset,
                            out TraCIVariableSubscriptionResponse curSubResponse
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

    private static int CreateVariableSubscriptionResponse(
        TraCIString objectId,
        TraCIResult r1,
        byte subResponseCode,
        byte countVariables,
        int offset,
        out TraCIVariableSubscriptionResponse variableSubscriptionResponce
    )
        {
        variableSubscriptionResponce = new TraCIVariableSubscriptionResponse(
            objectId.Value,
            countVariables,
            subResponseCode
        );

        for (int varNum = 0; varNum < countVariables; varNum++)
            {
            // extract variable identifier, status and datatype of the response
            byte variable = r1.Response[offset++];
            byte result = r1.Response[offset++];
            byte datatype = r1.Response[offset++];

            // extract value by datatype
            offset += GetValueFromTypeAndArray(
                datatype,
                r1.Response.Skip(offset),
                out object contentAsObject
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
                                Variable = variable,
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
    private static int GetTrafficLightPhaseList(
    IEnumerable<byte> array,
    int offset,
    out TrafficLightPhaseList trafficLightPhaseList
)
        {
        trafficLightPhaseList = new TrafficLightPhaseList();

        offset = GetByte(array, offset, out TraCIByte count);

        for (int i = 0; i < count.Value; i++)
            {
            offset = GetString(array, offset, out TraCIString precRoad);
            offset = GetString(array, offset, out TraCIString succRoad);
            offset = GetByte(array, offset, out TraCIByte phase);

            trafficLightPhaseList.Phases.Add(
                new TrafficLightPhase()
                    {
                    PrecRoad = precRoad.Value,
                    SuccRoad = succRoad.Value,
                    Phase = (PhaseState)phase.Value,
                    }
            );
            }
        return offset;
        }

    private static int GetColor(IEnumerable<byte> array, int offset, out Color color)
        {
        color = new Color
            {
            R = array.Skip(offset++).First(),
            G = array.Skip(offset++).First(),
            B = array.Skip(offset++).First(),
            A = array.Skip(offset++).First(),
            };

        return offset;
        }

    private static int GetBoundaryBox(
        IEnumerable<byte> array,
        int offset,
        out BoundaryBox boundaryBox
    )
        {
        BoundaryBox bb = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        bb.LowerLeftX = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        bb.LowerLeftY = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        bb.UpperRightX = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        bb.UpperRightY = BitConverter.ToDouble(take, 0);
        boundaryBox = bb;
        return offset;
        }

    private static int GetPositionRoadmap(
        IEnumerable<byte> array,
        int offset,
        out RoadMapPosition roadMapPosition
    )
        {
        RoadMapPosition rmp = new();
        StringBuilder sb = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
        offset += TraCIConstants.INTEGER_SIZE;
        int length = BitConverter.ToInt32(take, 0);
        for (int j = 0; j < length; ++j)
            {
            sb.Append((char)array.Skip(j + TraCIConstants.INTEGER_SIZE).First());
            ++offset;
            }
        rmp.RoadId = sb.ToString();
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        rmp.Pos = BitConverter.ToDouble(take, 0);
        rmp.LaneId = array.Skip(offset).First();
        roadMapPosition = rmp;
        return offset;
        }

    private static int GetPostion3D(
        IEnumerable<byte> array,
        int offset,
        out Position3D position3D
    )
        {
        Position3D pos3d = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        pos3d.X = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        pos3d.Y = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        pos3d.Z = BitConverter.ToDouble(take, 0);
        position3D = pos3d;
        return offset;
        }

    private static int GetPositionLonLatAlt(
        IEnumerable<byte> array,
        int offset,
        out LonLatAltPosition lonLatAltPosition
    )
        {
        LonLatAltPosition lonlatalt = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        lonlatalt.Longitude = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        lonlatalt.Latitude = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        lonlatalt.Altitude = BitConverter.ToDouble(take, 0);
        lonLatAltPosition = lonlatalt;
        return offset;
        }

    private static int Get2DPosition(
        IEnumerable<byte> array,
        int offset,
        out Position2D position2D
    )
        {
        Position2D pos2d = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        pos2d.X = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        pos2d.Y = BitConverter.ToDouble(take, 0);
        position2D = pos2d;

        return offset;
        }

    private static int GetPositionLonLat(
        IEnumerable<byte> array,
        int offset,
        out LonLatPosition lonLatPosition
    )
        {
        byte[] take;
        LonLatPosition lonlat = new();
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        lonlat.Longitude = BitConverter.ToDouble(take, 0);
        take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        offset += TraCIConstants.DOUBLE_SIZE;
        lonlat.Latitude = BitConverter.ToDouble(take, 0);
        lonLatPosition = lonlat;
        return offset;
        }

    private static int GetStringList(
        IEnumerable<byte> array,
        int offset,
        out TraCIStringList StringList
    )
        {
        StringList = new TraCIStringList();

        StringBuilder sb = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
        int count = BitConverter.ToInt32(take, 0);
        List<string> list = [];
        offset += TraCIConstants.INTEGER_SIZE;
        for (int i1 = 0; i1 < count; ++i1)
            {
            sb.Clear();
            take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
            offset += TraCIConstants.INTEGER_SIZE;
            int length = BitConverter.ToInt32(take, 0);
            for (int j = 0; j < length; ++j)
                {
                sb.Append((char)array.Skip(offset).First());
                ++offset;
                }
            list.Add(sb.ToString());
            }
        StringList.Value = list;
        return offset;
        }

    private static int GetString(IEnumerable<byte> array, int offset, out TraCIString String)
        {
        String = new TraCIString();
        StringBuilder sb = new();
        byte[] take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
        int length = BitConverter.ToInt32(take, 0);
        offset += TraCIConstants.INTEGER_SIZE;
        for (int i = 0; i < length; ++i)
            {
            sb.Append((char)array.Skip(offset).First());
            offset++;
            }
        String.Value = sb.ToString();

        return offset;
        }

    private static int GetDouble(IEnumerable<byte> array, int offset, out TraCIDouble Double)
        {
        Double = new TraCIDouble();
        byte[] take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
        Double.Value = BitConverter.ToDouble(take, 0);
        return offset + TraCIConstants.DOUBLE_SIZE;
        }

    private static int GetFloat(IEnumerable<byte> array, int offset, out TraCIFloat Float)
        {
        Float = new TraCIFloat();
        byte[] take = array.Skip(offset).Take(TraCIConstants.FLOAT_SIZE).Reverse().ToArray();
        Float.Value = BitConverter.ToSingle(take, 0);
        return offset + TraCIConstants.FLOAT_SIZE;
        }

    private static int GetInteger(IEnumerable<byte> array, int offset, out TraCIInteger integer)
        {
        integer = new TraCIInteger();
        byte[] take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
        integer.Value = BitConverter.ToInt32(take, 0);
        return offset + TraCIConstants.INTEGER_SIZE;
        }

    private static int GetByte(IEnumerable<byte> array, int offset, out TraCIByte Byte)
        {
        Byte = new TraCIByte { Value = array.Skip(offset).First() };
        return offset + TraCIConstants.BYTE_SIZE;
        }

    private static int GetUByte(IEnumerable<byte> array, int offset, out TraCIUByte Byte)
        {
        Byte = new TraCIUByte { Value = array.Skip(offset).First() };
        return offset + TraCIConstants.UBYTE_SIZE;
        }

    private static int GetPolygon(IEnumerable<byte> array, int offset, out Polygon pol)
        {
        byte[] take;
        byte length = array.Skip(offset).First();
        int skip = offset + 1; // first byte is length of data

        pol = new Polygon();

        for (int j = 1; j <= length; j++)
            {
            Position2D p = new();
            take = array.Skip(skip).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            skip += TraCIConstants.DOUBLE_SIZE;
            p.X = BitConverter.ToDouble(take, 0);
            take = array.Skip(skip).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            skip += TraCIConstants.DOUBLE_SIZE;
            p.Y = BitConverter.ToDouble(take, 0);
            pol.Points.Add(p);
            }
        return skip;
        }
    private static byte[] GetMessagesBytes(IEnumerable<TraCICommand> commands)
        {
        List<List<byte>> cmessages = [];
        foreach (TraCICommand c in commands)
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
                cmessage.AddRange(BitConverter.GetBytes(c.Contents.Length + 6).Reverse());
                }
            cmessage.Add(c.Identifier);
            if (c.Contents != null)
                {
                cmessage.AddRange(c.Contents);
                }
            cmessages.Add(cmessage);
            }
        int totlength = cmessages.Select(x => x.Count).Sum() + 4;
        List<byte> totmessage = [.. BitConverter.GetBytes(totlength).Reverse()];
        cmessages.ForEach(x => totmessage.AddRange(x));
        //totmessage.AddRange(BitConverter.GetBytes('\n'));
        return [.. totmessage];
        }
    }

