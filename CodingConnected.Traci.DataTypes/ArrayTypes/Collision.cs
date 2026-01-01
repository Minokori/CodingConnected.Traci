namespace CodingConnected.Traci.DataTypes;

public sealed class Collision(IEnumerable<ITraciType> innerObjects) : TraciArrayType(innerObjects)
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
