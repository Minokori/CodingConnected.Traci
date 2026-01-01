using CodingConnected.Traci.Services;
using Microsoft.Extensions.Logging;
namespace CodingConnected.Traci.Functions;

/// <summary>
/// Parking area related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/ParkingArea.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_ParkingArea_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class ParkingArea(ISumoConnectService tcpService, ITraciCommandService helper, ILogger logger) : FunctionBase(tcpService, helper, logger)
    {

    }
