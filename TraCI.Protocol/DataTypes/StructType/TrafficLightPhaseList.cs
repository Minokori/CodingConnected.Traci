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
    }
