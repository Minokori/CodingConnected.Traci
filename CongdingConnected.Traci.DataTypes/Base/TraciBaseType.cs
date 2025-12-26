
using System.Diagnostics.CodeAnalysis;

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
    public virtual DataType TypeIdentifier => DataType.NULL;

    /// <summary>
    /// traci 数据类型的值 (.NET对应类型)
    /// </summary>
    public virtual T Value { get; init; } = value;

    public virtual byte[] ToBytes() => throw new NotImplementedException();
    public virtual void WriteToSpan(Span<byte> destination, ref int offset) => throw new NotImplementedException();

    public static implicit operator T([NotNull] TraciBaseType<T> traciData) => traciData.Value;

    public override string? ToString() => Value!.ToString();
    }
