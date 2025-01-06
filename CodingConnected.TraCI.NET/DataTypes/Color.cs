using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;

namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// A (R,G,B,A)-quadruple of unsigned byte (0-255).
/// </summary>
public class Color : ITraciType
    {
    public byte TYPE => TYPE_COLOR;

    public TraCIByte R { get; set; }
    public TraCIByte G { get; set; }
    public TraCIByte B { get; set; }
    public TraCIByte A { get; set; }

    public static Tuple<Color, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var r, bytes) = TraCIByte.FromBytes(bytes);
        (var g, bytes) = TraCIByte.FromBytes(bytes);
        (var b, bytes) = TraCIByte.FromBytes(bytes);
        (var a, bytes) = TraCIByte.FromBytes(bytes);

        var result = new Color
            {
            R = r,
            G = g,
            B = b,
            A = a
            };
        return new Tuple<Color, IEnumerable<byte>>(result, bytes);
        }
    public byte[] ToBytes()
        {
        return [.. R.ToBytes(), .. G.ToBytes(), .. B.ToBytes(), .. A.ToBytes()];

        }
    }
