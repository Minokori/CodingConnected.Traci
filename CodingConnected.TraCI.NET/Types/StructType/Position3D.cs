using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
using CodingConnected.TraCI.NET.Helpers;
using static System.BitConverter;
namespace CodingConnected.TraCI.NET.Types;

public struct Position3D : ITraCIType
    {
    public readonly byte TYPE => POSITION_3D;
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public readonly byte[] ToBytes() => [.. X.ToTraCIBytes(), .. Y.ToTraCIBytes(), .. Z.ToTraCIBytes()];


    public static Tuple<Position3D, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        Position3D result = new()
            {
            X = ToDouble(bytes.Take(DOUBLE_SIZE).Reverse().ToArray()),
            Y = ToDouble(bytes.Skip(DOUBLE_SIZE).Take(DOUBLE_SIZE).Reverse().ToArray()),
            Z = ToDouble(bytes.Skip(2 * DOUBLE_SIZE).Take(DOUBLE_SIZE).Reverse().ToArray())
            };
        return new(result, bytes.Skip(3 * DOUBLE_SIZE));
        }
    }
