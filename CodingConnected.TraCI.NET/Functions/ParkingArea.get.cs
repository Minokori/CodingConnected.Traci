using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
public partial class ParkingArea
    {    /// <summary>
         /// The end position of the stop along the lane measured in m
         /// </summary>
         /// <param name="stopId"></param>
         /// <returns></returns>
         /// <remarks>
         /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getEndPos"/>
         /// </remarks>
    public double GetEndPosition(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE, TraCIConstants.VAR_LANEPOSITION, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the lane of this calibrator (if it applies to a single lane)
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getLaneID"/>
    /// </remarks>
    public string GetLaneId(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE, TraCIConstants.VAR_LANE_ID, stopId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the name of this stop
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getName"/>
    /// </remarks>
    public string GetName(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE, TraCIConstants.VAR_NAME, stopId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// The starting position of the stop along the lane measured in m.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getStartPos"/>
    /// </remarks>
    public double GetStartPosition(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE, TraCIConstants.VAR_POSITION, stopId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Get the total number of vehicles stopped at the named charging station.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getVehicleCount"/>
    /// </remarks>
    public int GetVehicleCount(string stopId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE,
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
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getVehicleIDs"/>
    /// </remarks>
    public List<string> GetVehicleIds(string stopId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE,
            TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS,
            stopId
        );
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Get the accepted badges for parking area access.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._parkingarea.html#ParkingAreaDomain-getAcceptedBadges"/>
    /// </remarks>
    public List<string> GetAcceptedBadges(string stopId)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_PARKINGAREA_VARIABLE,
            TraCIConstants.VAR_BADGES,
            stopId
        );
        return ((TraCIStringList)result.Value).Value;
        }
    }
