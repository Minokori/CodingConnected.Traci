using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier.Get;

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
        TraciStringList tmp = new(badges);
        var result = _helper.ExecuteGetCommand(PARKINGAREA_VARIABLE, TraciConstants.VAR_BADGES, stopId, tmp);
        return ((TraciStringList)result.Data).Value;
        }
    }
