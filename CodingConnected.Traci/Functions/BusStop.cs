using CodingConnected.Traci.Services;
using Microsoft.Extensions.Logging;

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
public partial class BusStop(ISumoConnectService tcpService, ITraciCommandService helper) : FunctionBase(tcpService, helper) { }
