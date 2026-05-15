using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A cartesian 3D position within the simulation network,
/// described by three double values (x, y and z coordinates).
/// </summary>
public sealed class Position3D
    : TraciListType<TraciDouble, double>,
        ITraciType,
        ITraciParserable<Position3D>
    {
    public override DataType TypeIdentifier => DataType.XYZ;
    public double X => this[0];
    public double Y => this[1];
    public double Z => this[2];

    public static Position3D Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var x = TraciDouble.Parse(source, out source);
        var y = TraciDouble.Parse(source, out source);
        var z = TraciDouble.Parse(source, out remaining);

        return [x, y, z];
        }

    private Position3D() { }

    public Position3D(double x, double y, double z)
        {
        Clear();
        Add(new(x));
        Add(new(y));
        Add(new(z));
        }

    public static implicit operator (double x, double y)([NotNull] Position3D position3D) =>
        (position3D.X, position3D.Y);

    public static implicit operator (double x, double y, double z)(
        [NotNull] Position3D position3D
    ) => (position3D.X, position3D.Y, position3D.Z);
    }
