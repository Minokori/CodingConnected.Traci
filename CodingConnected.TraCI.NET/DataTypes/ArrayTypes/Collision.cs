#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class Collision : TraciArrayType
    {
    public string ColliderId => ((TraciString)this[0]).Value;
    public string VictimId => ((TraciString)this[1]).Value;
    public string ColliderType => ((TraciString)this[2]).Value;
    public string VictimType => ((TraciString)this[3]).Value;
    public double ColliderSpeed => ((TraciDouble)this[4]).Value;
    public double VictimSpeed => ((TraciDouble)this[5]).Value;
    public string CollisionType => ((TraciString)this[6]).Value;
    public string LaneId => ((TraciString)this[7]).Value;
    public double PositionOnLane => ((TraciDouble)this[8]).Value;
    }
