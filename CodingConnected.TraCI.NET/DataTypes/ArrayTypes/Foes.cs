#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;
public sealed class Foe : TraciArrayType
    {
    public string FoeId => ((TraciString)this[0]).Value;

    public double EgoDistance => ((TraciDouble)this[1]).Value;

    public double FoeDistance => ((TraciDouble)this[2]).Value;

    public double EgoExitDistance => ((TraciDouble)this[3]).Value;

    public double FoeExitDistance => ((TraciDouble)this[4]).Value;

    public byte EgoLane => ((TraciByte)this[5]).Value;

    public byte FoeLane => ((TraciByte)this[6]).Value;

    public double EgoResponse => ((TraciDouble)this[7]).Value;

    public double FoeResponse => ((TraciDouble)this[8]).Value;
    }
