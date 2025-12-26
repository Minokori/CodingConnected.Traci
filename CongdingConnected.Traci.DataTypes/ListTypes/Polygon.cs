using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A sequence of 2D points, representing a polygon shape.
/// Length is the number of (x,y) points that make up the polygon.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#polygon_ubyte_identifier_0x06"/>
/// </remarks>
public sealed class Polygon : List<Position2D>, ITraciType, IFromTraci<Polygon>
    {
    public DataType TypeIdentifier => DataType.POLYGON;

    public byte[] ToBytes()
        {
        List<byte> bytes = [(byte)Count];
        foreach (var item in this)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }


    public static Polygon FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        int count = sourceBytes[0];
        sourceBytes = sourceBytes[1..];
        Polygon points = [];
        for (var i = 0; i < count; i++)
            {
            var result = Position2D.FromSpan(sourceBytes, out sourceBytes);
            points.Add(result);
            }
        remainingBytes = sourceBytes;
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

    public static implicit operator (double x, double y)[](Polygon polygon) =>
        [.. polygon.Select(i => (i.X, i.Y))];

    public (
        double lowerLeftX,
        double lowerLeftY,
        double rightUpperX,
        double rightUpperY
    ) ToValueTuple() => (this[0].X, this[0].Y, this[-1].X, this[-1].Y);

    public (double x, double y)[] ToValueTupleArray() => [.. this.Select(i => (i.X, i.Y))];
    }
