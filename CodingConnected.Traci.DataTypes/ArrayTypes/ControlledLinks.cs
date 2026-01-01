namespace CodingConnected.Traci.DataTypes;

public sealed class ControlledLinks(IEnumerable<ITraciType> innerObjects)
    : TraciArrayType(innerObjects)
    {
    public int NumberOfSignals => (TraciInteger)this[0];
    public IList<List<string>> Links => [.. this.Skip(1).Select(i => (TraciStringList)i)];
    }
