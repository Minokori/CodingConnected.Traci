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
    DataType TypeIdentifier =>
        throw new NotImplementedException(
            $"{nameof(TypeIdentifier)} is not implemented in interface"
        );

    /// <summary>
    /// 将数据转换为 TCP 发送的字节。<b>不包括类型标识符（重要）</b><para/>
    /// convert the data to bytes for TCP. <b>NOT CONTAINS TYPEIDENTIFIER(!)</b>
    /// </summary>
    /// <returns>bytes that send to TCP port</returns>
    byte[] ToBytes() =>
        throw new NotImplementedException($"{nameof(ToBytes)} is not implemented in interface");
    }
