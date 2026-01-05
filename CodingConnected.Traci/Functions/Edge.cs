using CodingConnected.Traci.Services;
using Microsoft.Extensions.Logging;
namespace CodingConnected.Traci.Functions;


/// <summary>
/// Edge related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// subscribe-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
/// </item>
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Edge_Value_Retrieval.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_Edge_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class Edge(ISumoConnectService tcpService, ITraciCommandService helper) : TraciContextSubscribeCommands(tcpService, helper)
    {
    protected override CommandIdentifier.Subscribe ContextSubscribeCommand => CommandIdentifier.Subscribe.EdgeContext;

    /// <summary>
    /// subscribe to a list of variables of a edge
    /// </summary>
    /// <param name="edgeId">edge ID</param>
    /// <param name="beginTime">the subscription is executed only in time steps &gt;= this value; in ms</param>
    /// <param name="endTime">the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms</param>
    /// <param name="ListOfVariablesToSubsribeTo">The list of variables to return. please refer to <see cref="TraciConstants"/></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
    /// </remarks>
    public void Subscribe(string edgeId, double beginTime, double endTime, List<byte> ListOfVariablesToSubsribeTo) => Helper.ExecuteSubscribeCommand(beginTime, endTime, (byte)CommandIdentifier.Subscribe.EdgeVariable, ListOfVariablesToSubsribeTo, edgeId);
    }
