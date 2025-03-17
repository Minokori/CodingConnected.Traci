namespace CodingConnected.Traci.DataTypes;

// TODO https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#tllogic_attributes
/// <summary>
/// Cause some describe of logic properties in set/get document have some different,
/// so use definitions in below link as standard<para/>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#tllogic_attributes"/>
/// </summary>
public sealed class TrafficLightLogic(IEnumerable<ITraciType> innerObjects) : TraciCompoundObject(innerObjects)
    {
    //protected override bool IsComplete => false;

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
    public int CurrentPhaseIndex => (TraciInteger)this[2];
    public List<TrafficLightProgramPhase> TrafficLightPhases
        {
        get
            {
            List<TrafficLightProgramPhase> phases = [];

            foreach (var phase in (TraciCompoundObject)this[3])
                {
                TrafficLightProgramPhase item = new((TraciCompoundObject)phase);
                phases.Add(item);
                }
            return phases;
            }
        }

    public TraciCompoundObject SubParameter => (TraciCompoundObject)this.Last();
    }
