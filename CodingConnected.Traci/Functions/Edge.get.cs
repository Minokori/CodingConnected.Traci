namespace CodingConnected.Traci.Functions;

public partial class Edge
    {
    /// <summary>
    /// Returns a list of ids of all edges within the scenario
    /// (the given Edge ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.IdList,
            "ignored"
        );
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// Returns the number of edges within the scenario
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.IdCount,
            "ignored"
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the number of lanes for the given edge ID
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLaneNumber"/>
    /// </remarks>
    public int GetLaneNumber(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_LANE_INDEX,
            edgeId
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the street name for the given edge ID
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getStreetName"/>
    /// </remarks>
    public string GetStreetName(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_STREET_NAME,
            edgeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the current travel time (length/mean speed).
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getTraveltime"/>
    /// </remarks>
    public double GetTravelTime(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_CURRENT_TRAVELTIME,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of CO2 emissions on this edge in mg/s during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getCO2Emission"/>
    /// </remarks>
    public double GetCO2Emission(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_CO2EMISSION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of CO emissions on this edge in mg/s during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getCOEmission"/>
    /// </remarks>
    public double GetCOEmission(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_COEMISSION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of HC emissions on this edge in mg/s during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getHCEmission"/>
    /// </remarks>
    public double GetHCEmission(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_HCEMISSION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of PMx emissions on this edge in mg/s during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getPMxEmission"/>
    /// </remarks>
    public double GetPMxEmission(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_PMXEMISSION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of NOx emissions on this edge in mg/s during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getNOxEmission"/>
    /// </remarks>
    public double GetNOxEmission(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_NOXEMISSION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of fuel consumption on this edge in mg/s during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getFuelConsumption"/>
    /// </remarks>
    public double GetFuelConsumption(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_FUELCONSUMPTION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of noise generated on this edge in dBA.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getNoiseEmission"/>
    /// </remarks>
    public double GetNoiseEmission(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_NOISEEMISSION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Sum of electricity consumption on this edge in kWh during this time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getElectricityConsumption"/>
    /// </remarks>
    public double GetElectricityConsumption(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_ELECTRICITYCONSUMPTION,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// The number of vehicles on this edge within the last time step.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepVehicleNumber"/>
    /// </remarks>
    public int GetLastStepVehicleNumber(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            (byte)StopFlag.ContainerStop,
            edgeId
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the mean speed of vehicles that were on the named edge within the last simulation step [m/s]
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepMeanSpeed"/>
    /// </remarks>
    public double GetLastStepMeanSpeed(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(GetVariable.Edge, (byte)DataType.Color, edgeId);
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that were on the named edge in the last simulation step.<para/>
    /// The order is from rightmost to leftmost lane and downstream for each lane.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepVehicleIDs"/>
    /// </remarks>
    public List<string> GetLastStepVehicleIDs(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.LastStepVehicleIdList,
            edgeId
        );
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// Returns the percentage of time the edge was occupied by a vehicle [%]
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepOccupancy"/>
    /// </remarks>
    public double GetLastStepOccupancy(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.LastStepOccupancy,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// The mean length of vehicles which were on the edge in the last step [m]
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepLength"/>
    /// </remarks>
    public double GetLastStepLength(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.LastStepLength,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the waiting time for all vehicles on the edge [s]
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getWaitingTime"/>
    /// </remarks>
    public double GetWaitingTime(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_WAITING_TIME,
            edgeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// 	Returns the list of ids of persons that were on the named edge in the last simulation step
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepPersonIDs"/>
    /// </remarks>
    public List<string> GetLastStepPersonIds(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.LAST_STEP_PERSON_ID_LIST,
            edgeId
        );
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// Returns the total number of halting vehicles for the last time step on the given edge. A speed of less than 0.1 m/s is considered a halt.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getLastStepHaltingNumber"/>
    /// </remarks>
    public int GetLastStepHaltingNumber(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.LastStepVehicleHaltingNumber,
            edgeId
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the heading of the straight line segment formed by the edge at the given position.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public double GetAngle(
        string edgeId,
        double relativePosition = TraciConstants.InvalidDoubleValue
    )
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_ANGLE,
            edgeId,
            new TraciDouble(relativePosition)
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the edgeId of the junction at the start of this edge.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getFromJunction"/>
    /// </remarks>
    public string GetFromJunction(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.FROM_JUNCTION,
            edgeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the edgeId of the junction at the end of this edge.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getToJunction"/>
    /// </remarks>
    public string GetToJunction(string edgeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.TO_JUNCTION,
            edgeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the edge travel time for the given time as stored in the global container.<para/>
    /// If such a value does not exist, -1 is returned.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getAdaptedTraveltime"/>
    /// </remarks>
    public double GetAdaptedTravelTime(string edgeId, double time)
        {
        var tmp = new TraciDouble(time);
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_EDGE_TRAVELTIME,
            edgeId,
            tmp
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the edge effort for the given time as stored in the global container.<para/>
    /// If such a value does not exist, -1 is returned.
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._edge.html#EdgeDomain-getEffort"/>
    /// </remarks>
    public double GetEffort(string edgeId, double time)
        {
        var tmp = new TraciDouble(time);
        var result = Helper.ExecuteGetCommand(
            GetVariable.Edge,
            TraciConstants.VAR_EDGE_EFFORT,
            edgeId,
            tmp
        );
        return (TraciDouble)result.Data;
        }
    }
