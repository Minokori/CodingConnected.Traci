namespace CodingConnected.TraCI.NET.Functions;
public partial class Vehicle
    {

    }

public enum StopFlag : byte
    {
    STOP_DEFAULT = 0x00,
    STOP_PARKING = 0x01,
    STOP_TRIGGERED = 0x02,
    STOP_CONTAINER_TRIGGERED = 0x04,
    STOP_BUS_STOP = 0x08,
    STOP_CONTAINER_STOP = 0x10,
    STOP_CHARGING_STATION = 0x20,
    STOP_PARKING_AREA = 0x40,
    }

/// <summary>
/// see http://sumo.dlr.de/wiki/TraCI/Vehicle_Signalling
/// </summary>
public enum VehicleSignalling : int
    {
    VEH_SIGNAL_BLINKER_RIGHT = 0,
    VEH_SIGNAL_BLINKER_LEFT = 1,
    VEH_SIGNAL_BLINKER_EMERGENCY = 2,
    VEH_SIGNAL_BRAKELIGHT = 3,
    VEH_SIGNAL_FRONTLIGHT = 4,
    VEH_SIGNAL_FOGLIGHT = 5,
    VEH_SIGNAL_HIGHBEAM = 6,
    VEH_SIGNAL_BACKDRIVE = 7,
    VEH_SIGNAL_WIPER = 8,
    VEH_SIGNAL_DOOR_OPEN_LEFT = 9,
    VEH_SIGNAL_DOOR_OPEN_RIGHT = 10,
    VEH_SIGNAL_EMERGENCY_BLUE = 11,
    VEH_SIGNAL_EMERGENCY_RED = 12,
    VEH_SIGNAL_EMERGENCY_YELLOW = 13,
    }

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Routing.html#travel-time_values_for_routing"/>
/// </summary>
public enum RoutingMode : int
    {
    Default = 0,
    Aggregated = 1,
    AggregatedCustom = 4,
    IgnoreRerouterChanges = 8,
    AggregatedAndIgnoringRerouterChanges = 9,
    }

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Change_Vehicle_State.html#speed_mode_0xb3"/>
/// </summary>
[Flags]
public enum SpeedMode : int
    {
    RegardSafeSpeed = 1,
    RegardMaximumAcceleration = 2,
    RegardMaximumDeceleration = 4,
    RegardRightOfWayAtIntersections = 8,
    BrakeHardToAvoidPassingARedLight = 16,
    }

public enum LaneChangeStrategicMode
    {
    NoChanges = 0,
    ChangeIfNotInConflict = 1,
    ChangeEvenIfOverriding = 2,
    }

public enum LaneChangeCooperativeMode
    {
    NoChanges = 0,
    ChangeIfNotInConflict = 1,
    ChangeEvenIfOverriding = 2,
    }

public enum LaneChangeSpeedMode
    {
    NoChanges = 0,
    ChangeIfNotInConflict = 1,
    ChangeEvenIfOverriding = 2,
    }

public enum LaneChangeRightMode
    {
    NoChanges = 0,
    ChangeIfNotInConflict = 1,
    ChangeEvenIfOverriding = 2,
    }

public enum LaneChangeRespectMode
    {
    NotRespectOther = 0,
    AvoidImmediateCollisions = 1,
    RespectOthersAdaptSpeed = 2,
    RespectOthersNoSpeedAdaption = 3,
    }

public enum LaneChangeSublaneMode
    {
    NoSublaneChanges = 0,
    DoSublaneChangesIfNotInConflict = 1,
    DoSublaneChangeEvenIfOverriding = 2,
    }

public enum MoveReason : int
    {
    MoveAutomatic = 0,
    MoveTeleport = 1,
    MoveNormal = 2,
    }


public enum RemoveReason : byte
    {
    /// <summary>
    /// vehicle started teleport
    /// </summary>
    Teleport = 0,
    /// <summary>
    /// vehicle removed while parking
    /// </summary>
    Parking = 1,
    /// <summary>
    /// vehicle arrived
    /// </summary>
    Arrived = 2,
    /// <summary>
    /// vehicle was vaporized
    /// </summary>
    Vaporized = 3,
    /// <summary>
    /// vehicle finished route during teleport
    /// </summary>
    TeleportArrived = 4,
    }

