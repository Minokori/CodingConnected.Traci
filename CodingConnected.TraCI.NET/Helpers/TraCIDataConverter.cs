using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
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

    internal static byte[] ToTraCIBytes(this object value)
        {
        if (value is null) { return []; }
        switch (value)
            {
            case float:
                return BitConverter.GetBytes((float)value).Reverse().ToArray();
            // TODO byte 是不是直接返回Value？short对不对
            case byte:
                return BitConverter.GetBytes((short)value).Reverse().ToArray();
            case int:
                return BitConverter.GetBytes((int)value).Reverse().ToArray();
            case double:
                return BitConverter.GetBytes((double)value).Reverse().ToArray();
            case string:
                return [.. BitConverter.GetBytes(((string)value).Length).Reverse(), .. Encoding.ASCII.GetBytes((string)value)];
            case List<string>:
                List<string> los = (List<string>)value;
                List<byte> bytes = [.. BitConverter.GetBytes(los.Count).Reverse()];
                foreach (string str in los)
                    {
                    bytes.AddRange(str.ToTraCIBytes());
                    }
                return [.. bytes];
            default:
                return [];
            }
        }


    internal static int GetValueFromTypeAndArray(byte type, IEnumerable<byte> array, out object Object)
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
                    List<ITraCIType> ctlist = [];
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
                                        TraCIObjects tmp = InnerObject as TraCIObjects;
                                        ctlist.Add(tmp);
                                        i += 1 + tmp.Count; //nested compounds are not nice!
                                        break;
                                        }
                                }
                            }
                        }
                    // TODO 初始化
                    TraCIObjects compoundObject = (TraCIObjects)ctlist;
                    Object = compoundObject;
                    return offset;
                    }
            default:
                    {
                    throw new ArgumentOutOfRangeException();
                    }
            }
        }


    internal static byte[] ToMessageBytes(this TraCICommand command)
        {
        return GetMessagesBytes([command]);
        }
    internal static TraCIResult[] ToTraCIResults(this List<byte> response)
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
                    && totlength == response.Count
                    && len + 8 != response.Count
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

    }

