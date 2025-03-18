namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A cartesian 3D position within the simulation network,
/// described by three double values (x, y and z coordinates).
/// </summary>
public sealed class Position3D : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.X_Y_Z;
    public double X => this[0];
    public double Y => this[1];
    public double Z => this[2];

    public static new (Position3D position3D, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    )
        {
        (var x, bytes) = TraciDouble.FromBytes(bytes);
        (var y, bytes) = TraciDouble.FromBytes(bytes);
        (var z, bytes) = TraciDouble.FromBytes(bytes);
        Position3D result = [x, y, z];
        return new(result, bytes);
        }

    private Position3D() { }

    public Position3D(double x, double y, double z)
        {
        Clear();
        Add(new(x));
        Add(new(y));
        Add(new(z));
        }

    public static implicit operator (double x, double y)(Position3D position3D) =>
        (position3D.X, position3D.Y);

    public static implicit operator (double x, double y, double z)(Position3D position3D) =>
        (position3D.X, position3D.Y, position3D.Z);
    }
