using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.Command.Get;
namespace CodingConnected.TraCI.NET.Functions;

public partial class Calibrator
    {
    /// <summary>
    /// Returns the begin time of the current calibration interval
    /// </summary>
    /// <param name="calibratorId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-getBegin"/>
    /// </remarks>
    public double GetBegin(string calibratorId)
        {
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_BEGIN, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_ROAD_ID, calibratorId);
        return ((TraciString)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_END, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_INSERTED, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_LANE_ID, calibratorId);
        return ((TraciString)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_PASSED, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_REMOVED, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_ROUTE_ID, calibratorId);
        return ((TraciString)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_ROUTE_PROBE, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_SPEED, calibratorId);
        return ((TraciDouble)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_TYPE, calibratorId);
        return ((TraciString)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_VTYPES, calibratorId);
        return ((TraciStringList)result.Data).Value;
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
        var result = _helper.ExecuteGetCommand(CALIBRATOR_VARIABLE, TraciConstants.VAR_VEHSPERHOUR, calibratorId);
        return ((TraciDouble)result.Data).Value;
        }
    }
