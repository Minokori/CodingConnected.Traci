using static System.BitConverter;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="double"/> value in traci
/// </summary>
public sealed class TraciDouble(double value, bool raw = false)
    : TraciBaseType<double>(value),
        ITraciType
    {
    public override DataType TypeIdentifier => raw ? DataType.NULL : DataType.DOUBLE;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public static new (TraciDouble traciData, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    ) =>
        new(
            new(ToDouble(bytes.Take(DataSize.DOUBLE_SIZE).Reverse().ToArray())),
            bytes.Skip(DataSize.DOUBLE_SIZE)
        );

    }
