namespace CodingConnected.TraCI.NET.Types;


/// <summary>
/// see http://sumo.dlr.de/wiki/Simulation/Traffic_Lights#Defining_New_TLS-Programs
/// </summary>
public struct TrafficLightProgram : ITraCIType
    {
    /// <summary>
    /// Name of the program
    /// </summary>
    public string ProgramId { get; init; }

    /// <summary>
    /// Number of phase to start with
    /// </summary>
    public int PhaseIndex { get; init; }
    /// <summary>
    /// List of phases
    /// </summary>
    public List<TrafficLightProgramPhase> Phases { get; init; }
    }

public struct TrafficCompleteLightProgram : ITraCIType
    {

    public int NumberOfLogics { get; init; }

    public List<TrafficLightLogics> TrafficLightLogics { get; init; }
    }

public struct TrafficLightLogics
    {
    public string SubId { get; init; }
    public int Type { get; init; }
    public TraCIObjects SubParameter { get; init; }
    public int CurrentPhaseIndex { get; init; }
    public int NumberOfPhases { get; init; }
    public List<TrafficLightProgramPhase> TrafficLightPhases { get; init; }

    }

public class TrafficLightProgramPhase
    {
    /// <summary>
    /// Duration in ms
    /// </summary>
    public double Duration { get; init; }

    public double MinDuration { get; init; }

    public double MaxDuration { get; init; }

    public string Definition { get; init; }
    }

