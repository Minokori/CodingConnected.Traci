using CodingConnected.TraCI.NET.Constants;

namespace CodingConnected.TraCI.NET.Types;

public enum PhaseState : byte
    {
    Red = 0x01,
    Yellow = 0x02,
    Green = 0x03,
    OffBlinking = 0x04,
    OffNotBlinking = 0x05,
    }

public struct TrafficLightPhase : ITraCIType
    {
    public readonly byte TYPE => throw new NotImplementedException();
    public TraCIString PrecRoad { get; set; }
    public TraCIString SuccRoad { get; set; }
    public PhaseState Phase { get; set; }

    public readonly byte[] ToBytes() => [.. PrecRoad.ToBytes(), .. SuccRoad.ToBytes(), (byte)Phase];

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

public class TrafficLightPhaseList : List<TrafficLightPhase>, ITraCIType
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
