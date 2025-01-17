namespace CodingConnected.TraCI.NET.DataTypes;
public class StopData : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;

    public TraCIString LaneId => (TraCIString)this[0];

    public TraCIDouble EndPosition => (TraCIDouble)this[1];

    public TraCIString StoppingPlaceId => (TraCIString)this[2];

    public TraCIInteger StopFlags => (TraCIInteger)this[3];

    public TraCIDouble Duration => (TraCIDouble)this[4];

    public TraCIDouble Until => (TraCIDouble)this[5];


    }
