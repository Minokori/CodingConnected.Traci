using CodingConnected.TraCI.NET.Constants;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.Constants.TraciConstants;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

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