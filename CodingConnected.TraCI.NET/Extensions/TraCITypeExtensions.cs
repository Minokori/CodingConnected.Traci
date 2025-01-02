using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Extensions;

/// <summary>
/// convert between TraCI types.
/// </summary>
internal static class TraCITypeExtensions
    {

    internal static List<EdgeInformation> ToEdgeInformations(this TraCICompoundObject content)
        {
        List<EdgeInformation> ret = [];

        int numberOfEdges = (content[0] as TraCIInteger).Value;

        for (int i = 0; i < numberOfEdges; i++)
            {
            EdgeInformation edge = new()
                {
                LaneId = (content[(6 * i) + 1] as TraCIString).Value,
                Length = (content[(6 * i) + 2] as TraCIDouble).Value,
                Occupation = (content[(6 * i) + 3] as TraCIDouble).Value,
                OffsetToBestLane = (content[(6 * i) + 4] as TraCIByte).Value,
                LaneInformation = (content[(6 * i) + 5] as TraCIUByte).Value,
                BestSubsequentLanes = (content[(6 * i) + 6] as TraCIStringList).Value,
                };
            ret.Add(edge);
            }
        return ret;
        }

    internal static List<TrafficLightSystem> ToTrafficLightSystems(this TraCICompoundObject content)
        {
        List<TrafficLightSystem> ret = [];

        int numberOfTLS = (content[0] as TraCIInteger).Value;

        for (int i = 0; i < numberOfTLS; i++)
            {
            TrafficLightSystem tls = new()
                {
                TrafficLightSystemId = (content[(4 * i) + 1] as TraCIString).Value,
                TrafficLightSystemLinkIndex = (
                    content[(4 * i) + 2] as TraCIInteger
                ).Value,
                DistanceToTrafficLightSystem = (
                    content[(4 * i) + 3] as TraCIDouble
                ).Value,
                LinkState = (content[(4 * i) + 4] as TraCIByte).Value,
                };

            ret.Add(tls);
            }

        return ret;
        }
    internal static TrafficCompleteLightProgram ToTrafficLightCompleteProgram(this TraCICompoundObject content)
        {
        TrafficCompleteLightProgram ret = new()
            {
            NumberOfLogics = (content[0] as TraCIInteger).Value,
            };

        int offset = 1; //offset for number of logics
                        // for 1 logic  = 5 + (4 * number of phases)

        for (int i = 0; i < ret.NumberOfLogics; i++)
            {
            TrafficLightLogics tmp = new()
                {
                SubId = (content[offset + 0] as TraCIString).Value,
                Type = (content[offset + 1] as TraCIInteger).Value,
                // TODO
                SubParameter = (content[offset + 2] as TraCICompoundObject),
                CurrentPhaseIndex = (content[offset + 3] as TraCIInteger).Value,
                NumberOfPhases = (content[offset + 4] as TraCIInteger).Value,
                };

            for (int j = 0; j < tmp.NumberOfPhases; j++)
                {
                TrafficLightProgramPhase phase = new()
                    {
                    Duration = (content[offset + 5 + (4 * j)] as TraCIInteger).Value, //4*j for the current phase
                    MinDuration = (content[offset + 6 + (4 * j)] as TraCIInteger).Value,
                    MaxDuration = (content[offset + 7 + (4 * j)] as TraCIInteger).Value,
                    Definition = (content[offset + 8 + (4 * j)] as TraCIString).Value,
                    };
                tmp.TrafficLightPhases.Add(phase);
                }

            ret.TrafficLightLogics.Add(tmp);
            offset += (5 + (4 * tmp.NumberOfPhases));
            }

        return ret;
        }
    internal static ControlledLinks ToControlledLinks(this List<ITraCIType> content)
        {
        ControlledLinks ret = new() { NumberOfSignals = (content[0] as TraCIInteger).Value };

        for (int i = 2; i < content.Count; i += 2)
            {
            ret.Links.Add((content[i] as TraCIStringList).Value);
            }

        return ret;
        }
    }

