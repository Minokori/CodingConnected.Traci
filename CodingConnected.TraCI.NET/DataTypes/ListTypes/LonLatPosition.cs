#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

using CodingConnected.TraCI.NET.Constants;


namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates,
/// described by two double values (longitude and latitude).
/// </summary>
public sealed class LonLatPosition : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.LON_LAT;
    public double Longitude => this[0].Value;
    public double Latitude => this[1].Value;

    public static new (LonLatPosition longLatPosition, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        (var longitude, bytes) = TraciDouble.FromBytes(bytes);
        (var latitude, bytes) = TraciDouble.FromBytes(bytes);
        LonLatPosition result = [longitude, latitude];
        return new(result, bytes);
        }

    private LonLatPosition() { }

    public LonLatPosition(double longitude, double latitude)
        {
        this[0] = new(longitude);
        this[1] = new(latitude);
        }
    }
