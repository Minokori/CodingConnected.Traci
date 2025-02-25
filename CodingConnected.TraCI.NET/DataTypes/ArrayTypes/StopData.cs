#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;
public sealed class StopData : TraciArrayType
    {

    public TraciString LaneId => (TraciString)this[0];

    public TraciDouble EndPosition => (TraciDouble)this[1];

    public TraciString StoppingPlaceId => (TraciString)this[2];

    public TraciInteger StopFlags => (TraciInteger)this[3];

    public TraciDouble Duration => (TraciDouble)this[4];

    public TraciDouble Until => (TraciDouble)this[5];
    }
