namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// unsigned <see cref="byte"/> value in traci
/// </summary>
public sealed class TraciUnsignedByte(byte value, bool raw = false)
    : TraciBaseType<byte>(value),
        ITraciType
    {
    public override DataType TypeIdentifier => raw ? DataType.NULL : DataType.UNSIGNEDBYTE;

    public override byte[] ToBytes() => [Value];

    public static new (TraciUnsignedByte TraciData, IEnumerable<byte> RemainingBytes) FromBytes(
        IEnumerable<byte> bytes
    ) => new(new(bytes.First()), bytes.Skip(1));

    }
