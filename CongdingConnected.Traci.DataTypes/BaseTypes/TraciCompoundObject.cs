namespace CodingConnected.Traci.DataTypes;
/// <summary>
/// a <see cref="List{T}"/> of <see cref="ITraciType"/> values
/// </summary>
/// <remarks>
/// Compound object, internal structure depends on inner object.
/// </remarks>
public class TraciCompoundObject : TraciArrayType, ITraciType
    {
    /// <summary>
    /// only in completed TLS define is false, whose count is 0.
    /// </summary>
    protected virtual bool HasCount => true;

    /// <summary>
    /// when <see cref="ToBytes"/>, add count or not
    /// </summary>
    /// <remarks>
    /// If a class inherited from <see cref="TraciCompoundObject"/> is a subList of other class inherited from <see cref="TraciCompoundObject"/>,
    /// may be the count shouldn't be added.
    /// In theses cases, override this property to false.
    /// </remarks>
    protected virtual bool IsComplete => true;
    public virtual DataType TypeIdentifier => IsComplete ? DataType.COMPOUND : throw new NotImplementedException($"a sub-list of {nameof(TraciCompoundObject)} has no TYPE ");

    public override byte[] ToBytes()
        {
        List<byte> bytes = [];
        bytes.AddRange(IsComplete ? TraciInteger.AsBytes(HasCount ? Count : 0) : []);
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }

    public static new (TraciCompoundObject traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) => throw new NotImplementedException($"{nameof(TraciCompoundObject)} cannot frombytes directly cause the class inner it is uncertain");

    public static new byte[] AsBytes(List<ValueType> value) =>
        throw new NotImplementedException($"{nameof(TraciCompoundObject)} cannot {nameof(AsBytes)} directly cause the class inner it is uncertain");

    public TraciCompoundObject()
        {

        }

    public TraciCompoundObject(IEnumerable<ITraciType> innerObjects) : base(innerObjects)
        {
        }
    }
