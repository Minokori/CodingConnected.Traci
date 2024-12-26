using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct Position3D : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.POSITION_3D;
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public readonly byte[] ToBytes() => [.. X.ToTraCIBytes(), .. Y.ToTraCIBytes(), .. Z.ToTraCIBytes()];
    }
