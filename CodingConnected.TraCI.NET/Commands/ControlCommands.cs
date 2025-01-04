using System.Diagnostics;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Commands;

/// <summary>
/// Control-related commands
/// </summary>
/// <param name="tcpService"><see cref="ITcpService"/></param>
/// <param name="helper"><see cref="ICommandHelperService"/></param>
/// <param name="eventService"><see cref="IEventService"/> </param>
public class ControlCommands(ITcpService tcpService, ICommandHelperService helper, IEventService eventService) : TraCICommandsBase(tcpService, helper)
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
        TraCICommand command = new() { Identifier = CMD_GETVERSION, Contents = null };

        var results = _tcpService.SendMessage(command);
        switch ((results[0] as IStatusResponse).Result)
            {
            case ResultCode.Success:
                    {
                    (var apiVersion, var leftBytes) = TraCIInteger.FromBytes(results[1].Content);
                    (var versionString, leftBytes) = TraCIString.FromBytes(leftBytes);
                    if (apiVersion.Value != TRACI_VERSION)
                        {
                        Console.WriteLine(
                            $"Warning: TraCI API version mismatch. SUMO installed with API version is {apiVersion.Value}. this library is using API version {TRACI_VERSION}"
                        );
                        }
                    if (leftBytes.Any())
                        {
                        Debug.WriteLine("not all bytes are consumed");
                        }
                    return new(apiVersion.Value, versionString.Value);
                    }
            default:
                    {
                    return new(-1, "");
                    }
            }
        }

    /// <summary>
    /// Make a simulation step. <para/>
    /// Note: the size of the step is set via the relevant .sumcfg file. <para/>
    /// if you have any subscription, the responses will be handled by the <see cref="IEventService"/>. Please add your event handler to use the responses.<para/>
    /// </summary>
    /// <param name="targetTime">If this is not 0, SUMO will run until target time is reached</param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Control-related_commands.html#command_0x02_simulation_step"/>
    /// </remarks>
    public void SimStep(double targetTime = 0)
        {
        // make a simulation step
        TraCICommand command = new() { Identifier = CMD_SIMSTEP, Contents = targetTime.ToTraCIBytes() };

        // get the results
        var results = _tcpService.SendMessage(command);
        if (results.Count != 1)
            {
            var responses = TraCIDataConverter.ExtractDataFromSimStepResults(results);
            if (responses != null)
                {
                return;
                }

            foreach (var item in responses)
                {
                SubscriptionEventArgs eventArgs = null;
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
                    case RESPONSE_SUBSCRIBE_INDUCTIONLOOP_VARIABLE:
                        _events.OnInductionLoopSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_MULTIENTRYEXIT_VARIABLE:
                        _events.OnMultiEntryExitSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_TL_VARIABLE:
                        _events.OnTrafficLightSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_LANE_VARIABLE:
                        _events.OnLaneSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_VEHICLE_VARIABLE:
                        _events.OnVehicleSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_VEHICLETYPE_VARIABLE:
                        _events.OnVehicleTypeSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_ROUTE_VARIABLE:
                        _events.OnRouteSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_POI_VARIABLE:
                        _events.OnPOISubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_POLYGON_VARIABLE:
                        _events.OnPolygonSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_JUNCTION_VARIABLE:
                        _events.OnJunctionSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_EDGE_VARIABLE:
                        _events.OnEdgeSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_SIM_VARIABLE:
                        _events.OnSimulationSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_GUI_VARIABLE:
                        _events.OnGUISubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_LANEAREA_VARIABLE:
                        _events.OnLaneAreaSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_PERSON_VARIABLE:
                        _events.OnPersonSubscription(eventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_INDUCTIONLOOP_CONTEXT:
                        _events.OnInductionLoopContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_LANE_CONTEXT:
                        _events.OnLaneContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_VEHICLE_CONTEXT:
                        _events.OnVehicleContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_POI_CONTEXT:
                        _events.OnPOIContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_POLYGON_CONTEXT:
                        _events.OnPolygonContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_JUNCTION_CONTEXT:
                        _events.OnJunctionContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case RESPONSE_SUBSCRIBE_EDGE_CONTEXT:
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
        TraCICommand command = new() { Identifier = CMD_EXECUTE_MOVE, Contents = null };
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
        TraCICommand command = new() { Identifier = CMD_CLOSE, Contents = null };
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

    public void Load(IEnumerable<string> options)
        {
        TraCICommand command = new() { Identifier = CMD_LOAD };
        List<byte> n = [.. options.Count().ToTraCIBytes()];
        foreach (var option in options)
            {
            n = [.. n, .. option.Length.ToTraCIBytes(), .. option.ToTraCIBytes()];
            }
        command.Contents = [.. n];
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
        TraCICommand command = new() { Identifier = CMD_SETORDER, Contents = index.ToTraCIBytes() };
        _ = _tcpService.SendMessage(command);
        }
    }
