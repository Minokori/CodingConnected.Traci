namespace CodingConnected.TraCI.NET.DataTypes;
public class Link : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;

    public TraCIString ConsecutiveNotInternalLane => (TraCIString)this[0];

    public TraCIString ConsecutiveInternalLane => (TraCIString)this[1];

    public TraCIUByte HasPiority => (TraCIUByte)this[2];

    public TraCIUByte IsOpened => (TraCIUByte)this[3];

    public TraCIUByte HasApproachingFoe => (TraCIUByte)this[4];

    /// <summary>
    /// enum ("-" = dead end, "=" = equal, "m" = minor link, "M" = major link, traffic light only: "O" = controller off, "o" = yellow flashing, "y" = yellow minor link, "Y" = yellow major link, "r" = red, "g" = green minor, "G" green major)<para/>
    /// see <see href="https://sumo.dlr.de/docs/Networks/SUMO_Road_Networks.html#plain_connections"/>
    /// </summary>
    public TraCIString CurrentState => (TraCIString)this[5];

    /// <summary>
    /// enum ("s" = straight, "t" = turn, "l" = left, "r" = right, "L" = partially left, R = partially right, "invalid" = no direction)<para/>
    /// see <see href="https://sumo.dlr.de/docs/Networks/SUMO_Road_Networks.html#plain_connections"/>
    /// </summary>
    public TraCIString Direction => (TraCIString)this[6];

    public TraCIDouble Length => (TraCIDouble)this[7];
    }
