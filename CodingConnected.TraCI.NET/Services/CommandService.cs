﻿using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.ProtocolTypes;
using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;
namespace CodingConnected.TraCI.NET.Services;

internal partial class CommandService(ITCPConnectService tcpService) : ICommandService
    {
    private readonly ITCPConnectService _tcpService = tcpService;

    public bool ExecuteSetCommand(string id, byte commandType, byte messageType, ITraciType value = null)
        {
        var command = GetCommand(commandType, messageType, id, value);
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

    public void ExecuteSubscribeCommand(double beginTime, double endTime, string objectId, byte commandType, List<byte> variables)
        {
        var command = GetCommand(objectId, beginTime, endTime, commandType, variables);
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
    /// <param name="client"> the client that is connected to the SUMO server </param>
    /// <param name="beginTime"> begin Time: the subscription is executed only in time steps >= this value; in ms </param>
    /// <param name="endTime"> the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms </param>
    /// <param name="objectId"> the id of the object for the context subsription </param>
    /// <param name="contextDomain"> the type of objects in the addressed object's surrounding to ask values from </param>
    /// <param name="contextRange"> the radius of the surrounding </param>
    /// <param name="commandType"> The identifier for the Object Context Subscription command. </param>
    /// <param name="variables"> the list of variables to return </param>
    public void ExecuteSubscribeContextCommand(
        double beginTime,
        double endTime,
        string objectId,
        byte contextDomain,
        double contextRange,
        byte commandType,
        List<byte> variables
    )
        {
        var command = GetCommand(objectId, beginTime, endTime, commandType, variables, contextDomain, contextRange);
        _ = _tcpService.SendMessage(command);
        }

    public IAnswerFromSumo ExecuteGetCommand(byte commandType, byte? messageType = null, string id = null, ITraciType extendVariables = null)
        {
        var command = GetCommand(commandType, messageType, id, extendVariables);
        var response = _tcpService.SendMessage(command);
        try
            {
            return response.ExtractData(commandType, messageType);
            }
        catch
            {
            throw;
            }
        }

    /// <summary>
    /// Helper GetCommand for Object Context Subscription
    /// </summary>
    /// <returns></returns>
    public static TraCICommand GetCommand(
        string objectId,
        double beginTime,
        double endTime,
        byte commandType,
        List<byte> variables,
        byte? contextDomain = null,
        double? contextRange = null
    )
        {
        List<byte> commandPart1 = [
            .. TraCIDouble.AsBytes(beginTime),
            .. TraCIDouble.AsBytes(endTime),
            .. TraCIString.AsBytes(objectId)];
        List<byte> commandPart2 = contextDomain.HasValue ? [contextDomain.Value] : [];
        List<byte> commandPart3 = contextRange.HasValue ? [.. TraCIDouble.AsBytes(contextRange.Value)] : [];
        List<byte> commandPart4 = [(byte)variables.Count, .. variables];
        TraCICommand command = new() { Identifier = commandType, Contents = [.. commandPart1, .. commandPart2, .. commandPart3, .. commandPart4] };
        return command;
        }

    public TraCICommand GetCommand(byte commandType, byte? messageType = null, string id = null, ITraciType contents = null)
        {
        byte[] commandPart1 = messageType.HasValue ? [messageType.Value] : [];
        var commandPart2 = id is null ? [] : TraCIString.AsBytes(id);
        var commandPart3 = contents?.ToBytes() ?? [];
        TraCICommand command = new() { Identifier = commandType, Contents = [.. commandPart1, .. commandPart2, .. commandPart3] };
        return command;
        }
    }
