using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
namespace CodingConnected.TraCI.NET.Types;

public class RoadMapPosition : ITraCIType
    {
    public byte TYPE => POSITION_ROADMAP;
    public TraCIString RoadId { get; set; }
    public TraCIDouble Pos { get; set; }
    public TraCIByte LaneId { get; set; }

    public byte[] ToBytes() => [.. RoadId.ToBytes(), .. Pos.ToBytes(), .. LaneId.ToBytes()];

    public static Tuple<RoadMapPosition, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var roadId, bytes) = TraCIString.FromBytes(bytes);
        (var pos, bytes) = TraCIDouble.FromBytes(bytes);
        (var laneId, bytes) = TraCIByte.FromBytes(bytes);
        RoadMapPosition result = new() { RoadId = roadId, Pos = pos, LaneId = laneId };
        return new(result, bytes);
        }
    }
