
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates,
/// described by two double values (longitude and latitude).
/// </summary>
public sealed class LonLatPosition : TraciListType<TraciDouble, double>, ITraciType, IFromTraci<LonLatPosition>
    {
    public override DataType TypeIdentifier => DataType.LON_LAT;
    public double Longitude => this[0];
    public double Latitude => this[1];

    public static LonLatPosition FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var longitude = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var latitude = TraciDouble.FromSpan(sourceBytes, out remainingBytes);
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
