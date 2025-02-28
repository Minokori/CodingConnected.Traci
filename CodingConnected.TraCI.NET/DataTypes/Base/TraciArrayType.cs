#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.DataTypes;
/// <summary>
/// a <see cref="List{T}"/> of <see cref="ITraciType"/> values<para/>
/// different from <see cref="TraciListType{U, T}"/>, this class is a <see cref="List{T}"/> of <see cref="ITraciType"/> values,
/// which means the inner type is uncertain.
/// </summary>
public abstract class TraciArrayType : List<ITraciType>
    {
    public virtual byte[] ToBytes()
        {
        List<byte> bytes = [];
        foreach (var item in this)
            {
            bytes.Add(item.TypeIdentifier.ToByte());
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static (TraciCompoundObject traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        throw new NotImplementedException($"{nameof(TraciArrayType)} cannot frombytes directly cause the class inner it is uncertain");

    public static byte[] AsBytes(List<ValueType> value) =>
        throw new NotImplementedException($"{nameof(TraciArrayType)} cannot {nameof(AsBytes)} directly cause the class inner it is uncertain");

    public static implicit operator List<object>(TraciArrayType traciData) =>
        throw new NotImplementedException($"{nameof(TraciArrayType)} cannot convert to List<object> directly cause the class inner it is uncertain");
    }