using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;
namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// A position within the simulation network in geo-coordinates,
/// described by two double values (longitude and latitude).
/// </summary>
public class LonLatPosition : ITraciType
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
