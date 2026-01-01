namespace CodingConnected.Traci.Constants;
#pragma warning disable CA1720 // 标识符包含类型名称

/// <summary>
/// 数据类型标识符.<para/>
/// <see cref="Null"/> 不是 traci 协议中的数据类型, 只是为了一些兼容性. 用于指示某些 Traci 数据类型转化为字节流时, 不需要添加类型标识符.
/// </summary>
public enum DataType
    {
    /// <summary>
    /// PositionRandom in geo-coordinates (longitude, latitude)
    /// </summary>
    LonLat = 0x00,

    /// <summary>
    /// 2D cartesian coordinates (x,y)
    /// </summary>
    XY = 0x01,

    /// <summary>
    /// PositionRandom in geo-coordinates with altitude(longitude,latitude, altitude)
    /// </summary>
    LonLatAlt = 0x02,

    /// <summary>
    /// 3D cartesian coordinates (x,y,z)
    /// </summary>
    XYZ = 0x03,

    /// <summary>
    /// PositionRandom on road map (road,offset, lane)
    /// </summary>
    RoadMap = 0x04,
    BoundingBox = 0x05,
    /// <summary>
    /// Polygon (2*n doubles)
    /// </summary>
    Polygon = 0x06,
    /// <summary>
    /// unsigned byte
    /// </summary>
    UnsignedByte = 0x07,
    /// <summary>
    /// signed byte
    /// </summary>
    Byte = 0x08,

    /// <summary>
    /// 32 bit signed integer
    /// </summary>
    Integer = 0x09,
    Float = 0x0A,
    /// <summary>
    /// double precision float
    /// </summary>
    Double = 0x0B,
    /// <summary>
    /// 8 bit ASCII string
    /// </summary>
    String = 0x0C,
    TLPhaseList = 0x0D,
    /// <summary>
    /// list of strings
    /// </summary>
    StringList = 0x0E,
    /// <summary>
    /// compound object
    /// </summary>
    Compound = 0x0F,
    /// <summary>
    /// list of double precision floats
    /// </summary>
    DoubleList = 0x10,
    /// <summary>
    /// olor (four ubytes)
    /// </summary>
    Color = 0x11,
    /// <summary>
    /// this flag is NOT from traci, just for some compatibility
    /// </summary>
    Null = 0xFF
    }
