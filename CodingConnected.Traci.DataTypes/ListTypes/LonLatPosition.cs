
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates,
/// described by two double values (longitude and latitude).
/// </summary>
public sealed class LonLatPosition : TraciListType<TraciDouble, double>, ITraciType, ITraciParserable<LonLatPosition>
    {
    public override DataType TypeIdentifier => DataType.LonLat;
    public double Longitude => this[0];
    public double Latitude => this[1];

    public static LonLatPosition Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var longitude = TraciDouble.Parse(source, out source);
        var latitude = TraciDouble.Parse(source, out remaining);
        return [longitude, latitude];
        }

    private LonLatPosition() { }

    public LonLatPosition(double longitude, double latitude)
        {
        Clear();
        Add(new(longitude));
        Add(new(latitude));
        }
    }
