using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Types;

public class Position2D : ITraCIType
    {
    public byte TYPE => POSITION_2D;
    public TraCIDouble X { get; set; }
    public TraCIDouble Y { get; set; }

    public byte[] ToBytes() => [.. X.ToBytes(), .. Y.ToBytes()];

    public static Tuple<Position2D, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var x, bytes) = TraCIDouble.FromBytes(bytes);
        (var y, bytes) = TraCIDouble.FromBytes(bytes);
        Position2D result = new()
            {
            X = x,
            Y = y
            };
        return new(result, bytes);
        }
    }
