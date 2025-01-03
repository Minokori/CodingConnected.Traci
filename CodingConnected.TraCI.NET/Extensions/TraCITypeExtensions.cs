using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Extensions;

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
            var edge = content.Skip(1 + (6 * i)).Take(6) as TraCICompoundObject as EdgeInformation;
            edges.Add(edge);
            }
        return edges;
        }

    internal static List<TrafficLightSystem> ToTrafficLightSystems(this TraCICompoundObject content)
        {
        List<TrafficLightSystem> systems = [];

        var numberOfTLS = (content[0] as TraCIInteger).Value;

        for (var i = 0; i < numberOfTLS; i++)
            {
            var tls = content.Skip(1 + (4 * i)).Take(4) as TraCICompoundObject as TrafficLightSystem;
            systems.Add(tls);
            }

        return systems;
        }
    internal static TrafficCompleteLightProgram ToTrafficLightCompleteProgram(this TraCICompoundObject content)
        {
        TrafficCompleteLightProgram result = new()
            {
            NumberOfLogics = (content[0] as TraCIInteger),
            };

        var len = 0; //offset for number of logics
                     // for 1 logic  = 5 + (4 * number of phases)

        for (var i = 0; i < result.NumberOfLogics.Value; i++)
            {
            var numberOfPhases = ((TraCIInteger)content.Skip(1 + len + 4).Take(1)).Value;
            var tmp = content.Skip(1 + len).Take(5 + numberOfPhases) as TraCICompoundObject as TrafficLightLogics;
            len += 5 + numberOfPhases;
            result.TrafficLightLogics.Add(tmp);
            }
        return result;
        }
    internal static ControlledLinks ToControlledLinks(this TraCICompoundObject content)
        {
        ControlledLinks links = new() { NumberOfSignals = content[0] as TraCIInteger };

        for (var i = 2; i < content.Count; i += 2)
            {
            links.Links.Add(content[i] as TraCIStringList);
            }

        return links;
        }
    }

