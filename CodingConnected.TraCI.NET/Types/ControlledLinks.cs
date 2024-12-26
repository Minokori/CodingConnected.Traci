namespace CodingConnected.TraCI.NET.Types;

public struct ControlledLinks : ITraCIType
    {
    public int NumberOfSignals { get; set; }
    public List<List<string>> Links { get; set; }
    }

