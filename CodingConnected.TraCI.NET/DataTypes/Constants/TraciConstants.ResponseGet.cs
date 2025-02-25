namespace CodingConnected.TraCI.NET.DataTypes;

public partial class TraciConstants
    {
    public static partial class Response
        {
        public static class Get
            {
            /// <summary>
            /// response: get induction loop (e1) variable
            /// </summary>
            public const byte INDUCTIONLOOP_VARIABLE = 0xb0;

            /// <summary>
            /// response: get multi-entry/multi-exit detector (e3) variable
            /// </summary>
            public const byte MULTIENTRYEXIT_VARIABLE = 0xb1;

            /// <summary>
            /// response: get traffic lights variable
            /// </summary>
            public const byte TL_VARIABLE = 0xb2;

            /// <summary>
            /// response: get lane variable
            /// </summary>
            public const byte LANE_VARIABLE = 0xb3;

            /// <summary>
            /// response: get vehicle variable
            /// </summary>
            public const byte VEHICLE_VARIABLE = 0xb4;

            /// <summary>
            /// response: get vehicle type variable
            /// </summary>
            public const byte VEHICLETYPE_VARIABLE = 0xb5;

            /// <summary>
            /// response: get route variable
            /// </summary>
            public const byte ROUTE_VARIABLE = 0xb6;

            /// <summary>
            /// response: get poi variable
            /// </summary>
            public const byte POI_VARIABLE = 0xb7;

            /// <summary>
            /// response: get polygon variable
            /// </summary>
            public const byte POLYGON_VARIABLE = 0xb8;

            /// <summary>
            /// response: get junction variable
            /// </summary>
            public const byte JUNCTION_VARIABLE = 0xb9;

            /// <summary>
            /// response: get edge variable
            /// </summary>
            public const byte EDGE_VARIABLE = 0xba;

            /// <summary>
            /// response: get simulation variable
            /// </summary>
            public const byte SIM_VARIABLE = 0xbb;

            /// <summary>
            /// response: get GUI variable
            /// </summary>
            public const byte GUI_VARIABLE = 0xbc;

            /// <summary>
            /// response: get areal detector (e2) variable
            /// </summary>
            public const byte LANEAREA_VARIABLE = 0xbd;

            /// <summary>
            /// response: get person variable
            /// </summary>
            public const byte PERSON_VARIABLE = 0xbe;
            }
        }
    }
