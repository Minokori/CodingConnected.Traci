using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.ProtocolTypes;
using CodingConnected.TraCI.NET.Services;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Command;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Response.Subscribe;
namespace CodingConnected.TraCI.NET.Functions;

/// <summary>
/// Control-related commands
/// </summary>
/// <param name="tcpService"><see cref="ITCPConnectService"/></param>
/// <param name="helper"><see cref="ICommandService"/></param>
/// <param name="eventService"><see cref="IEventService"/> </param>
/// <remarks>
/// <list type="bullet">
/// <item>
/// all-commands see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html"/>
/// </item>
/// </list>
/// </remarks>
public class Control(ITCPConnectService tcpService, ICommandService helper, IEventService eventService) : FunctionBase(tcpService, helper)
    {
    private readonly IEventService _events = eventService;

    /// <summary>
    /// Returns a tuple containing the TraCI API Version number (integer) and a string identifying the SUMO apiVersion running on the TraCI server in human-readable form.
    /// </summary>
    /// <returns>
    /// <list type="bullet">
    /// <item>
    /// an <see cref="int"/> API Version number identifying the current state of the TraCI API. <para/>
    /// </item>
    /// <item>
    /// an identifier <see cref="string"/> identifies the software apiVersion running on the TraCI server in human-readable form. <para/>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x00_get_version"/>
    /// </remarks>
    public Tuple<int, string> GetVersion()
        {
        var command = _helper.GetCommand(GETVERSION);
        var results = _tcpService.SendMessage(command);
        switch ((results[0] as IStatusResponse).Result)
            {
            case ResultCode.Success:
                    {
                    (var apiVersion, var leftBytes) = TraciInteger.FromBytes(results[1].Content);
                    (var version, _) = TraciString.FromBytes(leftBytes);
                    if (apiVersion.Value != TRACI_VERSION)
                        {
                        Console.WriteLine($"Warning: TraCI API version mismatch." +
                            $" SUMO installed with API version : {apiVersion.Value}." +
                            $" This library is using API version {TRACI_VERSION}.");
                        }
                    return new(apiVersion.Value, version.Value);
                    }
            default:
                    {
                    return new(-1, "");
                    }
            }
        }

    /// <summary>
    /// Make a simulation step. <para/>
    /// Note: the size of the step is set via the relevant *.sumcfg file. <para/>
    /// if you have any subscription, the responses will be handled by the <see cref="IEventService"/>. Please add your event handler to use the responses.<para/>
    /// </summary>
    /// <param name="targetTime">If this is not 0, SUMO will run until target time is reached</param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x02_simulation_step"/>
    /// </remarks>
    public void SimStep(double targetTime = 0)
        {
        // make a simulation step
        var command = _helper.GetCommand(SIMSTEP, contents: new TraciDouble(targetTime));
        // get the results
        var results = _tcpService.SendMessage(command);
        if (results.Count != 1)
            {
            var responses = results.ExtractSimStepData();
            if (responses != null) { return; }

            foreach (var item in responses)
                {
                SubscriptionEventArgs? eventArgs = null;
                switch (item.Identifier >> 4)
                    {
                    case 0x0e: // 0xeX => VariableType Subscription Content
                            {
                            eventArgs = new VariableSubscriptionEventArgs(item.ObjectId.Value, item.VariableCount.Value);
                            break;
                            }
                    case 0x09: // 0x9X => Object Context Subscription Content
                            {
                            var c = item as TraCIContextSubscriptionResponse;
                            eventArgs = new ContextSubscriptionEventArgs(
                                c.ObjectId.Value,
                                c.ContextDomain.Value,
                                c.VariableCount.Value,
                                c.ObjectCount.Value
                            );
                            break;
                            }
                    default:
                        break;
                    }

                if (eventArgs is null)
                    {
                    return;
                    }
                eventArgs.Responses = item.Responses;

                switch (item.Identifier)
                    {
                    case INDUCTIONLOOP_VARIABLE:
                        _events.OnInductionLoopSubscription(eventArgs);
                        break;
                    case MULTIENTRYEXIT_VARIABLE:
                        _events.OnMultiEntryExitSubscription(eventArgs);
                        break;
                    case TL_VARIABLE:
                        _events.OnTrafficLightSubscription(eventArgs);
                        break;
                    case LANE_VARIABLE:
                        _events.OnLaneSubscription(eventArgs);
                        break;
                    case VEHICLE_VARIABLE:
                        _events.OnVehicleSubscription(eventArgs);
                        break;
                    case VEHICLETYPE_VARIABLE:
                        _events.OnVehicleTypeSubscription(eventArgs);
                        break;
                    case ROUTE_VARIABLE:
                        _events.OnRouteSubscription(eventArgs);
                        break;
                    case POI_VARIABLE:
                        _events.OnPOISubscription(eventArgs);
                        break;
                    case POLYGON_VARIABLE:
                        _events.OnPolygonSubscription(eventArgs);
                        break;
                    case JUNCTION_VARIABLE:
                        _events.OnJunctionSubscription(eventArgs);
                        break;
                    case EDGE_VARIABLE:
                        _events.OnEdgeSubscription(eventArgs);
                        break;
                    case SIM_VARIABLE:
                        _events.OnSimulationSubscription(eventArgs);
                        break;
                    case GUI_VARIABLE:
                        _events.OnGUISubscription(eventArgs);
                        break;
                    case LANEAREA_VARIABLE:
                        _events.OnLaneAreaSubscription(eventArgs);
                        break;
                    case PERSON_VARIABLE:
                        _events.OnPersonSubscription(eventArgs);
                        break;
                    case INDUCTIONLOOP_CONTEXT:
                        _events.OnInductionLoopContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case LANE_CONTEXT:
                        _events.OnLaneContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case VEHICLE_CONTEXT:
                        _events.OnVehicleContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case POI_CONTEXT:
                        _events.OnPOIContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case POLYGON_CONTEXT:
                        _events.OnPolygonContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case JUNCTION_CONTEXT:
                        _events.OnJunctionContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case EDGE_CONTEXT:
                        _events.OnEdgeContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    default:
                        throw new Exception();
                    }
                }
            }
        }

    /// <summary>
    /// Performs only the first part of a simulation step until the vehicles have moved but before the outputs are generated.
    /// A subsequent call to simulation step will then create the output.
    /// </summary>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x7d_execute_move"/>
    /// </remarks>
    public void ExecuteMove()
        {
        var command = _helper.GetCommand(EXECUTE_MOVE);
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Tells TraCI to close the connection to any client, stop simulation and shut down sumo.
    /// </summary>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x7f_close"/>
    /// </remarks>
    public void Close()
        {
        var command = _helper.GetCommand(CLOSE);
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Let sumo load a simulation using the given command line like options
    /// </summary>
    /// <param name="options">List of options to pass to SUMO</param>
    /// <remarks>
    /// Loading does not work when using multiple clients, currently<para/>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x01_load"/>
    /// </remarks>

    public void Load(List<string> options)
        {
        var command = _helper.GetCommand(LOAD, contents: new TraciStringList(options));
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Tells TraCI to give the current client the given position in the execution order.
    /// It is mandatory to send this as the first command after connecting to the TraCI server when using multiple clients.
    /// Each client must be assigned a unique integer but there are not further restrictions on numbering.
    /// </summary>
    /// <param name="index">Specify the execution order (when using multiple clients)</param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x03_setorder"/>
    /// </remarks>
    public void SetOrder(int index)
        {
        var command = _helper.GetCommand(SETORDER, contents: new TraciInteger(index));
        _ = _tcpService.SendMessage(command);
        }
    }
