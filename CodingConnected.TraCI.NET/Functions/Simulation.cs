using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;

/// <summary>
/// Simulation related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// subscribe-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
/// </item>
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Simulation_Value_Retrieval.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_Simulation_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class Simulation(ITCPConnectService tcpService, ICommandService helper) : FunctionBase(tcpService, helper)
    {
    public int GetEmergencyStoppingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_EMERGENCYSTOPPING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    public List<string> GetEmergencyStoppingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_EMERGENCYSTOPPING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// subscribe to a list of variables of simulation
    /// </summary>
    /// <param name="beginTime">the subscription is executed only in time steps &gt;= this value; in ms</param>
    /// <param name="endTime">the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms</param>
    /// <param name="ListOfVariablesToSubsribeTo">The list of variables to return. please refer to <see cref="TraCIConstants"/></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
    /// </remarks>
    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, "", TraCIConstants.CMD_SUBSCRIBE_SIM_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    }
