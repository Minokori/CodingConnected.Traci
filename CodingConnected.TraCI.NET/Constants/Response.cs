namespace CodingConnected.TraCI.NET.Constants;

public static class Response
    {
    public enum Get : byte
        {
        /// <summary>
        /// response: get induction loop (e1) variable
        /// </summary>
        INDUCTIONLOOP_VARIABLE = 0xb0,

        /// <summary>
        /// response: get multi-entry/multi-exit detector (e3) variable
        /// </summary>
        MULTIENTRYEXIT_VARIABLE = 0xb1,

        /// <summary>
        /// response: get traffic lights variable
        /// </summary>
        TL_VARIABLE = 0xb2,

        /// <summary>
        /// response: get lane variable
        /// </summary>
        LANE_VARIABLE = 0xb3,

        /// <summary>
        /// response: get vehicle variable
        /// </summary>
        VEHICLE_VARIABLE = 0xb4,

        /// <summary>
        /// response: get vehicle type variable
        /// </summary>
        VEHICLETYPE_VARIABLE = 0xb5,

        /// <summary>
        /// response: get route variable
        /// </summary>
        ROUTE_VARIABLE = 0xb6,

        /// <summary>
        /// response: get poi variable
        /// </summary>
        POI_VARIABLE = 0xb7,

        /// <summary>
        /// response: get polygon variable
        /// </summary>
        POLYGON_VARIABLE = 0xb8,

        /// <summary>
        /// response: get junction variable
        /// </summary>
        JUNCTION_VARIABLE = 0xb9,

        /// <summary>
        /// response: get edge variable
        /// </summary>
        EDGE_VARIABLE = 0xba,

        /// <summary>
        /// response: get simulation variable
        /// </summary>
        SIM_VARIABLE = 0xbb,

        /// <summary>
        /// response: get GUI variable
        /// </summary>
        GUI_VARIABLE = 0xbc,

        /// <summary>
        /// response: get areal detector (e2) variable
        /// </summary>
        LANEAREA_VARIABLE = 0xbd,

        /// <summary>
        /// response: get person variable
        /// </summary>
        PERSON_VARIABLE = 0xbe,
        }

    public enum Subscribe : byte
        {
        /// <summary>
        /// response: subscribe induction loop (e1) context
        /// </summary>
        INDUCTIONLOOP_CONTEXT = 0x90,

        /// <summary>
        /// response: subscribe multi-entry/multi-exit detector (e3) context
        /// </summary>
        MULTIENTRYEXIT_CONTEXT = 0x91,

        /// <summary>
        /// response: subscribe traffic lights context
        /// </summary>
        TL_CONTEXT = 0x92,

        /// <summary>
        /// response: subscribe lane context
        /// </summary>
        LANE_CONTEXT = 0x93,

        /// <summary>
        /// response: subscribe vehicle context
        /// </summary>
        VEHICLE_CONTEXT = 0x94,

        /// <summary>
        /// response: subscribe vehicle type context
        /// </summary>
        VEHICLETYPE_CONTEXT = 0x95,

        /// <summary>
        /// response: subscribe route context
        /// </summary>
        ROUTE_CONTEXT = 0x96,

        /// <summary>
        /// response: subscribe poi context
        /// </summary>
        POI_CONTEXT = 0x97,

        /// <summary>
        /// response: subscribe polygon context
        /// </summary>
        POLYGON_CONTEXT = 0x98,

        /// <summary>
        /// response: subscribe junction context
        /// </summary>
        JUNCTION_CONTEXT = 0x99,

        /// <summary>
        /// response: subscribe edge context
        /// </summary>
        EDGE_CONTEXT = 0x9a,

        /// <summary>
        /// response: subscribe simulation context
        /// </summary>
        SIM_CONTEXT = 0x9b,

        /// <summary>
        /// response: subscribe GUI context
        /// </summary>
        GUI_CONTEXT = 0x9c,

        /// <summary>
        /// response: subscribe areal detector (e2) context
        /// </summary>
        LANEAREA_CONTEXT = 0x9d,

        /// <summary>
        /// response: subscribe person context
        /// </summary>
        PERSON_CONTEXT = 0x9e,

        /// <summary>
        /// response: subscribe induction loop (e1) variable
        /// </summary>
        INDUCTIONLOOP_VARIABLE = 0xe0,

        /// <summary>
        /// response: subscribe multi-entry/multi-exit detector (e3) variable
        /// </summary>
        MULTIENTRYEXIT_VARIABLE = 0xe1,

        /// <summary>
        /// response: subscribe traffic lights variable
        /// </summary>
        TL_VARIABLE = 0xe2,

        /// <summary>
        /// response: subscribe lane variable
        /// </summary>
        LANE_VARIABLE = 0xe3,

        /// <summary>
        /// response: subscribe vehicle variable
        /// </summary>
        VEHICLE_VARIABLE = 0xe4,

        /// <summary>
        /// response: subscribe vehicle type variable
        /// </summary>
        VEHICLETYPE_VARIABLE = 0xe5,

        /// <summary>
        /// response: subscribe route variable
        /// </summary>
        ROUTE_VARIABLE = 0xe6,

        /// <summary>
        /// response: subscribe poi variable
        /// </summary>
        POI_VARIABLE = 0xe7,

        /// <summary>
        /// response: subscribe polygon variable
        /// </summary>
        POLYGON_VARIABLE = 0xe8,

        /// <summary>
        /// response: subscribe junction variable
        /// </summary>
        JUNCTION_VARIABLE = 0xe9,

        /// <summary>
        /// response: subscribe edge variable
        /// </summary>
        EDGE_VARIABLE = 0xea,

        /// <summary>
        /// response: subscribe simulation variable
        /// </summary>
        SIM_VARIABLE = 0xeb,

        /// <summary>
        /// response: subscribe GUI variable
        /// </summary>
        GUI_VARIABLE = 0xec,

        /// <summary>
        /// response: subscribe areal detector (e2) variable
        /// </summary>
        LANEAREA_VARIABLE = 0xed,

        /// <summary>
        /// response: subscribe person variable
        /// </summary>
        PERSON_VARIABLE = 0xee,
        }
    }
