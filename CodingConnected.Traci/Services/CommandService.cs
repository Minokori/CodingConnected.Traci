using System.Buffers;

namespace CodingConnected.Traci.Services;

internal sealed partial class CommandService(ISumoConnectService tcpService) : ITraciCommandService
    {
    private readonly ISumoConnectService _tcpService = tcpService;
    private readonly byte[] _buffer = ArrayPool<byte>.Shared.Rent(1024);

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
            return answer is null ? throw new InvalidOperationException("Answer from traci is null, please check command.") : answer;
            }
        catch
            {
            throw;
            }
        }

    public void ExecuteSubscribeCommand(double beginTime, double endTime, byte commandIdentifier, IList<byte> variables, string objectId)
        {
        var command = GenerateSubscribeCommand(beginTime, endTime, commandIdentifier, variables, objectId);
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Context subscriptions are allowing the obtaining of specific values from surrounding objects of a certain so called "EGO" object.
    /// With these data one can determine the traffic status around that EGO object. Such an EGO Object can be any possible Vehicle, inductive loop, points-of-interest, and such like.
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
        IList<byte> variables,
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
    public TraciCommand GenerateSubscribeCommand(
        double beginTime,
        double endTime,
        byte commandIdentifier,
        IList<byte> variables,
        string objectId,
        byte? contextDomain = null,
        double? contextRange = null
    )
        {
        Span<byte> commandParts = new(_buffer);
        int offset = 0;
        // Part1: beginTime, endTime, objectId
        new TraciDouble(beginTime).WriteToSpan(commandParts, ref offset);
        new TraciDouble(endTime).WriteToSpan(commandParts, ref offset);
        new TraciString(objectId).WriteToSpan(commandParts, ref offset);
        // Part2: contextDomain
        if (contextDomain.HasValue)
            {
            commandParts[offset] = contextDomain.Value;
            offset += 1;
            }
        // Part3: contextRange
        if (contextRange.HasValue)
            {
            new TraciDouble(contextRange.Value).WriteToSpan(commandParts, ref offset);
            }
        // Part4: variables
        commandParts[offset] = (byte)variables.Count;
        offset += 1;
        foreach (var variable in variables)
            {
            commandParts[offset] = variable;
            offset += 1;
            }
        // Create optimized command
        TraciCommand commandOptimized = new(commandIdentifier, commandParts[..offset].ToArray());
        return commandOptimized;
        }

    public TraciCommand GenerateCommand(byte commandIdentifier, byte? messageType = null, string? id = null, ITraciType? contents = null)
        {
        Span<byte> commandParts = new(_buffer);
        int offset = 0;
        // Part1: Message Type
        if (messageType.HasValue)
            {
            commandParts[offset] = messageType.Value;
            offset += 1;
            }
        // Part2: ID
        if (id is not null)
            {
            new TraciString(id).WriteToSpan(commandParts, ref offset);
            }
        // Part3: Contents
        if (contents is not null)
            {
            if (contents.TypeIdentifier != DataType.Null)
                {
                commandParts[offset] = (byte)contents.TypeIdentifier;
                offset += 1;
                }
            contents.WriteToSpan(commandParts, ref offset);
            }
        TraciCommand commandOptimized = new(commandIdentifier, commandParts[..offset].ToArray());
        return commandOptimized;
        }

    }
