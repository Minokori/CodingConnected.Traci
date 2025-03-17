#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.Traci.DataTypes;

public sealed class VehicleInformationPacket(IEnumerable<ITraciType> innerObjects) : TraciArrayType(innerObjects)
    {
    public string VehicleId => (TraciString)this[0];

    public double VehicleLength => (TraciDouble)this[1];

    public double EntryTime => (TraciDouble)this[2];

    public double LeaveTime => (TraciDouble)this[3];

    public string VehicleTypeId => (TraciString)this[4];
    }
