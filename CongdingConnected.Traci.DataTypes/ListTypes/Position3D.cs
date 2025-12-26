using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A cartesian 3D position within the simulation network,
/// described by three double values (x, y and z coordinates).
/// </summary>
public sealed class Position3D
    : TraciListType<TraciDouble, double>,
        ITraciType,
        IFromTraci<Position3D>
    {
    public override DataType TypeIdentifier => DataType.X_Y_Z;
    public double X => this[0];
    public double Y => this[1];
    public double Z => this[2];

    public static Position3D FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var x = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var y = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var z = TraciDouble.FromSpan(sourceBytes, out remainingBytes);

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

    public (double x, double y, double z) ToValueTuple() => (X, Y, Z);
    }
