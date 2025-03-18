namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// a single phase in <see cref="TrafficLightPhaseList"/>
/// </summary>
public class TrafficLightPhase : TraciArrayType
    {
    /// <summary>
    /// preceding road affected by the respective light phase.
    /// </summary>
    public string PrecedingRoad => (TraciString)this[0];

    /// <summary>
    /// succeeding road affected by the respective light phase.
    /// </summary>
    public string SucceedingRoad => (TraciString)this[1];
    public PhaseState Phase => (PhaseState)((TraciByte)this[2]).Value;

    public static new (
        TrafficLightPhase trafficLightPhase,
        IEnumerable<byte> remainingBytes
    ) FromBytes(IEnumerable<byte> bytes)
        {
        (var precRoad, bytes) = TraciString.FromBytes(bytes);
        (var succRoad, bytes) = TraciString.FromBytes(bytes);
        (var phase, bytes) = TraciByte.FromBytes(bytes);
        TrafficLightPhase result = [precRoad, succRoad, phase];
        return new(result, bytes);
        }

    private TrafficLightPhase() { }

    public TrafficLightPhase(string precedingRoad, string succeedingRoad, PhaseState phase)
        {
        this[0] = new TraciString(precedingRoad);
        this[1] = new TraciString(succeedingRoad);
        this[2] = new TraciByte((byte)phase);
        }
    }
