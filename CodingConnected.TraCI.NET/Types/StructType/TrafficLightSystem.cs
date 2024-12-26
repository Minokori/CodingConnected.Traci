namespace CodingConnected.TraCI.NET.Types;

public readonly struct TrafficLightSystem : ITraCIType
    {
    public readonly byte TYPE => throw new NotImplementedException();
    public string TrafficLightSystemId { get; init; }
    public int TrafficLightSystemLinkIndex { get; init; }
    public double DistanceToTrafficLightSystem { get; init; }
    public byte LinkState { get; init; }
    }

