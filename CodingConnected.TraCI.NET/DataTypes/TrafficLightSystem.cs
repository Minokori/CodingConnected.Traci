﻿namespace CodingConnected.TraCI.NET.DataTypes;

public class TrafficLightSystem : TraCICompoundObject, ITraciType
    {
    public new byte TYPE => throw new NotImplementedException();
    public TraCIString TrafficLightSystemId { get; init; }
    public TraCIInteger TrafficLightSystemLinkIndex { get; init; }
    public TraCIDouble DistanceToTrafficLightSystem { get; init; }
    public TraCIByte LinkState { get; init; }
    }

