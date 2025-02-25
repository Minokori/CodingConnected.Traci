namespace CodingConnected.TraCI.NET.DataTypes;

public static partial class TraciConstants
    {
    public static partial class Command
        {
        public static class Subscribe
            {
            /// <summary>
            /// command: subscribe induction loop (e1) context
            /// </summary>
            public const byte INDUCTIONLOOP_CONTEXT = 0x80;
            /// <summary>
            /// command: subscribe multi-entry/multi-exit detector (e3) context
            /// </summary>
            public const byte MULTIENTRYEXIT_CONTEXT = 0x81;
            /// <summary>
            /// command: subscribe traffic lights context
            /// </summary>
            public const byte TL_CONTEXT = 0x82;
            /// <summary>
            /// command: subscribe lane context
            /// </summary>
            public const byte LANE_CONTEXT = 0x83;
            /// <summary>
            /// command: subscribe vehicle context
            /// </summary>
            public const byte VEHICLE_CONTEXT = 0x84;
            /// <summary>
            /// command: subscribe vehicle type context
            /// </summary>
            public const byte VEHICLETYPE_CONTEXT = 0x85;
            /// <summary>
            /// command: subscribe route context
            /// </summary>
            public const byte ROUTE_CONTEXT = 0x86;
            /// <summary>
            /// command: subscribe poi context
            /// </summary>
            public const byte POI_CONTEXT = 0x87;
            /// <summary>
            /// command: subscribe polygon context
            /// </summary>
            public const byte POLYGON_CONTEXT = 0x88;
            /// <summary>
            /// command: subscribe junction context
            /// </summary>
            public const byte JUNCTION_CONTEXT = 0x89;
            /// <summary>
            /// command: subscribe edge context
            /// </summary>
            public const byte EDGE_CONTEXT = 0x8a;
            /// <summary>
            /// command: subscribe simulation context
            /// </summary>
            public const byte SIM_CONTEXT = 0x8b;
            /// <summary>
            /// command: subscribe GUI context
            /// </summary>
            public const byte GUI_CONTEXT = 0x8c;
            /// <summary>
            /// command: subscribe areal detector (e2) context
            /// </summary>
            public const byte LANEAREA_CONTEXT = 0x8d;
            /// <summary>
            /// command: subscribe person context
            /// </summary>
            public const byte PERSON_CONTEXT = 0x8e;
            /// <summary>
            /// command: subscribe induction loop (e1) variable
            /// </summary>
            public const byte INDUCTIONLOOP_VARIABLE = 0xd0;
            /// <summary>
            /// command: subscribe multi-entry/multi-exit detector (e3) variable
            /// </summary>
            public const byte MULTIENTRYEXIT_VARIABLE = 0xd1;
            /// <summary>
            /// command: subscribe traffic lights variable
            /// </summary>
            public const byte TL_VARIABLE = 0xd2;
            /// <summary>
            /// command: subscribe lane variable
            /// </summary>
            public const byte LANE_VARIABLE = 0xd3;
            /// <summary>
            /// command: subscribe vehicle variable
            /// </summary>
            public const byte VEHICLE_VARIABLE = 0xd4;
            /// <summary>
            /// command: subscribe vehicle type variable
            /// </summary>
            public const byte VEHICLETYPE_VARIABLE = 0xd5;
            /// <summary>
            /// command: subscribe route variable
            /// </summary>
            public const byte ROUTE_VARIABLE = 0xd6;
            /// <summary>
            /// command: subscribe poi variable
            /// </summary>
            public const byte POI_VARIABLE = 0xd7;
            /// <summary>
            /// command: subscribe polygon variable
            /// </summary>
            public const byte POLYGON_VARIABLE = 0xd8;
            /// <summary>
            /// command: subscribe junction variable
            /// </summary>
            public const byte JUNCTION_VARIABLE = 0xd9;
            /// <summary>
            /// command: subscribe edge variable
            /// </summary>
            public const byte EDGE_VARIABLE = 0xda;
            /// <summary>
            /// command: subscribe simulation variable
            /// </summary>
            public const byte SIM_VARIABLE = 0xdb;
            /// <summary>
            /// command: subscribe GUI variable
            /// </summary>
            public const byte GUI_VARIABLE = 0xdc;
            /// <summary>
            /// command: subscribe areal detector (e2) variable
            /// </summary>
            public const byte LANEAREA_VARIABLE = 0xdd;
            /// <summary>
            /// command: subscribe person variable
            /// </summary>
            public const byte PERSON_VARIABLE = 0xde;
            }
        }
    }
