using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class SimulationCommands(ITcpService tcpService, ICommandHelperService helper) : TraCICommandsBase(tcpService, helper)
    {

    /// <summary>
    /// Returns the current simulation time (in s)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetCurrentTime(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TIME_STEP);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the current simulation time (in s)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetTime(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TIME);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the current simulation time (in ms)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLoadedNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_LOADED_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles which were loaded in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLoadedIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_LOADED_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// A list of ids of vehicles which were loaded in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetDepartedNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_DEPARTED_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles which departed (were inserted into the road network) in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetDepartedIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_DEPARTED_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// 	The number of vehicles which ended to be teleported in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetStartingTeleportNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles which started to teleport in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetStartingTeleportIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(
            id,
            TraCIConstants.CMD_GET_SIM_VARIABLE,
            TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_IDS
        );
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// 	The number of vehicles which ended to be teleported in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetEndingTeleportNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles which ended to be teleported in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetEndingTeleportIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// 	The number of vehicles which arrived (have reached their destination and are removed from the road network) in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetArrivedNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_ARRIVED_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// A list of ids of vehicles which arrived (have reached their destination and are removed from the road network) in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetArrivedIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_ARRIVED_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// The lower left and the upper right corner of the bounding box of the simulation network.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Polygon GetNetBoundary(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_NET_BOUNDING_BOX);
        return (Polygon)result.Value;
        }

    /// <summary>
    /// 	The number of vehicles which are in the net plus the ones still waiting to start. This number may be smaller than the actual number of vehicles still to come because of delayed route file parsing.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetMinExpectedNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles that halted on a scheduled stop in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetStopStartingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_STARTING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles that halted on a scheduled stop in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetStopStartingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// 	The number of vehicles that begin to continue their journey, leaving a scheduled stop in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetStopEndingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_ENDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles that begin to continue their journey, leaving a scheduled stop in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetStopEndingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_ENDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles that were involved in a collision in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetCollidingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_COLLIDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles that were involved in a collision in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetCollidingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_COLLIDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles that had an emergency stop in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetEmergencyStoppingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_EMERGENCYSTOPPING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles that had an emergency stop in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetEmergencyStoppingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(
            id,
            TraCIConstants.CMD_GET_SIM_VARIABLE,
            TraCIConstants.VAR_EMERGENCYSTOPPING_VEHICLES_IDS
        );
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles that enter a parking position in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetParkingStartingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_STARTING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles that enter a parking position in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetParkingStartingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_STARTING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }


    /// <summary>
    /// 	The number of vehicles that begin to continue their journey, leaving a scheduled parking in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetParkingEndingVehiclesNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_ENDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// A list of ids of vehicles that begin to continue their journey, leaving a scheduled parking in this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetParkingEndingVehiclesIDList(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_ENDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Get the total number of waiting persons at the named bus stop.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetBusStopWaiting(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_BUS_STOP_WAITING);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of one simulation step in seconds.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetDeltaT(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_DELTA_T);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the value for the given string parameter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetParameter(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARAMETER);
        return ((TraCIString)result.Value).Value;
        }

    // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Simulation_Value_Retrieval

    /// <summary>
    /// Discards all loaded vehicles with a depart time below the current time step which could not be inserted yet. If the given routeID has non-zero length, only vehicles that have this routeID are discarded.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="routeId"></param>
    /// <returns></returns>
    public bool ClearPending(string id, string routeId)
        {
        return _helper.ExecuteSetCommand<object, string>(
            id,
            TraCIConstants.CMD_SET_SIM_VARIABLE,
            TraCIConstants.CMD_CLEAR_PENDING_VEHICLES,
            routeId
        );
        }

    /// <summary>
    /// Saves current simulation state to the given filename.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    public bool SaveState(string id, string filename)
        {
        return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_SIM_VARIABLE, TraCIConstants.CMD_SAVE_SIMSTATE, filename);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_SIM_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    }

