using CodingConnected.TraCI.NET.DataTypes;
namespace CodingConnected.TraCI.NET.Functions;



public partial class BusStop
    {
    /// <summary>
    /// The end position of the stop along the lane measured in m.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getEndPos"/>
    /// </remarks>
    public double GetEndPosition(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_LANEPOSITION, stopId);
        return ((TraCIDouble)result.Value).Value;
        }


    /// <summary>
    /// Returns the lane of this calibrator (if it applies to a single lane)
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getLaneID"/>
    /// </remarks>

    public string GetLaneId(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_LANE_ID, stopId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the name of this stop
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getName"/>
    /// </remarks>
    public string GetName(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_NAME, stopId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Get the total number of waiting persons at the named bus stop
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getPersonCount"/>
    /// </remarks>
    public int GetPersonCount(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_BUS_STOP_WAITING, stopId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Get the IDs of waiting persons at the named bus stop.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getPersonIDs"/>
    /// </remarks>
    public List<string> GetPersonIds(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_BUS_STOP_WAITING_IDS, stopId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// The starting position of the stop along the lane measured in m.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getStartPos"/>
    /// </remarks>
    public double GetStartPosition(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_POSITION, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Get the total number of vehicles stopped at the named bus stop
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getVehicleCount"/>
    /// </remarks>
    public int GetVehicleCount(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_STOP_STARTING_VEHICLES_NUMBER, stopId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Get the IDs of vehicles stopped at the named bus stop.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._busstop.html#BusStopDomain-getVehicleIDs"/>
    /// </remarks>

    public List<string> GetVehicleIds(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_BUSSTOP_VARIABLE,
            TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS, stopId);
        return ((TraCIStringList)result.Value).Value;
        }
    }