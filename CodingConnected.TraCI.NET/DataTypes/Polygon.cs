namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A sequence of 2D points, representing a polygon shape.
/// Length is the number of (x,y) points that make up the polygon.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#polygon_ubyte_identifier_0x06"/>
/// </remarks>
public class Polygon : List<Position2D>, ITraciType
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
