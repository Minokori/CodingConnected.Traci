namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    public class RoutingMode
        {
        /// <summary>
        /// use custom weights if available, fall back to loaded weights and then to free-flow speed
        /// </summary>
        public const byte DEFAULT = 0x00;

        /// <summary>
        /// use aggregated travel times from device.rerouting
        /// </summary>
        public const byte AGGREGATED = 0x01;

        /// <summary>
        /// use loaded efforts
        /// </summary>
        public const byte EFFORT = 0x02;

        /// <summary>
        /// use combined costs
        /// </summary>
        public const byte COMBINED = 0x03;
        }
    }
