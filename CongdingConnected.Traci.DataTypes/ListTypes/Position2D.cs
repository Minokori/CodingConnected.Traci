namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A cartesian 2D position within the simulation network,
/// described by two double values (x and y coordinate).
/// </summary>
public sealed class Position2D : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.X_Y;
    public double X => this[0].Value;
    public double Y => this[1].Value;

    public static new (Position2D position2D, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        (var x, bytes) = TraciDouble.FromBytes(bytes);
        (var y, bytes) = TraciDouble.FromBytes(bytes);
        Position2D result = [x, y];
        return new(result, bytes);
        }

    private Position2D() { }

    public Position2D(double x, double y)
        {

        Add(new(x));
        Add(new(y));
        }

    public static implicit operator (double x, double y)(Position2D position2D) => (position2D.X, position2D.Y);
    public static implicit operator (double x, double y, double z)(Position2D position2D) => (position2D.X, position2D.Y, TraciConstants.INVALID_DOUBLE_VALUE);
    }
