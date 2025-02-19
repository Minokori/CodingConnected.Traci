﻿using CodingConnected.TraCI.NET.DataTypes;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;

namespace CodingConnected.TraCI.NET.ProtocolTypes;

internal static class TraCIResultExtension
    {
    /// <summary>
    /// 从response中提取数据
    /// </summary>
    /// <param name="results"></param>
    /// <param name="commandType"></param>
    /// <param name="variableType"></param>
    /// <returns></returns>
    internal static IAnswerFromSumo ExtractData(this IEnumerable<TraCIResult> results, byte commandType, byte? variableType = 0)
        {
        // check if results is null
        if (results == null)
            {
            return null;
            }

        // find results of specific command type, statusResponse is status results ,result is result
        var (statusResponse, i) = results.Select((item, index) => (item, index)).FirstOrDefault(x => x.item.Identifier == commandType);
        if (statusResponse is null)
            {
            return null;
            }

        switch ((statusResponse as IStatusResponse).Result)
            {
            case ResultCode.Success:
                    {
                    // https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo
                    var result = results
                        .Skip(i + 1)
                        .FirstOrDefault(x =>
                            x.Identifier == commandType + 0x10 /*results's identifier is GET command's identifire +0x10*/
                        );
                    return result?.Content[0] == variableType ? result : null;
                    }
            default:
                    {
                    return null;
                    }
            }
        }

    /// <summary>
    /// 从response中提取数据
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    internal static List<TraCISubscriptionResponse> ExtractSimStepData(this List<TraCIResult> results)
        {
        List<TraCISubscriptionResponse> responses = [];
        // check if results is null
        if (results == null)
            {
            return null;
            }

        // find results of specific command type, statusResponse is status results ,result is result
        (var statusResponse, var i) = results.Select((result, index) => (result, index)).FirstOrDefault(x => x.result.Identifier == CMD_SIMSTEP);
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
    internal static Tuple<ITraciType, IEnumerable<byte>> GetValueFromTypeAndArray(byte type, IEnumerable<byte> bytes)
        {
        switch (type)
            {
            case POSITION_LON_LAT:
                    {
                    (var result, bytes) = LonLatPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case POSITION_2D:
                    {
                    (var result, bytes) = Position2D.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case POSITION_LON_LAT_ALT:
                    {
                    (var result, bytes) = LonLatAltPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case POSITION_3D:
                    {
                    (var result, bytes) = Position3D.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case POSITION_ROADMAP:
                    {
                    (var result, bytes) = RoadMapPosition.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_BOUNDINGBOX:
                    {
                    (var result, bytes) = BoundaryBox.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_POLYGON:
                    {
                    (var result, bytes) = Polygon.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_UBYTE:
                    {
                    (var result, bytes) = TraCIUByte.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_BYTE:
                    {
                    (var result, bytes) = TraCIByte.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_INTEGER:
                    {
                    (var result, bytes) = TraCIInteger.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_FLOAT:
                    {
                    (var result, bytes) = TraCIFloat.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_DOUBLE:
                    {
                    (var result, bytes) = TraCIDouble.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_STRING:
                    {
                    (var result, bytes) = TraCIString.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_TLPHASELIST:
                    {
                    (var result, bytes) = TrafficLightPhaseList.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_COLOR:
                    {
                    (var result, bytes) = Color.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_STRINGLIST:
                    {
                    (var result, bytes) = TraCIStringList.FromBytes(bytes);
                    return new(result, bytes);
                    }
            case TYPE_COMPOUND:
                    {
                    var length = ToInt32(bytes.Take(INTEGER_SIZE).Reverse().ToArray());
                    bytes = bytes.Skip(INTEGER_SIZE);
                    List<ITraciType> innerDataList = [];
                    for (var i = 0; i < length; i++)
                        {
                        var innerItemType = bytes.First();
                        bytes = bytes.Skip(1);
                        (var result, bytes) = GetValueFromTypeAndArray(innerItemType, bytes);
                        innerDataList.Add(result);
                        }
                    return new((TraCICompoundObject)innerDataList, bytes);
                    }
            default:
                    {
                    throw new Exception();
                    }
            }
        }

    internal static List<TraCIResult> AsTraCIResults(this List<byte> response)
        {
        var (totalLength, leftBytes) = TraCIInteger.FromBytes(response);
        var count = new TraCIInteger();
        if (totalLength.Value != response.Count)
            {
            throw new Exception($"length(byte){totalLength} != length(count){response.Count}");
            }

        (var firstResult, leftBytes) = GetTraCIResult(leftBytes);
        List<TraCIResult> results = [firstResult];

        if (firstResult.Identifier == CMD_SIMSTEP)
            {
            (count, leftBytes) = TraCIInteger.FromBytes(leftBytes);
            }

        while (leftBytes.Any())
            {
            (var result, leftBytes) = GetTraCIResult(leftBytes);
            results.Add(result);
            }
        return firstResult.Identifier == CMD_SIMSTEP && count.Value + 1 != results.Count ? throw new Exception() : results;
        }

    private static Tuple<TraCIResult, IEnumerable<byte>> GetTraCIResult(IEnumerable<byte> bytes)
        {
        var isLong = bytes.First() == 0;
        var resultLength = isLong ? ToInt32(bytes.Skip(1).Take(4).Reverse().ToArray()) : bytes.First();
        TraCIResult tr = new()
            {
            ContentLength = isLong ? resultLength - 6 : resultLength - 2,
            Identifier = bytes.Skip(isLong ? 5 : 1).First(),
            Content = [.. bytes.Take(resultLength).Skip(isLong ? 6 : 2)],
            };
        return new(tr, bytes.Skip(resultLength));
        }

    private static TraCISubscriptionResponse ToSimStepResponse(this TraCIResult traciResult)
        {
        var commandType = traciResult.Identifier >> 4;

        switch (commandType)
            {
            case 0x0e: // 0xeX => VariableType Subscription Content
                    {
                    var (response, leftBytes) = TraCIVariableSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraCISubscriptionResponse)response;
                    }
            case 0x09: // 0x9X => Object Context Subscription Content
                    {
                    var (response, leftBytes) = TraCIContextSubscriptionResponse.FromBytes(traciResult.Content);
                    response.Identifier = traciResult.Identifier;
                    return leftBytes.Any() ? throw new Exception("GetDataFromSimStepResponse not all consumed") : (TraCISubscriptionResponse)response;
                    }
            default:
                throw new NotImplementedException();
            }
        }
    }
