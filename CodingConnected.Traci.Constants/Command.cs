namespace CodingConnected.Traci.Constants;
public static partial class CommandIdentifier
    {
    /// <summary>
    /// command: get version
    /// </summary>
    public const byte GETVERSION = 0x00;

    /// <summary>
    /// command: load
    /// </summary>
    public const byte LOAD = 0x01;

    /// <summary>
    /// command: simulation step
    /// </summary>
    public const byte SIMSTEP = 0x02;

    /// <summary>
    /// command: set connection priority (execution order)
    /// </summary>
    public const byte SETORDER = 0x03;

    /// <summary>
    /// command: stop node
    /// </summary>
    public const byte STOP = 0x12;

    /// <summary>
    /// command: set lane
    /// </summary>
    public const byte CHANGELANE = 0x13;

    /// <summary>
    /// command: slow down
    /// </summary>
    public const byte SLOWDOWN = 0x14;

    /// <summary>
    /// command: set sub-lane (vehicle)
    /// </summary>
    public const byte CHANGESUBLANE = 0x15;

    /// <summary>
    /// command: replace vehicle stop and update route
    /// </summary>
    public const byte REPLACE_STOP = 0x17;

    /// <summary>
    /// command: insert vehicle stop and update route
    /// </summary>
    public const byte INSERT_STOP = 0x18;

    /// <summary>
    /// command: Resume from parking
    /// </summary>
    public const byte RESUME = 0x19;

    /// <summary>
    /// command: send dispatch request for the given taxi
    /// </summary>
    public const byte TAXI_DISPATCH = 0x21;

    /// <summary>
    /// command: change target
    /// </summary>
    public const byte CHANGETARGET = 0x31;

    public const byte EXECUTE_MOVE = 0x7d;

    /// <summary>
    /// command: add subscription filter
    /// </summary>
    public const byte ADD_SUBSCRIPTION_FILTER = 0x7e;

    /// <summary>
    /// command: close sumo
    /// </summary>
    public const byte CLOSE = 0x7F;

    /// <summary>
    /// force rerouting based on travel time (vehicles)
    /// </summary>
    public const byte REROUTE_TRAVELTIME = 0x90;

    /// <summary>
    /// force rerouting based on effort (vehicles)
    /// </summary>
    public const byte REROUTE_EFFORT = 0x91;

    /// <summary>
    ///  clears the simulation of all not inserted vehicles (set: simulation)
    /// </summary>
    public const byte CLEAR_PENDING_VEHICLES = 0x94;

    /// <summary>
    /// triggers saving simulation state (set: simulation)
    /// </summary>
    public const byte SAVE_SIMSTATE = 0x95;

    /// <summary>
    /// triggers saving simulation state (set: simulation)
    /// </summary>
    public const byte LOAD_SIMSTATE = 0x96;

    /// <summary>
    /// command: reroute to parking area
    /// </summary>
    public const byte REROUTE_TO_PARKING = 0xc2;

    /// <summary>
    /// command: change lane area detector
    /// </summary>
    public const byte CHANGE_LANE_AREA_DETECTOR = 0xcd;
    }

