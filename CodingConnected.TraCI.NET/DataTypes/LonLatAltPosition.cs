using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;

namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// A position within the simulation network in geo-coordinates with altitude,
/// described by three double values (longitude, latitude, and altitude).
/// </summary>
public class LonLatAltPosition : ITraciType
    {
    public byte TYPE => POSITION_LON_LAT_ALT;
    public TraCIDouble Longitude { get; set; }
    public TraCIDouble Latitude { get; set; }
    public TraCIDouble Altitude { get; set; }

    public byte[] ToBytes() => [.. Longitude.ToBytes(), .. Latitude.ToBytes(), .. Altitude.ToBytes()];

    public static Tuple<LonLatAltPosition, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var longitude, bytes) = TraCIDouble.FromBytes(bytes);
        (var latitude, bytes) = TraCIDouble.FromBytes(bytes);
        (var altitude, bytes) = TraCIDouble.FromBytes(bytes);
        var result = new LonLatAltPosition()
            {
            Longitude = longitude,
            Latitude = latitude,
            Altitude = altitude
            };
        return new(result, bytes);
        }
    }
