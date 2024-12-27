using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.Types;

public struct Color : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.TYPE_COLOR;
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    public byte A { get; set; }
    }
