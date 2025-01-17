using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class POI
    {
    /// <summary>
    /// Sets the PoI's poiType to the given value
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="poiType"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setType"/>
    /// </remarks>
    public bool SetType(string poiId, string poiType)
        {
        var tmp = new TraCIString() { Value = poiType };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_TYPE, tmp);
        }

    /// <summary>
    /// Sets the PoI's color to the given value (r,g,b,a) - please note that a(lpha) = 0 means fully transparent
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setColor"/>
    /// </remarks>
    public bool SetColor(string poiId, int r, int g, int b, int a = 255)
        {
        var color = new Color
            {
            R = new TraCIByte() { Value = (byte)r },
            G = new TraCIByte() { Value = (byte)g },
            B = new TraCIByte() { Value = (byte)b },
            A = new TraCIByte() { Value = (byte)a },
            };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the PoI's position to the given value
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setPosition"/>
    /// </remarks>
    public bool SetPosition(string poiId, double x, double y)
        {
        var position2D = new Position2D
            {
            X = new TraCIDouble() { Value = x },
            Y = new TraCIDouble() { Value = y },
            };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_POSITION, position2D);
        }

    /// <summary>
    /// sets the path to the image file of the poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="imageFile"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setImageFile"/>
    /// </remarks>
    public bool SetImageFile(string poiId, string imageFile)
        {
        var tmp = new TraCIString() { Value = imageFile };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_IMAGEFILE, tmp);
        }

    /// <summary>
    /// Sets the width for the rendered image file
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setWidth"/>
    /// </remarks>
    public bool SetWidth(string poiId, double width)
        {
        var tmp = new TraCIDouble() { Value = width };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_WIDTH, tmp);
        }

    /// <summary>
    /// Sets the height for the rendered image file
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setHeight"/>
    /// </remarks>
    public bool SetHeight(string poiId, double height)
        {
        var tmp = new TraCIDouble() { Value = height };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_HEIGHT, tmp);
        }

    /// <summary>
    /// Sets the angle for the rendered image file
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-setAngle"/>
    /// </remarks>
    public bool SetAngle(string poiId, double angle)
        {
        var tmp = new TraCIDouble() { Value = angle };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_ANGLE, tmp);
        }

    /// <summary>
    /// Adds the defined PoI
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <param name="poiType"></param>
    /// <param name="layer"></param>
    /// <param name="imageFile"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="angle"></param>
    /// <param name="icon"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-add"/>
    /// </remarks>
    public bool Add(
        string poiId,
        double x,
        double y,
        int r,
        int g,
        int b,
        int a,
        string poiType = "",
        int layer = 0,
        string imageFile = "",
        double width = 1.0,
        double height = 1.0,
        double angle = 0.0,
        string icon = ""
    )
        {
        var color = new Color
            {
            R = new TraCIByte() { Value = (byte)r },
            G = new TraCIByte() { Value = (byte)g },
            B = new TraCIByte() { Value = (byte)b },
            A = new TraCIByte() { Value = (byte)a },
            };
        var position2D = new Position2D
            {
            X = new TraCIDouble() { Value = x },
            Y = new TraCIDouble() { Value = y },
            };
        var tmp = new TraCICompoundObject()
        {
            new TraCIString() { Value = poiType },
            color,
            new TraCIInteger() { Value = layer },
            position2D,
            new TraCIString() { Value = imageFile },
            new TraCIDouble() { Value = width },
            new TraCIDouble() { Value = height },
            new TraCIDouble() { Value = angle },
            new TraCIString() { Value = icon },
        };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.ADD, tmp);
        }

    /// <summary>
    /// Removes the defined PoI
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-remove"/>
    /// </remarks>
    public bool Remove(string poiId, int layer = 0)
        {
        var tmp = new TraCIInteger() { Value = layer };
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.REMOVE, tmp);
        }

    /// <summary>
    /// Adds a highlight to the PoI
    /// </summary>
    /// <param name="poiId"></param>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <param name="size"></param>
    /// <param name="alphaMax"></param>
    /// <param name="duration"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-highlight"/>
    /// </remarks>
    public bool Highlight(
        string poiId,
        int r = 255,
        int g = 0,
        int b = 0,
        int a = 255,
        double size = -1.0,
        int alphaMax = -1,
        int duration = -1,
        byte type = 0
    )
        {
        if (type > 255)
            throw new ArgumentOutOfRangeException(nameof(type), "poi.highlight(): maximal value for type is 255");
        if (alphaMax > 255)
            throw new ArgumentOutOfRangeException(nameof(alphaMax), "poi.highlight(): maximal value for alphaMax is 255");
        if (alphaMax < 0 && duration > 0)
            throw new ArgumentOutOfRangeException(nameof(alphaMax), "poi.highlight(): duration>0 requires alphaMax>0");
        if (alphaMax > 0 && duration < 0)
            throw new ArgumentOutOfRangeException(nameof(duration), "poi.highlight(): alphaMax>0 requires duration>0");

        var color = new Color
            {
            R = new TraCIByte() { Value = (byte)r },
            G = new TraCIByte() { Value = (byte)g },
            B = new TraCIByte() { Value = (byte)b },
            A = new TraCIByte() { Value = (byte)a },
            };
        var tmp = alphaMax > 0
            ? ([
                color,
                new TraCIDouble() { Value = size },
                new TraCIInteger() { Value = alphaMax },
                new TraCIInteger() { Value = duration },
                new TraCIUByte() { Value = type },
            ])
            : (TraCICompoundObject)([
                color,
                new TraCIDouble() { Value = size },
            ]);
        return _helper.ExecuteSetCommand(poiId, TraCIConstants.CMD_SET_POI_VARIABLE, TraCIConstants.VAR_HIGHLIGHT, tmp);
        }
    }
