using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.PositionType;

#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// Alternative position description that is also used by sumo in most cases.
/// </summary>
/// <remarks>
/// RoadId identifies a road segment (edge),
/// Position describes the position of the node in longitudinal direction (ranging from 0 to the road's length).
/// LaneId identifies the driving lane on the road segment. Lanes are numbered sequentially from right to left starting with 0.
/// </remarks>
public sealed class RoadMapPosition : TraciCompoundObject
    {
    protected override bool IsComplete => false;
    public override byte TYPE => ROADMAP;

    /// <summary>
    /// a road segment (edge)
    /// </summary>
    public string RoadId => ((TraciString)this[0]).Value;

    /// <summary>
    /// the position of the node in longitudinal direction (ranging from 0 to the road's length)
    /// </summary>
    public double Position => ((TraciDouble)this[1]).Value;

    /// <summary>
    /// the driving lane on the road segment. Lanes are numbered sequentially from right to left starting with 0
    /// </summary>
    public byte LaneId => ((TraciByte)this[2]).Value;


    public static new (RoadMapPosition roadMapPosition, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        (var roadId, bytes) = TraciString.FromBytes(bytes);
        (var pos, bytes) = TraciDouble.FromBytes(bytes);
        (var laneId, bytes) = TraciByte.FromBytes(bytes);
        RoadMapPosition result = [roadId, pos, laneId];
        return new(result, bytes);
        }

    private RoadMapPosition() { }

    public RoadMapPosition(string roadId, double position, byte laneId)
        {
        this[0] = new TraciString(roadId);
        this[1] = new TraciDouble(position);
        this[2] = new TraciByte(laneId);
        }
    }
