namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// phase state of traffic light, inherited from <see cref="byte"/>
/// </summary>
public enum PhaseState : byte
    {
    Red = 0x01,
    Yellow = 0x02,
    Green = 0x03,
    OffBlinking = 0x04,
    OffNotBlinking = 0x05,
    }


/// <summary>
/// a single phase in <see cref="TrafficLightPhaseList"/>
/// </summary>
public class TrafficLightPhase : ITraciType
    {
    public byte TYPE => throw new NotImplementedException();

    /// <summary>
    /// preceding road affected by the respective light phase.
    /// </summary>
    public TraCIString PrecRoad { get; set; }
    /// <summary>
    /// succeeding road affected by the respective light phase.
    /// </summary>
    public TraCIString SuccRoad { get; set; }
    public PhaseState Phase { get; set; }

    public byte[] ToBytes() => [.. PrecRoad.ToBytes(), .. SuccRoad.ToBytes(), (byte)Phase];

    public static Tuple<TrafficLightPhase, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var precRoad, bytes) = TraCIString.FromBytes(bytes);
        (var succRoad, bytes) = TraCIString.FromBytes(bytes);
        (var phase, bytes) = TraCIByte.FromBytes(bytes);
        TrafficLightPhase result = new()
            {
            PrecRoad = precRoad,
            SuccRoad = succRoad,
            Phase = (PhaseState)phase.Value,
            };
        return new(result, bytes);
        }
    }


/// <summary>
/// This type is used to report the different phases of a traffic light.
/// A total of Length phases is reported 
/// together with the preceding and succeeding roads 
/// that are affected by the respective light phase.
/// </summary>
/// <remarks>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#traffic_light_phase_list_ubyte_identifier_0x0d"/>
/// </remarks>
public class TrafficLightPhaseList : List<TrafficLightPhase>, ITraciType
    {
    public byte TYPE => TraCIConstants.TYPE_TLPHASELIST;

    public byte[] ToBytes()
        {
        List<byte> bytes = [(byte)this.Count];
        foreach (var item in this)
            {
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static Tuple<TrafficLightPhaseList, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        int count = bytes.First();
        bytes = bytes.Skip(1);
        List<TrafficLightPhase> phases = [];

        for (var i = 0; i < count; i++)
            {
            (var phase, bytes) = TrafficLightPhase.FromBytes(bytes);
            phases.Add(phase);
            }

        return new(phases as TrafficLightPhaseList, bytes);
        }
    }
