using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;


public partial class Calibrator
    {
    /// <summary>
    /// Set the hourly flow and speed at the calibrator location in a given time range. Missing traffic will be added with the given routeID (or routeDistribution ID) and type. DepartLane and departSpeed default to "first" and "max" but can optionally be set. For details on calibrating only flow, speed or type individually,
    /// </summary>
    /// <param name="calibrationId"></param>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    /// <param name="vehiclePerHour"></param>
    /// <param name="speed"></param>
    /// <param name="typeId"></param>
    /// <param name="routeId"></param>
    /// <param name="departLane"></param>
    /// <param name="departSpeed"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._calibrator.html#CalibratorDomain-setFlow"/>
    /// </remarks>
    public bool SetFlow(
        string calibrationId,
        double begin,
        double end,
        double vehiclePerHour,
        double speed,
        string typeId,
        string routeId,
        string departLane = "first",
        string departSpeed = "max"
    )
        {
        TraCICompoundObject tmp = [
            new TraCIDouble() { Value = begin },
            new TraCIDouble() { Value = end },
            new TraCIDouble() { Value = vehiclePerHour },
            new TraCIDouble() { Value = speed },
            new TraCIString() { Value = typeId },
            new TraCIString() { Value = routeId },
            new TraCIString() { Value = departLane },
            new TraCIString() { Value = departSpeed }
            ];
        return _helper.ExecuteSetCommand(calibrationId, TraCIConstants.CMD_SET_CALIBRATOR_VARIABLE,
            TraCIConstants.CMD_SET_FLOW, tmp);
        }
    }
