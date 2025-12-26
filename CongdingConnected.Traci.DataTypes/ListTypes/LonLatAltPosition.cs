namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates with altitude,
/// described by three double values (longitude, latitude, and altitude).
/// </summary>
public sealed class LonLatAltPosition
    : TraciListType<TraciDouble, double>,
        ITraciType,
        IFromTraci<LonLatAltPosition>
    {
    public override DataType TypeIdentifier => DataType.LON_LAT_ALT;
    public double Longitude => this[0];
    public double Latitude => this[1];
    public double Altitude => this[2];

    public static LonLatAltPosition FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var longitude = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var latitude = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var altitude = TraciDouble.FromSpan(sourceBytes, out remainingBytes);
        return [longitude, latitude, altitude];
        }

    private LonLatAltPosition() { }

    public LonLatAltPosition(double longitude, double latitude, double altitude)
        {
        this[0] = new(longitude);
        this[1] = new(latitude);
        this[2] = new(altitude);
        }
    }
