using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;
using static System.BitConverter;

namespace CodingConnected.TraCI.NET.Helpers;

internal static partial class TraCIDataConverter
    {
    /// <summary>
    /// 从response中提取数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="response"></param>
    /// <param name="commandType"></param>
    /// <param name="variableType"></param>
    /// <returns></returns>
    internal static TraCIResponse<T> ExtractDataFromResponse<T>(TraCIResult[] response, byte commandType, byte variableType = 0)
        {
        // check if response is null
        if (response == null) { return null; }

        // find response of specific command type, statusResponse is status response ,result is result
        var statusResponse = response.FirstOrDefault(x => x.Identifier == commandType);
        var i = Array.IndexOf(response, statusResponse);
        if (statusResponse is null) { return null; }

        switch (((IStatusResponse)statusResponse).Result)
            {
            case ResultCode.Success:
                    {

                    #region TODO
                    if (statusResponse.Identifier == TraCIConstants.CMD_SIMSTEP)
                        {
                        if (statusResponse.ContentLength != 5)// statusResponse has description
                            {
                            var tmp = GetDataFromSimStepResponse(statusResponse); // simstep will return subscription. 
                            return new TraCIResponse<T>
                                {
                                Identifier = statusResponse.Identifier,
                                ResponseIdentifier = null,
                                VariableType = null,
                                Result = ResultCode.Success,
                                Content = (T)tmp,
                                };
                            }
                        }
                    #endregion


                    // check if first byte is as requested (it gives the type of data requested)
                    // https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo
                    var result = response.Skip(i + 1).FirstOrDefault(x => x.Identifier == commandType + 0x10 /*response's identifier is GET command's identifire +0x10*/);

                    if (result?.Content[0] == variableType)
                        {
                        //// after the type of data, there is the length of the id (a string that we will skip)
                        //var idLength = ToInt32(result.Content.Skip(1/* varibale */).Take(4 /* stringLength(4byte) */ ).Reverse().ToArray());
                        //// after the string is the type of data returned
                        //var type = result.Content[5/*var(1) + strLen(4)*/ + idLength/*str*/];
                        //// now read and translate the data
                        //GetValueFromTypeAndArray(type, result.Content.Skip(6/**/ + idLength).ToArray(), out var contentAsObject);

                        return new TraCIResponse<T>
                            {
                            Identifier = statusResponse.Identifier,
                            ResponseIdentifier = result.Identifier,
                            VariableType = ((IAnswerFromSUMO)result).ReturnType,
                            Result = ResultCode.Success,
                            Content = (T)((IAnswerFromSUMO)result).Value,
                            };
                        }
                    else
                        {
                        // for state changing methods without response content
                        return new TraCIResponse<T>
                            {
                            Identifier = statusResponse.Identifier,
                            ResponseIdentifier = null,
                            VariableType = null,
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
                        VariableType = null,
                        Result = ((IStatusResponse)statusResponse).Result,
                        Content = default,
                        ErrorMessage = $"TraCI reports command {Enum.GetName(((IStatusResponse)statusResponse).Result)}: {((IStatusResponse)statusResponse).Description}",
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
                return GetBytes((float)value).Reverse().ToArray();
            // TODO byte 是不是直接返回Value？short对不对
            case byte:
                return GetBytes((short)value).Reverse().ToArray();
            case int:
                return GetBytes((int)value).Reverse().ToArray();
            case double:
                return GetBytes((double)value).Reverse().ToArray();
            case string:
                return [.. GetBytes(((string)value).Length).Reverse(), .. Encoding.ASCII.GetBytes((string)value)];
            case List<string>:
                var los = (List<string>)value;
                List<byte> bytes = [.. GetBytes(los.Count).Reverse()];
                foreach (var str in los)
                    {
                    bytes.AddRange(str.ToTraCIBytes());
                    }
                return [.. bytes];
            default:
                return [];
            }
        }

    /// <summary>
    /// 解析返回的值
    /// TODO 把对byte的依赖去掉
    /// </summary>
    /// <param name="type">值的类型</param>
    /// <param name="bytes">值</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal static Tuple<ITraCIType, IEnumerable<byte>> GetValueFromTypeAndArray(byte type, IEnumerable<byte> bytes)
        {
        switch (type)
            {
            case TraCIConstants.POSITION_LON_LAT:
                    {
                    (var result, bytes) = LonLatPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.POSITION_2D:
                    {
                    (var result, bytes) = Position2D.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.POSITION_LON_LAT_ALT:
                    {
                    (var result, bytes) = LonLatAltPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.POSITION_3D:
                    {
                    (var result, bytes) = Position3D.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.POSITION_ROADMAP:
                    {
                    (var result, bytes) = RoadMapPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_BOUNDINGBOX:
                    {
                    (var result, bytes) = BoundaryBox.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_POLYGON:
                    {
                    (var result, bytes) = Polygon.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_UBYTE:
                    {
                    (var result, bytes) = TraCIUByte.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_BYTE:
                    {
                    (var result, bytes) = TraCIByte.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_INTEGER:
                    {
                    (var result, bytes) = TraCIInteger.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_FLOAT:
                    {
                    (var result, bytes) = TraCIFloat.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_DOUBLE:
                    {
                    (var result, bytes) = TraCIDouble.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_STRING:
                    {
                    (var result, bytes) = TraCIString.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_TLPHASELIST:
                    {
                    (var result, bytes) = TrafficLightPhaseList.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_COLOR:
                    {
                    (var result, bytes) = Color.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_STRINGLIST:
                    {
                    (var result, bytes) = TraCIStringList.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TraCIConstants.TYPE_COMPOUND:
                    {
                    var length = ToInt32(bytes.Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray());
                    bytes = bytes.Skip(TraCIConstants.INTEGER_SIZE);
                    List<ITraCIType> innerDataList = [];
                    for (var i = 0; i < length; i++)
                        {
                        var innerItemType = bytes.First();
                        bytes = bytes.Skip(1);
                        (var result, bytes) = GetValueFromTypeAndArray(innerItemType, bytes);
                        innerDataList.Add(result);
                        }
                    return new((TraCIObjects)innerDataList, bytes);

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
        var totalLength = ToInt32(response.Take(4).Reverse().ToArray());
        if (totalLength != response.Count) { throw new Exception($"length(byte){totalLength} != length(count){response.Count}"); }
        List<TraCIResult> results = [];
        try
            {
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
                    traciResult.ContentLength = singleResultLength - 2; // content length = messageTotalLength - ContentLength(1byte) - identifier(1byte)
                    contentPointer++; //move Pointer
                    }
                // 若消息长度为0,说明result过长，一个byte不够用
                else
                    {
                    if (contentStartIndex + 6 /*1byte(0),  4byte(messagelength), 1byte(identifier)*/ < totalLength)
                        {
                        singleResultLength = ToInt32(response.Skip(contentStartIndex + 1).Take(4).Reverse().ToArray(), 0);
                        traciResult.ContentLength = singleResultLength - 6; // content length = messageTotalLength - ContentLength(5byte, 0(1byte), length(4byte) ) - identifier(1byte)
                        contentPointer += 5;//move Pointer
                        }
                    else { break; /*说明已经解析完最后一条 result*/ }
                    }


                // 解析一条 result的 identifier
                traciResult.Identifier = response[contentStartIndex + contentPointer++];


                // some special case for CMD_SIMSTEP
                // ? 
                // why we need it?
                // 模拟步骤的result包括多个子result , = length + identifier + content(result1,result2,...)
                // https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#response_0x02_simulation_step
                if (traciResult.Identifier == TraCIConstants.CMD_SIMSTEP && /*返回的结果是 执行一个仿真步骤的result*/ singleResultLength + 8 != response.Count)
                    {
                    // int 
                    var subscriptionResponsesCount = ToInt32(response.Skip(contentStartIndex + singleResultLength).Take(4/*int(4byte)*/).Reverse().ToArray());


                    singleResultLength += 4 /*int 的4byte也算进去*/;
                    for (var n = 0; n < subscriptionResponsesCount; n++)
                        {
                        var offset = contentStartIndex + singleResultLength;
                        offset += 4;//不该在这加，在下一句加
                        // BUG 错误，溢出了变成负数了
                        var subResponseLength = ToInt32(response.Skip(offset).Take(4).Reverse().ToArray());
                        singleResultLength += subResponseLength;
                        // For some reason when the subscription is context subscription
                        // we need one extra byte in the singleResultLength than simply adding SubResponseLength
                        var identifier = response.Skip(offset).First();
                        var identifierHighPart = identifier >> 4;
                        if (identifierHighPart == 0x09) singleResultLength++;
                        }
                    traciResult.ContentLength = --singleResultLength;
                    }


                // 解析一条 result的 content
                traciResult.Content = [.. response.Skip(contentStartIndex + contentPointer).Take(singleResultLength - contentPointer)];

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
    internal static List<TraCIResult> AsTraCIResults(this List<byte> response)
        {
        var totalLength = ToInt32(response.Take(4).Reverse().ToArray());
        if (totalLength != response.Count) { throw new Exception($"length(byte){totalLength} != length(count){response.Count}"); }

        var (firstResult, leftBytes) = GetTraCIResult(response.Skip(4));
        List<TraCIResult> results = [firstResult];
        if (firstResult.Identifier == TraCIConstants.CMD_SIMSTEP)
            {
            var count = ToInt32(leftBytes.Take(4).Reverse().ToArray());
            leftBytes = leftBytes.Skip(4);
            }
        while (leftBytes.Any())
            {
            (var result, leftBytes) = GetTraCIResult(leftBytes);
            results.Add(result);
            }
        return results;
        }

    internal static Tuple<TraCIResult, IEnumerable<byte>> GetTraCIResult(IEnumerable<byte> bytes)
        {
        var isLong = bytes.First() == 0;
        var resultLength = isLong ? ToInt32(bytes.Skip(1).Take(4).Reverse().ToArray()) : bytes.First();
        TraCIResult tr = new()
            {
            ContentLength = isLong ? resultLength - 6 : resultLength - 2,
            Identifier = bytes.Skip(isLong ? 5 : 1).First(),
            Content = [.. bytes.Take(resultLength).Skip(isLong ? 6 : 2)]
            };
        return new(tr, bytes.Skip(resultLength));
        }

    }

