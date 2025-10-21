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
    /// when <see cref="ToBytes"/>, add count or not
    /// </summary>
    /// <remarks>
    /// If a class inherited from <see cref="TraciCompoundObject"/> is a subList of other class inherited from <see cref="TraciCompoundObject"/>,
    /// may be the count shouldn't be added.
    /// In theses cases, override this property to false.
    /// </remarks>
    protected virtual bool HasCount => true;
    public virtual DataType TypeIdentifier => HasCount ? DataType.COMPOUND : throw new NotImplementedException($"a sub-list of {nameof(TraciCompoundObject)} has no TYPE ");

    public override byte[] ToBytes()
        {
        List<byte> bytes = [];
        bytes.AddRange(HasCount ? new TraciInteger(Count).ToBytes() : []);
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }

    public static new (TraciCompoundObject traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes) => throw new NotImplementedException($"{nameof(TraciCompoundObject)} cannot frombytes directly cause the class inner it is uncertain");


    public TraciCompoundObject()
        {

        }

    public TraciCompoundObject(IEnumerable<ITraciType> innerObjects) : base(innerObjects)
        {
        }
    }
