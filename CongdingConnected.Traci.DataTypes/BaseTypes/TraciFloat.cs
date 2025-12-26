using System.Buffers.Binary;
using static System.BitConverter;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="float"/> value in traci
/// </summary>
public sealed class TraciFloat(float value) : TraciBaseType<float>(value), ITraciType, IFromTraci<TraciFloat>
    {
    public override DataType TypeIdentifier => DataType.FLOAT;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteSingleBigEndian(destination[offset..], Value);
        offset += DataSize.FLOAT_SIZE;
        }


    public static TraciFloat FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        TraciFloat result = new(BinaryPrimitives.ReadSingleBigEndian(sourceBytes[..DataSize.FLOAT_SIZE]));
        remainingBytes = sourceBytes[DataSize.FLOAT_SIZE..];
        return result;
        }
    }
