
using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A cartesian 2D position within the simulation network,
/// described by two double values (x and y coordinate).
/// </summary>
public sealed class Position2D : TraciListType<TraciDouble, double>, ITraciType, ITraciParserable<Position2D>
    {
    public override DataType TypeIdentifier => DataType.XY;
    public double X => this[0];
    public double Y => this[1];

    public static Position2D Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var x = TraciDouble.Parse(source, out source);
        var y = TraciDouble.Parse(source, out remaining);
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
    public static implicit operator (double x, double y, double z)([NotNull] Position2D position2D) => (position2D.X, position2D.Y, TraciConstants.InvalidDoubleValue);

    }
