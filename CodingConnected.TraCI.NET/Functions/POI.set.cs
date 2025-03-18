namespace CodingConnected.Traci.Functions;

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
        TraciString tmp = new(poiType);
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.VAR_TYPE, poiId, tmp);
        }

    /// <summary>
    /// Sets the PoI's color to the given value (r,g,b,a) - please note that alpha) = 0 means fully transparent
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
        Color color = new(r, g, b, a);
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.VAR_COLOR, poiId, color);
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
        Position2D position2D = new(x, y);
        return _helper.ExecuteSetCommand(
            Set.POI_VARIABLE,
            TraciConstants.VAR_POSITION,
            poiId,
            position2D
        );
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
        TraciString tmp = new(imageFile);
        return _helper.ExecuteSetCommand(
            Set.POI_VARIABLE,
            TraciConstants.VAR_IMAGEFILE,
            poiId,
            tmp
        );
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
        var tmp = new TraciDouble(width);
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.VAR_WIDTH, poiId, tmp);
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
        TraciDouble tmp = new(height);
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.VAR_HEIGHT, poiId, tmp);
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
        TraciDouble tmp = new(angle);
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.VAR_ANGLE, poiId, tmp);
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
        Color color = new(r, g, b, a);
        Position2D position2D = new(x, y);
        var tmp = new TraciCompoundObject()
        {
            new TraciString(poiType),
            color,
            new TraciInteger(layer),
            position2D,
            new TraciString(imageFile),
            new TraciDouble(width),
            new TraciDouble(height),
            new TraciDouble(angle),
            new TraciString(icon),
        };
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.ADD, poiId, tmp);
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
        TraciInteger tmp = new(layer);
        return _helper.ExecuteSetCommand(Set.POI_VARIABLE, TraciConstants.REMOVE, poiId, tmp);
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
            throw new ArgumentOutOfRangeException(
                nameof(type),
                "poi.highlight(): maximal value for type is 255"
            );
        if (alphaMax > 255)
            throw new ArgumentOutOfRangeException(
                nameof(alphaMax),
                "poi.highlight(): maximal value for alphaMax is 255"
            );
        if (alphaMax < 0 && duration > 0)
            throw new ArgumentOutOfRangeException(
                nameof(alphaMax),
                "poi.highlight(): duration>0 requires alphaMax>0"
            );
        if (alphaMax > 0 && duration < 0)
            throw new ArgumentOutOfRangeException(
                nameof(duration),
                "poi.highlight(): alphaMax>0 requires duration>0"
            );

        Color color = new(r, g, b, a);
        TraciCompoundObject tmp =
            alphaMax > 0
                ?
                [
                    color,
                    new TraciDouble(size),
                    new TraciInteger(alphaMax),
                    new TraciInteger(duration),
                    new TraciUnsignedByte(type),
                ]
                : [color, new TraciDouble(size)];
        return _helper.ExecuteSetCommand(
            Set.POI_VARIABLE,
            TraciConstants.VAR_HIGHLIGHT,
            poiId,
            tmp
        );
        }
    }
