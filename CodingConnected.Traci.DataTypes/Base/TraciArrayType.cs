namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// a <see cref="List{T}"/> of <see cref="ITraciType"/> values<para/>
/// different from <see cref="TraciListType{U, T}"/>, this class is a <see cref="List{T}"/> of <see cref="ITraciType"/> values,
/// which means the inner type is uncertain.
/// </summary>
public abstract class TraciArrayType : List<ITraciType>, ITraciType
    {

    public virtual void WriteToSpan(Span<byte> destination, ref int offset)
        {
        foreach (var item in this)
            {
            if (item.TypeIdentifier != DataType.Null)
                {
                destination[offset] = (byte)item.TypeIdentifier;
                offset += 1;
                }
            item.WriteToSpan(destination, ref offset);
            }
        }

    protected TraciArrayType(IEnumerable<ITraciType>? innerObjects = null)
        {
        Clear();
        if (innerObjects != null)
            {
            AddRange(innerObjects);
            }
        }
    public override string? ToString() => $"[{string.Concat(this.Select(i => i!.ToString() + ", "))}]";
    }
