using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct Position2D : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.POSITION_2D;
    public double X { get; set; }
    public double Y { get; set; }

    public readonly byte[] ToBytes() => [.. X.ToTraCIBytes(), .. Y.ToTraCIBytes()];
    }
