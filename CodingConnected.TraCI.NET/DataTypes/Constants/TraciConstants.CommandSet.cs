namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    public static partial class Command
        {
        public static class Set
            {
            public const byte FLOW = 0x18;
            /// <summary>
            /// command: set parking area variable
            /// </summary>
            public const byte PARKINGAREA_VARIABLE = 0x44;
            /// <summary>
            /// command: set charging station variable
            /// </summary>
            public const byte CHARGINGSTATION_VARIABLE = 0x45;
            /// <summary>
            /// command: set calibrator variable
            /// </summary>
            public const byte CALIBRATOR_VARIABLE = 0x47;

            /// <summary>
            /// command: set induction loop (e1) variable, not used yet
            /// </summary>
            public const byte INDUCTIONLOOP_VARIABLE = 0xc0;
            // command: set traffic lights variable
            /// <summary>
            /// Changes the state of a traffic light. Because it is possible to change different values of a traffic light, the given value may have different types.
            /// </summary>
            public const byte TL_VARIABLE = 0xc2;

            // command: set lane variable
            public const byte LANE_VARIABLE = 0xc3;

            // command: set vehicle variable
            public const byte VEHICLE_VARIABLE = 0xc4;

            // command: set vehicle type variable
            public const byte VEHICLETYPE_VARIABLE = 0xc5;

            // command: set route variable
            public const byte ROUTE_VARIABLE = 0xc6;

            // command: set poi variable
            public const byte POI_VARIABLE = 0xc7;

            // command: set polygon variable
            public const byte POLYGON_VARIABLE = 0xc8;

            // command: set junction variable
            public const byte JUNCTION_VARIABLE = 0xc9;

            // command: set edge variable
            public const byte EDGE_VARIABLE = 0xca;

            // command: set simulation variable
            public const byte SIM_VARIABLE = 0xcb;

            // command: set GUI variable
            public const byte GUI_VARIABLE = 0xcc;

            // command: set person variable
            public const byte PERSON_VARIABLE = 0xce;
            }

        }
    }
