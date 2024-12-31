using CodingConnected.TraCI.NET.Helpers;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Types;

public struct Position2D : ITraCIType
    {
    public readonly byte TYPE => POSITION_2D;
    public double X { get; set; }
    public double Y { get; set; }

    public readonly byte[] ToBytes() => [.. X.ToTraCIBytes(), .. Y.ToTraCIBytes()];

    public static Tuple<Position2D, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        Position2D result = new()
            {
            X = ToDouble(bytes.Take(DOUBLE_SIZE).Reverse().ToArray()),
            Y = ToDouble(bytes.Skip(DOUBLE_SIZE).Take(DOUBLE_SIZE).Reverse().ToArray()),
            };

        return new(result, bytes.Skip(2 * DOUBLE_SIZE));
        }
    }
