using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// A (R,G,B,A)-quadruple of unsigned byte (0-255).
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </summary>
public sealed class Color : TraciListType<TraciByte, byte>, ITraciType, IFromTraci<Color>
    {
    public override DataType TypeIdentifier => DataType.COLOR;

    public byte R => this[0];
    public byte G => this[1];
    public byte B => this[2];
    public byte A => this[3];

    public static Color FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var r = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var g = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var b = TraciByte.FromSpan(sourceBytes, out sourceBytes);
        var a = TraciByte.FromSpan(sourceBytes, out remainingBytes);
        return [r, g, b, a];
        }

    private Color() { }

    public Color(int r, int g, int b, int a = 255)
        {
        Clear();
        Add(new((byte)r));
        Add(new((byte)g));
        Add(new((byte)b));
        Add(new((byte)a));
        }

    public void Deconstruct(out int r, out int g, out int b, out int a)
        {
        r = R;
        g = G;
        b = B;
        a = A;
        }

    public static implicit operator (int r, int g, int b, int a)([NotNull] Color color) =>
        new(color.R, color.G, color.B, color.A);

    public (int r, int g, int b, int a) ToValueTuple() => throw new NotImplementedException();
    }
