using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public enum PhaseState : byte
    {
    Red = 0x01,
    Yellow = 0x02,
    Green = 0x03,
    OffBlinking = 0x04,
    OffNotBlinking = 0x05
    }

public struct TrafficLightPhase : ITraCIType
    {
    public readonly byte TYPE => throw new NotImplementedException();
    public string PrecRoad { get; set; }
    public string SuccRoad { get; set; }
    public PhaseState Phase { get; set; }

    public readonly byte[] ToBytes() => [..PrecRoad.ToTraCIBytes(),
    ..SuccRoad.ToTraCIBytes(),..Phase.ToTraCIBytes()];

    public static Tuple<TrafficLightPhase, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var precRoad, bytes) = TraCIString.FromBytes(bytes);
        (var succRoad, bytes) = TraCIString.FromBytes(bytes);
        (var phase, bytes) = TraCIByte.FromBytes(bytes);
        TrafficLightPhase result = new() { PrecRoad = precRoad.Value, SuccRoad = succRoad.Value, Phase = (PhaseState)phase.Value };
        return new(result, bytes);
        }
    }

public struct TrafficLightPhaseList : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.TYPE_TLPHASELIST;
    public List<TrafficLightPhase> Phases { get; set; }
    public readonly byte[] ToBytes()
        {
        List<byte> bytes = [.. ((byte)Phases.Count).ToTraCIBytes()];
        foreach (var item in Phases)
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

        TrafficLightPhaseList result = new() { Phases = phases };
        return new(result, bytes);
        }
    }
