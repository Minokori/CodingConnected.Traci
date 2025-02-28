#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;
public sealed class StopData : TraciArrayType
    {

    public string LaneId => (TraciString)this[0];

    public double EndPosition => (TraciDouble)this[1];

    public string StoppingPlaceId => (TraciString)this[2];

    public int StopFlags => (TraciInteger)this[3];

    public double Duration => (TraciDouble)this[4];

    public double Until => (TraciDouble)this[5];
    }
