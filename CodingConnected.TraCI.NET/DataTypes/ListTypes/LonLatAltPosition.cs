#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.PositionType;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates with altitude,
/// described by three double values (longitude, latitude, and altitude).
/// </summary>
public class LonLatAltPosition : TraciListType<TraciDouble, double>, ITraciType
    {
    public override byte TYPE => LON_LAT_ALT;
    public double Longitude => this[0].Value;
    public double Latitude => this[1].Value;
    public double Altitude => this[2].Value;

    public static new (LonLatAltPosition longLatPosition, IEnumerable<byte> remaining) FromBytes(IEnumerable<byte> bytes)
        {
        (var longitude, bytes) = TraciDouble.FromBytes(bytes);
        (var latitude, bytes) = TraciDouble.FromBytes(bytes);
        (var altitude, bytes) = TraciDouble.FromBytes(bytes);
        LonLatAltPosition result = [longitude, latitude, altitude];
        return new(result, bytes);
        }

    private LonLatAltPosition() { }

    public LonLatAltPosition(double longitude, double latitude, double altitude)
        {
        this[0] = new(longitude);
        this[1] = new(latitude);
        this[2] = new(altitude);
        }
    }
