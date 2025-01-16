using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;
/// <summary>
/// Calibrator related Commands
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Calibrator.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_Calibrator_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class Calibrator(ITCPConnectService tcpService, ICommandService helper) : FunctionBase(tcpService, helper) { }
