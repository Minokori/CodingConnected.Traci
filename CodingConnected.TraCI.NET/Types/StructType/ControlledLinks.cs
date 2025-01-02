namespace CodingConnected.TraCI.NET.Types;

public struct ControlledLinks : ITraCIType
    {
    public readonly byte TYPE => throw new NotImplementedException();
    public int NumberOfSignals { get; set; }
    public List<List<string>> Links { get; set; }
    }

