using System.Buffers.Binary;
#pragma warning disable CA1034,IDE0130, CA1708, CA1851
namespace CodingConnected.Traci.ProtocolTypes;

public static class TraciResultExtension
    {
    /// <summary>
    /// traci results 扩展方法
    /// </summary>
    /// <param name="results">traci results</param>
    extension(IEnumerable<TraciResult> results)
        {
        /// <summary>
        /// 从 response 中提取数据
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="variableType">variableType, see <see cref="DataType"/></param>
        /// <returns></returns>
        public IAnswerFromSumo? ExtractData(byte commandType, byte? variableType = 0)
            {
            // check if results is null
            if (results == null)
                {
                return null;
                }

            // Materialize results to a list to avoid multiple enumeration (CA1851)
            var resultsList = results as IList<TraciResult> ?? [.. results];

            // find results of specific command type, statusResponse is status results
            var (statusResponse, i) = resultsList
                .Select((item, index) => (item, index))
                .FirstOrDefault(x => x.item.Identifier == commandType);
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
                    var result = resultsList
                        .Skip(i + 1) // i: index of ResultCode.
                        .FirstOrDefault(x =>
                            x.Identifier == commandType + 0x10 /* result's identifier is GET command's identifier +0x10 */
                        );
                    return result?.Content[0] == variableType ? result : null;
                    }
                case ResultCode.Failed:
                    {
                    // TODO raise exception like python api
                    var text = Enum.GetName(typeof(CommandIdentifier), commandType);
                    Console.WriteLine($"Command {text} failed");
                    goto default;
                    }
                case ResultCode.NotImplemented:
                    {
                    var text = Enum.GetName(typeof(CommandIdentifier), commandType);
                    Console.WriteLine($"Command {text}  not implemented in traci");
                    goto default;
                    }
                default:
                    {
                    return null;
                    }
                }
            }

        /// <summary>
        /// 从 response 中提取数据
        /// </summary>
        /// <returns></returns>
        public List<TraciSubscriptionResponse>? ExtractSimStepData()
            {
            List<TraciSubscriptionResponse> responses = [];
            // check if results is null
            if (results == null)
                {
                return null;
                }

            // find results of specific command type, statusResponse is status results ,result is result
            (var statusResponse, var i) = results
                .Select((result, index) => (result, index))
                .FirstOrDefault(x =>
                    x.result.Identifier == CommandIdentifier.SimulationStep
                );
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
        }

    /// <summary>
    /// 解析 type 和 bytes 获取对应的 ITraciType 实例<para/>
    /// </summary>
    /// <param name="type">type 标识符</param>
    /// <param name="bytes">原始bytes</param>
    /// <param name="remainingBytes">剩下的bytes</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    internal static ITraciType GetValueFromTypeAndSpan(
        byte type,
        ReadOnlySpan<byte> bytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        switch ((DataType)type)
            {
            case DataType.LonLat:
                {
                var result = LonLatPosition.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.XY:
                {
                var result = Position2D.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.LonLatAlt:
                {
                var result = LonLatAltPosition.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.XYZ:
                {
                var result = Position3D.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.RoadMap:
                {
                var result = RoadMapPosition.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.BoundingBox:
                {
                var result = BoundaryBox.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Polygon:
                {
                var result = Polygon.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.UnsignedByte:
                {
                var result = TraciUnsignedByte.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Byte:
                {
                var result = TraciByte.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Integer:
                {
                var result = TraciInteger.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Float:
                {
                var result = TraciFloat.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Double:
                {
                var result = TraciDouble.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.String:
                {
                var result = TraciString.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.TLPhaseList:
                {
                var result = TrafficLightPhaseList.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Color:
                {
                var result = Color.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.StringList:
                {
                var result = TraciStringList.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.DoubleList:
                {
                var result = TraciDoubleList.Parse(bytes, out remainingBytes);
                return result;
                }
            case DataType.Compound:
                {
                //get how many items in this traciCompoundObject
                int innerValueNumber = TraciInteger.Parse(bytes, out bytes);

                // init a list to put inner data
                List<ITraciType> innerDataList = [];

                // put inner data into the list
                for (var i = 0; i < innerValueNumber; i++)
                    {
                    var innerItemType = bytes[0];
                    bytes = bytes[1..];
                    var result = GetValueFromTypeAndSpan(innerItemType, bytes, out bytes);
                    innerDataList.Add(result);
                    }
                remainingBytes = bytes;
                return new TraciCompoundObject(innerDataList);
                }
            default:
                {
                throw new NotSupportedException("operation not supported.");
                }
            }
        }

    extension(ReadOnlySpan<byte> responseSpan)
        {
        public List<TraciResult> AsTraciResults()
            {
            var totalLengthOfBytes = TraciInteger.Parse(responseSpan, out var remainingSpan);
            // 检擦内部 byte 数是否正确 check if innerValueNumber of responseBytes is correct
            if (totalLengthOfBytes != responseSpan.Length)
                {
                throw new ArgumentException(
                    $"length(byte){totalLengthOfBytes} != length(count){responseSpan.Length}"
                );
                }
            // get the first result
            TraciInteger count = new(0);
            var firstResult = remainingSpan.GetTraciResult(out remainingSpan);
            List<TraciResult> results = [firstResult];

            // if the first result is SimulationStep, there is a TraciInteger after it. We need to get it.
            if (firstResult.Identifier == CommandIdentifier.SimulationStep)
                {
                count = TraciInteger.Parse(remainingSpan, out remainingSpan);
                }

            // get remain results
            while (remainingSpan.Length > 0)
                {
                var result = remainingSpan.GetTraciResult(out remainingSpan);
                results.Add(result);
                }
            return
                firstResult.Identifier == CommandIdentifier.SimulationStep
                && count.Value + 1 != results.Count
                ? throw new ArgumentException()
                : results;
            }
        }

    /// <summary>
    /// 从 bytes 中获取 TraCIResult，返回剩余的 bytes<para/>
    /// get TraCIResult from bytes, return remain bytes
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private static TraciResult GetTraciResult(
        this ReadOnlySpan<byte> bytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var isLongResult = bytes[0] == 0;
        var resultLength = isLongResult
            ? BinaryPrimitives.ReadInt32BigEndian(bytes.Slice(1, 4))
            : bytes[0];
        // TODO 改进TraciResult
        TraciResult result = new()
            {
            ContentLength = isLongResult ? resultLength - 6 : resultLength - 2,
            Identifier = bytes[isLongResult ? 5 : 1],
            Content =
            [
                .. bytes.Slice(
                    isLongResult ? 6 : 2,
                    isLongResult ? resultLength - 6 : resultLength - 2
                ),
            ],
            };
        remainingBytes = bytes[resultLength..];
        return result;
        }

    private static TraciSubscriptionResponse ToSimStepResponse(this TraciResult traciResult)
        {
        switch (traciResult.Identifier >> 4) //commandType
            {
            case 0x0e: // 0xeX => VariableType Subscription Content
                {
                var response = TraciVariableSubscriptionResponse.Parse(
                    traciResult.Content,
                    out var leftBytes
                );
                response.Identifier = traciResult.Identifier;
                return leftBytes.IsEmpty
                    ? (TraciSubscriptionResponse)response
                    : throw new ArgumentException("GetDataFromSimStepResponse not all consumed");
                }
            case 0x09: // 0x9X => Object Context Subscription Content
                {
                var response = TraciContextSubscriptionResponse.Parse(
                    traciResult.Content,
                    out var leftBytes
                );
                response.Identifier = traciResult.Identifier;
                return leftBytes.IsEmpty
                    ? (TraciSubscriptionResponse)response
                    : throw new ArgumentException("GetDataFromSimStepResponse not all consumed");
                }
            default:
                throw new NotImplementedException();
            }
        }
    }
