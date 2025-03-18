namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates with altitude,
/// described by three double values (longitude, latitude, and altitude).
/// </summary>
public sealed class LonLatAltPosition : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.LON_LAT_ALT;
    public double Longitude => this[0];
    public double Latitude => this[1];
    public double Altitude => this[2];

    public static new (
        LonLatAltPosition longLatPosition,
        IEnumerable<byte> remainingBytes
    ) FromBytes(IEnumerable<byte> bytes)
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
