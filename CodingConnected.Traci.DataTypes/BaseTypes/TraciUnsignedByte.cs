namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// unsigned <see cref="byte"/> value in traci
/// </summary>
/// <param name="value">unsigned byte 值</param>
/// <param name="raw">是否包含 TypeIdentifier(默认为否)</param>
public sealed class TraciUnsignedByte(byte value, bool raw = false)
    : TraciBaseType<byte>(value),
        ITraciType, ITraciParserable<TraciUnsignedByte>
    {
    public override DataType TypeIdentifier => raw ? DataType.Null : DataType.UnsignedByte;

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        destination[offset] = Value;
        offset += 1;
        }

    public static TraciUnsignedByte Parse(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        TraciUnsignedByte result = new(sourceBytes[0]);
        remainingBytes = sourceBytes[1..];
        return result;
        }
    }
