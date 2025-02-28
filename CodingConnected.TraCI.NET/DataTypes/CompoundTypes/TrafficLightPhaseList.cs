using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// This type is used to report the different phases of a traffic light.
/// A total of Length phases is reported 
/// together with the preceding and succeeding roads 
/// that are affected by the respective light phase.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#traffic_light_phase_list_ubyte_identifier_0x0d"/>
/// </remarks>
public sealed class TrafficLightPhaseList : List<TrafficLightPhase>, ITraciType
    {
    public DataType TypeIdentifier => DataType.TLPHASELIST;

    public byte[] ToBytes()
        {
        List<byte> bytes = [(byte)this.Count];
        foreach (var item in this)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static (TrafficLightPhaseList tlsPhaseList, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        // how many phases are there
        int count = bytes.First();
        bytes = bytes.Skip(1);

        // a list to put the phases in
        List<TrafficLightPhase> phases = [];

        for (var i = 0; i < count; i++)
            {
            (var phase, bytes) = TrafficLightPhase.FromBytes(bytes);
            phases.Add(phase);
            }
        return new((TrafficLightPhaseList)phases, bytes);
        }
    }
