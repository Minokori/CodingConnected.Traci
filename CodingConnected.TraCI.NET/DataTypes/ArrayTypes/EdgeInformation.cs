#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class EdgeInformation : TraciArrayType
    {
    public string LaneId => ((TraciString)this[0]).Value;
    public double Length => ((TraciDouble)this[1]).Value;
    public double Occupation => ((TraciDouble)this[2]).Value;
    public byte OffsetToBestLane => ((TraciByte)this[3]).Value;
    /// <summary>
    /// 0: lane may not be used for continuing drive, 1: it may be used
    /// </summary>
    public byte LaneInformation => ((TraciUnsignedByte)this[4]).Value;
    public List<string> BestSubsequentLanes => ((TraciStringList)this[5]).Value;
    }

