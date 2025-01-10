using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;


/// <summary>
/// Lane Area Detector (E2 Detector) related Commands<para/>
/// <u>Warning: some contents in <see href="https://sumo.dlr.de/docs/TraCI/Lane_Area_Detector_Value_Retrieval.html"/> have error, we haven't check them out yet.</u>
/// </summary>
/// <param name="tcpService"></param>
/// <param name="helper"></param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// subscribe-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
/// </item>
/// <item>
/// get-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Lane_Area_Detector_Value_Retrieval.html"/>
/// </item>
/// <item>
///  set-commands part see <see href="https://sumo.dlr.de/docs/TraCI/Change_Lane_Area_Detector_State.html"/>
/// </item>
/// </list>
/// </remarks>
public partial class LaneAreaDetector(ITCPConnectService tcpService, ICommandService helper) : FunctionBase(tcpService, helper)
    {
    /// <summary>
    /// subscribe to a list of variables of a E2 detector
    /// </summary>
    /// <param name="detectorId">vehicle type ID</param>
    /// <param name="beginTime">the subscription is executed only in time steps >= this value; in ms</param>
    /// <param name="endTime">the subscription is executed in time steps <= this value; the subscription is removed if the simulation has reached a higher time step; in ms</param>
    /// <param name="ListOfVariablesToSubsribeTo">The list of variables to return. please refer to <see cref="TraCIConstants"/></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
    /// </remarks>
    public void Subscribe(string detectorId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, detectorId, TraCIConstants.CMD_SUBSCRIBE_LANEAREA_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    }
