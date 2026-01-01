using System.Buffers.Binary;
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="int"/> value in traci
/// </summary>
public sealed class TraciInteger(int value) : TraciBaseType<int>(value), ITraciType, ITraciParserable<TraciInteger>
    {
    public override DataType TypeIdentifier => DataType.Integer;

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteInt32BigEndian(destination[offset..], Value);
        offset += DataSize.IntegerSize;
        }
    public static TraciInteger Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        TraciInteger result = new(BinaryPrimitives.ReadInt32BigEndian(source));
        remaining = source[DataSize.IntegerSize..];
        return result;
        }
    }
