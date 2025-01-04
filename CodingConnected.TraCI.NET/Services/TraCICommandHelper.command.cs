using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Services;

internal partial class TraCICommandHelper
    {

    public static TraCICommand GetCommand<T>(TraCIString id, TraCIByte commandType, TraCIByte messageType, ITraCIType contents)
        {


        return null;
        }

    public static TraCICommand GetCommand(string id, byte commandType, byte messageType, TraCICompoundObject co)
        {
        List<byte> bytes =
            [messageType, .. id.ToTraCIBytes(), TraCIConstants.TYPE_COMPOUND, .. co.Count.ToTraCIBytes(),];
        foreach (var item in co)
            {
            switch (item)
                {
                case TraCIByte:
                case TraCIUByte:
                case TraCIInteger:
                case TraCIFloat:
                case TraCIDouble:
                case TraCIString:
                case TraCIStringList:
                case Position2D:
                case Position3D:
                case RoadMapPosition:
                case LonLatPosition:
                case LonLatAltPosition:
                case BoundaryBox:
                case Polygon:
                case TrafficLightPhaseList:
                    bytes.Add(item.TYPE);
                    bytes.AddRange(item.ToBytes());
                    break;
                case TraCICompoundObject CO:
                case Color c:
                    throw new NotImplementedException($"{item.GetType()} objects are not implemented yet");
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
        foreach (var point in polygon.Points)
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
                ..color.R.ToBytes(),
                ..color.G.ToBytes(),
                ..color.B.ToBytes(),
                ..color.A.ToBytes(),
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
            foreach (var parameter in values)
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

