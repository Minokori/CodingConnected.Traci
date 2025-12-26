#pragma warning disable CA1034,CA1851 // 嵌套类型应不可见
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// convert between Traci types.<para/>
/// mainly used for converting <see cref="TraciCompoundObject"/> to specific type
/// </summary>
public static class TraciTypeExtensions
    {
    extension(TraciCompoundObject content)
        {
        public IList<ControlledLinks> ToControlledLinks()
            {
            List<ControlledLinks> result = [];
            // int numberOfSignals = (TraciInteger)content.First();
            var remainContent = content.Skip(
                1 /*skip the number of signals*/
            );
            while (remainContent.Any())
                {
                var linksNumber = (TraciInteger)remainContent.First();
                ControlledLinks link = new(remainContent.Take(1 + linksNumber));
                remainContent = remainContent.Skip(1 + linksNumber);
                result.Add(link);
                }
            return result;
            }

        public IList<EdgeInformation> ToEdgeInformationList()
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

        public IList<Foe> ToJunctionFoes() =>
            [.. content.Skip(1).Chunk(9).Select(i => (Foe)i.ToList())];

        public IList<Link> ToLinks() => [.. content.Skip(1).Chunk(8).Select(i => new Link(i))];

        public IList<StopData> ToStopDataList() =>
            [.. content.Skip(1).Chunk(16).Select(i => new StopData(i))];

        public IList<TrafficLightLogic> ToTrafficLightLogics()
            {
            List<TrafficLightLogic> result = [];

            foreach (var trafficLightLogic in content.Cast<TraciCompoundObject>())
                {
                TrafficLightLogic item = new(trafficLightLogic);
                result.Add(item);
                }
            return result;
            }

        public IList<UpcomingTrafficLights> ToUpcomingTrafficLights() =>
            [.. content.Skip(1).Chunk(4).Select(i => (UpcomingTrafficLights)i.ToList())];

        public IList<VehicleInformationPacket> ToVehicleInformationPackets() =>
            [.. content.Skip(1).Chunk(5).Select(i => new VehicleInformationPacket(i))];
        }
    }
