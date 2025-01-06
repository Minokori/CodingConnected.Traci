namespace CodingConnected.TraCI.NET.DataTypes;

public struct ControlledLinks : ITraciType
    {
    public readonly byte TYPE => throw new NotImplementedException();
    public TraCIInteger NumberOfSignals { get; set; }
    public List<TraCIStringList> Links { get; set; }
    }

