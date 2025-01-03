namespace CodingConnected.TraCI.NET.Types;

public struct ControlledLinks : ITraCIType
    {
    public readonly byte TYPE => throw new NotImplementedException();
    public TraCIInteger NumberOfSignals { get; set; }
    public List<TraCIStringList> Links { get; set; }
    }

