using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
namespace CodingConnected.TraCI.NET.Types;

public class LonLatPosition : ITraCIType
    {
    public byte TYPE => POSITION_LON_LAT;
    public TraCIDouble Longitude { get; set; }
    public TraCIDouble Latitude { get; set; }

    public byte[] ToBytes() => [.. Longitude.ToBytes(), .. Latitude.ToBytes()];

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
