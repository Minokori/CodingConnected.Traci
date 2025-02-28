#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

namespace CodingConnected.TraCI.NET.DataTypes;

// TODO https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#tllogic_attributes
/// <summary>
/// Cause some describe of logic properties in set/get document have some different,
/// so use definitions in below link as standard<para/>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#tllogic_attributes"/>
/// </summary>
public sealed class TrafficLightLogic : TraciCompoundObject
    {
    protected override bool IsComplete => false;

    /// <summary>
    /// The id of the traffic light program; This must be a new program name for the traffic light id.
    /// Please note that "off" is reserved
    /// </summary>
    public string ProgramId => (TraciString)this[0];

    /// <summary>
    /// The type of the traffic light (fixed phase durations, phase prolongation based on time gaps between vehicles (actuated), or on accumulated time loss of queued vehicles (delay_based) )
    /// </summary>
    /// <remarks>
    /// <u> <see cref="Type"/> and <see cref="SubParameter"/> aren't currently implemented therefore they are 0.</u>
    /// </remarks>
    public int Type => (TraciInteger)this[1];

    /// <summary>
    /// no describe in document. we guess "offset","tlsId" may be put in this field in the future.
    /// </summary>
    /// <remarks>
    /// <u> <see cref="Type"/> and <see cref="SubParameter"/> aren't currently implemented therefore they are 0.</u>
    /// </remarks>
    public TraciCompoundObject SubParameter => (TraciCompoundObject)this[2];
    public int CurrentPhaseIndex => (TraciInteger)this[3];
    public int NumberOfPhases => (TraciInteger)this[4];
    public List<TrafficLightProgramPhase> TrafficLightPhases => [.. this.Skip(5) //skip sub-id, type, sub-parameter, current phase index, number of phases
                .Take(NumberOfPhases * 4) // every phase has 4 elements,totally 4 * number of phases elements
                .Chunk(4) //every phase has 4 elements
                .Select(i => (TrafficLightProgramPhase)i.ToList())];
    }
