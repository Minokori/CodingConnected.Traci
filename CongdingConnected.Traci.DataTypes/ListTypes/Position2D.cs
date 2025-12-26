
using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A cartesian 2D position within the simulation network,
/// described by two double values (x and y coordinate).
/// </summary>
public sealed class Position2D : TraciListType<TraciDouble, double>, ITraciType, IFromTraci<Position2D>
    {
    public override DataType TypeIdentifier => DataType.X_Y;
    public double X => this[0];
    public double Y => this[1];

    public static Position2D FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var x = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var y = TraciDouble.FromSpan(sourceBytes, out remainingBytes);
        return [x, y];
        }

    private Position2D() { }

    public Position2D(double x, double y)
        {
        Clear();
        Add(new(x));
        Add(new(y));
        }

    public static implicit operator (double x, double y)([NotNull] Position2D position2D) => (position2D.X, position2D.Y);
    public static implicit operator (double x, double y, double z)([NotNull] Position2D position2D) => (position2D.X, position2D.Y, TraciConstants.INVALID_DOUBLE_VALUE);

    public (double x, double y) ToValueTuple() => (X, Y);
    }
