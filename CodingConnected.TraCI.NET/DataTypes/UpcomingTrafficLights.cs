namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Vehicle_Value_Retrieval.html#next_tls_0x70"/>
/// </summary>
public class UpcomingTrafficLights : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;
    public new byte TYPE => throw new NotImplementedException();
    public TraCIString TrafficLightsId { get; init; }

    public TraCIInteger TrafficLightsLinkIndex { get; init; }

    /// <summary>
    /// distance to TLS
    /// </summary>
    public TraCIDouble Distance { get; init; }
    /// <summary>
    /// see<see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#signal_state_definitions"/>
    /// </summary>
    public TraCIByte State { get; init; }
    }

