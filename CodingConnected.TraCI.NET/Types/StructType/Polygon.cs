using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public class Polygon : List<Position2D>, ITraCIType
    {
    public byte TYPE => TraCIConstants.TYPE_POLYGON;


    public byte[] ToBytes()
        {
        List<byte> bytes = [(byte)this.Count];

        foreach (var item in this)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static Tuple<Polygon, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        int count = bytes.First();
        bytes = bytes.Skip(1).ToArray();
        Polygon points = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = Position2D.FromBytes([.. bytes]);
            points.Add(result);
            }
        return new(points, bytes);
        }
    }
