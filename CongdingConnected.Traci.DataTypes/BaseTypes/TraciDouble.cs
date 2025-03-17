using static System.BitConverter;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="double"/> value in traci
/// </summary>
public sealed class TraciDouble(double value, bool raw = false) : TraciBaseType<double>(value), ITraciType
    {
    public override DataType TypeIdentifier => raw ? DataType.NULL : DataType.DOUBLE;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public static new (TraciDouble traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        new(new(ToDouble(bytes.Take(DataSize.DOUBLE_SIZE).Reverse().ToArray())), bytes.Skip(DataSize.DOUBLE_SIZE));

    public static new byte[] AsBytes(double value) => [.. GetBytes(value).Reverse()];
    }
