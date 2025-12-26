using System.Buffers.Binary;
using System.Diagnostics;
using static System.BitConverter;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="double"/> value in traci
/// </summary>
[DebuggerDisplay("double {Value}")]
public sealed class TraciDouble(double value, bool raw = false)
    : TraciBaseType<double>(value), ITraciType, IFromTraci<TraciDouble>
    {
    public override DataType TypeIdentifier => raw ? DataType.NULL : DataType.DOUBLE;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteDoubleBigEndian(destination.Slice(offset, DataSize.DOUBLE_SIZE), Value);
        offset += DataSize.DOUBLE_SIZE;
        }

    public static TraciDouble FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        TraciDouble result = new(BinaryPrimitives.ReadDoubleBigEndian(sourceBytes));
        remainingBytes = sourceBytes[DataSize.DOUBLE_SIZE..];
        return result;
        }

    }
