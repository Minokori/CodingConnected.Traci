namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// 继承该接口表示该类是一个 traci 数据类型。<para/>
/// Implementing this interface indicates that the class is a traci data type.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#data_types"/>
/// </remarks>
public interface ITraciType
    {
    /// <summary>
    /// 类型标识符。<para/>
    /// The type identifier of the Traci data type.
    /// </summary>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci.constants.html"/>
    /// </remarks>
    DataType TypeIdentifier => DataType.NULL;

    /// <summary>
    /// 将数据转换为 TCP 发送的字节。<b>不包括类型标识符（重要）</b><para/>
    /// convert the data to bytes for TCP. <b>NOT CONTAINS TYPEIDENTIFIER(!)</b>
    /// </summary>
    /// <returns>bytes that send to TCP port</returns>
    byte[] ToBytes() => throw new NotImplementedException();

    /// <summary>
    /// 将数据写入到指定的 Span 中。<para/>
    /// </summary>
    /// <param name="destination">指定的span</param>
    /// <param name="offset">写入的索引位置 (该索引位置将写入)</param>
    /// <exception cref="NotImplementedException"></exception>
    void WriteToSpan(Span<byte> destination, ref int offset) => throw new NotImplementedException();
    }

/// <summary>
/// 实现该接口表示该类可以从字节流中解析出 traci 数值。<para/>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IFromTraci<T>
    {
    /// <summary>
    /// 从字节流中解析出 traci 数值, 并返回剩下的字节流<para/>
    /// </summary>
    /// <param name="sourceBytes">字节流</param>
    /// <param name="remainingBytes">剩下的字节流</param>
    /// <returns></returns>
    static abstract T FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes);
    }
