using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Base class for TraCI Functions
/// </summary>
/// <param name="sumoConnectService">send/receive data to/from traci host</param>
/// <param name="traciCommandService">parse commands/convert contents from response</param>
public abstract class FunctionBase(
    ISumoConnectService sumoConnectService,
    ITraciCommandService traciCommandService
)
    {
    protected ITraciCommandService Helper { get; } = traciCommandService;
    protected ISumoConnectService SumoHelper { get; } = sumoConnectService;

    public virtual void Subscribe(
        string objectId,
        int beginTime,
        int endTime,
        List<byte> VariablesToSubscribeTo
    ) => throw new NotImplementedException();
    }

public abstract class TraciContextSubscribeCommands(
    ISumoConnectService sumoConnectService,
    ITraciCommandService traciCommandService
) : FunctionBase(sumoConnectService, traciCommandService)
    {
    /// <summary>
    /// Cache an empty list of bytes to unsubscribe. Prevents allocation when multiple unsubscribe occur.
    /// </summary>
    private static readonly List<byte> EmptyVariableSubscriptionList = [];

    /// <summary>
    /// Should be overridden and return TraciConstants.CMD_SUBSCRIBE_&lt;CommandIdentifier Domain&gt;_CONTEXT
    /// for the corresponding domain.
    /// </summary>
    /// <remarks>
    /// For a list of supported  EGO-objects see <see href="https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription"/><para/>
    /// i.e VehicleCommands should override it like:<para/>
    /// <example>
    /// protected override byte ContextSubscribeCommand => TraciConstants.CMD_SUBSCRIBE_VEHICLE_CONTEXT;
    /// </example>
    /// </remarks>
    protected abstract CommandIdentifier.Subscribe ContextSubscribeCommand { get; }

    /// <summary>
    /// SubscribeContext for the objects of the domain this class belongs to.
    /// The object the subscription happened under is called EGO object.
    /// Objects of domain <paramref name="contextDomain"/> that are in <paramref name="dist"/> range to the EGO object
    /// have their values returned. The values are based on <paramref name="ListOfVariablesToSubsribeTo"/><para/>
    /// For a list of supported  EGO-objects see <see href="https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription"/>
    /// </summary>
    /// <param name="objectId"> the id of the object for the context subsription </param>
    /// <param name="beginTime"> begin Time: the subscription is executed only in time steps >= this value; in ms </param>
    /// <param name="endTime"> the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms </param>
    /// <param name="contextDomain"> the type of objects in the addressed object's surrounding to ask values from </param>
    /// <param name="dist"> the radius of the surrounding </param>
    /// <param name="variables"> the list of variables to return </param>
    public void SubscribeContext(
        string objectId,
        double beginTime,
        double endTime,
        byte contextDomain,
        double dist,
        List<byte> ListOfVariablesToSubscribeTo
    ) =>
        Helper.ExecuteSubscribeContextCommand(
            beginTime,
            endTime,
            (byte)ContextSubscribeCommand,
            ListOfVariablesToSubscribeTo,
            objectId,
            contextDomain,
            dist
        );

    public void UnsubscribeContext(string objectId, byte contextDomain) =>
        Helper.ExecuteSubscribeContextCommand(
            TraciConstants.InvalidDoubleValue,
            TraciConstants.InvalidDoubleValue,
            (byte)ContextSubscribeCommand,
            EmptyVariableSubscriptionList,
            objectId,
            contextDomain,
            TraciConstants.InvalidDoubleValue
        );
    }
