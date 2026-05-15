using System.Diagnostics.CodeAnalysis;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// a <see cref="List{T}"/> of <see cref="TraciBaseType{U}"/> values
/// </summary>
/// <typeparam name="TBaseType">a class inherit from <see cref="TraciBaseType{T}"/></typeparam>
/// <typeparam name="TValue">the type of value inner the <typeparamref name="TValue"/></typeparam>
public abstract class TraciListType<TBaseType, TValue> : List<TBaseType>, ITraciType where TBaseType : TraciBaseType<TValue>
    {
    public virtual DataType TypeIdentifier => DataType.Null;

    public virtual List<TValue> Value => [.. this.Select(i => i)];



    public virtual void WriteToSpan(Span<byte> destination, ref int offset)
        {
        foreach (var item in this)
            {
            item.WriteToSpan(destination, ref offset);
            }
        }

    public static implicit operator List<TValue>([NotNull] TraciListType<TBaseType, TValue> traciData) => traciData.Value;

    public override string? ToString() => $"[{string.Concat(Value.Select(i => i!.ToString() + ", "))}]";

    }