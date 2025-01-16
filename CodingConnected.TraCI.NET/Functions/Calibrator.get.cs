using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Calibrator
    {
    /// <summary>
    /// 	Returns the begin time of the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getBegin"/>
    /// </remarks>
    public double GetBegin(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_BEGIN, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the edge of this calibrator
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getEdgeID" />
    /// </remarks>
    public string GetEdgeId(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_ROAD_ID, calibratorId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the edge of this calibrator
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getEdgeID" />
    /// </remarks>
    public double GetEnd(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_END, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of inserted vehicles in the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getInserted" />
    /// </remarks>
    public double GetInserted(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_INSERTED, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the lane of this calibrator (if it applies to a single lane)
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getLaneID" />
    /// </remarks>
    public string GetLaneId(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_LANE_ID, calibratorId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the number of passed vehicles in the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getPassed" />
    /// </remarks>
    public double GetPassed(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_PASSED, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the number of removed vehicles in the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getRemoved" />
    /// </remarks>
    public double GetRemoved(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_REMOVED, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the route id for the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getRouteID" />
    /// </remarks>
    public string GetRouteId(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_ROUTE_ID, calibratorId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the routeProbe id for this calibrator
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getRouteProbeID" />
    /// </remarks>
    public double GetRouteProbeId(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_ROUTE_PROBE, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the target speed of the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getSpeed" />
    /// </remarks>
    public double GetSpeed(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_SPEED, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the type id for the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getTypeID" />
    /// </remarks>
    public string GetTypeId(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_TYPE, calibratorId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of all types to which the calibrator applies (in a type filter is active)
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getVTypes" />
    /// </remarks>

    public List<string> GetVTypes(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_VTYPES, calibratorId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles per hour in the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getVehsPerHour" />
    /// </remarks>
    public double GetVehiclePerHour(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_CALIBRATOR_VARIABLE, TraCIConstants.VAR_VEHSPERHOUR, calibratorId);
        return ((TraCIDouble)result.Value).Value;
        }
    }
