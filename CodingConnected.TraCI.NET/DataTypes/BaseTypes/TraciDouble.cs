using CodingConnected.TraCI.NET.Constants;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.Constants.TraciConstants;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// <see cref="double"/> value in traci
/// </summary>
public sealed class TraciDouble(double value) : TraciBaseType<double>(value), ITraciType
    {
    public override DataType TypeIdentifier => DataType.DOUBLE;

    public override byte[] ToBytes() => [.. GetBytes(Value).Reverse()];

    public static new (TraciDouble traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        new(new(ToDouble(bytes.Take(DataSize.DOUBLE_SIZE).Reverse().ToArray())), bytes.Skip(DataSize.DOUBLE_SIZE));

    public static new byte[] AsBytes(double value) => [.. GetBytes(value).Reverse()];
    }
