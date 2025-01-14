namespace CodingConnected.TraCI.NET.DataTypes;
public class VehicleInformationPacket : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;

    public TraCIString VehicleId => (TraCIString)this[0];

    public TraCIDouble VehicleLength => (TraCIDouble)this[1];

    public TraCIDouble EntryTime => (TraCIDouble)this[2];

    public TraCIDouble LeaveTime => (TraCIDouble)this[3];

    public TraCIString VehicleTypeId => (TraCIString)this[4];

    }
