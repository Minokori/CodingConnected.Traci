namespace CodingConnected.TraCI.NET.DataTypes;


/// <summary>
/// see http://sumo.dlr.de/wiki/Simulation/Traffic_Lights#Defining_New_TLS-Programs
/// </summary>
public class TrafficLightProgram : List<TrafficLightProgramPhase>, ITraciType
    {
    public byte TYPE => throw new NotImplementedException();
    /// <summary>
    /// Name of the program
    /// </summary>
    public string ProgramId { get; init; }

    /// <summary>
    /// Number of phase to start with
    /// </summary>
    public int PhaseIndex { get; init; }
    }

public class TrafficCompleteLightProgram : ITraciType
    {
    public byte TYPE => throw new NotImplementedException();
    public TraCIInteger NumberOfLogics { get; init; }

    public List<TrafficLightLogics> TrafficLightLogics { get; init; }
    }

public class TrafficLightLogics : TraCICompoundObject, ITraciType
    {
    public new byte TYPE => throw new NotImplementedException();
    public TraCIString SubId => this[0] as TraCIString;
    public TraCIInteger Type => this[1] as TraCIInteger;
    public TraCICompoundObject SubParameter => this[2] as TraCICompoundObject;
    public TraCIInteger CurrentPhaseIndex => this[3] as TraCIInteger;
    public TraCIInteger NumberOfPhases => this[4] as TraCIInteger;
    public List<TrafficLightProgramPhase> TrafficLightPhases
        {
        get => this.Skip(5).Take(NumberOfPhases.Value * 4)
                .Chunk(4).Select(i => i.ToList() as TraCICompoundObject as TrafficLightProgramPhase)
                .ToList();
        }

    }

public class TrafficLightProgramPhase : TraCICompoundObject, ITraciType
    {
    public new byte TYPE => throw new NotImplementedException();
    /// <summary>
    /// Duration in ms
    /// </summary>
    public TraCIDouble Duration => this[0] as TraCIDouble;

    public TraCIDouble MinDuration => this[1] as TraCIDouble;

    public TraCIDouble MaxDuration => this[2] as TraCIDouble;

    public TraCIString Definition => this[3] as TraCIString;



    // TODO uncheck if it‘s correct
    public new byte[] ToBytes()
        {
        byte[] bytes = [Duration.TYPE, .. Duration.ToBytes(),
        MinDuration.TYPE, .. TraCIDouble.AsBytes(0),
        MaxDuration.TYPE, .. TraCIDouble.AsBytes(0),
        Definition.TYPE, .. Definition.ToBytes()
        ];
        return bytes;
        }
    }

