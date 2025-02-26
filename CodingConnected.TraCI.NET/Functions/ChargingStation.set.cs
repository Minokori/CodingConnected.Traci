using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Command.Set;
namespace CodingConnected.TraCI.NET.Functions;

public partial class ChargingStation
    {
    /// <summary>
    /// The charging power in W
    /// </summary>
    /// <param name="stopId"></param>
    /// <param name="power"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-setChargingPower"/>
    /// </remarks>
    public bool SetChargingPower(string stopId, double power)
        {
        TraciDouble tmp = new(power);
        return _helper.ExecuteSetCommand(CHARGINGSTATION_VARIABLE, TraciConstants.VAR_CHARGING_POWER, stopId, tmp);
        }

    /// <summary>
    /// The charging efficiency
    /// </summary>
    /// <param name="stopId"></param>
    /// <param name="efficiency"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-setEfficiency"/>
    /// </remarks>
    public bool SetEfficiency(string stopId, double efficiency)
        {
        TraciDouble tmp = new(efficiency);
        return _helper.ExecuteSetCommand(CHARGINGSTATION_VARIABLE, TraciConstants.VAR_CHARGING_EFFICIENCY, stopId, tmp);
        }

    /// <summary>
    /// Whether the vehicle is forced/not forced to stop for charging
    /// </summary>
    /// <param name="stopId"></param>
    /// <param name="inTransit"> (0=no, 1=yes)</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-setChargeInTransit"/>
    /// </remarks>
    public bool SetChargeInTransit(string stopId, int inTransit)
        {
        TraciDouble tmp = new(inTransit);
        return _helper.ExecuteSetCommand(CHARGINGSTATION_VARIABLE, TraciConstants.VAR_CHARGING_TRANSIT, stopId, tmp);
        }

    /// <summary>
    /// The time delay before starting charging in s
    /// </summary>
    /// <param name="stopId"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-setChargeDelay"/>
    /// </remarks>
    public bool SetChargeDelay(string stopId, double delay)
        {
        TraciDouble tmp = new(delay);
        return _helper.ExecuteSetCommand(CHARGINGSTATION_VARIABLE, TraciConstants.VAR_CHARGING_DELAY, stopId, tmp);
        }
    }
