using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Person related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// subscribe-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
/// </item>
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Person_Value_Retrieval.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_Person_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class Person(ITCPConnectService tcpService, ICommandService helper, IDebugService logger) : FunctionBase(tcpService, helper, logger)
    {
    /// <summary>
    /// subscribe to a list of variables of a person
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="beginTime">the subscription is executed only in time steps >= this value; in ms</param>
    /// <param name="endTime">the subscription is executed in time steps <= this value; the subscription is removed if the simulation has reached a higher time step; in ms</param>
    /// <param name="VariablesToSubscribeTo">The list of variables to return. please refer to <see cref="TraciConstants"/></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
    /// </remarks>
    public override void Subscribe(string personId, int beginTime, int endTime, List<byte> VariablesToSubscribeTo) => _helper.ExecuteSubscribeCommand(beginTime, endTime, (byte)CommandIdentifier.Subscribe.PERSON_VARIABLE, VariablesToSubscribeTo, personId);
    }
