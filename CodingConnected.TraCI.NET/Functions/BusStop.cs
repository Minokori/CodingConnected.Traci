using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Bus stop related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/BusStop.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class BusStop(ITcpConnectService tcpService, ICommandService helper, IDebugService logger) : FunctionBase(tcpService, helper, logger) { }
