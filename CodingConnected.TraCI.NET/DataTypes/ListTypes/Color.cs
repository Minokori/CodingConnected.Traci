#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A (R,G,B,A)-quadruple of unsigned byte (0-255).
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </summary>
public class Color : TraciListType<TraciByte, byte>, ITraciType
    {
    public override byte TYPE => DataType.COLOR;

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
        this[0] = new((byte)r);
        this[1] = new((byte)g);
        this[2] = new((byte)b);
        this[3] = new((byte)a);
        }

    public void Deconstruct(out int r, out int g, out int b, out int a)
        {
        r = R;
        g = G;
        b = B;
        a = A;
        }
    }
