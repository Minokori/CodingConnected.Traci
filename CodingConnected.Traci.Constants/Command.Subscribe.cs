namespace CodingConnected.Traci.Constants;

public static partial class CommandIdentifier
    {
    public enum Subscribe : int
        {
        None = 0x00,

        #region context
        /// <summary>
        /// command: subscribe induction loop (e1) context
        /// </summary>
        InductionLoopContext = 0x80,

        /// <summary>
        /// command: subscribe multi-entry/multi-exit detector (e3) context
        /// </summary>
        MultiEntryExitContext = 0x81,

        /// <summary>
        /// command: subscribe traffic lights context
        /// </summary>
        TrafficLightsContext = 0x82,

        /// <summary>
        /// command: subscribe lane context
        /// </summary>
        LaneContext = 0x83,

        /// <summary>
        /// command: subscribe vehicle context
        /// </summary>
        VehicleContext = 0x84,

        /// <summary>
        /// command: subscribe vehicle type context
        /// </summary>
        VehicleTypeContext = 0x85,

        /// <summary>
        /// command: subscribe route context
        /// </summary>
        RouteContext = 0x86,

        /// <summary>
        /// command: subscribe poi context
        /// </summary>
        PoiContext = 0x87,

        /// <summary>
        /// command: subscribe polygon context
        /// </summary>
        PolygonContext = 0x88,

        /// <summary>
        /// command: subscribe junction context
        /// </summary>
        JunctionContext = 0x89,

        /// <summary>
        /// command: subscribe edge context
        /// </summary>
        EdgeContext = 0x8a,

        /// <summary>
        /// command: subscribe simulation context
        /// </summary>
        SimulationContext = 0x8b,

        /// <summary>
        /// command: subscribe GUI context
        /// </summary>
        GuiContext = 0x8c,

        /// <summary>
        /// command: subscribe areal detector (e2) context
        /// </summary>
        LaneAreaContext = 0x8d,

        /// <summary>
        /// command: subscribe person context
        /// </summary>
        PersonContext = 0x8e,

        #endregion

        #region variable
        /// <summary>
        /// command: subscribe induction loop (e1) variable
        /// </summary>
        InductionLoopVariable = 0xd0,

        /// <summary>
        /// command: subscribe multi-entry/multi-exit detector (e3) variable
        /// </summary>
        MultiEntryExitVariable = 0xd1,

        /// <summary>
        /// command: subscribe traffic lights variable
        /// </summary>
        TrafficLightsVariable = 0xd2,

        /// <summary>
        /// command: subscribe lane variable
        /// </summary>
        LaneVariable = 0xd3,

        /// <summary>
        /// command: subscribe vehicle variable
        /// </summary>
        VehicleVariable = 0xd4,

        /// <summary>
        /// command: subscribe vehicle type variable
        /// </summary>
        VehicleTypeVariable = 0xd5,

        /// <summary>
        /// command: subscribe route variable
        /// </summary>
        RouteVariable = 0xd6,

        /// <summary>
        /// command: subscribe poi variable
        /// </summary>
        PoiVariable = 0xd7,

        /// <summary>
        /// command: subscribe polygon variable
        /// </summary>
        PolygonVariable = 0xd8,

        /// <summary>
        /// command: subscribe junction variable
        /// </summary>
        JunctionVariable = 0xd9,

        /// <summary>
        /// command: subscribe edge variable
        /// </summary>
        EdgeVariable = 0xda,

        /// <summary>
        /// command: subscribe simulation variable
        /// </summary>
        SimulationVariable = 0xdb,

        /// <summary>
        /// command: subscribe GUI variable
        /// </summary>
        GuiVariable = 0xdc,

        /// <summary>
        /// command: subscribe areal detector (e2) variable
        /// </summary>
        LaneAreaVariable = 0xdd,

        /// <summary>
        /// command: subscribe person variable
        /// </summary>
        PersonVariable = 0xde,
        #endregion
        }
    }
