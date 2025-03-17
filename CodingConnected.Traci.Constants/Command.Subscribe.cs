namespace CodingConnected.Traci.Constants;
public static partial class CommandIdentifier
    {
    public enum Subscribe : byte
        {
        /// <summary>
        /// command: subscribe induction loop (e1) context
        /// </summary>
        INDUCTIONLOOP_CONTEXT = 0x80,
        /// <summary>
        /// command: subscribe multi-entry/multi-exit detector (e3) context
        /// </summary>
        MULTIENTRYEXIT_CONTEXT = 0x81,
        /// <summary>
        /// command: subscribe traffic lights context
        /// </summary>
        TL_CONTEXT = 0x82,
        /// <summary>
        /// command: subscribe lane context
        /// </summary>
        LANE_CONTEXT = 0x83,
        /// <summary>
        /// command: subscribe vehicle context
        /// </summary>
        VEHICLE_CONTEXT = 0x84,
        /// <summary>
        /// command: subscribe vehicle type context
        /// </summary>
        VEHICLETYPE_CONTEXT = 0x85,
        /// <summary>
        /// command: subscribe route context
        /// </summary>
        ROUTE_CONTEXT = 0x86,
        /// <summary>
        /// command: subscribe poi context
        /// </summary>
        POI_CONTEXT = 0x87,
        /// <summary>
        /// command: subscribe polygon context
        /// </summary>
        POLYGON_CONTEXT = 0x88,
        /// <summary>
        /// command: subscribe junction context
        /// </summary>
        JUNCTION_CONTEXT = 0x89,
        /// <summary>
        /// command: subscribe edge context
        /// </summary>
        EDGE_CONTEXT = 0x8a,
        /// <summary>
        /// command: subscribe simulation context
        /// </summary>
        SIM_CONTEXT = 0x8b,
        /// <summary>
        /// command: subscribe GUI context
        /// </summary>
        GUI_CONTEXT = 0x8c,
        /// <summary>
        /// command: subscribe areal detector (e2) context
        /// </summary>
        LANEAREA_CONTEXT = 0x8d,
        /// <summary>
        /// command: subscribe person context
        /// </summary>
        PERSON_CONTEXT = 0x8e,
        /// <summary>
        /// command: subscribe induction loop (e1) variable
        /// </summary>
        INDUCTIONLOOP_VARIABLE = 0xd0,
        /// <summary>
        /// command: subscribe multi-entry/multi-exit detector (e3) variable
        /// </summary>
        MULTIENTRYEXIT_VARIABLE = 0xd1,
        /// <summary>
        /// command: subscribe traffic lights variable
        /// </summary>
        TL_VARIABLE = 0xd2,
        /// <summary>
        /// command: subscribe lane variable
        /// </summary>
        LANE_VARIABLE = 0xd3,
        /// <summary>
        /// command: subscribe vehicle variable
        /// </summary>
        VEHICLE_VARIABLE = 0xd4,
        /// <summary>
        /// command: subscribe vehicle type variable
        /// </summary>
        VEHICLETYPE_VARIABLE = 0xd5,
        /// <summary>
        /// command: subscribe route variable
        /// </summary>
        ROUTE_VARIABLE = 0xd6,
        /// <summary>
        /// command: subscribe poi variable
        /// </summary>
        POI_VARIABLE = 0xd7,
        /// <summary>
        /// command: subscribe polygon variable
        /// </summary>
        POLYGON_VARIABLE = 0xd8,
        /// <summary>
        /// command: subscribe junction variable
        /// </summary>
        JUNCTION_VARIABLE = 0xd9,
        /// <summary>
        /// command: subscribe edge variable
        /// </summary>
        EDGE_VARIABLE = 0xda,
        /// <summary>
        /// command: subscribe simulation variable
        /// </summary>
        SIM_VARIABLE = 0xdb,
        /// <summary>
        /// command: subscribe GUI variable
        /// </summary>
        GUI_VARIABLE = 0xdc,
        /// <summary>
        /// command: subscribe areal detector (e2) variable
        /// </summary>
        LANEAREA_VARIABLE = 0xdd,
        /// <summary>
        /// command: subscribe person variable
        /// </summary>
        PERSON_VARIABLE = 0xde,
        }
    }

