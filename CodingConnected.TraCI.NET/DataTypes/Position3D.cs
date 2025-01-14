using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;

namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// A cartesian 3D position within the simulation network,
/// described by three double values (x, y and z coordinates).
/// </summary>
public class Position3D : ITraciType
    {
    public byte TYPE => POSITION_3D;
    public TraCIDouble X { get; set; }
    public TraCIDouble Y { get; set; }
    public TraCIDouble Z { get; set; }

    public byte[] ToBytes() => [.. X.ToBytes(), .. Y.ToBytes(), .. Z.ToBytes()];

    public static Tuple<Position3D, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var x, bytes) = TraCIDouble.FromBytes(bytes);
        (var y, bytes) = TraCIDouble.FromBytes(bytes);
        (var z, bytes) = TraCIDouble.FromBytes(bytes);
        Position3D result = new()
            {
            X = x,
            Y = y,
            Z = z,
            };
        return new(result, bytes);
        }
    }
