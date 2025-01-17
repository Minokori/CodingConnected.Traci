namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// convert between TraCI types.
/// </summary>
internal static class TraCITypeExtensions
    {
    internal static List<EdgeInformation> ToEdgeInformations(this TraCICompoundObject content)
        {
        List<EdgeInformation> edges = [];
        var numberOfEdges = (content[0] as TraCIInteger).Value;
        for (var i = 0; i < numberOfEdges; i++)
            {
            var edge = content.Skip(1 + (6 * i)).Take(6) as EdgeInformation;
            edges.Add(edge);
            }
        return edges;
        }

    internal static List<UpcomingTrafficLights> ToUpcomingTrafficLights(this TraCICompoundObject content)
        {
        return content.Skip(1).Chunk(4).Select(i => (UpcomingTrafficLights)i.ToList()).ToList();
        }

    internal static List<TrafficLightLogic> ToTrafficLightLogics(this TraCICompoundObject content)
        {
        List<TrafficLightLogic> result = [];
        var numberOfLogics = (content[0] as TraCIInteger).Value;
        content = (TraCICompoundObject)content.Skip(1);
        while (content.Count > 0)
            {
            var totalLengthOfLogic = 5 + (((TraCIInteger)content.Skip(4).First()).Value * 4);
            var logic = (TrafficLightLogic)content.Take(totalLengthOfLogic);
            content = (TraCICompoundObject)content.Skip(totalLengthOfLogic);
            result.Add(logic);
            }
        return result;
        }

    internal static List<ControlledLinks> ToControlledLinks(this TraCICompoundObject content)
        {
        List<ControlledLinks> result = [];
        while (content.Count > 0)
            {
            var totalLengthOfLinks = 1 + ((TraCIInteger)content.First()).Value;
            var links = (ControlledLinks)content.Take(totalLengthOfLinks);
            content = (TraCICompoundObject)content.Skip(totalLengthOfLinks);
            result.Add(links);
            }
        return result;
        }

    internal static List<VehicleInformationPacket> ToVehicleInformationPackets(this TraCICompoundObject content)
        {
        return content.Skip(1).Chunk(5).Select(i => (VehicleInformationPacket)i.ToList()).ToList();
        }

    internal static List<Link> ToLinks(this TraCICompoundObject content)
        {
        return content.Skip(1).Chunk(8).Select(i => (Link)i.ToList()).ToList();
        }

    internal static List<StopData> ToStopDatas(this TraCICompoundObject content)
        {
        return content.Skip(1).Chunk(6).Select(i => (StopData)i.ToList()).ToList();
        }

    internal static List<Foe> ToJunctionFoes(this TraCICompoundObject content)
        {
        return content.Skip(1).Chunk(9).Select(i => (Foe)i.ToList()).ToList();
        }
    }
