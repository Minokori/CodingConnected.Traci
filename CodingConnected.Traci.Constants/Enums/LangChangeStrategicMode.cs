namespace CodingConnected.Traci.Constants;

public enum LaneChangeStrategicMode : int
    {
    NoChanges = 0,
    ChangeIfNotInConflict = 1,
    ChangeEvenIfOverriding = 2,
    }
