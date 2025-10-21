namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// traci 数据类型的基础值类型.
/// 例如 int, double ,string 等<para/>
/// base value type for traci data type.
/// Such as integer, double, string, etc.
/// </summary>
/// <typeparam name="T">
/// traci 数据类型对应的 .NET 类型<para/>
/// the type of data included in class</typeparam>
/// <param name="value">要包装成 Traci 类型的值</param>
public abstract class TraciBaseType<T>(T value) : ITraciType
    {
    public virtual DataType TypeIdentifier =>
        throw new NotImplementedException(
            $"{nameof(TypeIdentifier)} is not implemented in abstract class"
        );
    /// <summary>
    /// traci 数据类型的值 (.NET对应类型)
    /// </summary>
    public virtual T Value { get; init; } = value;

    public virtual byte[] ToBytes() =>
        throw new NotImplementedException(
            $"{nameof(ToBytes)} is not implemented in abstract class"
        );

    /// <summary>
    /// 从字节流中解析出 traci 数值, 并返回剩下的字节流<para/>
    /// </summary>
    /// <param name="bytes">字节流</param>
    /// <returns>解析出的 traci 数值, 剩下的字节流</returns>
    public static (TraciBaseType<T> traciData, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    ) =>
        throw new NotImplementedException(
            $"{nameof(FromBytes)} is not implemented in abstract class"
        );

    public static implicit operator T(TraciBaseType<T> traciData) => traciData.Value;
    public override string? ToString() => Value!.ToString();
    }
