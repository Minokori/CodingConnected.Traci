namespace CodingConnected.TraCI.NET.Types;

public struct LonLatAltPosition : ITraCIType
    {
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Altitude { get; set; }
    }
