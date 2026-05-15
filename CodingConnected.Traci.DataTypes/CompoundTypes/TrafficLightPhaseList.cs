
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// This type is used to report the different phases of a traffic light.
/// A total of Length phases is reported
/// together with the preceding and succeeding roads
/// that are affected by the respective light phase.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#traffic_light_phase_list_ubyte_identifier_0x0d"/>
/// </remarks>
public sealed class TrafficLightPhaseList : List<TrafficLightPhase>, ITraciType, ITraciParserable<TrafficLightPhaseList>
    {
    public DataType TypeIdentifier => DataType.TLPhaseList;


    public void WriteToSpan(Span<byte> destination, ref int offset)
        {
        destination[offset] = (byte)Count;
        offset += 1;
        foreach (var item in this)
            {
            item.WriteToSpan(destination[offset..], ref offset);
            }
        }

    public static TrafficLightPhaseList Parse(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        int count = sourceBytes[0];
        sourceBytes = sourceBytes[1..];
        List<TrafficLightPhase> phases = [];
        for (var i = 0; i < count; i++)
            {
            var phase = TrafficLightPhase.Parse(sourceBytes, out sourceBytes);
            phases.Add(phase);
            }
        remainingBytes = sourceBytes;
        return (TrafficLightPhaseList)phases;
        }
    }
