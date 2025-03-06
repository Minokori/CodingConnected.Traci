namespace CodingConnected.TraCI.NET.DataTypes;

public class Stage : TraciCompoundObject
    {
    //TODO string 类型的均可空，和TraCICompoundObject的转换需要注意
    public TraciInteger StageType
        {
        get => (TraciInteger)this[0];
        set => this[0] = value;
        }

    public TraciString VType
        {
        get => (TraciString)this[1];
        set => this[1] = value;
        } //

    public TraciString Line
        {
        get => (TraciString)this[2];
        set => this[2] = value;
        } //

    public TraciString DestinationStop
        {
        get => (TraciString)this[3];
        set => this[3] = value;
        } //
    public TraciStringList Edges
        {
        get => (TraciStringList)this[4];
        set => this[4] = value;
        }

    public TraciDouble TravelTime
        {
        get => (TraciDouble)this[5];
        set => this[5] = value;
        }

    public TraciDouble Cost
        {
        get => (TraciDouble)this[6];
        set => this[6] = value;
        }

    public TraciDouble Length
        {
        get => (TraciDouble)this[7];
        set => this[7] = value;
        }

    public TraciString Intended
        {
        get => (TraciString)this[8];
        set => this[8] = value;
        } //

    public TraciDouble Depart
        {
        get => (TraciDouble)this[9];
        set => this[9] = value;
        }

    public TraciString DepartPos
        {
        get => (TraciString)this[10];
        set => this[10] = value;
        }

    public TraciString ArrivalPos
        {
        get => (TraciString)this[11];
        set => this[11] = value;
        }

    public TraciString Description
        {
        get => (TraciString)this[12];
        set => this[12] = value;
        }

    // TODO 改成工厂方法
    public Stage(IEnumerable<ITraciType> traciCompoundObject)
        {
        Clear();
        AddRange(traciCompoundObject);
        }
    }

public sealed class WaitingStage : TraciCompoundObject
    {
    public int StageType => ((TraciInteger)this[0]).Value;

    public int Duration => ((TraciInteger)this[1]).Value;

    public string Description => ((TraciString)this[2]).Value;

    public string StopId => ((TraciString)this[3]).Value;

    public WaitingStage(int duration, string? description, string stopId)
        {
        this[0] = new TraciInteger(1);
        this[1] = new TraciInteger(duration);
        this[2] = new TraciString(description ?? "");
        this[3] = new TraciString(stopId);
        }
    }

public sealed class WalkingStage : TraciCompoundObject
    {
    public WalkingStage() => this[0] = new TraciInteger(2);

    public int StageType => ((TraciInteger)this[0]).Value;

    public List<string> Edges => ((TraciStringList)this[1]).Value;

    public double ArrivalPosition => ((TraciDouble)this[2]).Value;

    public int Duration => ((TraciInteger)this[3]).Value;

    /// <summary>
    /// when a positive value is given this speed is used,
    /// otherwise the default speed of the person is used
    /// </summary>
    public double Speed => ((TraciDouble)this[4]).Value;

    public string StopId => ((TraciString)this[5]).Value;

    public WalkingStage(List<string> edges, double arrivalPosition, int duration, double speed, string stopId)
        {
        this[0] = new TraciInteger(2);
        this[1] = new TraciStringList(edges);
        this[2] = new TraciDouble(arrivalPosition);
        this[3] = new TraciDouble(duration);
        this[4] = new TraciDouble(speed);
        this[5] = new TraciString(stopId);
        }
    }

public sealed class DrivingStage : TraciCompoundObject
    {
    public int StageType => ((TraciInteger)this[0]).Value;

    public string DestinationEdge => ((TraciString)this[1]).Value;

    public string Lines => ((TraciString)this[2]).Value;

    public string StopId => ((TraciString)this[3]).Value;

    public DrivingStage(string destinationEdge, string lines, string stopId)
        {
        this[0] = new TraciInteger(3);
        this[1] = new TraciString(destinationEdge);
        this[2] = new TraciString(lines);
        this[3] = new TraciString(stopId);
        }
    }

public class TaxiReservations : TraciCompoundObject
    {
    public TraciString Id
        {
        get => (TraciString)this[0];
        set => this[0] = value;
        }
    public TraciString Persons
        {
        get => (TraciString)this[1];
        set => this[1] = value;
        }
    public TraciString Group
        {
        get => (TraciString)this[2];
        set => this[2] = value;
        }

    public TraciString FromEdge
        {
        get => (TraciString)this[3];
        set => this[3] = value;
        }

    public TraciString ToEdge
        {
        get => (TraciString)this[4];
        set => this[4] = value;
        }

    public TraciDouble DepartPos
        {
        get => (TraciDouble)this[5];
        set => this[5] = value;
        }

    public TraciDouble ArrivalPos
        {
        get => (TraciDouble)this[6];
        set => this[6] = value;
        }

    public TraciDouble Depart
        {
        get => (TraciDouble)this[7];
        set => this[7] = value;
        }

    public TraciDouble ReservationTime
        {
        get => (TraciDouble)this[8];
        set => this[8] = value;
        }
    }
