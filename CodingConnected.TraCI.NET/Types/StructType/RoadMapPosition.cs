using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct RoadMapPosition : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.POSITION_ROADMAP;
    public string RoadId { get; set; }
    public double Pos { get; set; }
    public byte LaneId { get; set; }

    public readonly byte[] ToBytes() => [.. RoadId.ToTraCIBytes(), .. Pos.ToTraCIBytes(), .. LaneId.ToTraCIBytes()];
    }
