namespace CodingConnected.Traci.DataTypes;

public sealed class Link(IEnumerable<ITraciType> innerObjects) : TraciArrayType(innerObjects)
    {
    public string ConsecutiveNotInternalLane => (TraciString)this[0];

    public string ConsecutiveInternalLane => (TraciString)this[1];

    public byte HasPriority => (TraciUnsignedByte)this[2];

    public byte IsOpened => (TraciUnsignedByte)this[3];

    public byte HasApproachingFoe => (TraciUnsignedByte)this[4];

    /// <summary>
    /// enum ("-" = dead end, "=" = equal, "m" = minor link, "M" = major link, traffic light only: "O" = controller off, "o" = yellow flashing, "y" = yellow minor link, "Y" = yellow major link, "r" = red, "g" = green minor, "G" green major)<para/>
    /// see <see href="https://sumo.dlr.de/docs/Networks/SUMO_Road_Networks.html#plain_connections"/>
    /// </summary>
    public string CurrentState => (TraciString)this[5];

    /// <summary>
    /// enum ("s" = straight, "t" = turn, "l" = left, "r" = right, "L" = partially left, R = partially right, "invalid" = no direction)<para/>
    /// see <see href="https://sumo.dlr.de/docs/Networks/SUMO_Road_Networks.html#plain_connections"/>
    /// </summary>
    public string Direction => (TraciString)this[6];

    public double Length => (TraciDouble)this[7];
    }
