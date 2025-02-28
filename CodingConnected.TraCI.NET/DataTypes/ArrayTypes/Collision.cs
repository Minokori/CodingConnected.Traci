#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class Collision : TraciArrayType
    {
    public string ColliderId => (TraciString)this[0];
    public string VictimId => (TraciString)this[1];
    public string ColliderType => (TraciString)this[2];
    public string VictimType => (TraciString)this[3];
    public double ColliderSpeed => (TraciDouble)this[4];
    public double VictimSpeed => (TraciDouble)this[5];
    public string CollisionType => (TraciString)this[6];
    public string LaneId => (TraciString)this[7];
    public double PositionOnLane => (TraciDouble)this[8];
    }
