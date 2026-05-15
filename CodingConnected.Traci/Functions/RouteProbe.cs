using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Router probe related Commands
/// </summary>
/// <param name="sumoConnetService"></param>
/// <param name="traciCommandService"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/RouteProbe.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class RouteProbe(
    ISumoConnectService sumoConnetService,
    ITraciCommandService traciCommandService
) : FunctionBase(sumoConnetService, traciCommandService)
    { }
