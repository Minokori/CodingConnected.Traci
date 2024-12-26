using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Services;

internal partial class TraCICommandHelper
    {

    public static TraCICommand GetCommand<T>(string id, byte commandType, byte messageType, T contents)
        {


        return null;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, TraCIObjects co)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_COMPOUND,
                .. co.Count.ToTraCIBytes(),
                ];
        foreach (ITraCIType item in co)
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
                    bytes.AddRange(i.Value.ToTraCIBytes());
                    break;
                case TraCIFloat f:
                    bytes.Add(TraCIConstants.TYPE_FLOAT);
                    bytes.AddRange(f.Value.ToTraCIBytes());
                    break;
                case TraCIDouble d:
                    bytes.Add(TraCIConstants.TYPE_DOUBLE);
                    bytes.AddRange(d.Value.ToTraCIBytes());
                    break;
                case TraCIString s:
                    bytes.Add(TraCIConstants.TYPE_STRING);
                    bytes.AddRange(s.Value.ToTraCIBytes());
                    break;
                case TraCIStringList sl:
                    bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                    bytes.AddRange(sl.Value.ToTraCIBytes());
                    break;
                case TraCIObjects CO:
                    throw new NotImplementedException("Nested compound objects are not implemented yet");
                case Position2D p2d:
                    bytes.Add(TraCIConstants.POSITION_2D);
                    bytes.AddRange(p2d.ToTraCIBytes());
                    break;
                case Position3D p3d:
                    bytes.Add(TraCIConstants.POSITION_3D);
                    bytes.AddRange(p3d.ToTraCIBytes());
                    break;
                case RoadMapPosition rmp:
                    bytes.Add(TraCIConstants.POSITION_ROADMAP);
                    bytes.AddRange(rmp.ToTraCIBytes());
                    break;
                case LonLatPosition llp:
                    bytes.Add(TraCIConstants.POSITION_LON_LAT);
                    bytes.AddRange(llp.ToTraCIBytes());
                    break;
                case LonLatAltPosition llap:
                    bytes.Add(TraCIConstants.POSITION_LON_LAT_ALT);
                    bytes.AddRange(llap.ToTraCIBytes());
                    break;
                case BoundaryBox bb:
                    bytes.Add(TraCIConstants.TYPE_BOUNDINGBOX);
                    bytes.AddRange(bb.ToTraCIBytes());
                    break;
                case Polygon p:
                    bytes.Add(TraCIConstants.TYPE_POLYGON);
                    bytes.AddRange(p.ToTraCIBytes());
                    break;
                case TrafficLightPhaseList tlpl:
                    bytes.Add(TraCIConstants.TYPE_TLPHASELIST);
                    bytes.AddRange(tlpl.ToTraCIBytes());
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
        List<byte> bytes = [messageType, .. id.ToTraCIBytes()];
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
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_BOUNDINGBOX,
                .. boundaryBox.LowerLeftX.ToTraCIBytes(),
                .. boundaryBox.LowerLeftY.ToTraCIBytes(),
                .. boundaryBox.UpperRightX.ToTraCIBytes(),
                .. boundaryBox.UpperRightY.ToTraCIBytes(),
                ];

        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, Polygon polygon)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_POLYGON,
                (byte)polygon.Points.Count,
                ];
        foreach (Position2D point in polygon.Points)
            {
            bytes.AddRange(point.X.ToTraCIBytes());
            bytes.AddRange(point.Y.ToTraCIBytes());
            }

        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, Position2D position2D)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.POSITION_2D,
                .. position2D.X.ToTraCIBytes(),
                .. position2D.Y.ToTraCIBytes(),
                ];

        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, Color color)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_COLOR,
                color.R,
                color.G,
                color.B,
                color.A,
                ];

        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, List<string> values)
        {
        List<byte> bytes = [messageType, .. id.ToTraCIBytes()];

        if (values != null && values.Count > 0)
            {
            bytes.Add(TraCIConstants.TYPE_STRINGLIST);
            bytes.AddRange(values.Count.ToTraCIBytes());
            foreach (string parameter in values)
                {
                bytes.AddRange(parameter.ToTraCIBytes());
                }
            }
        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, string value)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_STRING,
                .. value.ToTraCIBytes(),
                ];
        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, double value)
        {
        List<byte> bytes =
            [
            messageType,
                ..id.ToTraCIBytes(),
                TraCIConstants.TYPE_DOUBLE,
                .. value.ToTraCIBytes(),
                ];
        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, int value)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_INTEGER,
                .. value.ToTraCIBytes(),
                ];
        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, byte value)
        {
        List<byte> bytes =
            [
            messageType,
                .. id.ToTraCIBytes(),
                TraCIConstants.TYPE_BYTE,
                value,
                ];
        TraCICommand command = new()
            {
            Identifier = commandType,
            Contents = [.. bytes]
            };
        return command;
        }

    }

