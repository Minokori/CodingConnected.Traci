using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_TYPE, poiId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the color of this poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getColor"/>
    /// </remarks>
    public Tuple<int, int, int, int> GetColor(string poiId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_COLOR, poiId);
        var color = (Color)result.Value;
        return new(color.R.Value, color.G.Value, color.B.Value, color.A.Value);
        }

    /// <summary>
    /// Returns the position of this poi
    /// </summary>
    /// <param name="poiId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._poi.html#PoiDomain-getPosition"/>
    /// </remarks>
    public Tuple<double, double> GetPosition(string poiId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_POSITION, poiId);
        var position = (Position2D)result.Value;
        return new(position.X.Value, position.Y.Value);
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_IMAGEFILE, poiId);
        return ((TraCIString)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_WIDTH, poiId);
        return ((TraCIDouble)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_HEIGHT, poiId);
        return ((TraCIDouble)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_POI_VARIABLE, TraCIConstants.VAR_ANGLE, poiId);
        return ((TraCIDouble)result.Value).Value;
        }
    }
