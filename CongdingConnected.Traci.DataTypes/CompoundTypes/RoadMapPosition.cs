
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// Alternative position description that is also used by sumo in most cases.
/// </summary>
/// <remarks>
/// RoadId identifies a road segment (edge),
/// Position describes the position of the node in longitudinal direction (ranging from 0 to the road's length).
/// LaneId identifies the driving lane on the road segment. Lanes are numbered sequentially from right to left starting with 0.
/// </remarks>
public sealed class RoadMapPosition : TraciCompoundObject, IFromTraci<RoadMapPosition>
    {
    protected override bool HasCount => false;
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
    public static RoadMapPosition FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var roadId = TraciString.FromSpan(sourceBytes, out sourceBytes);
        var pos = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var laneId = TraciByte.FromSpan(sourceBytes, out remainingBytes);
        return [roadId, pos, laneId];
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

    public override void WriteToSpan(Span<byte> span, ref int offset)
        {
        foreach (var item in this)
            {
            item.WriteToSpan(span, ref offset);
            }
        }

    }
