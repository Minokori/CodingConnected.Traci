namespace CodingConnected.Traci.DataTypes;

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
            if (item.TypeIdentifier != DataType.NULL)
                {
                bytes.Add((byte)item.TypeIdentifier);
                }
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static (TraciCompoundObject traciData, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    ) =>
        throw new NotImplementedException(
            $"{nameof(TraciArrayType)} cannot frombytes directly cause the class inner it is uncertain"
        );

    public static byte[] AsBytes(List<ValueType> value) =>
        throw new NotImplementedException(
            $"{nameof(TraciArrayType)} cannot {nameof(AsBytes)} directly cause the class inner it is uncertain"
        );

    public static implicit operator List<object>(TraciArrayType traciData) =>
        throw new NotImplementedException(
            $"{nameof(TraciArrayType)} cannot convert to List<object> directly cause the class inner it is uncertain"
        );

    protected TraciArrayType(IEnumerable<ITraciType>? innerObjects = null)
        {
        Clear();
        if (innerObjects != null)
            AddRange(innerObjects);
        }
    }
