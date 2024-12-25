using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Helpers
    {
    internal static class TraCIDataConverter
        {
        #region Static Methods
        internal static TraCIResponse<T> ExtractDataFromResponse<T>(
            TraCIResult[] response,
            byte commandType,
            byte messageType = 0
        )
            {
            if (response?.Length > 0)
                {
                TraCIResult r1 = response.FirstOrDefault(x => x.Identifier == commandType);
                if (r1?.Response[0] == 0x00) // Success
                    {
                    if (r1.Identifier == TraCIConstants.CMD_SIMSTEP)
                        {
                        if (r1.Length != 5)
                            {
                            object tmp = GetDataFromSimStepResponse(r1);

                            return new TraCIResponse<T>
                                {
                                Identifier = r1.Identifier,
                                ResponseIdentifier = null,
                                Variable = null,
                                Result = ResultCode.Success,
                                Content = (T)tmp,
                                };
                            }
                        }
                    // check if first byte is as requested (it gives the type of data requested)
                    TraCIResult r2 = response.FirstOrDefault(x =>
                        x.Identifier == commandType + 0x10
                    );
                    if (r2?.Response[0] == messageType)
                        {
                        // after the type of data, there is the length of the id (a string that we will skip)
                        byte[] take = r2.Response.Skip(1).Take(4).Reverse().ToArray();
                        int idl = BitConverter.ToInt32(take, 0);
                        // after the string is the type of data returned
                        byte type = r2.Response[5 + idl];
                        // now read and translate the data
                        GetValueFromTypeAndArray(
                            type,
                            r2.Response.Skip(6 + idl).ToArray(),
                            out object contentAsObject
                        );

                        return new TraCIResponse<T>
                            {
                            Identifier = r1.Identifier,
                            ResponseIdentifier = r2.Identifier,
                            Variable = r2.Response[0],
                            Result = ResultCode.Success,
                            Content = (T)contentAsObject,
                            };
                        }
                    else
                        {
                        // for state changing methods without response content
                        return new TraCIResponse<T>
                            {
                            Identifier = r1.Identifier,
                            ResponseIdentifier = null,
                            Variable = null,
                            Result = ResultCode.Success,
                            Content = default,
                            };
                        }
                    }

                if (r1?.Response[0] == 0xFF) // Failed
                    {
                    byte[] take = r1.Response.Skip(1).Take(4).Reverse().ToArray();
                    int dlen = BitConverter.ToInt32(take, 0);
                    StringBuilder sb = new();
                    int k1 = 5;
                    for (int j = 0; j < dlen; ++j)
                        {
                        sb.Append((char)r1.Response[k1]);
                        ++k1;
                        }

                    return new TraCIResponse<T>
                        {
                        Identifier = r1.Identifier,
                        ResponseIdentifier = null,
                        Variable = null,
                        Result = ResultCode.Failed,
                        Content = default,
                        ErrorMessage = "TraCI reports command failure: " + sb,
                        };
                    }

                if (r1?.Response[0] == 0x01) // Not implemented
                    {
                    byte[] take = r1.Response.Skip(1).Take(4).Reverse().ToArray();
                    int dlen = BitConverter.ToInt32(take, 0);
                    StringBuilder sb = new();
                    int k1 = 5;
                    for (int j = 0; j < dlen; ++j)
                        {
                        sb.Append((char)r1.Response[k1]);
                        ++k1;
                        }

                    return new TraCIResponse<T>
                        {
                        Identifier = r1.Identifier,
                        ResponseIdentifier = null,
                        Variable = null,
                        Result = ResultCode.NotImplemented,
                        Content = default,
                        ErrorMessage = "TraCI reports command not implemented: " + sb,
                        };
                    }
                }
            return null;
            }

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
                                new TraCIResponse<CompoundObject>
                                    {
                                    Identifier = subResponseCode,
                                    Variable = variable,
                                    Result = (ResultCode)result,
                                    Content = (CompoundObject)contentAsObject,
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

        internal static List<EdgeInformation> ConvertToListOfEdgeInformation(CompoundObject content)
            {
            List<EdgeInformation> ret = new();

            int numberOfEdges = (content.Value[0] as TraCIInteger).Value;

            for (int i = 0; i < numberOfEdges; i++)
                {
                EdgeInformation edge = new()
                    {
                    LaneId = (content.Value[(6 * i) + 1] as TraCIString).Value,
                    Length = (content.Value[(6 * i) + 2] as TraCIDouble).Value,
                    Occupation = (content.Value[(6 * i) + 3] as TraCIDouble).Value,
                    OffsetToBestLane = (content.Value[(6 * i) + 4] as TraCIByte).Value,
                    laneInformation = (content.Value[(6 * i) + 5] as TraCIUByte).Value,
                    BestSubsequentLanes = (content.Value[(6 * i) + 6] as TraCIStringList).Value,
                    };
                ret.Add(edge);
                }

            return ret;
            }

        internal static List<TrafficLightSystem> ConvertToListOfTrafficLightSystem(
            CompoundObject content
        )
            {
            List<TrafficLightSystem> ret = new();

            int numberOfTLS = (content.Value[0] as TraCIInteger).Value;

            for (int i = 0; i < numberOfTLS; i++)
                {
                TrafficLightSystem tls = new()
                    {
                    TrafficLightSystemId = (content.Value[(4 * i) + 1] as TraCIString).Value,
                    TrafficLightSystemLinkIndex = (
                        content.Value[(4 * i) + 2] as TraCIInteger
                    ).Value,
                    DistanceToTrafficLightSystem = (
                        content.Value[(4 * i) + 3] as TraCIDouble
                    ).Value,
                    LinkState = (content.Value[(4 * i) + 4] as TraCIByte).Value,
                    };

                ret.Add(tls);
                }

            return ret;
            }

        internal static TrafficCompleteLightProgram ConvertToTrafficLightCompleteProgramm(
            CompoundObject content
        )
            {
            TrafficCompleteLightProgram ret = new()
                {
                NumberOfLogics = (content.Value[0] as TraCIInteger).Value,
                };

            int offset = 1; //offset for number of logics
            // for 1 logic  = 5 + (4 * number of phases)

            for (int i = 0; i < ret.NumberOfLogics; i++)
                {
                TrafficLightLogics tmp = new()
                    {
                    SubId = (content.Value[offset + 0] as TraCIString).Value,
                    Type = (content.Value[offset + 1] as TraCIInteger).Value,
                    SubParameter = (content.Value[offset + 2] as CompoundObject),
                    CurrentPhaseIndex = (content.Value[offset + 3] as TraCIInteger).Value,
                    NumberOfPhases = (content.Value[offset + 4] as TraCIInteger).Value,
                    };

                for (int j = 0; j < tmp.NumberOfPhases; j++)
                    {
                    TrafficLightProgramPhase phase = new()
                        {
                        Duration = (content.Value[offset + 5 + (4 * j)] as TraCIInteger).Value, //4*j for the current phase
                        MinDuration = (content.Value[offset + 6 + (4 * j)] as TraCIInteger).Value,
                        MaxDuration = (content.Value[offset + 7 + (4 * j)] as TraCIInteger).Value,
                        Definition = (content.Value[offset + 8 + (4 * j)] as TraCIString).Value,
                        };
                    tmp.TrafficLightPhases.Add(phase);
                    }

                ret.TrafficLightLogics.Add(tmp);
                offset += (5 + (4 * tmp.NumberOfPhases));
                }

            return ret;
            }

        internal static ControlledLinks ConvertToControlledLinks(List<ComposedTypeBase> content)
            {
            ControlledLinks ret = new() { NumberOfSignals = (content[0] as TraCIInteger).Value };

            for (int i = 2; i < content.Count; i += 2)
                {
                ret.Links.Add((content[i] as TraCIStringList).Value);
                }

            return ret;
            }

        internal static byte[] GetTraCIBytesFromTrafficLightPhaseList(TrafficLightPhaseList tlpl)
            {
            List<byte> bytes = new();

            bytes.AddRange(GetTraCIBytesFromUByte((byte)tlpl.Phases.Count));

            foreach (TrafficLightPhase phase in tlpl.Phases)
                {
                bytes.AddRange(GetTraCIBytesFromASCIIString(phase.PrecRoad));
                bytes.AddRange(GetTraCIBytesFromASCIIString(phase.SuccRoad));
                bytes.AddRange(GetTraCIBytesFromUByte((byte)phase.Phase));
                }

            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromBoundaryBox(BoundaryBox bb)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromDouble(bb.LowerLeftX));
            bytes.AddRange(GetTraCIBytesFromDouble(bb.LowerLeftY));
            bytes.AddRange(GetTraCIBytesFromDouble(bb.UpperRightX));
            bytes.AddRange(GetTraCIBytesFromDouble(bb.UpperRightY));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromPolygon(Polygon p)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromUByte((byte)p.Points.Count));
            foreach (Position2D point in p.Points)
                {
                bytes.AddRange(GetTraCIBytesFromDouble(point.X));
                bytes.AddRange(GetTraCIBytesFromDouble(point.Y));
                }

            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromLonLatAltPosition(LonLatAltPosition llap)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromDouble(llap.Longitude));
            bytes.AddRange(GetTraCIBytesFromDouble(llap.Latitude));
            bytes.AddRange(GetTraCIBytesFromDouble(llap.Altitude));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromLonLatPosition(LonLatPosition llp)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromDouble(llp.Longitude));
            bytes.AddRange(GetTraCIBytesFromDouble(llp.Latitude));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromRoadMapPosition(RoadMapPosition rmp)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromASCIIString(rmp.RoadId));
            bytes.AddRange(GetTraCIBytesFromDouble(rmp.Pos));
            bytes.AddRange(GetTraCIBytesFromUByte(rmp.LaneId));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromPosition3D(Position3D p3d)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromDouble(p3d.X));
            bytes.AddRange(GetTraCIBytesFromDouble(p3d.Y));
            bytes.AddRange(GetTraCIBytesFromDouble(p3d.Z));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromPosition2D(Position2D p2d)
            {
            List<byte> bytes = new();
            bytes.AddRange(GetTraCIBytesFromDouble(p2d.X));
            bytes.AddRange(GetTraCIBytesFromDouble(p2d.Y));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromFloat(float f)
            {
            return BitConverter.GetBytes(f).Reverse().ToArray();
            }

        internal static byte[] GetTraCIBytesFromUByte(byte ub)
            {
            return BitConverter.GetBytes((short)ub).Reverse().ToArray();
            }

        internal static byte[] GetTraCIBytesFromByte(byte b)
            {
            return BitConverter.GetBytes((short)b).Reverse().ToArray();
            }

        internal static byte[] GetTraCIBytesFromInt32(int i)
            {
            return BitConverter.GetBytes(i).Reverse().ToArray();
            }

        internal static byte[] GetTraCIBytesFromDouble(double d)
            {
            return BitConverter.GetBytes(d).Reverse().ToArray();
            }

        internal static byte[] GetTraCIBytesFromASCIIString(string s)
            {
            List<byte> bytes = new();
            bytes.AddRange(BitConverter.GetBytes(s.Length).Reverse());
            bytes.AddRange(Encoding.ASCII.GetBytes(s));
            return bytes.ToArray();
            }

        internal static byte[] GetTraCIBytesFromASCIIStringList(List<string> los)
            {
            List<byte> bytes = new();
            bytes.AddRange(BitConverter.GetBytes(los.Count).Reverse());
            foreach (string str in los)
                {
                bytes.AddRange(GetTraCIBytesFromASCIIString(str));
                }

            return bytes.ToArray();
            }

        internal static int GetValueFromTypeAndArray(
            byte type,
            IEnumerable<byte> array,
            out object Object
        )
            {
            switch (type)
                {
                case TraCIConstants.POSITION_LON_LAT:
                        {
                        int newOffset = GetPositionLonLat(array, 0, out LonLatPosition lonLatPosition);
                        Object = lonLatPosition;
                        return newOffset;
                        }
                case TraCIConstants.POSITION_2D:
                        {
                        int newOffset = Get2DPosition(array, 0, out Position2D position2D);
                        Object = position2D;
                        return newOffset;
                        }
                case TraCIConstants.POSITION_LON_LAT_ALT:
                        {
                        int newOffset = GetPositionLonLatAlt(
                            array,
                            0,
                            out LonLatAltPosition lonLatAltPosition
                        );
                        Object = lonLatAltPosition;
                        return newOffset;
                        }
                case TraCIConstants.POSITION_3D:
                        {
                        int newOffset = GetPostion3D(array, 0, out Position3D position3D);
                        Object = position3D;
                        return newOffset;
                        }
                case TraCIConstants.POSITION_ROADMAP:
                        {
                        int newOffset = GetPositionRoadmap(
                            array,
                            0,
                            out RoadMapPosition roadMapPosition
                        );
                        Object = roadMapPosition;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_BOUNDINGBOX:
                        {
                        int newOffset = GetBoundaryBox(array, 0, out BoundaryBox boundaryBox);
                        Object = boundaryBox;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_POLYGON:
                        {
                        int newOffset = GetPolygon(array, 0, out Polygon polygon);
                        Object = polygon;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_UBYTE:
                        {
                        int newOffset = GetUByte(array, 0, out TraCIUByte UByte);
                        Object = UByte.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_BYTE:
                        {
                        int newOffset = GetByte(array, 0, out TraCIByte sByte);
                        Object = sByte.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_INTEGER:
                        {
                        int newOffset = GetInteger(array, 0, out TraCIInteger integer);
                        Object = integer.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_FLOAT:
                        {
                        int newOffset = GetFloat(array, 0, out TraCIFloat Float);
                        Object = Float.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_DOUBLE:
                        {
                        int newOffset = GetDouble(array, 0, out TraCIDouble Double);
                        Object = Double.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_STRING:
                        {
                        int newOffset = GetString(array, 0, out TraCIString String);
                        Object = String.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_STRINGLIST:
                        {
                        int newOffset = GetStringList(array, 0, out TraCIStringList StringList);
                        Object = StringList.Value;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_COLOR:
                        {
                        int newOffset = GetColor(array, 0, out Color color);
                        Object = color;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_TLPHASELIST:
                        {
                        int newOffset = GetTrafficLightPhaseList(
                            array,
                            0,
                            out TrafficLightPhaseList trafficLightPhaseList
                        );
                        Object = trafficLightPhaseList;
                        return newOffset;
                        }
                case TraCIConstants.TYPE_COMPOUND:
                        {
                        byte[] take = array.Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
                        int count = BitConverter.ToInt32(take, 0);
                        List<ComposedTypeBase> ctlist = new();
                        int offset = TraCIConstants.INTEGER_SIZE;
                        if (count > 0)
                            {
                            for (int i = 0; i <= count; ++i)
                                {
                                byte ctype = array.Skip(offset).First();
                                ++offset;
                                switch (ctype)
                                    {
                                    case TraCIConstants.POSITION_LON_LAT:
                                            {
                                            offset = GetPositionLonLat(
                                                array,
                                                offset,
                                                out LonLatPosition lonLatPosition
                                            );
                                            ctlist.Add(lonLatPosition);
                                            break;
                                            }
                                    case TraCIConstants.POSITION_2D:
                                            {
                                            offset = Get2DPosition(
                                                array,
                                                offset,
                                                out Position2D position2D
                                            );
                                            ctlist.Add(position2D);
                                            break;
                                            }
                                    case TraCIConstants.POSITION_LON_LAT_ALT:
                                            {
                                            offset = GetPositionLonLatAlt(
                                                array,
                                                offset,
                                                out LonLatAltPosition lonLatAltPosition
                                            );
                                            ctlist.Add(lonLatAltPosition);
                                            break;
                                            }
                                    case TraCIConstants.POSITION_3D:
                                            {
                                            offset = GetPostion3D(array, offset, out Position3D position3D);
                                            ctlist.Add(position3D);
                                            break;
                                            }
                                    case TraCIConstants.POSITION_ROADMAP:
                                            {
                                            offset = GetPositionRoadmap(
                                                array,
                                                offset,
                                                out RoadMapPosition roadMapPosition
                                            );
                                            ctlist.Add(roadMapPosition);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_BOUNDINGBOX:
                                            {
                                            offset = GetBoundaryBox(
                                                array,
                                                offset,
                                                out BoundaryBox boundaryBox
                                            );
                                            ctlist.Add(boundaryBox);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_POLYGON:
                                            {
                                            offset = GetPolygon(array, offset, out Polygon polygon);
                                            ctlist.Add(polygon);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_UBYTE:
                                            {
                                            offset = GetUByte(array, offset, out TraCIUByte UByte);
                                            ctlist.Add(UByte);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_BYTE:
                                            {
                                            offset = GetByte(array, offset, out TraCIByte Byte);
                                            ctlist.Add(Byte);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_INTEGER:
                                            {
                                            offset = GetInteger(array, offset, out TraCIInteger integer);
                                            ctlist.Add(integer);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_FLOAT:
                                            {
                                            offset = GetFloat(array, offset, out TraCIFloat Float);
                                            ctlist.Add(Float);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_DOUBLE:
                                            {
                                            offset = GetDouble(array, offset, out TraCIDouble Double);
                                            ctlist.Add(Double);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_STRING:
                                            {
                                            offset = GetString(array, offset, out TraCIString String);
                                            ctlist.Add(String);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_TLPHASELIST:
                                            {
                                            int newOffset = GetTrafficLightPhaseList(
                                                array,
                                                offset,
                                                out TrafficLightPhaseList trafficLightPhaseList
                                            );
                                            Object = trafficLightPhaseList;
                                            return newOffset;
                                            }
                                    case TraCIConstants.TYPE_COLOR:
                                            {
                                            offset = GetColor(array, offset, out Color color);
                                            ctlist.Add(color);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_STRINGLIST:
                                            {
                                            offset = GetStringList(
                                                array,
                                                offset,
                                                out TraCIStringList StringList
                                            );
                                            ctlist.Add(StringList);
                                            break;
                                            }
                                    case TraCIConstants.TYPE_COMPOUND:
                                            {
                                            offset += GetValueFromTypeAndArray(
                                                TraCIConstants.TYPE_COMPOUND,
                                                array.Skip(offset).ToArray(),
                                                out object InnerObject
                                            );
                                            CompoundObject tmp = InnerObject as CompoundObject;
                                            ctlist.Add(tmp);
                                            i += 1 + tmp.Value.Count; //nested compounds are not nice!
                                            break;
                                            }
                                    }
                                }
                            }
                        CompoundObject compoundObject = new() { Value = ctlist };
                        Object = compoundObject;
                        return offset;
                        }
                default:
                        {
                        throw new ArgumentOutOfRangeException();
                        }
                }
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
            List<string> list = new();
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

        internal static byte[] GetMessageBytes(TraCICommand command)
            {
            return GetMessagesBytes(new[] { command });
            }

        internal static byte[] GetMessagesBytes(IEnumerable<TraCICommand> commands)
            {
            List<List<byte>> cmessages = new();
            foreach (TraCICommand c in commands)
                {
                List<byte> cmessage = new();
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
            List<byte> totmessage = new();
            totmessage.AddRange(BitConverter.GetBytes(totlength).Reverse());
            cmessages.ForEach(x => totmessage.AddRange(x));
            //totmessage.AddRange(BitConverter.GetBytes('\n'));
            return totmessage.ToArray();
            }

        internal static TraCIResult[] HandleResponse(byte[] response)
            {
            try
                {
                byte[] revLength = response.Take(4).Reverse().ToArray();
                int totlength = BitConverter.ToInt32(revLength, 0);
                int i = 4;
                List<TraCIResult> results = [];
                while (i < totlength)
                    {
                    TraCIResult trresult = new();
                    int j = 0;
                    int len = response[i + j++];
                    trresult.Length = len - 2; // bytes lenght will be: msg - length - id
                    if (len == 0)
                        {
                        if (j + i + 3 < totlength)
                            {
                            revLength = new byte[4];
                            revLength[0] = response[i + j + 3];
                            revLength[1] = response[i + j + 2];
                            revLength[2] = response[i + j + 1];
                            revLength[3] = response[i + j + 0];
                            len = BitConverter.ToInt32(revLength, 0);
                            trresult.Length = len - 6; // bytes lenght will be: msg - length - int32len - id
                            j += 4;
                            }
                        else
                            {
                            break;
                            }
                        }
                    trresult.Identifier = response[i + j++];

                    if (
                        trresult.Identifier == TraCIConstants.CMD_SIMSTEP
                        && totlength == response.Length
                        && len + 8 != response.Length
                    )
                        {
                        byte[] revSubCount = response.Skip(i + len).Take(4).Reverse().ToArray();
                        int subCount = BitConverter.ToInt32(revSubCount, 0);
                        len += 5;
                        for (int n = 0; n < subCount; n++)
                            {
                            int offset = i + len;
                            byte[] revSubResponseLength = response
                                .Skip(offset)
                                .Take(4)
                                .Reverse()
                                .ToArray();
                            offset += 4;
                            int subResponseLength = BitConverter.ToInt32(revSubResponseLength, 0);
                            len += subResponseLength;

                            // For some reason when the subscription is context subscription
                            // we need one extra byte in the len than simply adding SubResponseLength
                            byte identifier = response.Skip(offset).First();
                            int identifierHighPart = identifier >> 4;
                            if (identifierHighPart == 0x09)
                                len++;
                            }
                        trresult.Length = --len;
                        }

                    List<byte> cmd = [];
                    while (j < len)
                        {
                        cmd.Add(response[i + j++]);
                        }
                    trresult.Response = [.. cmd];
                    i += j;
                    results.Add(trresult);
                    }
                return [.. results];
                }
            catch (IndexOutOfRangeException)
                {
                return null;
                }
            }

        #endregion // Static Methods
        }
    }
