namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A position within the simulation network in geo-coordinates,
/// described by two double values (longitude and latitude).
/// </summary>
public sealed class LonLatPosition : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.LON_LAT;
    public double Longitude => this[0];
    public double Latitude => this[1];

    public static new (LonLatPosition longLatPosition, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    )
        {
        (var longitude, bytes) = TraciDouble.FromBytes(bytes);
        (var latitude, bytes) = TraciDouble.FromBytes(bytes);
        LonLatPosition result = [longitude, latitude];
        return new(result, bytes);
        }

    private LonLatPosition() { }

    public LonLatPosition(double longitude, double latitude)
        {
        Clear();
        Add(new(longitude));
        Add(new(latitude));
        }
    }
