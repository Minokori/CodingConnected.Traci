using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct Polygon : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.TYPE_POLYGON;
    public List<Position2D> Points { get; set; }


    public readonly byte[] ToBytes()
        {
        List<byte> bytes = [.. ((byte)Points.Count).ToTraCIBytes()];

        foreach (var item in Points)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static Tuple<Polygon, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        int count = bytes.First();
        bytes = bytes.Skip(1).ToArray();
        List<Position2D> points = [];
        for (int i = 0; i < count; i++)
            {
            (var result, bytes) = Position2D.FromBytes([.. bytes]);
            points.Add(result);
            }
        return new(new Polygon { Points = points }, bytes);
        }
    }
