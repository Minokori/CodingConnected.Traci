namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// a <see cref="List{T}"/> of <see cref="ITraciType"/> values<para/>
/// different from <see cref="TraciListType{U, T}"/>, this class is a <see cref="List{T}"/> of <see cref="ITraciType"/> values,
/// which means the inner type is uncertain.
/// </summary>
public abstract class TraciArrayType : List<ITraciType>
    {
    /// <summary>
    /// 将数据转换为 TCP 发送的字节。<b>不包括类型标识符（重要）</b><para/>
    /// convert the data to bytes for TCP. <b>NOT CONTAINS TYPEIDENTIFIER(!)</b>
    /// </summary>
    /// <returns>bytes that send to TCP port</returns>
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

    public virtual void WriteToSpan(Span<byte> span, ref int offset)
        {
        foreach (var item in this)
            {
            if (item.TypeIdentifier != DataType.NULL)
                {
                span[offset] = (byte)item.TypeIdentifier;
                offset += 1;
                }
            item.WriteToSpan(span, ref offset);
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

    }


public interface ITraciArrayType : IList<ITraciType>, ITraciType
    {
    /// <summary>
    /// 将数据转换为 TCP 发送的字节。<b>不包括类型标识符（重要）</b><para/>
    /// convert the data to bytes for TCP. <b>NOT CONTAINS TYPEIDENTIFIER(!)</b>
    /// </summary>
    /// <returns>bytes that send to TCP port</returns>
    new virtual byte[] ToBytes()
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
    }
