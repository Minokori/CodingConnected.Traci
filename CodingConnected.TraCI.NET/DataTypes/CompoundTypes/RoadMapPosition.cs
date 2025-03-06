using CodingConnected.TraCI.NET.Constants;
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
    public override DataType TypeIdentifier => DataType.ROADMAP;

    /// <summary>
    /// a road segment (edge)
    /// </summary>
    public string RoadId => (TraciString)this[0];

    /// <summary>
    /// the position of the node in longitudinal direction (ranging from 0 to the road's length)
    /// </summary>
    public double Position => (TraciDouble)this[1];

    /// <summary>
    /// the driving lane on the road segment. Lanes are numbered sequentially from right to left starting with 0
    /// </summary>
    public byte LaneId => (TraciByte)this[2];


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
        Clear();
        Add(new TraciString(roadId));
        Add(new TraciDouble(position));
        Add(new TraciByte(laneId));
        }

    public override byte[] ToBytes()
        {
        List<byte> bytes = [];
        foreach (var item in this)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }
    }
