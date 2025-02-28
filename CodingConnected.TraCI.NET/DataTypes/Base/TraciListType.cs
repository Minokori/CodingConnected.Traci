#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// a <see cref="List{T}"/> of <see cref="TraciBaseType{U}"/> values
/// </summary>
/// <typeparam name="U">the type of value inner the <typeparamref name="T"/></typeparam>
/// <typeparam name="T">a class inherit from <see cref="TraciBaseType{T}"/></typeparam>
public abstract class TraciListType<U, T> : List<U>, ITraciType
    where U : TraciBaseType<T>
    {
    public virtual DataType TypeIdentifier => throw new NotImplementedException($"{nameof(TypeIdentifier)} is not implemented in abstract class");

    public virtual List<T> Value => [.. this.Select(i => i)];

    public virtual byte[] ToBytes()
        {
        List<byte> result = [];
        foreach (var item in this)
            {
            result.AddRange(item.ToBytes());
            }
        return [.. result];
        }

    public static (TraciListType<U, T> traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) =>
        throw new NotImplementedException($"{nameof(FromBytes)} is not implemented in abstract class");

    public static byte[] AsBytes(IEnumerable<T> value) =>
        throw new NotImplementedException($"{nameof(AsBytes)} is not implemented in abstract class");

    public static implicit operator List<T>(TraciListType<U, T> traciData) => traciData.Value;
    }
