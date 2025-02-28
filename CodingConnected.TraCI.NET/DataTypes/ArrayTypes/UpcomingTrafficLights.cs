#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Vehicle_Value_Retrieval.html#next_tls_0x70"/>
/// </summary>
public sealed class UpcomingTrafficLights : TraciArrayType
    {
    public string TrafficLightsId => (TraciString)this[0];

    public int TrafficLightsLinkIndex => (TraciInteger)this[1];

    /// <summary>
    /// distance to TLS
    /// </summary>
    public double Distance => (TraciDouble)this[2];

    /// <summary>
    /// see<see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#signal_state_definitions"/>
    /// </summary>
    public byte State => (TraciByte)this[3];
    }
