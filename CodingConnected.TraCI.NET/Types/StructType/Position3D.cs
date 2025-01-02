using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
namespace CodingConnected.TraCI.NET.Types;

public struct Position3D : ITraCIType
    {
    public readonly byte TYPE => POSITION_3D;
    public TraCIDouble X { get; set; }
    public TraCIDouble Y { get; set; }
    public TraCIDouble Z { get; set; }

    public readonly byte[] ToBytes() => [.. X.ToBytes(), .. Y.ToBytes(), .. Z.ToBytes()];


    public static Tuple<Position3D, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var x, bytes) = TraCIDouble.FromBytes(bytes);
        (var y, bytes) = TraCIDouble.FromBytes(bytes);
        (var z, bytes) = TraCIDouble.FromBytes(bytes);
        Position3D result = new()
            {
            X = x,
            Y = y,
            Z = z
            };
        return new(result, bytes);
        }
    }
