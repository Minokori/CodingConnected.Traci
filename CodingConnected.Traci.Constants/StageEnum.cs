namespace CodingConnected.Traci.Constants;

public enum StageEnum : byte
    {
    // person / container stopping
    STAGE_WAITING_FOR_DEPART = 0x00,

    // person / container stopping
    STAGE_WAITING = 0x01,

    // person walking / container transshipping
    STAGE_WALKING = 0x02,

    // person riding / container being transported
    STAGE_DRIVING = 0x03,
    }
