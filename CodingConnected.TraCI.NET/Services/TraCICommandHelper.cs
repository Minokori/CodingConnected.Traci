using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Services
    {
    internal partial class TraCICommandHelper(ITcpService tcpService) : ICommandHelperService
        {

        private readonly ITcpService _tcpService = tcpService;


        public bool ExecuteSetCommand<Tresponse, Tvalue>(string id, byte commandType, byte messageType, Tvalue value)
        //public TraCIResponse<Tresponse> ExecuteSetCommand<Tresponse, Tvalue>(string id, byte commandType, byte messageType, Tvalue value)
            {
            TraCICommand command;
            switch (value)
                {
                case byte b:
                    command = GetCommand(id, commandType, messageType, b);
                    break;
                case int i:
                    command = GetCommand(id, commandType, messageType, i);
                    break;
                case double d:
                    command = GetCommand(id, commandType, messageType, d);
                    break;
                case string s:
                    command = GetCommand(id, commandType, messageType, s);
                    break;
                case List<string> los:
                    command = GetCommand(id, commandType, messageType, los);
                    break;
                case TraCICompoundObject co:
                    command = GetCommand(id, commandType, messageType, co);
                    break;
                case Color c:
                    command = GetCommand(id, commandType, messageType, c);
                    break;
                case Position2D p2d:
                    command = GetCommand(id, commandType, messageType, p2d);
                    break;
                case Polygon p:
                    command = GetCommand(id, commandType, messageType, p);
                    break;
                case BoundaryBox bb:
                    command = GetCommand(id, commandType, messageType, bb);
                    break;
                default:
                        {
                        throw new InvalidCastException($"Type {value.GetType().Name} is not implemented in method TraCICommandHelper.ExecuteSetCommand().");
                        }
                }

            if (command != null)
                {
                var response = _tcpService.SendMessage(command);
                var result = ((IStatusResponse)response[0]).Result == ResultCode.Success;
                return result;
                //try
                //    {
                //    return TraCIDataConverter.ExtractDataFromResults<Tresponse>([.. response], commandType, messageType);
                //    }
                //catch
                //    {
                //    throw;
                //    }
                }
            else
                {
                return false;
                //return default;
                }
            }

        public void ExecuteSubscribeCommand(double beginTime, double endTime, string objectId, byte commandType, List<byte> variables)
            {
            TraCICommand command = GetCommand(objectId, beginTime, endTime, commandType, variables);
            _ = _tcpService.SendMessage(command);
            }

        /// <summary>
        /// Context subscriptions are allowing the obtaining of specific values from surrounding objects of a certain so called "EGO" object.
        /// With these datas one can determine the traffic status around that EGO object. Such an EGO Object can be any possible Vehicle, inductive loop, points-of-interest, and such like.
        /// A vehicle driving through a city, for example, is surrounded by a lot of different and changing vehicles, lanes, junctions, or points-of-interest along his ride. 
        /// Context subscriptions can provide selected variables of those objects that surround the EGO object within a certain range.
        /// 
        /// <see href="https://sumo.dlr.de/wiki/TraCI/Object_Context_Subscription"/>
        /// </summary>
        /// <remarks>  </remarks>
        /// <param name="client"> the client that is connected to the SUMO server </param>
        /// <param name="beginTime"> begin Time: the subscription is executed only in time steps >= this value; in ms </param>
        /// <param name="endTime"> the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms </param>
        /// <param name="objectId"> the id of the object for the context subsription </param>
        /// <param name="contextDomain"> the type of objects in the addressed object's surrounding to ask values from </param>
        /// <param name="contextRange"> the radius of the surrounding </param>
        /// <param name="commandType"> The identifier for the Object Context Subscription command. </param>
        /// <param name="variables"> the list of variables to return </param>
        public void ExecuteSubscribeContextCommand(double beginTime, double endTime, string objectId, byte contextDomain, double contextRange, byte commandType, List<byte> variables)
            {
            TraCICommand command = GetCommand(objectId, beginTime, endTime, commandType, variables, contextDomain, contextRange);
            _ = _tcpService.SendMessage(command);
            }

        public IAnswerFromSumo ExecuteGetCommand(string id, byte commandType, byte messageType)
            {
            TraCICommand command = GetCommand(id, commandType, messageType);
            var response = _tcpService.SendMessage(command);
            try
                {
                return TraCIDataConverter.ExtractDataFromResults(response, commandType, messageType);
                }
            catch
                {
                throw;
                }
            }

        public static TraCICommand GetCommand(string objectId, double beginTime, double endTime, byte commandType, List<byte> variables)
            {
            List<byte> bytes =
                [
                .. beginTime.ToTraCIBytes(),
                .. endTime.ToTraCIBytes(),
                .. objectId.ToTraCIBytes(),
                (byte)variables.Count,
                .. variables,
                ];

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = [.. bytes]
                };
            return command;
            }

        /// <summary>
        /// Helper GetCommand for Object Context Subscription
        /// </summary>
        /// <returns></returns>
        public static TraCICommand GetCommand(string objectId, double beginTime, double endTime, byte commandType, List<byte> variables, byte contextDomain, double contextRange)
            {
            List<byte> bytes =
                [
                .. beginTime.ToTraCIBytes(),
                .. endTime.ToTraCIBytes(),
                .. objectId.ToTraCIBytes(),
                contextDomain,
                .. contextRange.ToTraCIBytes(),
                (byte)variables.Count,
                .. variables,
                ];

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = [.. bytes]
                };
            return command;
            }


        }
    }

