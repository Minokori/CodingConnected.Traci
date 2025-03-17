namespace CodingConnected.Traci.DataTypes;

public class Stage : TraciCompoundObject
    {
    public int StageType => (TraciInteger)this[0];

    public string VType => (TraciString)this[1];

    public string Line => (TraciString)this[2];

    public string DestinationStop => (TraciString)this[3];
    public List<string> Edges => (TraciStringList)this[4];

    public double TravelTime => (TraciDouble)this[5];

    public double Cost => (TraciDouble)this[6];

    public double Length => (TraciDouble)this[7];

    public string Intended => (TraciString)this[8];

    public double Depart => (TraciDouble)this[9];

    public double DepartPos => (TraciDouble)this[10];

    public double ArrivalPos => (TraciDouble)this[11];

    public string Description => (TraciString)this[12];

    public Stage(IEnumerable<ITraciType> traciCompoundObject)
        {
        Clear();
        AddRange(traciCompoundObject);
        }
    }

public sealed class WaitingStage : TraciCompoundObject
    {
    public int StageType => (TraciInteger)this[0];

    public int Duration => (TraciInteger)this[1];

    public string Description => (TraciString)this[2];

    public string StopId => (TraciString)this[3];

    public WaitingStage(double duration, string? description, string stopId)
        {
        Clear();
        Add(new TraciInteger(1));
        Add(new TraciDouble(duration));
        Add(new TraciString(description ?? ""));
        Add(new TraciString(stopId));
        }
    }

public sealed class WalkingStage : TraciCompoundObject
    {
    public int StageType => (TraciInteger)this[0];

    public List<string> Edges => (TraciStringList)this[1];

    public double ArrivalPosition => (TraciDouble)this[2];

    public int Duration => (TraciInteger)this[3];

    /// <summary>
    /// when a positive value is given this speed is used,
    /// otherwise the default speed of the person is used
    /// </summary>
    public double Speed => (TraciDouble)this[4];

    public string StopId => (TraciString)this[5];

    public WalkingStage(List<string> edges, double arrivalPosition, int duration, double speed, string stopId)
        {
        Clear();
        Add(new TraciInteger(2));
        Add(new TraciStringList(edges));
        Add(new TraciDouble(arrivalPosition));
        Add(new TraciDouble(duration));
        Add(new TraciDouble(speed));
        Add(new TraciString(stopId));
        }
    }

public sealed class DrivingStage : TraciCompoundObject
    {
    public int StageType => (TraciInteger)this[0];

    public string DestinationEdge => (TraciString)this[1];

    public string Lines => (TraciString)this[2];

    public string StopId => (TraciString)this[3];

    public DrivingStage(string destinationEdge, string lines, string stopId)
        {
        Clear();
        Add(new TraciInteger(3));
        Add(new TraciString(destinationEdge));
        Add(new TraciString(lines));
        Add(new TraciString(stopId));
        }
    }

public sealed class TaxiReservations : TraciCompoundObject
    {
    public string Id => (TraciString)this[0];
    public string Persons => (TraciString)this[1];
    public string Group => (TraciString)this[2];

    public string FromEdge => (TraciString)this[3];

    public string ToEdge => (TraciString)this[4];

    public double DepartPos => (TraciDouble)this[5];

    public double ArrivalPos => (TraciDouble)this[6];

    public double Depart => (TraciDouble)this[7];

    public double ReservationTime => (TraciDouble)this[8];
    }
