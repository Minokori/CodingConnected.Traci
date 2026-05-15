namespace CodingConnected.Traci.Functions;

public partial class ParkingArea
    {
    /// <summary>
    /// Setter the accepted badges for parkingArea access.
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
        return Helper.ExecuteSetCommand(
            Setter.ParkingArea,
            TraciConstants.VAR_BADGES,
            stopId,
            tmp
        );
        }
    }
