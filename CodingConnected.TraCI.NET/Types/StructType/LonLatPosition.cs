using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
namespace CodingConnected.TraCI.NET.Types;

public struct LonLatPosition : ITraCIType
    {
    public readonly byte TYPE => POSITION_LON_LAT;
    public TraCIDouble Longitude { get; set; }
    public TraCIDouble Latitude { get; set; }

    public readonly byte[] ToBytes() => [.. Longitude.ToBytes(), .. Latitude.ToBytes()];

    public static Tuple<LonLatPosition, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var longitude, bytes) = TraCIDouble.FromBytes(bytes);
        (var latitude, bytes) = TraCIDouble.FromBytes(bytes);
        var result = new LonLatPosition()
            {
            Longitude = longitude,
            Latitude = latitude,
            };
        return new(result, bytes);
        }
    }
