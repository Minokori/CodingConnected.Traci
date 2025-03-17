using static System.BitConverter;
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="float"/> value in traci
/// </summary>
public sealed class TraciFloat(float value) : TraciBaseType<float>(value), ITraciType
    {
    public override DataType TypeIdentifier => DataType.FLOAT;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public static new (TraciFloat traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        new(new(ToSingle([.. bytes.Take(DataSize.FLOAT_SIZE).Reverse()])), bytes.Skip(DataSize.FLOAT_SIZE));

    public static new byte[] AsBytes(float value) => [.. GetBytes(value).Reverse()];
    }