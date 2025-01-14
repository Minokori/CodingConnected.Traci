namespace CodingConnected.TraCI.NET.DataTypes;

// TODO https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#tllogic_attributes

/// <summary>
/// see http://sumo.dlr.de/wiki/Simulation/Traffic_Lights#Defining_New_TLS-Programs
/// </summary>
//public class TrafficCompleteLightProgram : List<TrafficLightProgramPhase>, ITraciType
//    {
//    public byte TYPE => throw new NotImplementedException();

//    /// <summary>
//    /// Name of the program
//    /// </summary>
//    public string ProgramId { get; init; }

//    /// <summary>
//    /// Number of phase to logicStartIndex with
//    /// </summary>
//    public int PhaseIndex { get; init; }
//    }

///// <summary>
///// get use
///// </summary>
//public class TrafficLightProgram : TraCICompoundObject, ITraciType
//    {

//    public int Length => 1 + TrafficLightLogics.Count;

//    public TraCIInteger NumberOfLogics { get => (TraCIInteger)this[0]; }

//    public List<TrafficLightLogic> TrafficLightLogics
//        {
//        get
//            {
//            var logicStartIndex = 1;
//            List<Tuple<int, int>> startIndexAndLength = [];
//            do
//                {
//                var phaseNumOfLogic = ((TraCIInteger)this.Skip(logicStartIndex).Skip(4).First()).Value;
//                var totalLengthOfLogic = 5 + phaseNumOfLogic * 4;
//                startIndexAndLength.Add(new(logicStartIndex, totalLengthOfLogic));
//                logicStartIndex += totalLengthOfLogic;
//                }
//            while (logicStartIndex < Count);
//            List<TrafficLightLogic> result = [];
//            foreach (var item in startIndexAndLength)
//                {
//                var logic = this.Skip(item.Item1).Take(item.Item2) as TrafficLightLogic;
//                result.Add(logic);
//                }
//            return result;
//            }
//        }
//    }

/// <summary>
/// Cause some discribe of logic'properpites in set/get document have some different,
/// so use definitions in below link as standard<para/>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#tllogic_attributes"/>
/// </summary>
public class TrafficLightLogic : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;
    public new byte TYPE => throw new NotImplementedException();

    /// <summary>
    /// The id of the traffic light program; This must be a new program name for the traffic light id.
    /// Please note that "off" is reserved
    /// </summary>
    public TraCIString ProgramId => (TraCIString)this[0];

    /// <summary>
    /// The type of the traffic light (fixed phase durations, phase prolongation based on time gaps between vehicles (actuated), or on accumulated time loss of queued vehicles (delay_based) )
    /// </summary>
    /// <remarks>
    /// <u> <see cref="Type"/> and <see cref="SubParameter"/> aren't currently implemented therefore they are 0.</u>
    /// </remarks>
    public TraCIInteger Type => (TraCIInteger)this[1];

    /// <summary>
    /// no discribe in document. we guess "offset","tlsId" may be put in this field in the future.
    /// </summary>
    /// <remarks>
    /// <u> <see cref="Type"/> and <see cref="SubParameter"/> aren't currently implemented therefore they are 0.</u>
    /// </remarks>
    public TraCICompoundObject SubParameter => (TraCICompoundObject)this[2];


    public TraCIInteger CurrentPhaseIndex => (TraCIInteger)this[3];
    public TraCIInteger NumberOfPhases => (TraCIInteger)this[4];
    public List<TrafficLightProgramPhase> TrafficLightPhases
        {
        get =>
            this.Skip(5) //skip subid, type, subparameter, currentphaseindex, numberofphases
                .Take(NumberOfPhases.Value * 4) // every phase has 4 elements,totally 4*numberofphases elements
                .Chunk(4) //every phase has 4 elements
                .Select(i => (TrafficLightProgramPhase)i.ToList()) //convert 4 elments to TrafficLightProgramPhase
                .ToList();
        }
    }

/// <summary>
/// Cause some discribe of phase'properpites in set/get document have some different,
/// so use definitions in below link as standard<para/>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#phase_attributes"/>
/// </summary>
public class TrafficLightProgramPhase : TraCICompoundObject, ITraciType
    {
    protected override bool ShouldAddCountToBytes => false;
    /// <summary>
    /// The duration of the phase
    /// </summary>
    public TraCIDouble Duration => (TraCIDouble)this[0];
    /// <summary>
    /// The minimum duration of the phase when using type actuated. Optional, defaults to duration.
    /// </summary>
    public TraCIDouble MinDuration => (TraCIDouble)this[1];
    /// <summary>
    /// The maximum duration of the phase when using type actuated. Optional, if minDur is not set it defaults to duration , otherwise to 2147483.
    /// </summary>
    public TraCIDouble MaxDuration => (TraCIDouble)this[2];

    /// <summary>
    /// The traffic light states for this phase, a string of "rRgGyYoO"
    /// </summary>
    public TraCIString State => (TraCIString)this[3];
    }
