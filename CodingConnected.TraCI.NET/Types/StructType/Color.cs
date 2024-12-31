using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Types;

public struct Color : ITraCIType
    {
    public readonly byte TYPE => TYPE_COLOR;

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    public byte A { get; set; }

    public static Tuple<Color, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var result = new Color
            {
            R = bytes.ElementAt(0),
            G = bytes.ElementAt(1),
            B = bytes.ElementAt(2),
            A = bytes.ElementAt(3)
            };
        return new Tuple<Color, IEnumerable<byte>>(result, bytes.Skip(4));
        }
    }
