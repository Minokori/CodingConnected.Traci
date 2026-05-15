namespace CodingConnected.Traci.Constants;
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
