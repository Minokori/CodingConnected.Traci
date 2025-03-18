namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// convert between Traci types.<para/>
/// mainly used for converting <see cref="TraciCompoundObject"/> to specific type
/// </summary>
public static class TraciTypeExtensions
    {
    public static List<EdgeInformation> ToEdgeInformationList(this TraciCompoundObject content)
        {
        List<EdgeInformation> edges = [];
        var numberOfEdges = content.Count / 6;
        for (var i = 0; i < numberOfEdges; i++)
            {
            EdgeInformation edge = new(content.Skip(0 + (6 * i)).Take(6));
            edges.Add(edge);
            }
        return edges;
        }

    public static List<UpcomingTrafficLights> ToUpcomingTrafficLights(
        this TraciCompoundObject content
    ) => [.. content.Skip(1).Chunk(4).Select(i => (UpcomingTrafficLights)i.ToList())];

    public static List<TrafficLightLogic> ToTrafficLightLogics(this TraciCompoundObject content)
        {
        List<TrafficLightLogic> result = [];

        foreach (var trafficLightLogic in content.Cast<TraciCompoundObject>())
            {
            TrafficLightLogic item = new(trafficLightLogic);
            result.Add(item);
            }
        return result;
        }

    public static List<ControlledLinks> ToControlledLinks(this TraciCompoundObject content)
        {
        List<ControlledLinks> result = [];
        // int numberOfSignals = (TraciInteger)content.First();
        var remainContent = content.Skip(1 /*skip the number of signals*/);
        while (remainContent.Any())
            {
            var linksNumber = (TraciInteger)remainContent.First();
            ControlledLinks link = new(remainContent.Take(1 + linksNumber));
            remainContent = remainContent.Skip(1 + linksNumber);
            result.Add(link);
            }
        return result;
        }

    public static List<VehicleInformationPacket> ToVehicleInformationPackets(
        this TraciCompoundObject content
    ) => [.. content.Skip(1).Chunk(5).Select(i => new VehicleInformationPacket(i))];

    public static List<Link> ToLinks(this TraciCompoundObject content) =>
        [.. content.Skip(1).Chunk(8).Select(i => new Link(i))];

    public static List<StopData> ToStopDataList(this TraciCompoundObject content) =>
        [.. content.Skip(1).Chunk(16).Select(i => new StopData(i))];

    public static List<Foe> ToJunctionFoes(this TraciCompoundObject content) =>
        [.. content.Skip(1).Chunk(9).Select(i => (Foe)i.ToList())];
    }
