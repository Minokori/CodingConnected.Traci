using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct LonLatPosition : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.POSITION_LON_LAT;
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public readonly byte[] ToBytes() => [.. Longitude.ToTraCIBytes(), .. Latitude.ToTraCIBytes()];
    }
