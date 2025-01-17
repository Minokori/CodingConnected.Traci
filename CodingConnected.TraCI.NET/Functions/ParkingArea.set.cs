using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class ParkingArea
    {
    /// <summary>
    /// Set the accepted badges for parkingArea access.
    /// </summary>
    /// <param name="stopId"></param>
    /// <param name="badges"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-setAcceptedBadges"/>
    /// </remarks>
    public List<string> SetAcceptedBadges(string stopId, List<string> badges)
        {
        TraCIStringList tmp = new() { Value = badges };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE, TraCIConstants.VAR_BADGES, stopId, tmp);
        return ((TraCIStringList)result.Value).Value;
        }
    }
