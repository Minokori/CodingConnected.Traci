namespace CodingConnected.TraCI.NET.DataTypes;
public class ControlledLinks : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;
    public new byte TYPE => throw new NotImplementedException();
    public TraCIInteger NumberOfSignals => (TraCIInteger)this[0];
    public List<TraCIStringList> Links => this.Skip(1).Select(i => (TraCIStringList)i).ToList();
    }