using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
public partial class Simulation
    {
    /// <summary>
    /// Discards all loaded vehicles with a depart time below the current time step which could not be inserted yet.<para/>
    /// If the given routeID has non-zero length, only vehicles that have this routeID are discarded.
    /// </summary>
    /// <param name="routeId"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-clearPending"/>
    /// </remarks>
    public bool ClearPending(string routeId = "")
        {
        var tmp = new TraCIString() { Value = routeId };
        return _helper.ExecuteSetCommand("", TraCIConstants.CMD_SET_SIM_VARIABLE, TraCIConstants.CMD_CLEAR_PENDING_VEHICLES, tmp);
        }

    /// <summary>
    /// Saves current simulation state to the given fileName.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-saveState"/>
    /// </remarks>
    public bool SaveState(string fileName)
        {
        var tmp = new TraCIString() { Value = fileName };

        return _helper.ExecuteSetCommand("", TraCIConstants.CMD_SET_SIM_VARIABLE, TraCIConstants.CMD_SAVE_SIMSTATE, tmp);
        }


    /// <summary>
    /// Quick-loads simulation state from the given fileName.<para/>
    /// Caution:<para/>
    /// Vehicles from an incrementally loaded route file as well as flow-vehicles may be missing when loading the state this way.<para/>
    /// If all route input is in &lt;vehicle&gt; or &lt;trip&gt; format and loaded with option --additional-files (non-incremental loading), traffic is guaranteed to be complete.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-loadState"/>
    /// </remarks>
    public bool LoadState(string fileName)
        {
        var tmp = new TraCIString() { Value = fileName };
        return _helper.ExecuteSetCommand("", TraCIConstants.CMD_SET_SIM_VARIABLE, TraCIConstants.CMD_LOAD_SIMSTATE, tmp);
        }

    /// <summary>
    /// 	Set traffic scaling factor
    /// </summary>
    /// <param name="value"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-setScale"/>
    /// </remarks>
    public bool SetScale(double value)
        {
        var tmp = new TraCIDouble() { Value = value };
        return _helper.ExecuteSetCommand("", TraCIConstants.CMD_SET_SIM_VARIABLE, TraCIConstants.VAR_SCALE, tmp);
        }
    }
