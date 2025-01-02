using System.Text;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
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
    /// <param name="results"></param>
    /// <param name="commandType"></param>
    /// <param name="variableType"></param>
    /// <returns></returns>
    internal static TraCIResponse<T> ExtractDataFromResults<T>(IEnumerable<TraCIResult> results, byte commandType, byte variableType = 0)
        {
        // check if results is null
        if (results == null) { return null; }

        // find results of specific command type, statusResponse is status results ,result is result
        var (statusResponse, i) = results.Select((item, index) => (item, index)).FirstOrDefault(x => x.item.Identifier == commandType);
        if (statusResponse is null) { return null; }

        switch (((IStatusResponse)statusResponse).Result)
            {
            case ResultCode.Success:
                    {
                    // check if first byte is as requested (it gives the type of data requested)
                    // https://sumo.dlr.de/docs/TraCI/SUMO_ID_Commands_Structure.html#answer_from_sumo
                    var result = results.Skip(i + 1).FirstOrDefault(x => x.Identifier == commandType + 0x10 /*results's identifier is GET command's identifire +0x10*/);

                    if (result?.Content[0] == variableType)
                        {
                        return new TraCIResponse<T>
                            {
                            Identifier = statusResponse.Identifier,
                            ResponseIdentifier = result.Identifier,
                            VariableType = ((IAnswerFromSumo)result).ReturnType,
                            Result = ResultCode.Success,
                            Content = (T)((IAnswerFromSumo)result).Value,
                            };
                        }
                    else
                        {
                        // for state changing methods without results content
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



    /// <summary>
    /// 从response中提取数据
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    internal static List<TraCISubscriptionResponse> ExtractDataFromSimStepResults(TraCIResult[] results)
        {
        List<TraCISubscriptionResponse> responses = [];
        // check if results is null
        if (results == null) { return null; }

        // find results of specific command type, statusResponse is status results ,result is result
        var statusResponse = results.FirstOrDefault(x => x.Identifier == CMD_SIMSTEP);
        var i = Array.IndexOf(results, statusResponse);
        if (statusResponse is null) { return null; }

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
                    List<ITraCIType> innerDataList = [];
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
                    throw new ArgumentOutOfRangeException();
                    }
            }
        }




    internal static List<TraCIResult> AsTraCIResults(this List<byte> response)
        {
        var (totalLength, leftBytes) = TraCIInteger.FromBytes(response);// ToInt32(response.Take(4).Reverse().ToArray());
        var count = new TraCIInteger();
        if (totalLength.Value != response.Count) { throw new Exception($"length(byte){totalLength} != length(count){response.Count}"); }

        (var firstResult, leftBytes) = GetTraCIResult(leftBytes);
        List<TraCIResult> results = [firstResult];

        if (firstResult.Identifier == CMD_SIMSTEP)
            {
            (count, leftBytes) = TraCIInteger.FromBytes(leftBytes); //ToInt32(leftBytes.Take(4).Reverse().ToArray());
            }


        while (leftBytes.Any())
            {
            (var result, leftBytes) = GetTraCIResult(leftBytes);
            results.Add(result);
            }
        if (firstResult.Identifier == CMD_SIMSTEP && count.Value + 1 != results.Count) { throw new Exception(); }
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

