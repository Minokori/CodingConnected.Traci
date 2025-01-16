namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class EdgeInformation : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;
    public new byte TYPE => throw new NotImplementedException();
    public TraCIString LaneId => (TraCIString)this[0];
    public TraCIDouble Length => (TraCIDouble)this[1];
    public TraCIDouble Occupation => (TraCIDouble)this[2];
    public TraCIByte OffsetToBestLane => (TraCIByte)this[3];
    /// <summary>
    /// 0: lane may not be used for continuing drive, 1: it may be used
    /// </summary>
    public TraCIUByte LaneInformation => (TraCIUByte)this[4];
    public TraCIStringList BestSubsequentLanes => (TraCIStringList)this[5];
    }

