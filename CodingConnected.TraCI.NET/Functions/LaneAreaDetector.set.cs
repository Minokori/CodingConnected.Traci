using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
public partial class LaneAreaDetector
    {
    /// <summary>
    /// Persistently overrides the number of vehicles on the detector.
    /// Setting a negative value resets the override.
    /// </summary>
    /// <param name="detectorId">detector ID</param>
    /// <param name="vehicleNumber">the number of vehicles on the detector</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lanearea.html#LaneAreaDomain-overrideVehicleNumber"/>
    /// </remarks>
    public bool OverrideVehicleNumber(string detectorId, int vehicleNumber)
        {
        var tmp = new TraCIInteger() { Value = vehicleNumber };
        return _helper.ExecuteSetCommand(detectorId, TraCIConstants.CMD_CHANGE_LANE_AREA_DETECTOR, TraCIConstants.VAR_VEHICLE_NUMBER, tmp);
        }
    }
