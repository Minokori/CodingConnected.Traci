#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.Traci.DataTypes;
public sealed class StopData(IEnumerable<ITraciType> innerObjects) : TraciArrayType(innerObjects)
    {

    public string LaneId => (TraciString)this[0];

    public double EndPosition => (TraciDouble)this[1];

    public string StoppingPlaceId => (TraciString)this[2];

    public int StopFlags => (TraciInteger)this[3];

    public double Duration => (TraciDouble)this[4];

    public double Until => (TraciDouble)this[5];

    public double StartPosition => (TraciDouble)this[6];

    public double IntendedArrival => (TraciDouble)this[7];

    public double Arrival => (TraciDouble)this[8];

    public double Departure => (TraciDouble)this[9];

    public string Split => (TraciString)this[10];

    public string Join => (TraciString)this[11];

    public string ActType => (TraciString)this[12];

    public string TripId => (TraciString)this[13];

    public string LineId => (TraciString)this[14];

    public double Speed => (TraciDouble)this[15];
    }
