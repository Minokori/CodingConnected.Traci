using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// rerouter related Commands
/// </summary>
/// <param name="sumoConnnectService"></param>
/// <param name="traciCommandService"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Rerouter.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class Rerouter(ISumoConnectService sumoConnnectService, ITraciCommandService traciCommandService)
    : FunctionBase(sumoConnnectService, traciCommandService)
    { }
