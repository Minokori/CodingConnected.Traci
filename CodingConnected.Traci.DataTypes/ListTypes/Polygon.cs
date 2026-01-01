using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A sequence of 2D points, representing a polygon shape.
/// Length is the number of (x,y) points that make up the polygon.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#polygon_ubyte_identifier_0x06"/>
/// </remarks>
public sealed class Polygon : List<Position2D>, ITraciType, ITraciParserable<Polygon>
    {
    public DataType TypeIdentifier => DataType.Polygon;

    public void WriteToSpan(Span<byte> destination, ref int offset)
        {
        destination[offset] = (byte)Count;
        offset += 1;
        foreach (var item in this)
            {
            item.WriteToSpan(destination, ref offset);
            }
        }

    public static Polygon Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        int count = source[0];
        source = source[1..];
        Polygon points = [];
        for (var i = 0; i < count; i++)
            {
            var result = Position2D.Parse(source, out source);
            points.Add(result);
            }
        remaining = source;
        return points;
        }

    public Polygon([NotNull] params IEnumerable<(double x, double y)> points)
        {
        Clear();
        foreach (var (x, y) in points)
            {
            Add(new Position2D(x, y));
            }
        }

    /// <summary>
    /// this will return the lower left and upper right corner of the polygon(first and last point)
    /// </summary>
    /// <param name="polygon"></param>
    public static implicit operator (
        double lowerLeftX,
        double lowerLeftY,
        double rightUpperX,
        double rightUpperY
    )([NotNull] Polygon polygon) => (polygon[0].X, polygon[0].Y, polygon[-1].X, polygon[-1].Y);

    public static implicit operator List<(double x, double y)>(Polygon polygon) =>
        [.. polygon.Select(i => (i.X, i.Y))];
    }
