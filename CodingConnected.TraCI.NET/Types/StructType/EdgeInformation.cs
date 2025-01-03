namespace CodingConnected.TraCI.NET.Types;

public class EdgeInformation : TraCICompoundObject, ITraCIType
    {
    public new byte TYPE => throw new NotImplementedException();
    public TraCIString LaneId => this[0] as TraCIString;
    public TraCIDouble Length => this[1] as TraCIDouble;
    public TraCIDouble Occupation => this[2] as TraCIDouble;
    public TraCIByte OffsetToBestLane => this[3] as TraCIByte;
    /// <summary>
    /// 0: lane may not be used for continuing drive, 1: it may be used
    /// </summary>
    public TraCIUByte LaneInformation => this[4] as TraCIUByte;
    public TraCIStringList BestSubsequentLanes => this[5] as TraCIStringList;
    }

