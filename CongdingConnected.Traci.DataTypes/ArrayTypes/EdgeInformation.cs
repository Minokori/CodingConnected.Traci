namespace CodingConnected.Traci.DataTypes;

public sealed class EdgeInformation(IEnumerable<ITraciType> innerObjects)
    : TraciArrayType(innerObjects)
    {
    public string LaneId => (TraciString)this[0];
    public double Length => (TraciDouble)this[1];
    public double Occupation => (TraciDouble)this[2];
    public byte OffsetToBestLane => (TraciByte)this[3];

    /// <summary>
    /// 0: lane may not be used for continuing drive, 1: it may be used
    /// </summary>
    public byte LaneInformation => (TraciUnsignedByte)this[4];
    public IList<string> BestSubsequentLanes => [.. (TraciStringList)this[5]];
    }
