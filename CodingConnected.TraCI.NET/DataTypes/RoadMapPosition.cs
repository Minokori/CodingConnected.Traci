using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;
namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// Alternative position description that is also used by sumo in most cases.
/// </summary>
/// <remarks>
/// RoadId identifies a road segment (edge),
/// Pos describes the position of the node in longitudinal direction (ranging from 0 to the road's length). 
/// LaneId identifies the driving lane on the road segment. Lanes are numbered sequentially from right to left starting with 0.
/// </remarks>
public class RoadMapPosition : ITraciType
    {
    public byte TYPE => POSITION_ROADMAP;

    /// <summary>
    /// a road segment (edge)
    /// </summary>
    public TraCIString RoadId { get; set; }
    /// <summary>
    /// the position of the node in longitudinal direction (ranging from 0 to the road's length)
    /// </summary>
    public TraCIDouble Pos { get; set; }
    /// <summary>
    /// the driving lane on the road segment. Lanes are numbered sequentially from right to left starting with 0
    /// </summary>
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
