using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class LaneCommands(ITcpService tcpService, ICommandHelperService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    #region Protected Override Methods
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_LANE_CONTEXT;

    #endregion Protected Override Methods

    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all lanes within the scenario (the given Lane ID is ignored)
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of lanes within the scenario (the given Lane ID is ignored)
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.ID_COUNT);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of links outgoing from this lane [#]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public byte GetLinkNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_LINK_NUMBER);
        return ((TraCIByte)result.Value).Value;
        }

    /// <summary>
    /// Returns the id of the edge this lane belongs to
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetEdgeId(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_EDGE_ID);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns descriptions of the links outgoing from this lane [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCICompoundObject GetLinks(string id)
        {
        //TODO: parse the result into a usable format
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_LINKS);
        return (TraCICompoundObject)result.Value;
        }

    /// <summary>
    /// Returns the mml-definitions of vehicle classes allowed on this lane
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetAllowed(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_ALLOWED);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the mml-definitions of vehicle classes not allowed on this lane
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetDisallowed(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_DISALLOWED);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the named lane [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLength(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_LENGTH);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum speed allowed on this lane [m/s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMaxSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_MAXSPEED);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns this lane's shape
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Polygon GetShape(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_SHAPE);
        return (Polygon)result.Value;
        }

    /// <summary>
    /// Returns the width of the named lane [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWidth(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_WIDTH);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of CO2 emissions on this lane in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetCO2Emission(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_CO2EMISSION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of CO emissions on this lane in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetCOEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_COEMISSION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of HC emissions on this lane in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetHCEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_HCEMISSION);
        return ((TraCIDouble)result.Value).Value;

        }

    /// <summary>
    /// Sum of PMx emissions on this lane in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetPMxEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_PMXEMISSION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of NOx emissions on this lane in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetNOxEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_NOXEMISSION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of fuel consumption on this lane in ml during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetFuelConsumption(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_FUELCONSUMPTION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of foe lanes. There are two modes for calling this method. If toLane is a normal road
    /// lane that is reachable from the laneID argument, the list contains all lanes that are the origin of a
    /// connection with right-of-way over the connection between laneID and toLane. If toLane is empty and laneID
    /// is an internal lane, the list contains all internal lanes that intersect with laneID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="toLane"></param>
    /// <returns></returns>
    public object GetFoes(string id, string toLane)
        {
        throw new NotImplementedException();
        }

    /// <summary>
    /// Sum of noise generated on this lane in dBA.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetNoiseEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_NOISEEMISSION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of electricity consumption on this lane in kWh during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetElectricityConsumption(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles on this lane within the last time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepVehicleNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mean speed of vehicles that were on this lane within the last simulation step [m/s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that were on this lane in the last simulation step
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLastStepVehicleIds(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the total lengths of vehicles on this lane during the last simulation step divided by the length of this lane
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepOccupancy(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The mean length of vehicles which were on this lane in the last step [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepLength(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_LENGTH);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the waiting time for all vehicles on the lane [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWaitingTime(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_WAITING_TIME);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the estimated travel time for the last time step on the given lane [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetTravelTime(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_CURRENT_TRAVELTIME);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the total number of halting vehicles for the last time step on the given lane.
    /// A speed of less than 0.1 m/s is considered a halt.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepHaltingNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Sets a list of allowed vehicle classes.
    /// </summary>
    public bool SetAllowed(string laneId, List<string> allowedVehicleClasses)
        {
        return _helper.ExecuteSetCommand<object, List<string>>(
            laneId,
            TraCIConstants.CMD_SET_LANE_VARIABLE,
            TraCIConstants.LANE_ALLOWED,
            allowedVehicleClasses
        );
        }

    /// <summary>
    /// Sets a list of disallowed vehicle classes.
    /// </summary>
    public bool SetDisallowed(string laneId, List<string> disallowedVehicleClasses)
        {
        return _helper.ExecuteSetCommand<object, List<string>>(
            laneId,
            TraCIConstants.CMD_SET_LANE_VARIABLE,
            TraCIConstants.LANE_DISALLOWED,
            disallowedVehicleClasses
        );
        }

    /// <summary>
    /// Sets the length of the lane in m
    /// </summary>
    public bool SetLength(string laneId, double length)
        {
        return _helper.ExecuteSetCommand<object, double>(laneId, TraCIConstants.CMD_SET_LANE_VARIABLE, TraCIConstants.VAR_LENGTH, length);
        }

    /// <summary>
    /// Sets a new maximum allowed speed on the lane in m/s.
    /// </summary>
    public bool SetMaxSpeed(string laneId, double maxSpeed)
        {
        return _helper.ExecuteSetCommand<object, double>(laneId, TraCIConstants.CMD_SET_LANE_VARIABLE, TraCIConstants.VAR_MAXSPEED, maxSpeed);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_LANE_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
