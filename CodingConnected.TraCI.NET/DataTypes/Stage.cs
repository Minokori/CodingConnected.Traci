namespace CodingConnected.TraCI.NET.DataTypes;

public class Stage : TraCICompoundObject
    {
    //TODO string 类型的均可空，和TraCICompoundObject的转换需要注意
    public TraCIInteger StageType { get => (TraCIInteger)this[0]; set => this[0] = value; }

    public TraCIString VType { get => (TraCIString)this[1]; set => this[1] = value; }//

    public TraCIString Line { get => (TraCIString)this[2]; set => this[2] = value; }//

    public TraCIString DestStop { get => (TraCIString)this[3]; set => this[3] = value; }//
    public TraCIStringList Edges { get => (TraCIStringList)this[4]; set => this[4] = value; }

    public TraCIDouble TravelTime { get => (TraCIDouble)this[5]; set => this[5] = value; }

    public TraCIDouble Cost { get => (TraCIDouble)this[6]; set => this[6] = value; }

    public TraCIDouble Length { get => (TraCIDouble)this[7]; set => this[7] = value; }

    public TraCIString Intended { get => (TraCIString)this[8]; set => this[8] = value; } //

    public TraCIDouble Depart { get => (TraCIDouble)this[9]; set => this[9] = value; }

    public TraCIString DepartPos { get => (TraCIString)this[10]; set => this[10] = value; }

    public TraCIString ArrivalPos { get => (TraCIString)this[11]; set => this[11] = value; }

    public TraCIString Description { get => (TraCIString)this[12]; set => this[12] = value; } //
    }


public class WaitingStage : TraCICompoundObject
    {
    public WaitingStage()
        {
        this[0] = new TraCIInteger() { Value = 1 };
        }

    public TraCIInteger StageType { get => (TraCIInteger)this[0]; }

    public TraCIInteger Duration { get => (TraCIInteger)this[1]; set => this[1] = value; }

    public TraCIString Description { get => (TraCIString)this[2]; set => this[2] = value; }


    public TraCIString StopId { get => (TraCIString)this[3]; set => this[3] = value; }
    }

public class WalkingStage : TraCICompoundObject
    {
    public WalkingStage()
        {
        this[0] = new TraCIInteger() { Value = 2 };
        }
    public TraCIInteger StageType { get => (TraCIInteger)this[0]; }

    public TraCIStringList Edges { get => (TraCIStringList)this[1]; set => this[1] = value; }

    public TraCIDouble ArrivalPosition { get => (TraCIDouble)this[2]; set => this[2] = value; }

    public TraCIInteger Duration { get => (TraCIInteger)this[3]; set => this[3] = value; }

    /// <summary>
    /// when a positive value is given this speed is used, 
    /// otherwise the default speed of the person is used
    /// </summary>
    public TraCIDouble Speed { get => (TraCIDouble)this[4]; set => this[4] = value; }

    public TraCIString StopId { get => (TraCIString)this[5]; set => this[5] = value; }
    }


public class DrivingStage : TraCICompoundObject
    {
    public DrivingStage()
        {
        this[0] = new TraCIInteger() { Value = 3 };
        }
    public TraCIInteger StageType { get => (TraCIInteger)this[0]; }

    public TraCIString DestinationEdge { get => (TraCIString)this[1]; set => this[1] = value; }

    public TraCIString Lines { get => (TraCIString)this[2]; set => this[2] = value; }

    public TraCIString StopId { get => (TraCIString)this[3]; set => this[3] = value; }


    }

public class TaxiResevations : TraCICompoundObject
    {
    public TraCIString Id { get => (TraCIString)this[0]; set => this[0] = value; }
    public TraCIString Persons { get => (TraCIString)this[1]; set => this[1] = value; }
    public TraCIString Group { get => (TraCIString)this[2]; set => this[2] = value; }

    public TraCIString FromEdge { get => (TraCIString)this[3]; set => this[3] = value; }

    public TraCIString ToEdge { get => (TraCIString)this[4]; set => this[4] = value; }

    public TraCIDouble DepartPos { get => (TraCIDouble)this[5]; set => this[5] = value; }

    public TraCIDouble ArrivalPos { get => (TraCIDouble)this[6]; set => this[6] = value; }

    public TraCIDouble Depart { get => (TraCIDouble)this[7]; set => this[7] = value; }

    public TraCIDouble ReservationTime { get => (TraCIDouble)this[8]; set => this[8] = value; }
    }