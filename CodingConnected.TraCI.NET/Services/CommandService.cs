using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.ProtocolTypes;

namespace CodingConnected.TraCI.NET.Services;

internal partial class CommandService(ITCPConnectService tcpService, IDebugService debugHelper) : ICommandService
    {
    private readonly ITCPConnectService _tcpService = tcpService;
    private readonly IDebugService _debugHelper = debugHelper;

    public bool ExecuteSetCommand(byte commandIdentifier, byte variable, string id, ITraciType? value = null)
        {
        var command = GenerateCommand(commandIdentifier, variable, id, value);
        if (command != null)
            {
            var response = _tcpService.SendMessage(command);
            var result = ((IStatusResponse)response[0]).Result == ResultCode.Success;
            return result;
            }
        else
            {
            return false;
            }
        }

    public IAnswerFromSumo ExecuteGetCommand(byte commandIdentifier, byte? variable = null, string? id = "", ITraciType? extendParameter = null)
        {
        var command = GenerateCommand(commandIdentifier, variable, id, extendParameter);
        var response = _tcpService.SendMessage(command);
        try
            {
            var answer = response.ExtractData(commandIdentifier, variable);
            return answer is null ? throw new Exception("Answer from traci is null") : answer;
            }
        catch
            {
            throw;
            }
        }

    public void ExecuteSubscribeCommand(double beginTime, double endTime, byte commandIdentifier, List<byte> variables, string objectId)
        {
        var command = GenerateSubscribeCommand(beginTime, endTime, commandIdentifier, variables, objectId);
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Context subscriptions are allowing the obtaining of specific values from surrounding objects of a certain so called "EGO" object.
    /// With these datas one can determine the traffic status around that EGO object. Such an EGO Object can be any possible Vehicle, inductive loop, points-of-interest, and such like.
    /// A vehicle driving through a city, for example, is surrounded by a lot of different and changing vehicles, lanes, junctions, or points-of-interest along his ride.
    /// Context subscriptions can provide selected variables of those objects that surround the EGO object within a certain range.
    ///
    /// <see href="https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription"/>
    /// </summary>
    /// <remarks>  </remarks>
    /// <param name="beginTime"> begin Time: the subscription is executed only in time steps >= this value; in ms </param>
    /// <param name="endTime"> the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms </param>
    /// <param name="commandIdentifier"> The identifier for the Object Context Subscription command. </param>
    /// <param name="variables"> the list of variables to return </param>
    /// <param name="objectId"> the id of the object for the context subscription </param>
    /// <param name="contextDomain"> the type of objects in the addressed object's surrounding to ask values from </param>
    /// <param name="contextRange"> the radius of the surrounding </param>
    public void ExecuteSubscribeContextCommand(
        double beginTime,
        double endTime,
        byte commandIdentifier,
        List<byte> variables,
        string objectId,
        byte contextDomain,
        double contextRange
    )
        {
        var command = GenerateSubscribeCommand(beginTime, endTime, commandIdentifier, variables, objectId, contextDomain, contextRange);
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Helper GenerateSubscribeCommand for Object Context Subscription
    /// </summary>
    /// <returns></returns>
    public TraCICommand GenerateSubscribeCommand(
        double beginTime,
        double endTime,
        byte commandIdentifier,
        List<byte> variables,
        string objectId,
        byte? contextDomain = null,
        double? contextRange = null
    )
        {
        List<byte> commandPart1 = [.. TraciDouble.AsBytes(beginTime), .. TraciDouble.AsBytes(endTime), .. TraciString.AsBytes(objectId)];
        List<byte> commandPart2 = contextDomain.HasValue ? [contextDomain.Value] : [];
        List<byte> commandPart3 = contextRange.HasValue ? [.. TraciDouble.AsBytes(contextRange.Value)] : [];
        List<byte> commandPart4 = [(byte)variables.Count, .. variables];
        TraCICommand command = new(commandIdentifier, [.. commandPart1, .. commandPart2, .. commandPart3, .. commandPart4]);
        return command;
        }

    public TraCICommand GenerateCommand(byte commandIdentifier, byte? messageType = null, string? id = null, ITraciType? contents = null)
        {
        byte[] commandPart1 = messageType.HasValue ? [messageType.Value] : [];
        var commandPart2 = id is null ? [] : TraciString.AsBytes(id);

        byte[] commandPart3 = contents is not null ? [(byte)contents.TypeIdentifier, .. contents.ToBytes()] : [];
        if (contents is not null && contents.TypeIdentifier == DataType.NULL)
            {
            commandPart3 = [.. commandPart3.Skip(1)];
            }
        TraCICommand command = new(commandIdentifier, [.. commandPart1, .. commandPart2, .. commandPart3]);

        _debugHelper.LogToConsole($"GenerateCommand : {command.DebugString}");

        return command;
        }
    }
