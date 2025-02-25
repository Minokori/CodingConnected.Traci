#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class VehicleInformationPacket : TraciArrayType
    {

    public string VehicleId => ((TraciString)this[0]).Value;

    public double VehicleLength => ((TraciDouble)this[1]).Value;

    public double EntryTime => ((TraciDouble)this[2]).Value;

    public double LeaveTime => ((TraciDouble)this[3]).Value;

    public string VehicleTypeId => ((TraciString)this[4]).Value;
    }
