namespace CodingConnected.Traci.Constants;

public static partial class CommandIdentifier
    {
    /// <summary>
    /// command: get version
    /// </summary>
    public const byte GetVersion = 0x00;

    /// <summary>
    /// command: load
    /// </summary>
    public const byte Load = 0x01;

    /// <summary>
    /// command: simulation step
    /// </summary>
    public const byte SimulationStep = 0x02;

    /// <summary>
    /// command: set connection priority (execution order)
    /// </summary>
    public const byte SetOrder = 0x03;

    /// <summary>
    /// command: stop node
    /// </summary>
    public const byte Stop = 0x12;

    /// <summary>
    /// command: set lane
    /// </summary>
    public const byte ChangeLane = 0x13;

    /// <summary>
    /// command: slow down
    /// </summary>
    public const byte Slowdown = 0x14;

    /// <summary>
    /// command: set sub-lane (vehicle)
    /// </summary>
    public const byte ChangeSublane = 0x15;

    /// <summary>
    /// command: replace vehicle stop and update route
    /// </summary>
    public const byte ReplaceStop = 0x17;

    /// <summary>
    /// command: insert vehicle stop and update route
    /// </summary>
    public const byte InsertStop = 0x18;

    /// <summary>
    /// command: Resume from parking
    /// </summary>
    public const byte Resume = 0x19;

    /// <summary>
    /// command: send dispatch request for the given taxi
    /// </summary>
    public const byte TaxiDispatch = 0x21;

    /// <summary>
    /// command: change target
    /// </summary>
    public const byte ChangeTarget = 0x31;

    public const byte ExecuteMove = 0x7d;

    /// <summary>
    /// command: add subscription filter
    /// </summary>
    public const byte AddSubscriptionFilter = 0x7e;

    /// <summary>
    /// command: close sumo
    /// </summary>
    public const byte Close = 0x7F;

    /// <summary>
    /// force rerouting based on travel time (vehicles)
    /// </summary>
    public const byte RerouteTravelTime = 0x90;

    /// <summary>
    /// force rerouting based on effort (vehicles)
    /// </summary>
    public const byte RerouteEffort = 0x91;

    /// <summary>
    ///  clears the simulation of all not inserted vehicles (set: simulation)
    /// </summary>
    public const byte ClearPendingVehicles = 0x94;

    /// <summary>
    /// triggers saving simulation state (set: simulation)
    /// </summary>
    public const byte SaveSimulationState = 0x95;

    /// <summary>
    /// triggers saving simulation state (set: simulation)
    /// </summary>
    public const byte LoadSimulationState = 0x96;

    /// <summary>
    /// command: reroute to parking area
    /// </summary>
    public const byte RerouteToParking = 0xc2;

    /// <summary>
    /// command: change lane area detector
    /// </summary>
    public const byte ChangeLaneAreaDetector = 0xcd;
    }
