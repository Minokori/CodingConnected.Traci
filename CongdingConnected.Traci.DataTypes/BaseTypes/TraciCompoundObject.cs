
using System.Buffers.Binary;

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
    public virtual DataType TypeIdentifier => HasCount ? DataType.COMPOUND : DataType.NULL;

    public override byte[] ToBytes()
        {
        List<byte> bytes = [];
        bytes.AddRange(HasCount ? new TraciInteger(Count).ToBytes() : []);
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }

    public override void WriteToSpan(Span<byte> span, ref int offset)
        {
        if (HasCount)
            {
            BinaryPrimitives.WriteInt32BigEndian(span[offset..], Count);
            offset += DataSize.INTEGER_SIZE;
            }
        base.WriteToSpan(span, ref offset);
        }

    public TraciCompoundObject()
        {

        }

    public TraciCompoundObject(IEnumerable<ITraciType> innerObjects) : base(innerObjects)
        {
        }
    }
