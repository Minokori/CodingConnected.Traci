using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Charging Station related Commands
/// </summary>
/// <param name="sumoConnectService"></param>
/// <param name="traciCommandService"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/ChargingStation.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_ChargingStation_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class ChargingStation(
    ISumoConnectService sumoConnectService,
    ITraciCommandService traciCommandService
) : FunctionBase(sumoConnectService, traciCommandService)
    { }
