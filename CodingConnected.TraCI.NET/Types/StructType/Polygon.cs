using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct Polygon : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.TYPE_POLYGON;
    public List<Position2D> Points { get; set; }


    public readonly byte[] ToBytes()
        {
        List<byte> bytes = [.. ((byte)Points.Count).ToTraCIBytes()];

        foreach (var item in Points)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }
    }
