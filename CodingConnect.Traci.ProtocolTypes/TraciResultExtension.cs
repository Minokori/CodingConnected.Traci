
using static System.BitConverter;
namespace CodingConnected.Traci.ProtocolTypes;

public static class TraciResultExtension
    {
    /// <summary>
    /// 从 response 中提取数据
    /// </summary>
    /// <param name="results"></param>
    /// <param name="commandType"></param>
    /// <param name="variableType">variableType, see <see cref="DataType"/></param>
    /// <returns></returns>
    public static IAnswerFromSumo? ExtractData(this IEnumerable<TraciResult> results, byte commandType, byte? variableType = 0)
        {
        // check if results is null
        if (results == null)
            {
            return null;
            }

        // find results of specific command type, statusResponse is status results
        var (statusResponse, i) = results.Select((item, index) => (item, index)).FirstOrDefault(x => x.item.Identifier == commandType);
        if (statusResponse is null)
            {
            return null;
            }

        // check if the command is successful
        switch ((statusResponse as IStatusResponse).Result)
            {
            case ResultCode.Success:
                    {
                    // https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo
                    var result = results
                        .Skip(i + 1) // i: index of ResultCode.
                        .FirstOrDefault(x =>
                            x.Identifier == commandType + 0x10 /* result's identifier is GET command's identifier +0x10 */
                        );
                    return result?.Content[0] == variableType ? result : null;
                    }
            default:
                    {
                    Console.WriteLine($"Command {commandType} failed");
                    return null;
                    }
            }
        }

    /// <summary>
    /// 从 response 中提取数据
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    public static List<TraciSubscriptionResponse>? ExtractSimStepData(this List<TraciResult> results)
        {
        List<TraciSubscriptionResponse> responses = [];
        // check if results is null
        if (results == null)
            {
            return null;
            }

        // find results of specific command type, statusResponse is status results ,result is result
        (var statusResponse, var i) = results.Select((result, index) => (result, index)).FirstOrDefault(x => x.result.Identifier == CommandIdentifier.SIMSTEP);
        if (statusResponse is null)
            {
            return null;
            }

        switch (((IStatusResponse)statusResponse).Result)
            {
            case ResultCode.Success:
                    {
                    foreach (var item in results.Skip(i + 1))
                        {
                        var response = item.ToSimStepResponse();
                        responses.Add(response);
                        return responses;
                        }
                    break;
                    }
            case ResultCode.Failed:
            case ResultCode.NotImplemented:
                    {
                    return null;
                    }
            }
        return null;
        }

    /// <summary>
    /// 解析返回的值
    /// </summary>
    /// <param name="type">值的类型</param>
    /// <param name="bytes">值</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal static (ITraciType traciValue, IEnumerable<byte> remainBytes) GetValueFromTypeAndArray(byte type, IEnumerable<byte> bytes)
        {
        switch ((DataType)type)
            {
            case DataType.LON_LAT:
                    {
                    (var result, bytes) = LonLatPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.X_Y:
                    {
                    (var result, bytes) = Position2D.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.LON_LAT_ALT:
                    {
                    (var result, bytes) = LonLatAltPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.X_Y_Z:
                    {
                    (var result, bytes) = Position3D.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.ROADMAP:
                    {
                    (var result, bytes) = RoadMapPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.BOUNDINGBOX:
                    {
                    (var result, bytes) = BoundaryBox.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.POLYGON:
                    {
                    (var result, bytes) = Polygon.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.UNSIGNEDBYTE:
                    {
                    (var result, bytes) = TraciUnsignedByte.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.BYTE:
                    {
                    (var result, bytes) = TraciByte.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.INTEGER:
                    {
                    (var result, bytes) = TraciInteger.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.FLOAT:
                    {
                    (var result, bytes) = TraciFloat.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.DOUBLE:
                    {
                    (var result, bytes) = TraciDouble.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.STRING:
                    {
                    (var result, bytes) = TraciString.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.TLPHASELIST:
                    {
                    (var result, bytes) = TrafficLightPhaseList.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.COLOR:
                    {
                    (var result, bytes) = Color.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.STRINGLIST:
                    {
                    (var result, bytes) = TraciStringList.FromBytes(bytes);
                    return new(result, bytes);
                    }

            case DataType.DOUBLELIST:
                    {
                    (var result, bytes) = TraciDoubleList.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case DataType.COMPOUND:
                    {
                    //get how many items in this traciCompoundObject
                    var innerValueNumber = ToInt32(bytes.Take(DataSize.INTEGER_SIZE).Reverse().ToArray());
                    bytes = bytes.Skip(DataSize.INTEGER_SIZE);

                    // init a list to put inner data
                    List<ITraciType> innerDataList = [];

                    // put inner data into the list
                    for (var i = 0; i < innerValueNumber; i++)
                        {
                        var innerItemType = bytes.First();
                        bytes = bytes.Skip(1);
                        (var result, bytes) = GetValueFromTypeAndArray(innerItemType, bytes);
                        innerDataList.Add(result);
                        }
                    // BUG 不能直接将List<ITraciType> 转换为 TraciCompoundObject
                    return new(new TraciCompoundObject(innerDataList), bytes);
                    }
            default:
                    {
                    throw new Exception();
                    }
            }
        }

    /// <summary>
    /// 将 TCP 返回的完整信息 (bytes) 解析为若干 TraCIResults<para/>
    /// analyze the complete information (bytes) returned by TCP as several TraCIResults
    /// </summary>
    /// <param name="responseBytes"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static List<TraciResult> AsTraCIResults(this List<byte> responseBytes)
        {
        // check if innerValueNumber of responseBytes is correct
        var (totalLengthOfBytes, remainBytes) = TraciInteger.FromBytes(responseBytes);
        if (totalLengthOfBytes != responseBytes.Count)
            {
            throw new Exception($"length(byte){totalLengthOfBytes} != length(count){responseBytes.Count}");
            }

        // get the first result
        TraciInteger count = new(0);
        (var firstResult, remainBytes) = remainBytes.GetTraCIResult();
        List<TraciResult> results = [firstResult];

        // if the first result is SIMSTEP, there is a TraciInteger after it. We need to get it.
        if (firstResult.Identifier == CommandIdentifier.SIMSTEP)
            {
            (count, remainBytes) = TraciInteger.FromBytes(remainBytes);
            }

        // get remain results
        while (remainBytes.Any())
            {
            (var result, remainBytes) = remainBytes.GetTraCIResult();
            results.Add(result);
            }
        return firstResult.Identifier == CommandIdentifier.SIMSTEP && count.Value + 1 != results.Count ? throw new Exception() : results;
        }

    /// <summary>
    /// 从 bytes 中获取 TraCIResult，返回剩余的 bytes<para/>
    /// get TraCIResult from bytes, return remain bytes
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private static (TraciResult traciResult, IEnumerable<byte> remainBytes) GetTraCIResult(this IEnumerable<byte> bytes)
        {
        var isLongResult = bytes.First() == 0;
        var resultLength = isLongResult ? ToInt32(bytes.Skip(1).Take(4).Reverse().ToArray()) : bytes.First();
        TraciResult result = new()
            {
            ContentLength = isLongResult ? resultLength - 6 : resultLength - 2,
            Identifier = bytes.Skip(isLongResult ? 5 : 1).First(),
            Content = [.. bytes.Take(resultLength).Skip(isLongResult ? 6 : 2)],
            };
        return new(result, bytes.Skip(resultLength));
        }

    private static TraciSubscriptionResponse ToSimStepResponse(this TraciResult traciResult)
        {
        var commandType = traciResult.Identifier >> 4;

        switch (commandType)
            {
            case 0x0e: // 0xeX => VariableType Subscription Content
                    {
                    var (response, leftBytes) = TraciVariableSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraciSubscriptionResponse)response;
                    }
            case 0x09: // 0x9X => Object Context Subscription Content
                    {
                    var (response, leftBytes) = TraciContextSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraciSubscriptionResponse)response;
                    }
            default:
                throw new NotImplementedException();
            }
        }
    }
