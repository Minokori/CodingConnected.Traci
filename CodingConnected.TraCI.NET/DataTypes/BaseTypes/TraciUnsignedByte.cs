using static CodingConnected.TraCI.NET.DataTypes.TraciConstants;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// unsigned <see cref="byte"/> value in traci
/// </summary>
public class TraciUnsignedByte(byte value) : TraciBaseType<byte>(value), ITraciType
    {
    public override byte TYPE => DataType.UNSIGNEDBYTE;

    public override byte[] ToBytes() => [Value];

    public static new (TraciUnsignedByte TraciData, IEnumerable<byte> RemainingBytes) FromBytes(IEnumerable<byte> bytes) => new(new(bytes.First()), bytes.Skip(1));

    public static new byte[] AsBytes(byte value) => [value];
    }

// list-like traci types



