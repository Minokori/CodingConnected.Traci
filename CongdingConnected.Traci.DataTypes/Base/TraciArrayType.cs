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
    /// <summary>
    /// 从字节流中解析出 traci 数值, 并返回剩下的字节流<para/>
    /// </summary>
    /// <param name="bytes">字节流</param>
    /// <returns>解析出的 traci 数值, 剩下的字节流</returns>
    public static (TraciCompoundObject traciData, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    ) =>
        throw new NotImplementedException(
            $"{nameof(TraciArrayType)} cannot frombytes directly cause the class inner it is uncertain"
        );

    //隐式转换符
    public static implicit operator List<object>(TraciArrayType traciData) =>
        throw new NotImplementedException(
            $"{nameof(TraciArrayType)} cannot convert to List<object> directly cause the class inner it is uncertain"
        );

    protected TraciArrayType(IEnumerable<ITraciType>? innerObjects = null)
        {
        Clear();
        if (innerObjects != null)
            {
            AddRange(innerObjects);
            }
        }
    }
