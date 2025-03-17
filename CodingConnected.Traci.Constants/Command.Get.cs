namespace CodingConnected.Traci.Constants;
public static partial class CommandIdentifier
    {
    public static class Get
        {
        /// <summary>
        /// command: get parking area variable
        /// </summary>
        public const byte PARKINGAREA_VARIABLE = 0x24;
        /// <summary>
        /// command: get charging station variable
        /// </summary>
        public const byte CHARGINGSTATION_VARIABLE = 0x25;
        /// <summary>
        /// command: get route probe variable
        /// </summary>
        public const byte ROUTEPROBE_VARIABLE = 0x26;
        /// <summary>
        /// command: get calibrator variable
        /// </summary>
        public const byte CALIBRATOR_VARIABLE = 0x27;
        /// <summary>
        /// command: get re-router variable
        /// </summary>
        public const byte REROUTER_VARIABLE = 0x28;
        public const byte VARIABLESPEEDSIGN_VARIABLE = 0x29;


        /// <summary>
        /// command: get induction loop (e1) variable
        /// </summary>
        public const byte INDUCTIONLOOP_VARIABLE = 0xa0;

        /// <summary>
        /// command: get multi-entry/multi-exit detector (e3) variable
        /// </summary>
        /// <remarks>
        /// Asks for the value of a certain variable of the named multi-entry/multi-exit (e3) detector.<para/>
        /// The value returned is the state of the asked variable/value within the last simulation step.
        /// Please note that for asking values from your multi-entry/multi-exit detectors with TraCI,
        /// you have to define them in an additional input file (see multi-entry/multi-exit (e3) detectors)
        /// <u>and cannot add them via TraCI (yet)</u>.
        /// </remarks>
        public const byte MULTIENTRYEXIT_VARIABLE = 0xa1;

        /// <summary>
        /// command: get traffic lights variable
        /// </summary>
        public const byte TL_VARIABLE = 0xa2;

        /// <summary>
        /// command: get lane variable
        /// </summary>
        public const byte LANE_VARIABLE = 0xa3;

        /// <summary>
        /// command: get vehicle variable
        /// </summary>
        public const byte VEHICLE_VARIABLE = 0xa4;

        /// <summary>
        /// command: get vehicle type variable
        /// </summary>
        public const byte VEHICLETYPE_VARIABLE = 0xa5;

        /// <summary>
        /// command: get route variable
        /// </summary>
        public const byte ROUTE_VARIABLE = 0xa6;

        /// <summary>
        /// command: get poi variable
        /// </summary>
        public const byte POI_VARIABLE = 0xa7;

        /// <summary>
        /// command: get polygon variable
        /// </summary>
        public const byte POLYGON_VARIABLE = 0xa8;

        /// <summary>
        /// command: get junction variable
        /// </summary>
        public const byte JUNCTION_VARIABLE = 0xa9;

        /// <summary>
        /// command: get edge variable
        /// </summary>
        public const byte EDGE_VARIABLE = 0xaa;

        /// <summary>
        /// command: get simulation variable
        /// </summary>
        public const byte SIM_VARIABLE = 0xab;

        /// <summary>
        /// command: get GUI variable
        /// </summary>
        public const byte GUI_VARIABLE = 0xac;

        /// <summary>
        /// command: get areal detector (e2) variable<para/>
        /// </summary>
        /// <remarks>
        /// Asks for the value of a certain variable of the named LaneArea (e2) detector.<para/>
        /// The value returned is the state of the asked variable/value within the last simulation step.
        /// Please note that for asking values from your detectors you have to define them within an additional-file and load them at the start of the simulation.
        /// The <u><i>period</i></u> and <u><i>file</i></u> attributes do not matter for TraCI.
        /// </remarks>
        public const byte LANEAREA_VARIABLE = 0xad;

        /// <summary>
        /// command: get person variable<para/>
        /// Asks for the value of a certain variable of the named person.
        /// </summary>
        /// <remarks>
        /// The value returned is the state of the asked variable/value within the last simulation step.<para/>
        /// In the case the person is loaded, but outside the network
        /// - due not being yet inserted into the network or being teleported within the current time step
        /// - a default "error" value is returned.
        /// </remarks>
        public const byte PERSON_VARIABLE = 0xae;
        /// <summary>
        /// command: get bus stop variable
        /// </summary>
        public const byte BUSSTOP_VARIABLE = 0xaf;
        }
    }

