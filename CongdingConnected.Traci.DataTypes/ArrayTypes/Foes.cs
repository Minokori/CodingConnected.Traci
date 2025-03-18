namespace CodingConnected.Traci.DataTypes;

public sealed class Foe : TraciArrayType
    {
    public string FoeId => (TraciString)this[0];

    public double EgoDistance => (TraciDouble)this[1];

    public double FoeDistance => (TraciDouble)this[2];

    public double EgoExitDistance => (TraciDouble)this[3];

    public double FoeExitDistance => (TraciDouble)this[4];

    public byte EgoLane => (TraciByte)this[5];

    public byte FoeLane => (TraciByte)this[6];

    public double EgoResponse => (TraciDouble)this[7];

    public double FoeResponse => (TraciDouble)this[8];
    }
