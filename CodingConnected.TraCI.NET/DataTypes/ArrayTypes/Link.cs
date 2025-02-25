#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class Link : TraciArrayType
    {

    public string ConsecutiveNotInternalLane => ((TraciString)this[0]).Value;

    public string ConsecutiveInternalLane => ((TraciString)this[1]).Value;

    public byte HasPriority => ((TraciUnsignedByte)this[2]).Value;

    public byte IsOpened => ((TraciUnsignedByte)this[3]).Value;

    public byte HasApproachingFoe => ((TraciUnsignedByte)this[4]).Value;

    /// <summary>
    /// enum ("-" = dead end, "=" = equal, "m" = minor link, "M" = major link, traffic light only: "O" = controller off, "o" = yellow flashing, "y" = yellow minor link, "Y" = yellow major link, "r" = red, "g" = green minor, "G" green major)<para/>
    /// see <see href="https://sumo.dlr.de/docs/Networks/SUMO_Road_Networks.html#plain_connections"/>
    /// </summary>
    public string CurrentState => ((TraciString)this[5]).Value;

    /// <summary>
    /// enum ("s" = straight, "t" = turn, "l" = left, "r" = right, "L" = partially left, R = partially right, "invalid" = no direction)<para/>
    /// see <see href="https://sumo.dlr.de/docs/Networks/SUMO_Road_Networks.html#plain_connections"/>
    /// </summary>
    public string Direction => ((TraciString)this[6]).Value;

    public double Length => ((TraciDouble)this[7]).Value;
    }
