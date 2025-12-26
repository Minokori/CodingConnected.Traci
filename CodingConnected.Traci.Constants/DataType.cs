namespace CodingConnected.Traci.Constants;

/// <summary>
/// 数据类型标识符.<para/>
/// <see cref="NULL"/> 不是 traci 协议中的数据类型, 只是为了一些兼容性. 用于指示某些 Traci 数据类型转化为字节流时, 不需要添加类型标识符.
/// </summary>
public enum DataType
    {
    /// <summary>
    /// Position in geo-coordinates (longitude, latitude)
    /// </summary>
    LON_LAT = 0x00,

    /// <summary>
    /// 2D cartesian coordinates (x,y)
    /// </summary>
    X_Y = 0x01,

    /// <summary>
    /// Position in geo-coordinates with altitude(longitude,latitude, altitude)
    /// </summary>
    LON_LAT_ALT = 0x02,

    /// <summary>
    /// 3D cartesian coordinates (x,y,z)
    /// </summary>
    X_Y_Z = 0x03,

    /// <summary>
    /// Position on road map (road,offset, lane)
    /// </summary>
    ROADMAP = 0x04,
    BOUNDINGBOX = 0x05,
    POLYGON = 0x06,
    UNSIGNEDBYTE = 0x07,
    BYTE = 0x08,
    INTEGER = 0x09,
    FLOAT = 0x0A,
    DOUBLE = 0x0B,
    STRING = 0x0C,
    TLPHASELIST = 0x0D,
    STRINGLIST = 0x0E,
    COMPOUND = 0x0F,
    DOUBLELIST = 0x10,
    COLOR = 0x11,
    /// <summary>
    /// this flag is NOT from traci, just for some compatibility
    /// </summary>
    NULL = 0xFF
    }
