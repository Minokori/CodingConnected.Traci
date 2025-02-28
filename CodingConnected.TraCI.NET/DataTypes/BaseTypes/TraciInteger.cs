using CodingConnected.TraCI.NET.Constants;
using static System.BitConverter;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// <see cref="int"/> value in traci
/// </summary>
public sealed class TraciInteger(int value) : TraciBaseType<int>(value), ITraciType
    {
    public override DataType TypeIdentifier => DataType.INTEGER;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public static new (TraciInteger traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        new(new(ToInt32(bytes.Take(DataSize.INTEGER_SIZE).Reverse().ToArray())), bytes.Skip(DataSize.INTEGER_SIZE));

    public static new byte[] AsBytes(int value) => [.. GetBytes(value).Reverse()];
    }
