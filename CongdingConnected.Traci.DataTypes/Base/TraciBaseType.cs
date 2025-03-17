#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

namespace CodingConnected.Traci.DataTypes;
/// <summary>
/// base value type for traci data type.
/// Such as integer, double, string, etc.
/// </summary>
/// <typeparam name="T">the type of data included in class</typeparam>
/// <param name="value"></param>
public abstract class TraciBaseType<T>(T value) : ITraciType
    {
    public virtual DataType TypeIdentifier => throw new NotImplementedException($"{nameof(TypeIdentifier)} is not implemented in abstract class");
    public virtual T Value { get; init; } = value;
    public virtual byte[] ToBytes() => throw new NotImplementedException($"{nameof(ToBytes)} is not implemented in abstract class");


    public static (TraciBaseType<T> traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) => throw new NotImplementedException($"{nameof(FromBytes)} is not implemented in abstract class");
    public static byte[] AsBytes(T value) => throw new NotImplementedException($"{nameof(AsBytes)} is not implemented in abstract class");

    public static implicit operator T(TraciBaseType<T> traciData) => traciData.Value;

    public override string? ToString() => Value!.ToString();
    }


