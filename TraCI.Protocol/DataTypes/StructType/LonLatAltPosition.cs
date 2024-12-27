using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct LonLatAltPosition : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.POSITION_LON_LAT_ALT;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Altitude { get; set; }

    public readonly byte[] ToBytes() => [.. Longitude.ToTraCIBytes(), .. Latitude.ToTraCIBytes(), .. Altitude.ToTraCIBytes()];
    }
