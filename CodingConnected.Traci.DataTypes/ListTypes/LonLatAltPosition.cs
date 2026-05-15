namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates with altitude,
/// described by three double values (longitude, latitude, and altitude).
/// </summary>
public sealed class LonLatAltPosition
    : TraciListType<TraciDouble, double>,
        ITraciType,
        ITraciParserable<LonLatAltPosition>
    {
    public override DataType TypeIdentifier => DataType.LonLatAlt;
    public double Longitude => this[0];
    public double Latitude => this[1];
    public double Altitude => this[2];

    public static LonLatAltPosition Parse(
        ReadOnlySpan<byte> source,
        out ReadOnlySpan<byte> remaining
    )
        {
        var longitude = TraciDouble.Parse(source, out source);
        var latitude = TraciDouble.Parse(source, out source);
        var altitude = TraciDouble.Parse(source, out remaining);
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
