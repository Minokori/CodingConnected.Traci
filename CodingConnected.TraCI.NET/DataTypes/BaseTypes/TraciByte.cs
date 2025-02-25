using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.DataType;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// <see cref="byte"/> value in Traci
/// </summary>
/// <remarks>
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </remarks>
public sealed class TraciByte(byte value) : TraciBaseType<byte>(value), ITraciType
    {
    public override byte TYPE => BYTE;

    public override byte[] ToBytes() => [Value];

    public static new (TraciByte TraciData, IEnumerable<byte> RemainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        new(new(bytes.First()), bytes.Skip(1));

    public static new byte[] AsBytes(byte value) => [value];
    }
