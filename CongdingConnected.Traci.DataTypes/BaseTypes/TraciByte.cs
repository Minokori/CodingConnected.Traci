
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="byte"/> value in Traci
/// </summary>
/// <remarks>
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </remarks>
public sealed class TraciByte(byte value) : TraciBaseType<byte>(value), ITraciType
    {
    public override DataType TypeIdentifier => DataType.BYTE;

    public override byte[] ToBytes() => [Value];

    public static new (TraciByte traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        new(new(bytes.First()), bytes.Skip(1));

    public static new byte[] AsBytes(byte value) => [value];
    }
