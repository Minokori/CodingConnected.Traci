using System.Buffers.Binary;
using System.Text;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="string"/> value in traci
/// </summary>
/// <param name="value">ASCII 字符串</param>
/// <param name="raw">是否包含 TypeIdentifier(默认为否)</param>
public sealed class TraciString(string value, bool raw = false)
    : TraciBaseType<string>(value),
        ITraciType,
        ITraciParserable<TraciString>
    {
    public override DataType TypeIdentifier => raw ? DataType.Null : DataType.String;


    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteInt32BigEndian(destination[offset..], Value.Length);
        offset += DataSize.IntegerSize;
        var content = Encoding.ASCII.GetBytes(Value);
        content.CopyTo(destination[offset..]);
        offset += content.Length;
        }

    public static TraciString Parse(
        ReadOnlySpan<byte> source,
        out ReadOnlySpan<byte> remaining
    )
        {
        var length = BinaryPrimitives.ReadInt32BigEndian(source);
        TraciString result = new(
            Encoding.ASCII.GetString(source.Slice(DataSize.IntegerSize, length))
        );
        remaining = source[(DataSize.IntegerSize + length)..];
        return result;
        }
    }
