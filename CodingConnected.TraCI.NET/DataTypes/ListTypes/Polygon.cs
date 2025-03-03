#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A sequence of 2D points, representing a polygon shape.
/// Length is the number of (x,y) points that make up the polygon.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#polygon_ubyte_identifier_0x06"/>
/// </remarks>
public sealed class Polygon : List<Position2D>, ITraciType
    {
    public DataType TypeIdentifier => DataType.POLYGON;


    public byte[] ToBytes()
        {
        List<byte> bytes = [(byte)Count];
        foreach (var item in this)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static (Polygon polygon, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        int count = bytes.First();
        bytes = [.. bytes.Skip(1)];
        Polygon points = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = Position2D.FromBytes([.. bytes]);
            points.Add(result);
            }
        return new(points, bytes);
        }

    public static implicit operator (double lowerLeftX, double lowerLeftY, double rightUpperX, double rightUpperY)(Polygon polygon) => (polygon[0].X, polygon[0].Y, polygon[1].X, polygon[1].Y);
    }
