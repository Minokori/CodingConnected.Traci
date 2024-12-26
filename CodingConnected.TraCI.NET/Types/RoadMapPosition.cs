namespace CodingConnected.TraCI.NET.Types;

public struct RoadMapPosition : ITraCIType
    {
    public string RoadId { get; set; }
    public double Pos { get; set; }
    public byte LaneId { get; set; }
    }
