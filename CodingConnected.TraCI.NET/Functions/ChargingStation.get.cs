using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class ChargingStation
    {
    /// <summary>
    /// The end position of the stop along the lane measured in m
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getEndPos"/>
    /// </remarks>
    public double GetEndPosition(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_LANEPOSITION, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the lane of this calibrator (if it applies to a single lane)
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getLaneID"/>
    /// </remarks>
    public string GetLaneId(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_LANE_ID, stopId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the name of this stop
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getName"/>
    /// </remarks>
    public string GetName(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_NAME, stopId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// The starting position of the stop along the lane measured in m.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getStartPos"/>
    /// </remarks>
    public double GetStartPosition(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_POSITION, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Get the total number of vehicles stopped at the named charging station.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getVehicleCount"/>
    /// </remarks>
    public int GetVehicleCount(string stopId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE,
            TraCIConstants.VAR_STOP_STARTING_VEHICLES_NUMBER,
            stopId
        );
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	Get the IDs of vehicles stopped at the named charging station.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getVehicleIDs"/>
    /// </remarks>
    public List<string> GetVehicleIds(string stopId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE,
            TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS,
            stopId
        );
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Get the IDs of vehicles stopped at the named charging station.The charging power in W
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getChargingPower"/>
    /// </remarks>
    public double GetChargingPower(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_POWER, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// 	The charging efficiency
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getEfficiency"/>
    /// </remarks>
    public double GetEfficiency(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_EFFICIENCY, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Whether the vehicle is forced/not forced to stop for charging
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getChargeInTransit"/>
    /// </remarks>
    public int GetChargeInTransit(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_TRANSIT, stopId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// The time delay before starting charging in s
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._chargingstation.html#ChargingStationDomain-getChargeDelay"/>
    /// </remarks>
    public double GetChargeDelay(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CHARGINGSTATION_VARIABLE, TraCIConstants.VAR_CHARGING_DELAY, stopId);
        return ((TraCIDouble)result.Value).Value;
        }
    }
