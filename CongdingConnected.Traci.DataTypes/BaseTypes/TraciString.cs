using System.Buffers.Binary;
using System.Text;
using static System.BitConverter;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="string"/> value in traci
/// </summary>
/// <param name="value">ASCII 字符串</param>
/// <param name="raw">是否包含 TypeIdentifier(默认为否)</param>
public sealed class TraciString(string value, bool raw = false)
    : TraciBaseType<string>(value),
        ITraciType,
        IFromTraci<TraciString>
    {
    public override DataType TypeIdentifier => raw ? DataType.NULL : DataType.STRING;

    public override byte[] ToBytes() =>
        [.. GetBytes(Value.Length).Reverse(), .. Encoding.ASCII.GetBytes(Value)];

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteInt32BigEndian(destination[offset..], Value.Length);
        offset += DataSize.INTEGER_SIZE;
        var content = Encoding.ASCII.GetBytes(Value);
        content.CopyTo(destination[offset..]);
        offset += content.Length;
        }

    public static TraciString FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var length = BinaryPrimitives.ReadInt32BigEndian(sourceBytes);
        TraciString result = new(
            Encoding.ASCII.GetString(sourceBytes.Slice(DataSize.INTEGER_SIZE, length))
        );
        remainingBytes = sourceBytes[(DataSize.INTEGER_SIZE + length)..];
        return result;
        }
    }
