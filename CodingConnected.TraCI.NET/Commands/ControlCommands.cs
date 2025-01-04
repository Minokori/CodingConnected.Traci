using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class ControlCommands(ITcpService tcpService, ICommandHelperService helper, IEventService eventService) : TraCICommandsBase(tcpService, helper)
    {
    private readonly IEventService _events = eventService;

    /// <summary>
    /// Gets an identifying version number as described here: <see href="http://sumo.dlr.de/wiki/TraCI/Control-related_commands"/>
    /// </summary>
    public Tuple<int, string> GetVersion()
        {
        TraCICommand command = new()
            {
            Identifier = TraCIConstants.CMD_GETVERSION,
            Contents = null,
            };

        var results = _tcpService.SendMessage(command);
        return ((IStatusResponse)results[0]).Result == ResultCode.Success
            ? new(
                BitConverter.ToInt32(results[1].Content.Take(4).Reverse().ToArray()),
                ((IStatusResponse)results[1]).Description
            )
            : new(-1, "");
        }

    /// <summary>
    /// Instruct SUMO to execute a single simulation step
    /// Note: the size of the step is set via the relevant .sumcfg file
    /// </summary>
    /// <param name="targetTime">If this is not 0, SUMO will run until target time is reached</param>
    public void SimStep(double targetTime = 0)
        {
        // 执行一个模拟步骤
        TraCICommand command = new()
            {
            Identifier = TraCIConstants.CMD_SIMSTEP,
            Contents = targetTime.ToTraCIBytes(),
            };

        //TODO
        //获得返回值
        var results = _tcpService.SendMessage(command);
        if (results.Count != 1)
            {
            var responses = TraCIDataConverter.ExtractDataFromSimStepResults([.. results]);
            if (responses != null)
                {
                return;
                }
            // 0xeX => VariableType Subscription Content
            // 0x9X => Object Context Subscription Content
            foreach (var item in responses)
                {
                SubscriptionEventArgs eventArgs = null;
                switch (item.Identifier >> 4)
                    {
                    case 0x0e:
                            {
                            eventArgs = new VariableSubscriptionEventArgs(item.ObjectId.Value, item.VariableCount.Value);
                            break;
                            }
                    case 0x09:
                            {
                            var c = item as ContextSubscriptionResponse;
                            eventArgs = new ContextSubscriptionEventArgs(
                                c.ObjectId.Value,
                                c.ContextDomain.Value,
                                c.VariableCount.Value,
                                c.ObjectCount.Value);
                            break;
                            }
                    default:
                        break;
                    }
                eventArgs.Responses = item.Responses;
                if (eventArgs is null) { return; }

                switch (item.Identifier)
                    {
                    case TraCIConstants.RESPONSE_SUBSCRIBE_INDUCTIONLOOP_VARIABLE:
                        _events.OnInductionLoopSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_MULTIENTRYEXIT_VARIABLE:
                        _events.OnMultiEntryExitSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_TL_VARIABLE:
                        _events.OnTrafficLightSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_LANE_VARIABLE:
                        _events.OnLaneSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_VEHICLE_VARIABLE:
                        _events.OnVehicleSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_VEHICLETYPE_VARIABLE:
                        _events.OnVehicleTypeSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_ROUTE_VARIABLE:
                        _events.OnRouteSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_POI_VARIABLE:
                        _events.OnPOISubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_POLYGON_VARIABLE:
                        _events.OnPolygonSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_JUNCTION_VARIABLE:
                        _events.OnJunctionSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_EDGE_VARIABLE:
                        _events.OnEdgeSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_SIM_VARIABLE:
                        _events.OnSimulationSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_GUI_VARIABLE:
                        _events.OnGUISubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_LANEAREA_VARIABLE:
                        _events.OnLaneAreaSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_PERSON_VARIABLE:
                        _events.OnPersonSubscription(eventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_INDUCTIONLOOP_CONTEXT:
                        _events.OnInductionLoopContextSubscription(
                            eventArgs as ContextSubscriptionEventArgs
                        );
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_LANE_CONTEXT:
                        _events.OnLaneContextSubscription(
                            eventArgs as ContextSubscriptionEventArgs
                        );
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_VEHICLE_CONTEXT:
                        _events.OnVehicleContextSubscription(
                            eventArgs as ContextSubscriptionEventArgs
                        );
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_POI_CONTEXT:
                        _events.OnPOIContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_POLYGON_CONTEXT:
                        _events.OnPolygonContextSubscription(
                            eventArgs as ContextSubscriptionEventArgs
                        );
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_JUNCTION_CONTEXT:
                        _events.OnJunctionContextSubscription(
                            eventArgs as ContextSubscriptionEventArgs
                        );
                        break;
                    case TraCIConstants.RESPONSE_SUBSCRIBE_EDGE_CONTEXT:
                        _events.OnEdgeContextSubscription(
                            eventArgs as ContextSubscriptionEventArgs
                        );
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    }
                }


            }
        }

    /// <summary>
    /// Instruct SUMO to stop the simulation and close
    /// </summary>
    public void Close()
        {
        TraCICommand command = new() { Identifier = TraCIConstants.CMD_CLOSE, Contents = null };
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Tells TraCI to reload the simulation with the given options
    /// <remarks>Loading does not work when using multiple clients, currently</remarks>
    /// </summary>
    /// <param name="options">List of options to pass to SUMO</param>
    public void Load(List<string> options)
        {
        TraCICommand command = new() { Identifier = TraCIConstants.CMD_LOAD };
        List<byte> n = [.. options.Count.ToTraCIBytes()];
        foreach (var option in options)
            {
            n = [.. n, .. option.Length.ToTraCIBytes(), .. option.ToTraCIBytes()];
            }
        command.Contents = [.. n];
        _ = _tcpService.SendMessage(command);
        }

    /// <summary>
    /// Tells TraCI to reload the simulation with the given options
    /// <remarks>Loading does not work when using multiple clients, currently</remarks>
    /// </summary>
    /// <param name="options">List of options to pass to SUMO</param>
    public void SetOrder(int index)
        {
        TraCICommand command = new()
            {
            Identifier = TraCIConstants.CMD_SETORDER,
            Contents = BitConverter.GetBytes(index).Reverse().ToArray(),
            };
        _ = _tcpService.SendMessage(command);
        }
    }
