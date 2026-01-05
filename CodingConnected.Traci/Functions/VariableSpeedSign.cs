using CodingConnected.Traci.Services;

namespace CodingConnected.Traci.Functions;

/// <summary>
/// Variable speed sign related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/VariableSpeedSign.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class VariableSpeedSign(
    ISumoConnectService tcpService,
    ITraciCommandService helper
) : FunctionBase(tcpService, helper)
    { }
