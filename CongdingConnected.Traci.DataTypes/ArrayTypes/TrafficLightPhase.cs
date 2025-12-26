
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// a single phase in <see cref="TrafficLightPhaseList"/>
/// </summary>
public sealed class TrafficLightPhase : TraciArrayType, ITraciType, IFromTraci<TrafficLightPhase>
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

    public static TrafficLightPhase FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var precRoad = TraciString.FromSpan(sourceBytes, out sourceBytes);
        var succRoad = TraciString.FromSpan(sourceBytes, out sourceBytes);
        var phase = TraciByte.FromSpan(sourceBytes, out remainingBytes);
        return [precRoad, succRoad, phase];
        }

    private TrafficLightPhase() { }

    public TrafficLightPhase(string precedingRoad, string succeedingRoad, PhaseState phase)
        {
        this[0] = new TraciString(precedingRoad);
        this[1] = new TraciString(succeedingRoad);
        this[2] = new TraciByte((byte)phase);
        }
    }
