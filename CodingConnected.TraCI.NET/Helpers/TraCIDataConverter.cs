using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;
using static System.BitConverter;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
    internal static TraCIResponse<T> ExtractDataFromResponse<T>(TraCIResult[] response, byte commandType, byte messageType = 0
    )
        {
        // check if response is null
        if (response == null) { return null; }

        // find response of specific command type, statusResponse is status response ,r2 is result
        var statusResponse = (TraCIStatusResponse)response.FirstOrDefault(x => x.Identifier == commandType);

        if (statusResponse is null) { return null; }

        switch (statusResponse.Result)
            {
            case ResultCode.Success:
                    {


                    if (statusResponse.Identifier == TraCIConstants.CMD_SIMSTEP)
                        {
                        if (statusResponse.Length != 5)
                            {
                            var tmp = GetDataFromSimStepResponse(statusResponse);

                            return new TraCIResponse<T>
                                {
                                Identifier = statusResponse.Identifier,
                                ResponseIdentifier = null,
                                Variable = null,
                                Result = ResultCode.Success,
                                Content = (T)tmp,
                                };
                            }
                        }


                    // check if first byte is as requested (it gives the type of data requested)
                    var r2 = response.FirstOrDefault(x => x.Identifier == commandType + 0x10 /*response's identifier is GET command's identifire +0x10*/);
                    if (r2?.Response[0] == messageType)
                        {
                        // after the type of data, there is the length of the id (a string that we will skip)
                        var take = r2.Response.Skip(1).Take(4).Reverse().ToArray();
                        var idl = ToInt32(take, 0);
                        // after the string is the type of data returned
                        var type = r2.Response[5 + idl];
                        // now read and translate the data
                        GetValueFromTypeAndArray(
                            type,
                            r2.Response.Skip(6 + idl).ToArray(),
                            out var contentAsObject
                        );

                        return new TraCIResponse<T>
                            {
                            Identifier = statusResponse.Identifier,
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
                            Identifier = statusResponse.Identifier,
                            ResponseIdentifier = null,
                            Variable = null,
                            Result = ResultCode.Success,
                            Content = default,
                            };
                        }
                    }
            case ResultCode.Failed:
            case ResultCode.NotImplemented:
                    {
                    return new TraCIResponse<T>
                        {
                        Identifier = statusResponse.Identifier,
                        ResponseIdentifier = null,
                        Variable = null,
                        Result = statusResponse.Result,
                        Content = default,
                        ErrorMessage = $"TraCI reports command {Enum.GetName(statusResponse.Result)}: {statusResponse.Description}",
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
                var los = (List<string>)value;
                List<byte> bytes = [.. BitConverter.GetBytes(los.Count).Reverse()];
                foreach (var str in los)
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
                    var newOffset = GetPositionLonLat(array, 0, out var lonLatPosition);
                    Object = lonLatPosition;
                    return newOffset;
                    }
            case TraCIConstants.POSITION_2D:
                    {
                    var newOffset = Get2DPosition(array, 0, out var position2D);
                    Object = position2D;
                    return newOffset;
                    }
            case TraCIConstants.POSITION_LON_LAT_ALT:
                    {
                    var newOffset = GetPositionLonLatAlt(
                        array,
                        0,
                        out var lonLatAltPosition
                    );
                    Object = lonLatAltPosition;
                    return newOffset;
                    }
            case TraCIConstants.POSITION_3D:
                    {
                    var newOffset = GetPostion3D(array, 0, out var position3D);
                    Object = position3D;
                    return newOffset;
                    }
            case TraCIConstants.POSITION_ROADMAP:
                    {
                    var newOffset = GetPositionRoadmap(
                        array,
                        0,
                        out var roadMapPosition
                    );
                    Object = roadMapPosition;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_BOUNDINGBOX:
                    {
                    var newOffset = GetBoundaryBox(array, 0, out var boundaryBox);
                    Object = boundaryBox;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_POLYGON:
                    {
                    var newOffset = GetPolygon(array, 0, out var polygon);
                    Object = polygon;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_UBYTE:
                    {
                    var newOffset = GetUByte(array, 0, out var UByte);
                    Object = UByte.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_BYTE:
                    {
                    var newOffset = GetByte(array, 0, out var sByte);
                    Object = sByte.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_INTEGER:
                    {
                    var newOffset = GetInteger(array, 0, out var integer);
                    Object = integer.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_FLOAT:
                    {
                    var newOffset = GetFloat(array, 0, out var Float);
                    Object = Float.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_DOUBLE:
                    {
                    var newOffset = GetDouble(array, 0, out var Double);
                    Object = Double.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_STRING:
                    {
                    var newOffset = GetString(array, 0, out var String);
                    Object = String.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_STRINGLIST:
                    {
                    var newOffset = GetStringList(array, 0, out var StringList);
                    Object = StringList.Value;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_COLOR:
                    {
                    var newOffset = GetColor(array, 0, out var color);
                    Object = color;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_TLPHASELIST:
                    {
                    var newOffset = GetTrafficLightPhaseList(
                        array,
                        0,
                        out var trafficLightPhaseList
                    );
                    Object = trafficLightPhaseList;
                    return newOffset;
                    }
            case TraCIConstants.TYPE_COMPOUND:
                    {
                    var take = array.Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
                    var count = BitConverter.ToInt32(take, 0);
                    List<ITraCIType> ctlist = [];
                    int offset = TraCIConstants.INTEGER_SIZE;
                    if (count > 0)
                        {
                        for (var i = 0; i <= count; ++i)
                            {
                            var ctype = array.Skip(offset).First();
                            ++offset;
                            switch (ctype)
                                {
                                case TraCIConstants.POSITION_LON_LAT:
                                        {
                                        offset = GetPositionLonLat(
                                            array,
                                            offset,
                                            out var lonLatPosition
                                        );
                                        ctlist.Add(lonLatPosition);
                                        break;
                                        }
                                case TraCIConstants.POSITION_2D:
                                        {
                                        offset = Get2DPosition(
                                            array,
                                            offset,
                                            out var position2D
                                        );
                                        ctlist.Add(position2D);
                                        break;
                                        }
                                case TraCIConstants.POSITION_LON_LAT_ALT:
                                        {
                                        offset = GetPositionLonLatAlt(
                                            array,
                                            offset,
                                            out var lonLatAltPosition
                                        );
                                        ctlist.Add(lonLatAltPosition);
                                        break;
                                        }
                                case TraCIConstants.POSITION_3D:
                                        {
                                        offset = GetPostion3D(array, offset, out var position3D);
                                        ctlist.Add(position3D);
                                        break;
                                        }
                                case TraCIConstants.POSITION_ROADMAP:
                                        {
                                        offset = GetPositionRoadmap(
                                            array,
                                            offset,
                                            out var roadMapPosition
                                        );
                                        ctlist.Add(roadMapPosition);
                                        break;
                                        }
                                case TraCIConstants.TYPE_BOUNDINGBOX:
                                        {
                                        offset = GetBoundaryBox(
                                            array,
                                            offset,
                                            out var boundaryBox
                                        );
                                        ctlist.Add(boundaryBox);
                                        break;
                                        }
                                case TraCIConstants.TYPE_POLYGON:
                                        {
                                        offset = GetPolygon(array, offset, out var polygon);
                                        ctlist.Add(polygon);
                                        break;
                                        }
                                case TraCIConstants.TYPE_UBYTE:
                                        {
                                        offset = GetUByte(array, offset, out var UByte);
                                        ctlist.Add(UByte);
                                        break;
                                        }
                                case TraCIConstants.TYPE_BYTE:
                                        {
                                        offset = GetByte(array, offset, out var Byte);
                                        ctlist.Add(Byte);
                                        break;
                                        }
                                case TraCIConstants.TYPE_INTEGER:
                                        {
                                        offset = GetInteger(array, offset, out var integer);
                                        ctlist.Add(integer);
                                        break;
                                        }
                                case TraCIConstants.TYPE_FLOAT:
                                        {
                                        offset = GetFloat(array, offset, out var Float);
                                        ctlist.Add(Float);
                                        break;
                                        }
                                case TraCIConstants.TYPE_DOUBLE:
                                        {
                                        offset = GetDouble(array, offset, out var Double);
                                        ctlist.Add(Double);
                                        break;
                                        }
                                case TraCIConstants.TYPE_STRING:
                                        {
                                        offset = GetString(array, offset, out var String);
                                        ctlist.Add(String);
                                        break;
                                        }
                                case TraCIConstants.TYPE_TLPHASELIST:
                                        {
                                        var newOffset = GetTrafficLightPhaseList(
                                            array,
                                            offset,
                                            out var trafficLightPhaseList
                                        );
                                        Object = trafficLightPhaseList;
                                        return newOffset;
                                        }
                                case TraCIConstants.TYPE_COLOR:
                                        {
                                        offset = GetColor(array, offset, out var color);
                                        ctlist.Add(color);
                                        break;
                                        }
                                case TraCIConstants.TYPE_STRINGLIST:
                                        {
                                        offset = GetStringList(
                                            array,
                                            offset,
                                            out var StringList
                                        );
                                        ctlist.Add(StringList);
                                        break;
                                        }
                                case TraCIConstants.TYPE_COMPOUND:
                                        {
                                        offset += GetValueFromTypeAndArray(
                                            TraCIConstants.TYPE_COMPOUND,
                                            array.Skip(offset).ToArray(),
                                            out var InnerObject
                                        );
                                        var tmp = InnerObject as TraCIObjects;
                                        ctlist.Add(tmp);
                                        i += 1 + tmp.Count; //nested compounds are not nice!
                                        break;
                                        }
                                }
                            }
                        }
                    // TODO 初始化
                    var compoundObject = (TraCIObjects)ctlist;
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

    /// <summary>
    /// 把TCP 返回的值转换成TraCIResult
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#messages"/>
    /// </remarks>
    internal static TraCIResult[] ToTraCIResults(this List<byte> response)
        {
        try
            {
            List<TraCIResult> results = [];

            //<summary>数据总长度（多少byte）</summary>
            var totalLength = ToInt32(response.Take(4).Reverse().ToArray(), 0);

            //已经解析过的byte指针，contentStartIndex = 4 说明从 response[4] 开始还没被读取解析
            var contentStartIndex = 4;

            while (contentStartIndex < totalLength)
                {
                TraCIResult traciResult = new();
                var contentPointer = 0;// 在一条result中，contentPointer 为已经解析的byte指针


                // 解析一条 result的 内容长度
                int singleResultLength = response[contentStartIndex];
                if (singleResultLength != 0)
                    {
                    traciResult.Length = singleResultLength - 2; // content length = messageTotalLength - Length(1byte) - identifier(1byte)
                    contentPointer++; //move Pointer
                    }
                // 若消息长度为0,说明result过长，一个byte不够用
                else
                    {
                    if (contentStartIndex + 6 /*1byte(0),  4byte(messagelength), 1byte(identifier)*/ < totalLength)
                        {
                        singleResultLength = ToInt32(response.Skip(contentStartIndex + 1).Take(4).Reverse().ToArray(), 0);
                        traciResult.Length = singleResultLength - 6; // content length = messageTotalLength - Length(5byte, 0(1byte), length(4byte) ) - identifier(1byte)
                        contentPointer += 5;//move Pointer
                        }
                    else { break;/*说明已经解析完最后一条 result*/ }
                    }


                // 解析一条 result的 identifier
                traciResult.Identifier = response[contentStartIndex + contentPointer++];


                // some special case for CMD_SIMSTEP
                // ? 
                // why we need it?
                // 模拟步骤的result包括多个子result , = length + identifier + content(result1,result2,...)
                // https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#response_0x02_simulation_step
                if (
                    traciResult.Identifier == TraCIConstants.CMD_SIMSTEP
                    && totalLength == response.Count
                    && singleResultLength + 8 != response.Count
                )
                    {
                    var subscriptionResponsesCount = ToInt32(response.Skip(contentStartIndex + singleResultLength).Take(4/*int(4byte)*/).Reverse().ToArray(), 0);
                    singleResultLength += 5;
                    for (var n = 0; n < subscriptionResponsesCount; n++)
                        {
                        var offset = contentStartIndex + singleResultLength;
                        offset += 4;
                        var subResponseLength = ToInt32(response.Skip(offset).Take(4).Reverse().ToArray(), 0);
                        singleResultLength += subResponseLength;
                        // For some reason when the subscription is context subscription
                        // we need one extra byte in the singleResultLength than simply adding SubResponseLength
                        var identifier = response.Skip(offset).First();
                        var identifierHighPart = identifier >> 4;
                        if (identifierHighPart == 0x09) singleResultLength++;
                        }
                    traciResult.Length = --singleResultLength;
                    }


                // 解析一条 result的 content
                traciResult.Response = [.. response.Skip(contentStartIndex + contentPointer).Take(singleResultLength - contentPointer)];

                // 更新已解析的byte指针
                contentStartIndex += singleResultLength;
                results.Add(traciResult);


                }
            return [.. results];
            }
        catch (IndexOutOfRangeException)
            {
            return null;
            }
        }

    }

