namespace CodingConnected.TraCI.NET.DataTypes;
public class Foe : TraCICompoundObject, ITraciType
    {
    public TraCIString FoeId => (TraCIString)this[0];

    public TraCIDouble EgoDistance => (TraCIDouble)this[1];

    public TraCIDouble FoeDistance => (TraCIDouble)this[2];

    public TraCIDouble EgoExitDistance => (TraCIDouble)this[3];

    public TraCIDouble FoeExitDistance => (TraCIDouble)this[4];

    public TraCIByte EgoLane => (TraCIByte)this[5];

    public TraCIByte FoeLane => (TraCIByte)this[6];

    public TraCIDouble EgoResponse => (TraCIDouble)this[7];

    public TraCIDouble FoeResponse => (TraCIDouble)this[8];
    }
