namespace CodingConnected.TraCI.NET.DataTypes;
public static partial class TraciConstants
    {
    public static class PositionType
        {

        /// <summary>
        /// Position in geo-coordinates (longitude, latitude)
        /// </summary>
        public const byte LON_LAT = 0x00;

        /// <summary>
        /// 2D cartesian coordinates (x,y)
        /// </summary>
        public const byte X_Y = 0x01;

        /// <summary>
        /// Position in geo-coordinates with altitude(longitude,latitude, altitude)
        /// </summary>
        public const byte LON_LAT_ALT = 0x02;

        /// <summary>
        /// 3D cartesian coordinates (x,y,z)
        /// </summary>
        public const byte X_Y_Z = 0x03;

        /// <summary>
        /// Position on road map (road,offset, lane)
        /// </summary>
        public const byte ROADMAP = 0x04;
        }
    }
