using CodingConnected.TraCI.NET.DataTypes;

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
        TraCIDouble tmp = new() { Value = power };
        return _helper.ExecuteSetCommand(stopId, TraCIConstants.CMD_SET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_POWER, tmp);
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
        TraCIDouble tmp = new() { Value = efficiency };
        return _helper.ExecuteSetCommand(stopId, TraCIConstants.CMD_SET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_EFFICIENCY, tmp);
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
        TraCIDouble tmp = new() { Value = inTransit };
        return _helper.ExecuteSetCommand(stopId, TraCIConstants.CMD_SET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_TRANSIT, tmp);
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
        TraCIDouble tmp = new() { Value = delay };
        return _helper.ExecuteSetCommand(stopId, TraCIConstants.CMD_SET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_DELAY, tmp);
        }
    }
