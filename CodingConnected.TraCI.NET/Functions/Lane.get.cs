using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Lane
    {
    /// <summary>
    /// Returns a list of ids of all lanes within the scenario
    /// (the given Lane ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of lanes within the scenario
    /// (the given Lane ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of links outgoing from this lane [#]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLinkNumber"/>
    /// </remarks>
    public byte GetLinkNumber(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_LINK_NUMBER, laneId);
        return ((TraCIByte)result.Value).Value;
        }

    /// <summary>
    /// Returns the laneId of the edge this lane belongs to
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getEdgeID"/>
    /// </remarks>
    public string GetEdgeId(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_EDGE_ID, laneId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns descriptions of the links outgoing from this lane [m]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLinks"/>
    /// </remarks>
    public List<Link> GetLinks(string laneId)
        {
        var result = (TraCICompoundObject)_helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_LINKS, laneId);
        return result.ToLinks();
        }

    /// <summary>
    /// Returns the mml-definitions of vehicle classes allowed on this lane
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getAllowed"/>
    /// </remarks>
    public List<string> GetAllowed(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_ALLOWED, laneId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the mml-definitions of vehicle classes not allowed on this lane
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getDisallowed"/>
    /// </remarks>
    public List<string> GetDisallowed(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_DISALLOWED, laneId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the mml-definitions of vehicle classes allowed to change to the left/right neighbor lane
    /// </summary>
    /// <param name="laneId"></param>
    /// <param name="direction">(left=0, right=1)</param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getChangePermissions"/>
    /// </remarks>
    public List<string> GetChangePermissions(string laneId, int direction)
        {
        var tmp = new TraCIByte { Value = (byte)direction };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LANE_CHANGES, laneId, tmp);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the named lane [m]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLength"/>
    /// </remarks>
    public double GetLength(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_LENGTH, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum speed allowed on this lane [m/s]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getMaxSpeed"/>
    /// </remarks>
    public double GetMaxSpeed(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_MAXSPEED, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns this lane's shape
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getShape"/>
    /// </remarks>
    public List<Tuple<double, double>> GetShape(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_SHAPE, laneId);
        var polygon = (Polygon)result.Value;
        return polygon.Select(i => new Tuple<double, double>(i.X.Value, i.Y.Value)).ToList();
        }

    /// <summary>
    /// Returns the width of the named lane [m]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getWidth"/>
    /// </remarks>
    public double GetWidth(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_WIDTH, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of CO2 emissions on this lane in mg/s during this time step
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getCO2Emission"/>
    /// </remarks>
    public double GetCO2Emission(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_CO2EMISSION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of CO emissions on this lane in mg/s during this time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getCOEmission"/>
    /// </remarks>
    public double GetCOEmission(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_COEMISSION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of HC emissions on this lane in mg/s during this time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getHCEmission"/>
    /// </remarks>
    public double GetHCEmission(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_HCEMISSION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of PMx emissions on this lane in mg/s during this time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getPMxEmission"/>
    /// </remarks>
    public double GetPMxEmission(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_PMXEMISSION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of NOx emissions on this lane in mg during this time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getNOxEmission"/>
    /// </remarks>
    public double GetNOxEmission(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_NOXEMISSION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of fuel consumption on this lane in mg/s during this time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getFuelConsumption"/>
    /// </remarks>
    public double GetFuelConsumption(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_FUELCONSUMPTION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of noise generated on this lane in dBA.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getNoiseEmission"/>
    /// </remarks>
    public double GetNoiseEmission(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_NOISEEMISSION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sum of electricity consumption on this lane in kWh during this time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    public double GetElectricityConsumption(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_ELECTRICITYCONSUMPTION, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The number of vehicles on this lane within the last time step.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLastStepVehicleNumber"/>
    /// </remarks>
    public int GetLastStepVehicleNumber(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_NUMBER, laneId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mean speed of vehicles that were on this lane within the last simulation step [m/s]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLastStepMeanSpeed"/>
    /// </remarks>
    public double GetLastStepMeanSpeed(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_MEAN_SPEED, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of ids of vehicles that were on this lane in the last simulation step
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLastStepVehicleIDs"/>
    /// </remarks>
    public List<string> GetLastStepVehicleIds(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_ID_LIST, laneId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the total lengths of vehicles on this lane during the last simulation step divided by the length of this lane
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLastStepOccupancy"/>
    /// </remarks>
    public double GetLastStepOccupancy(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_OCCUPANCY, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The mean length of vehicles which were on this lane in the last step [m]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLastStepLength"/>
    /// </remarks>
    public double GetLastStepLength(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_LENGTH, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the waiting time for all vehicles on the lane [s]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getWaitingTime"/>
    /// </remarks>
    public double GetWaitingTime(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_WAITING_TIME, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the estimated travel time for the last time step on the given lane [s]
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getTraveltime"/>
    /// </remarks>
    public double GetTravelTime(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_CURRENT_TRAVELTIME, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the total number of halting vehicles for the last time step on the given lane.
    /// A speed of less than 0.1 m/s is considered a halt.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getLastStepHaltingNumber"/>
    /// </remarks>
    public int GetLastStepHaltingNumber(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER, laneId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the heading of the straight line segment formed by the lane at the given position.
    /// </summary>
    /// <param name="laneId"></param>
    /// <returns></returns>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getAngle"/>
    /// </remarks>
    public double GetAngle(string laneId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_ANGLE, laneId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of foe lanes. <para/>
    /// There are two modes for calling this method.
    /// <list type="bullet">
    /// <item>
    /// If <paramref name="toLaneId"/> is a normal road lane that is reachable from the laneID argument,
    /// the list contains all lanes that are the origin of a connection with right-of-way over the connection between <paramref name="laneId"/> and <paramref name="toLaneId"/>.
    /// </item>
    /// <item>
    /// If <paramref name="toLaneId"/> is empty and <paramref name="laneId"/> is an internal lane, the list contains all internal lanes that intersect with <paramref name="laneId"/>.
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="laneId"></param>
    ///<remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._lane.html#LaneDomain-getFoes"/>
    /// </remarks>
    public List<string> GetFoes(string laneId, string toLaneId)
        {
        var tmp = new TraCIString { Value = toLaneId };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_LANE_VARIABLE, TraCIConstants.VAR_FOES, laneId, tmp);
        return ((TraCIStringList)result.Value).Value;
        }
    }
