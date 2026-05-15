
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
    /// when <see cref="WriteToSpan(Span{byte}, ref int)"/>, add count or not
    /// </summary>
    /// <remarks>
    /// If a class inherited from <see cref="TraciCompoundObject"/> is a subList of other class inherited from <see cref="TraciCompoundObject"/>,
    /// may be the count shouldn't be added.
    /// In theses cases, override this property to false.
    /// </remarks>
    protected virtual bool HasCount => true;
    public virtual DataType TypeIdentifier => HasCount ? DataType.Compound : DataType.Null;


    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        if (HasCount)
            {
            BinaryPrimitives.WriteInt32BigEndian(destination[offset..], Count);
            offset += DataSize.IntegerSize;
            }
        base.WriteToSpan(destination, ref offset);
        }

    public TraciCompoundObject()
        {

        }

    public TraciCompoundObject(IEnumerable<ITraciType> innerObjects) : base(innerObjects)
        {
        }
    }
