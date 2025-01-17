using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;


/// <summary>
/// Induction loop related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// subscribe-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
/// </item>
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Induction_Loop_Value_Retrieval.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_Inductionloop_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class InductionLoop(ITCPConnectService tcpService, ICommandService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_INDUCTIONLOOP_CONTEXT;





    /// <summary>
    /// subscribe to a list of variables of a Induction loop
    /// </summary>
    /// <param name="loopId">Induction loop ID</param>
    /// <param name="beginTime">the subscription is executed only in time steps &gt;= this value; in ms</param>
    /// <param name="endTime">the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms</param>
    /// <param name="ListOfVariablesToSubsribeTo">The list of variables to return. please refer to <see cref="TraCIConstants"/></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
    /// </remarks>
    public void Subscribe(string loopId, double beginTime, double endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(
            beginTime,
            endTime,
            loopId,
            TraCIConstants.CMD_SUBSCRIBE_INDUCTIONLOOP_VARIABLE,
            ListOfVariablesToSubsribeTo
        );
        }
    }
