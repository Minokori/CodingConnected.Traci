using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Bus stop related Commands
/// </summary>
/// <param name="sumoConnectService"></param>
/// <param name="traciCommandService"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/BusStop.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class BusStop(
    ISumoConnectService sumoConnectService,
    ITraciCommandService traciCommandService
) : FunctionBase(sumoConnectService, traciCommandService)
    { }
