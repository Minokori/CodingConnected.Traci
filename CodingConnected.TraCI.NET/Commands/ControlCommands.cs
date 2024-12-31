using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
    {
    public class ControlCommands(ITcpService tcpService, ICommandHelperService helper, IEventService events) : TraCICommandsBase(tcpService, helper)
        {
        private readonly IEventService _events = events;
        #region Public Methods

        /// <summary>
        /// Gets an identifying version number as described here: http://sumo.dlr.de/wiki/TraCI/Control-related_commands
        /// </summary>
        public Tuple<int, string> GetVersion()
            {
            TraCICommand command = new()
                {
                Identifier = TraCIConstants.CMD_GETVERSION,
                Contents = null
                };
            var results = _tcpService.SendMessage(command);
            if (((IStatusResponse)results[0]).Result == ResultCode.Success)
                {
                return new(BitConverter.ToInt32(results[1].Content.Take(4).Reverse().ToArray()), ((IStatusResponse)results[1]).Description);
                }
            else
                {
                return new(-1, "");
                }
            }

        /// <summary>
        /// Instruct SUMO to execute a single simulation step
        /// Note: the size of the step is set via the relevant .sumcfg file
        /// </summary>
        /// <param name="targetTime">If this is not 0, SUMO will run until target time is reached</param>
        public TraCIResponse<object> SimStep(double targetTime = 0)
            {

            // 执行一个模拟步骤
            TraCICommand command = new()
                {
                Identifier = TraCIConstants.CMD_SIMSTEP,
                Contents = targetTime.ToTraCIBytes()
                };

            //TODO
            //获得返回值
            var response = _tcpService.SendMessage(command);
            if (response.Count != 1)
                {
                TraCIResponse<object> tmp = TraCIDataConverter.ExtractDataFromResponse<object>(response.ToArray(), TraCIConstants.CMD_SIMSTEP);

                if (tmp.Content != null)
                    {
                    List<ISubscriptionResponse> listOfSubscriptions = tmp.Content as List<ISubscriptionResponse>;
                    foreach (ISubscriptionResponse item in listOfSubscriptions)
                        {
                        SubscriptionEventArgs eventArgs;

                        // subscription can only be VariableType or Context Subrciption. If it isnt the first then it is the latter
                        if (item is TraCIVariableSubscriptionResponse subscription)
                            {
                            eventArgs = new VariableSubscriptionEventArgs(
                                item.ObjectId,
                                item.VariableCount,
                                subscription.ResponseData
                                );
                            }

                        else
                            {
                            TraCIContextSubscriptionResponse i = (item as TraCIContextSubscriptionResponse);
                            eventArgs = new ContextSubscriptionEventArgs
                                (
                                i.ObjectId,
                                i.VariableSubscriptionByObjectId,
                                i.ContextDomain,
                                i.VariableCount,
                                i.ObjectCount
                                );
                            }

                        eventArgs.Responses = item.Responses;

                        switch (item.ResponseCode)
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
                                _events.OnInductionLoopContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            case TraCIConstants.RESPONSE_SUBSCRIBE_LANE_CONTEXT:
                                _events.OnLaneContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            case TraCIConstants.RESPONSE_SUBSCRIBE_VEHICLE_CONTEXT:
                                _events.OnVehicleContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            case TraCIConstants.RESPONSE_SUBSCRIBE_POI_CONTEXT:
                                _events.OnPOIContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            case TraCIConstants.RESPONSE_SUBSCRIBE_POLYGON_CONTEXT:
                                _events.OnPolygonContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            case TraCIConstants.RESPONSE_SUBSCRIBE_JUNCTION_CONTEXT:
                                _events.OnJunctionContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            case TraCIConstants.RESPONSE_SUBSCRIBE_EDGE_CONTEXT:
                                _events.OnEdgeContextSubscription(eventArgs as ContextSubscriptionEventArgs);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                            }
                        }
                    }

                return tmp;
                }
            else { return null; }
            }

        /// <summary>
        /// Instruct SUMO to stop the simulation and close
        /// </summary>
        public void Close()
            {
            TraCICommand command = new()
                {
                Identifier = TraCIConstants.CMD_CLOSE,
                Contents = null
                };
            _ = _tcpService.SendMessage(command);
            }

        /// <summary>
        /// Tells TraCI to reload the simulation with the given options
        /// <remarks>Loading does not work when using multiple clients, currently</remarks>
        /// </summary>
        /// <param name="options">List of options to pass to SUMO</param>
        public void Load(List<string> options)
            {
            TraCICommand command = new()
                {
                Identifier = TraCIConstants.CMD_LOAD
                };
            List<byte> n = [.. (options.Count).ToTraCIBytes()];
            foreach (string opt in options)
                {
                n.AddRange((opt.Length).ToTraCIBytes());
                n.AddRange((opt).ToTraCIBytes());
                }
            command.Contents = [.. n];
            // ReSharper disable once UnusedVariable
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
                Contents = BitConverter.GetBytes(index).Reverse().ToArray()
                };
            _ = _tcpService.SendMessage(command);
            }

        #endregion // Public Methods
        }
    }
