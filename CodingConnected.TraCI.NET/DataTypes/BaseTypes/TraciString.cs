using System.Text;
using CodingConnected.TraCI.NET.Constants;
using static System.BitConverter;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// <see cref="string"/> value in traci
/// </summary>
public sealed class TraciString(string value, bool raw = false) : TraciBaseType<string>(value), ITraciType
    {
    public override DataType TypeIdentifier => raw ? DataType.NULL : DataType.STRING;

    public override byte[] ToBytes() => [.. GetBytes(Value.Length).Reverse(), .. Encoding.ASCII.GetBytes(Value)];

    public static new (TraciString traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        var length = ToInt32(bytes.Take(DataSize.INTEGER_SIZE).Reverse().ToArray());
        return new(new(Encoding.ASCII.GetString([.. bytes.Skip(DataSize.INTEGER_SIZE).Take(length)])), bytes.Skip(DataSize.INTEGER_SIZE + length));
        }

    public static new byte[] AsBytes(string value) => [.. GetBytes(value.Length).Reverse(), .. Encoding.ASCII.GetBytes(value)];
    }
