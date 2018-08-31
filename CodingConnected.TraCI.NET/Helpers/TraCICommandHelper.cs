﻿using CodingConnected.TraCI.NET.Types;
using System;
using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Helpers
{
	internal static class TraCICommandHelper
	{
        internal static TraCIResponse<Tres> ExecuteSetCommand<Tres, Tvalue>(TraCIClient client, string id, byte commandType, byte messageType, Tvalue value)
        {
            TraCICommand command = null;

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
                var response = client.SendMessage(command);

                try
                {
                    return TraCIDataConverter.ExtractDataFromResponse<Tres>(response, commandType, messageType);
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

        internal static void ExecuteSubscribeCommand(TraCIClient client, int beginTime, int endTime, string objectId, byte commandType, List<byte> variables)
        {
            TraCICommand command = null;
            command = GetCommand(objectId, beginTime, endTime, commandType, variables);
            var response = client.SendMessage(command);

            //try
            //{
            //    var tmp = TraCIDataConverter.ExtractDataFromResponse<T>(response, commandType);
            //}
            //catch
            //{
            //    throw;
            //}
        }

        internal static TraCIResponse<T> ExecuteGetCommand<T>(TraCIClient client, string id, byte commandType, byte messageType)
        {
            var command = GetCommand(id, commandType, messageType);
            var response = client.SendMessage(command);

            try
            {
                return TraCIDataConverter.ExtractDataFromResponse<T>(response, commandType, messageType); 
            }
            catch
            {
                throw;
            }
        }

        internal static TraCICommand GetCommand(string objectId, int beginTime, int endTime, byte commandType, List<byte> variables)
        {
            var bytes = new List<byte>();
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(beginTime));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(endTime));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(objectId));
            bytes.Add((byte)variables.Count);
            foreach (var variable in variables)
            {
                bytes.Add(variable);
            }

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, CompoundObject co)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_COMPOUND);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(co.Value.Count));
            foreach (var item in co.Value)
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
                        break;
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
                        break;
            } }

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType)
		{
			var bytes = new List<byte> { messageType };
			bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
			var command = new TraCICommand
			{
				Identifier = commandType,
				Contents = bytes.ToArray()
			};
			return command;
		}

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, BoundaryBox boundaryBox)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_BOUNDINGBOX);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.LowerLeftX));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.LowerLeftY));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.UpperRightX));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(boundaryBox.UpperRightY));

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, Polygon polygon)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_POLYGON);
            bytes.Add((byte)polygon.Points.Count);
            foreach (var point in polygon.Points)
            {
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(point.X));
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(point.Y));
            }

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, Position2D position2D)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.POSITION_2D);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(position2D.X));
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(position2D.Y));

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, Color color)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_COLOR);
            bytes.Add(color.R);
            bytes.Add(color.G);
            bytes.Add(color.B);
            bytes.Add(color.A);

            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, List<string> values)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            
            if (values != null && values.Count > 0)
            {
                bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(values.Count));
                foreach (var parameter in values)
                {
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(parameter));
                }
            }
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, string value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_STRING);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, double value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_DOUBLE);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, int value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_INTEGER);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, byte value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_BYTE);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromByte(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }


    }
}

