using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Helpers
    {
    internal class TraCICommandHelper(ITcpService tcpService) : ICommandHelperService
        {

        private readonly ITcpService _tcpService = tcpService;

        public TraCIResponse<Tresponse> ExecuteSetCommand<Tresponse, Tvalue>(string id, byte commandType, byte messageType, Tvalue value)
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
                case CompoundObject co:
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
                TraCIResult[] response = _tcpService.SendMessage(command);

                try
                    {
                    return TraCIDataConverter.ExtractDataFromResponse<Tresponse>(response, commandType, messageType);
                    }
                catch
                    {
                    throw;
                    }
                }
            else
                {
                return default;
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
            TraCICommand command = GetCommand(objectId, beginTime, endTime, contextDomain, contextRange, commandType, variables);
            _ = _tcpService.SendMessage(command);
            }

        public TraCIResponse<T> ExecuteGetCommand<T>(string id, byte commandType, byte messageType)
            {
            TraCICommand command = GetCommand(id, commandType, messageType);
            TraCIResult[] response = _tcpService.SendMessage(command);

            try
                {
                return TraCIDataConverter.ExtractDataFromResponse<T>(response, commandType, messageType);
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
                .. TraCIDataConverter.GetTraCIBytesFromDouble(beginTime),
                .. TraCIDataConverter.GetTraCIBytesFromDouble(endTime),
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(objectId),
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
        public static TraCICommand GetCommand(string objectId, double beginTime, double endTime, byte contextDomain, double contextRange, byte commandType, List<byte> variables)
            {
            List<byte> bytes =
                [
                .. TraCIDataConverter.GetTraCIBytesFromDouble(beginTime),
                .. TraCIDataConverter.GetTraCIBytesFromDouble(endTime),
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(objectId),
                contextDomain,
                .. TraCIDataConverter.GetTraCIBytesFromDouble(contextRange),
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

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, CompoundObject co)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_COMPOUND,
                .. TraCIDataConverter.GetTraCIBytesFromInt32(co.Value.Count),
                ];
            foreach (ComposedTypeBase item in co.Value)
                {
                switch (item)
                    {
                    case TraCIByte b:
                        bytes.Add(TraCIConstants.TYPE_BYTE);
                        bytes.Add(b.Value);
                        break;
                    case TraCIUByte ub:
                        bytes.Add(TraCIConstants.TYPE_UBYTE);
                        bytes.Add(ub.Value);
                        break;
                    case TraCIInteger i:
                        bytes.Add(TraCIConstants.TYPE_INTEGER);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(i.Value));
                        break;
                    case TraCIFloat f:
                        bytes.Add(TraCIConstants.TYPE_FLOAT);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromFloat(f.Value));
                        break;
                    case TraCIDouble d:
                        bytes.Add(TraCIConstants.TYPE_DOUBLE);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(d.Value));
                        break;
                    case TraCIString s:
                        bytes.Add(TraCIConstants.TYPE_STRING);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(s.Value));
                        break;
                    case TraCIStringList sl:
                        bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIStringList(sl.Value));
                        break;
                    case CompoundObject CO:
                        throw new NotImplementedException("Nested compound objects are not implemented yet");
                    case Position2D p2d:
                        bytes.Add(TraCIConstants.POSITION_2D);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromPosition2D(p2d));
                        break;
                    case Position3D p3d:
                        bytes.Add(TraCIConstants.POSITION_3D);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromPosition3D(p3d));
                        break;
                    case RoadMapPosition rmp:
                        bytes.Add(TraCIConstants.POSITION_ROADMAP);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromRoadMapPosition(rmp));
                        break;
                    case LonLatPosition llp:
                        bytes.Add(TraCIConstants.POSITION_LON_LAT);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromLonLatPosition(llp));
                        break;
                    case LonLatAltPosition llap:
                        bytes.Add(TraCIConstants.POSITION_LON_LAT_ALT);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromLonLatAltPosition(llap));
                        break;
                    case BoundaryBox bb:
                        bytes.Add(TraCIConstants.TYPE_BOUNDINGBOX);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromBoundaryBox(bb));
                        break;
                    case Polygon p:
                        bytes.Add(TraCIConstants.TYPE_POLYGON);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromPolygon(p));
                        break;
                    case TrafficLightPhaseList tlpl:
                        bytes.Add(TraCIConstants.TYPE_TLPHASELIST);
                        bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromTrafficLightPhaseList(tlpl));
                        break;
                    case Color c:
#warning missing code
                        throw new NotImplementedException();
                    }
                }

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = [.. bytes]
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType)
            {
            List<byte> bytes = [messageType, .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id)];
            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = [.. bytes]
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, BoundaryBox boundaryBox)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_BOUNDINGBOX,
                .. TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.LowerLeftX),
                .. TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.LowerLeftY),
                .. TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.UpperRightX),
                .. TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.UpperRightY),
                ];

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, Polygon polygon)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_POLYGON,
                (byte)polygon.Points.Count,
                ];
            foreach (Position2D point in polygon.Points)
                {
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(point.X));
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(point.Y));
                }

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, Position2D position2D)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.POSITION_2D,
                .. TraCIDataConverter.GetTraCIBytesFromDouble(position2D.X),
                .. TraCIDataConverter.GetTraCIBytesFromDouble(position2D.Y),
                ];

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, Color color)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_COLOR,
                color.R,
                color.G,
                color.B,
                color.A,
                ];

            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, List<string> values)
            {
            List<byte> bytes = [messageType, .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id)];

            if (values != null && values.Count > 0)
                {
                bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(values.Count));
                foreach (string parameter in values)
                    {
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(parameter));
                    }
                }
            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, string value)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_STRING,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(value),
                ];
            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, double value)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_DOUBLE,
                .. TraCIDataConverter.GetTraCIBytesFromDouble(value),
                ];
            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, int value)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_INTEGER,
                .. TraCIDataConverter.GetTraCIBytesFromInt32(value),
                ];
            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }

        public static TraCICommand GetCommand(string id, byte commandType, byte messageType, byte value)
            {
            List<byte> bytes =
                [
                messageType,
                .. TraCIDataConverter.GetTraCIBytesFromASCIIString(id),
                TraCIConstants.TYPE_BYTE,
                value,
                ];
            TraCICommand command = new()
                {
                Identifier = commandType,
                Contents = bytes.ToArray()
                };
            return command;
            }


        }
    }

