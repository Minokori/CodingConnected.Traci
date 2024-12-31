using CodingConnected.TraCI.NET.Helpers;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
namespace CodingConnected.TraCI.NET.Types;

public struct RoadMapPosition : ITraCIType
    {
    public readonly byte TYPE => POSITION_ROADMAP;
    public string RoadId { get; set; }
    public double Pos { get; set; }
    public byte LaneId { get; set; }

    public readonly byte[] ToBytes() => [.. RoadId.ToTraCIBytes(), .. Pos.ToTraCIBytes(), .. LaneId.ToTraCIBytes()];

    public static Tuple<RoadMapPosition, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var roadId, bytes) = TraCIString.FromBytes(bytes);
        (var pos, bytes) = TraCIDouble.FromBytes(bytes);
        (var laneId, bytes) = TraCIByte.FromBytes(bytes);
        RoadMapPosition result = new() { RoadId = roadId.Value, Pos = pos.Value, LaneId = laneId.Value };
        return new(result, bytes);
        }
    }
