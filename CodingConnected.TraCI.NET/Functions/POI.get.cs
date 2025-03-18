namespace CodingConnected.Traci.Functions;

public partial class POI
    {
    /// <summary>
    /// Returns a list of ids of all poi
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(Get.POI_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// Returns the number of pois
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(
            Get.POI_VARIABLE,
            TraciConstants.ID_COUNT,
            "ignored"
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the (abstract) type of the poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getType"/>
    /// </remarks>
    public string GetType(string poiId)
        {
        var result = _helper.ExecuteGetCommand(Get.POI_VARIABLE, TraciConstants.VAR_TYPE, poiId);
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the color of this poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getColor"/>
    /// </remarks>
    public (int r, int g, int b, int a) GetColor(string poiId)
        {
        var result = _helper.ExecuteGetCommand(Get.POI_VARIABLE, TraciConstants.VAR_COLOR, poiId);
        return (Color)result.Data;
        }

    /// <summary>
    /// Returns the position of this poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getPosition"/>
    /// </remarks>
    public (double x, double y) GetPosition(string poiId)
        {
        var result = _helper.ExecuteGetCommand(
            Get.POI_VARIABLE,
            TraciConstants.VAR_POSITION,
            poiId
        );
        return (Position2D)result.Data;
        }

    /// <summary>
    /// Returns the path to the image file of the poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getImageFile"/>
    /// </remarks>
    public string GetImageFile(string poiId)
        {
        var result = _helper.ExecuteGetCommand(
            Get.POI_VARIABLE,
            TraciConstants.VAR_IMAGEFILE,
            poiId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the width for the rendered image file
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getWidth"/>
    /// </remarks>
    public double GetWidth(string poiId)
        {
        var result = _helper.ExecuteGetCommand(Get.POI_VARIABLE, TraciConstants.VAR_WIDTH, poiId);
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the height for the rendered image file
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getHeight"/>
    /// </remarks>
    public double GetHeight(string poiId)
        {
        var result = _helper.ExecuteGetCommand(Get.POI_VARIABLE, TraciConstants.VAR_HEIGHT, poiId);
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the angle for the rendered image file
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getAngle"/>
    /// </remarks>
    public double GetAngle(string poiId)
        {
        var result = _helper.ExecuteGetCommand(Get.POI_VARIABLE, TraciConstants.VAR_ANGLE, poiId);
        return (TraciDouble)result.Data;
        }
    }
