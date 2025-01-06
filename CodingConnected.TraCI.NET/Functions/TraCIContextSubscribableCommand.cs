using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public abstract class TraCIContextSubscribableCommands(ITCPConnectService tcpService, ICommandService helper) : TraCICommandsBase(tcpService, helper)
    {
    // Cache an empty list of bytes to unsubscribe. Prevents allocation when multiple unsubscribe occur.
    private static readonly List<byte> EmptyVariableSubscriptionList = [];

    /// <summary>
    /// Should be overriden and return TraCIConstants.CMD_SUBSCRIBE_&lt; Command Domain &gt;_CONTEXT 
    /// for the corresponding domain.
    /// <para>
    /// For a list of supported  EGO-objects see <see href="https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription"/>
    /// </para>
    /// i.e VehicleCommands should override it like:
    /// 
    /// <example>
    /// protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_VEHICLE_CONTEXT;
    /// </example>
    /// </summary>
    protected abstract byte ContextSubscribeCommand { get; }


    /// <summary>
    /// SubscribeContext for the objects of the domain this class belongs to. The object the subscription happened under 
    /// is called EGO object.
    /// 
    /// Objects of domain <paramref name="contextDomain"/> that are in <paramref name="dist"/> range to the EGO object
    /// have their values returned. The values are based on <paramref name="ListOfVariablesToSubsribeTo"/>
    /// 
    /// <para>
    /// For a list of supported  EGO-objects see <see href="https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription"/>
    /// </para>
    /// </summary>
    /// <param name="objectId"> the id of the object for the context subsription </param>
    /// <param name="beginTime"> begin Time: the subscription is executed only in time steps >= this value; in ms </param>
    /// <param name="endTime"> the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms </param>
    /// <param name="contextDomain"> the type of objects in the addressed object's surrounding to ask values from </param>
    /// <param name="dist"> the radius of the surrounding </param>
    /// <param name="variables"> the list of variables to return </param>
    public void SubscribeContext(string objectId, double beginTime, double endTime, byte contextDomain, double dist, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeContextCommand(
        beginTime,
        endTime,
        objectId,
        contextDomain,
        dist,
        ContextSubscribeCommand,
        ListOfVariablesToSubsribeTo);
        }

    public void UnsubscribeContext(string objectId, byte contextDomain)
        {
        _helper.ExecuteSubscribeContextCommand(
            TraCIConstants.INVALID_DOUBLE_VALUE,
        TraCIConstants.INVALID_DOUBLE_VALUE,
        objectId,
        contextDomain,
        TraCIConstants.INVALID_DOUBLE_VALUE,
        ContextSubscribeCommand,
        EmptyVariableSubscriptionList);
        }

    }

