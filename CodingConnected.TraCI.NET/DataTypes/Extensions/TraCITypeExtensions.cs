#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// convert between Traci types.<para/>
/// mainly used for converting <see cref="TraciCompoundObject"/> to specific type
/// </summary>
internal static class TraciTypeExtensions
    {
    internal static List<EdgeInformation> ToEdgeInformationList(this TraciCompoundObject content)
        {
        List<EdgeInformation> edges = [];
        //var numberOfEdges = (TraciInteger)content[0];
        var numberOfEdges = content.Count / 6;
        for (var i = 0; i < numberOfEdges; i++)
            {
            // TODO it seems no need to skip 1 + (6*i), check it
            var edge = (EdgeInformation)content.Skip(0 + (6 * i)).Take(6);
            edges.Add(edge);
            }
        return edges;
        }

    internal static List<UpcomingTrafficLights> ToUpcomingTrafficLights(this TraciCompoundObject content) =>
        [.. content.Skip(1).Chunk(4).Select(i => (UpcomingTrafficLights)i.ToList())];

    internal static List<TrafficLightLogic> ToTrafficLightLogics(this TraciCompoundObject content)
        {
        List<TrafficLightLogic> result = [];

        foreach (var trafficLightLogic in content.Cast<TraciCompoundObject>())
            {
            TrafficLightLogic item = new(trafficLightLogic);
            result.Add(item);
            }
        return result;

        }

    internal static List<ControlledLinks> ToControlledLinks(this TraciCompoundObject content)
        {
        List<ControlledLinks> result = [];
        int numberOfSignals = (TraciInteger)content.First();
        var remainContent = content.Skip(1);
        while (remainContent.Count() > 0)
            {
            var linksNumber = (TraciInteger)remainContent.First();
            ControlledLinks link = new(remainContent.Take(1 + linksNumber));
            remainContent = remainContent.Skip(1 + linksNumber);
            result.Add(link);
            }
        return result;
        }

    internal static List<VehicleInformationPacket> ToVehicleInformationPackets(this TraciCompoundObject content) =>
        [.. content.Skip(1).Chunk(5).Select(i => (VehicleInformationPacket)i.ToList())];

    internal static List<Link> ToLinks(this TraciCompoundObject content) => [.. content.Skip(1).Chunk(8).Select(i => new Link(i))];

    internal static List<StopData> ToStopDataList(this TraciCompoundObject content) =>
        [.. content.Skip(1).Chunk(6).Select(i => (StopData)i.ToList())];

    internal static List<Foe> ToJunctionFoes(this TraciCompoundObject content) => content.Skip(1).Chunk(9).Select(i => (Foe)i.ToList()).ToList();
    }
