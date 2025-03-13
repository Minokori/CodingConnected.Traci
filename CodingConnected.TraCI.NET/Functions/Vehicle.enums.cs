namespace CodingConnected.TraCI.NET.Functions;
public partial class Vehicle
    {

    }

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/Simulation/Routing.html#travel-time_values_for_routing"/>
/// </summary>
//public enum RoutingMode : int
//    {
//    Default = 0,
//    Aggregated = 1,
//    AggregatedCustom = 4,
//    IgnoreRerouterChanges = 8,
//    AggregatedAndIgnoringRerouterChanges = 9,
//    }

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

