using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class EdgeCommands(ITCPConnectService tcpService, ICommandService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_EDGE_CONTEXT;


    /// <summary>
    /// Returns a list of ids of all edges within the scenario
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of edges within the scenario
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of lanes for the given edge ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLaneNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_LANE_INDEX, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the street name for the given edge ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetStreetName(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_STREET_NAME, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the current travel time (length/mean speed).
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetTraveltime(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_CURRENT_TRAVELTIME, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of CO2 emissions on this edge in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetCO2Emission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_CO2EMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of CO emissions on this edge in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetCOEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_COEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of HC emissions on this edge in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetHCEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_HCEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of PMx emissions on this edge in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetPMxEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_PMXEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of NOx emissions on this edge in mg during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetNOxEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_NOXEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of fuel consumption on this edge in ml during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetFuelConsumption(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_FUELCONSUMPTION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of noise generated on this edge in dBA.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetNoiseEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_NOISEEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of electricity consumption on this edge in kWh during this time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetElectricityConsumption(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_ELECTRICITYCONSUMPTION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles on this edge within the last time step.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepVehicleNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.STOP_CONTAINER_STOP, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mean speed of vehicles that were on the named edge within the last simulation step [m/s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepMeanSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.TYPE_COLOR, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that were on the named edge in the last simulation step. The order is from rightmost to leftmost lane and downstream for each lane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLastStepVehicleIDs(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, id);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the percentage of time the edge was occupied by a vehicle [%]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepOccupancy(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The mean length of vehicles which were on the edge in the last step [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastStepLength(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.LAST_STEP_LENGTH, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the waiting time for all vehicles on the edge [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWaitingTime(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.VAR_WAITING_TIME, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the list of ids of persons that were on the named edge in the last simulation step
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetLastStepPersonIDs(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.LAST_STEP_PERSON_ID_LIST, id);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the total number of halting vehicles for the last time step on the given edge. A speed of less than 0.1 m/s is considered a halt.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLastStepHaltingNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_EDGE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER, id);
        return ((TraCIInteger)result.Value).Value;
        }

    // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Edge_Value_Retrieval




    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_EDGE_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    }
