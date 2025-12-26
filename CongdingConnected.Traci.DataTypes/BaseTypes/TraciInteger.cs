using System.Buffers.Binary;
using static System.BitConverter;
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="int"/> value in traci
/// </summary>
public sealed class TraciInteger(int value) : TraciBaseType<int>(value), ITraciType, IFromTraci<TraciInteger>
    {
    public override DataType TypeIdentifier => DataType.INTEGER;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteInt32BigEndian(destination[offset..], Value);
        offset += DataSize.INTEGER_SIZE;
        }
    public static TraciInteger FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        TraciInteger result = new(BinaryPrimitives.ReadInt32BigEndian(sourceBytes));
        remainingBytes = sourceBytes[DataSize.INTEGER_SIZE..];
        return result;
        }
    }
