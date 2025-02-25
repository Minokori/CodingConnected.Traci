#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;
/// <summary>
/// Implementing this interface indicates that the class is a traci data type.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#data_types"/>
/// </remarks>
public interface ITraciType
    {
    /// <summary>
    /// The type identifier of the Traci data type.
    /// </summary>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci.constants.html"/>
    /// </remarks>
    byte TYPE => throw new NotImplementedException($"{nameof(TYPE)} is not implemented in interface");

    /// <summary>
    /// convert the data to bytes for TCP.
    /// </summary>
    /// <returns>bytes that send to TCP port</returns>
    byte[] ToBytes() => throw new NotImplementedException($"{nameof(ToBytes)} is not implemented in interface");
    }




