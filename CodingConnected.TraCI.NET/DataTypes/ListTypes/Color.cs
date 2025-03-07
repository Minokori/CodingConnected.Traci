#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A (R,G,B,A)-quadruple of unsigned byte (0-255).
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </summary>
public sealed class Color : TraciListType<TraciByte, byte>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.COLOR;

    public byte R => this[0].Value;
    public byte G => this[1].Value;
    public byte B => this[2].Value;
    public byte A => this[3].Value;

    public static new (Color color, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        (var r, bytes) = TraciByte.FromBytes(bytes);
        (var g, bytes) = TraciByte.FromBytes(bytes);
        (var b, bytes) = TraciByte.FromBytes(bytes);
        (var a, bytes) = TraciByte.FromBytes(bytes);
        Color result = [r, g, b, a];
        return new(result, bytes);
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
    }
