namespace CodingConnected.Traci.Constants;
#pragma warning disable CA1034 // 嵌套类型应不可见

public static partial class CommandIdentifier
    {
    public static class Setter

        {
        public const byte Flow = 0x18;
        /// <summary>
        /// command: set parking area variable
        /// </summary>
        public const byte ParkingArea = 0x44;
        /// <summary>
        /// command: set charging station variable
        /// </summary>
        public const byte ChargingStation = 0x45;
        /// <summary>
        /// command: set calibrator variable
        /// </summary>
        public const byte Calibrator = 0x47;

        /// <summary>
        /// command: set induction loop (e1) variable; not used yet
        /// </summary>
        public const byte InductionLoop = 0xc0;
        /// <summary>
        /// Changes the state of a traffic light. Because it is possible to change different values of a traffic light; the given value may have different types.
        /// </summary>
        public const byte TrafficLights = 0xc2;

        /// <summary>
        /// command: set lane variable
        /// </summary>
        public const byte Lane = 0xc3;

        /// <summary>
        /// command: set vehicle variable
        /// </summary>
        public const byte Vehicle = 0xc4;

        /// <summary>
        /// command: set vehicle type variable
        /// </summary>
        public const byte VehicleType = 0xc5;

        /// <summary>
        /// command: set route variable
        /// </summary>
        public const byte Route = 0xc6;

        /// <summary>
        /// command: set poi variable
        /// </summary>
        public const byte Poi = 0xc7;

        /// <summary>
        /// command: set polygon variable
        /// </summary>
        public const byte Polygon = 0xc8;

        /// <summary>
        /// command: set junction variable
        /// </summary>
        public const byte Junction = 0xc9;

        /// <summary>
        /// command: set edge variable
        /// </summary>
        public const byte Edge = 0xca;

        /// <summary>
        /// command: set simulation variable
        /// </summary>
        public const byte Simulation = 0xcb;

        /// <summary>
        /// command: set GUI variable
        /// </summary>
        public const byte Gui = 0xcc;

        /// <summary>
        /// command: set person variable
        /// </summary>
        public const byte Person = 0xce;
        }

    }

