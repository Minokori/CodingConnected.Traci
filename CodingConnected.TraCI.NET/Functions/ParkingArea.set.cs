using static CodingConnected.Traci.Constants.CommandIdentifier.Set;
namespace CodingConnected.Traci.Functions;

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
    public bool SetAcceptedBadges(string stopId, List<string> badges)
        {
        TraciStringList tmp = new(badges);
        return _helper.ExecuteSetCommand(PARKINGAREA_VARIABLE, TraciConstants.VAR_BADGES, stopId, tmp);
        }
    }
