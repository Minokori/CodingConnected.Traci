namespace CodingConnected.TraCI.NET.Types;

public readonly struct EdgeInformation : ITraCIType
    {
    public string LaneId { get; init; }
    public double Length { get; init; }
    public double Occupation { get; init; }
    public byte OffsetToBestLane { get; init; }
    /// <summary>
    /// 0: lane may not be used for continuing drive, 1: it may be used
    /// </summary>
    public byte LaneInformation { get; init; }
    public List<string> BestSubsequentLanes { get; init; }
    }

