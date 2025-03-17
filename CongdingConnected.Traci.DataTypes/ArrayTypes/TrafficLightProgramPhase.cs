#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// Cause some describe of phase properties in set/get document have some different,
/// so use definitions in below link as standard<para/>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Traffic_Lights.html#phase_attributes"/>
/// </summary>
public sealed class TrafficLightProgramPhase(IEnumerable<ITraciType> innerObjects) : TraciArrayType(innerObjects)
    {
    /// <summary>
    /// The duration of the phase
    /// </summary>
    public double Duration => (TraciDouble)this[0];

    public string Type => (TraciString)this[1];

    /// <summary>
    /// The minimum duration of the phase when using type actuated. Optional, defaults to duration.
    /// </summary>
    public double MinDuration => (TraciDouble)this[2];

    /// <summary>
    /// The maximum duration of the phase when using type actuated. Optional, if minDur is not set it defaults to duration , otherwise to 2147483.
    /// </summary>
    public double MaxDuration => (TraciDouble)this[3];


    public ITraciType Next => this[4];

    /// <summary>
    /// The traffic light states for this phase, a string of "rRgGyYoO"
    /// </summary>
    public string State => (TraciString)this[5];
    }
