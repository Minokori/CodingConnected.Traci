using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Vehicle
    {
    /// <summary>
    /// Returns a list of ids of all vehicles currently running within the scenario
    /// (the given vehicle ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles currently running within the scenario
    /// (the given vehicle ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the speed of the named vehicle within the last step [m/s]; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSpeed"/>
    /// </remarks>
    public double GetSpeed(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the lateral speed of the named vehicle within the last step [m/s]; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLateralSpeed"/>
    /// </remarks>
    public double GetLateralSpeed(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_LAT, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the acceleration in the previous time step [m/s^2]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getAcceleration"/>
    /// </remarks>
    public double GetAcceleration(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCELERATION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the position(two doubles) of the named vehicle (center of the front bumper) within the last step [m,m]; error value: [-2^30, -2^30].
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getPosition"/>
    /// </remarks>
    public (double X, double Y) GetPosition(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_POSITION, vehicleId);
        var position = (Position2D)result.Value;
        return (position.X.Value, position.Y.Value);
        }

    /// <summary>
    /// Returns the 3D-position(three doubles) of the named vehicle (center of the front bumper) within the last step [m,m,m]; error value: [-2^30, -2^30, -2^30].
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getPosition3D"/>
    /// </remarks>
    public (double X, double Y, double Z) GetPosition3D(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_POSITION3D, vehicleId);
        var position = (Position3D)result.Value;
        return (position.X.Value, position.Y.Value, position.Z.Value);
        }

    /// <summary>
    /// Returns the angle of the named vehicle within the last step [°]; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getAngle"/>
    /// </remarks>
    public double GetAngle(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ANGLE, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the edge the named vehicle was at within the last step; error value: ""
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRoadID"/>
    /// </remarks>
    public string GetRoadID(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROAD_ID, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the lane the named vehicle was at within the last step; error value: ""
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLaneID"/>
    /// </remarks>
    public string GetLaneID(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANE_ID, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the index of the lane the named vehicle was at within the last step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLaneIndex"/>
    /// </remarks>
    public int GetLaneIndex(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANE_INDEX, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the type of the named vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getTypeID"/>
    /// </remarks>
    public string GetTypeID(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TYPE, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the route of the named vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRouteID"/>
    /// </remarks>
    public string GetRouteID(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the index of the current edge within the vehicles route or -1 if the vehicle has not yet departed
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRouteIndex"/>
    /// </remarks>
    public int GetRouteIndex(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of the edges the vehicle's route is made of
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRoute"/>
    /// </remarks>
    public List<string> GetRoute(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGES, vehicleId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicle's color (RGBA).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getColor"/>
    /// </remarks>
    public (int r, int g, int b, int a) GetColor(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR, vehicleId);
        var color = (Color)result.Value;
        return (color.R.Value, color.G.Value, color.B.Value, color.A.Value);
        }

    /// <summary>
    /// The position of the vehicle along the lane (the distance from the front bumper to the start of the lane in [m]); error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLanePosition"/>
    /// </remarks>
    public double GetLanePosition(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANEPOSITION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The distance, the vehicle has already driven [m]); error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getDistance"/>
    /// </remarks>
    public double GetDistance(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DISTANCE, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// An integer encoding the state of a vehicle's signals
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSignals"/>
    /// </remarks>
    public int GetSignals(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SIGNALS, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Gets the routing speedMode (0: default, 1: aggregated)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRoutingMode"/>
    /// </remarks>
    public int GetRoutingMode(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTING_MODE, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Return the list of all taxis with the given mode:(-1: all, 0 : empty, 1 : pickup,2 : occupied, 3: pickup+occupied). Note: vehicles that are in state pickup+occupied (due to ride sharing) will also be returned when requesting mode 1 or 2
    /// </summary>
    /// <param name="taxiState"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getTaxiFleet"/>
    /// </remarks>
    public List<string> GetTaxiFleet(int taxiState = 0)
        {
        var tmp = new TraCIInteger { Value = taxiState };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAXI_FLEET, "", tmp);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's CO2 emissions in mg/s during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getCO2Emission"/>
    /// </remarks>
    public double GetCO2Emission(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_CO2EMISSION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's CO emissions in mg/s during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getCOEmission"/>
    /// </remarks>
    public double GetCOEmission(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_COEMISSION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's HC emissions in mg/s during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getHCEmission"/>
    /// </remarks>
    public double GetHCEmission(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_HCEMISSION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's PMx emissions in mg/ during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getPMxEmission"/>
    /// </remarks>
    public double GetPMxEmission(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PMXEMISSION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's NOx emissions in mg/s during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getNOxEmission"/>
    /// </remarks>
    public double GetNOxEmission(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NOXEMISSION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's fuel consumption in mg/s during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getFuelConsumption"/>
    /// </remarks>
    public double GetFuelConsumption(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_FUELCONSUMPTION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Noise generated by the vehicleId in dBA; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getNoiseEmission"/>
    /// </remarks>
    public double GetNoiseEmission(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NOISEEMISSION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's electricity consumption in Wh/s during this time step; error value: -2^30
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getElectricityConsumption"/>
    /// </remarks>
    public double GetElectricityConsumption(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ELECTRICITYCONSUMPTION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// For each lane on the current edge, the sequences of lanes that would be followed from that lane without lane-change as well as information regarding lane-change desirability are returned
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getBestLanes"/>
    /// </remarks>
    public List<EdgeInformation> GetBestLanes(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_BEST_LANES, vehicleId);
        return ((TraCICompoundObject)result.Value).ToEdgeInformations();
        }

    /// <summary>
    /// value = 1 * stopped + 2 * parking + 4 * triggered + 8 * containerTriggered + 16 * atBusStop + 32 * atContainerStop + 64 * atChargingStation + 128 * atParkingArea
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getStopState"/>
    /// </remarks>
    public int GetStopState(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_STOPSTATE, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Return whether the vehicle is stopped at a bus stop
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-isAtBusStop"/>
    /// </remarks>
    public bool IsAtBusStop(string vehicleId)
        {
        return (GetStopState(vehicleId) & 16) == 16;
        }

    /// <summary>
    /// Return whether the vehicle is stopped at a container stop
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-isAtContainerStop"/>
    /// </remarks>
    public bool IsAtContainerStop(string vehicleId)
        {
        return (GetStopState(vehicleId) & 32) == 32;
        }

    /// <summary>
    /// Return whether the vehicle is stopped
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-isStopped"/>
    /// </remarks>
    public bool IsStopped(string vehicleId)
        {
        return (GetStopState(vehicleId) & 1) == 1;
        }

    /// <summary>
    /// Return whether the vehicle is parking (implies stopped)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-isStoppedParking"/>
    /// </remarks>
    public bool IsStoppedParking(string vehicleId)
        {
        return (GetStopState(vehicleId) & 2) == 2;
        }

    /// <summary>
    /// Return whether the vehicle is stopped and waiting for a person or container
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-isStoppedTriggered"/>
    /// </remarks>
    public bool IsStoppedTriggered(string vehicleId)
        {
        return (GetStopState(vehicleId) & 12) > 0;
        }

    /// <summary>
    /// Returns the length of the vehicles [m]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLength"/>
    /// </remarks>
    public double GetLength(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum speed of the vehicleId [m/s]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getMaxSpeed"/>
    /// </remarks>
    public double GetMaxSpeed(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum acceleration possibility of this vehicleId [m/s^2]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getAccel"/>
    /// </remarks>
    public double GetAccel(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum deceleration possibility of this vehicleId [m/s^2]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getDecel"/>
    /// </remarks>
    public double GetDecel(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the driver's desired time headway for this vehicleId [s]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getTau"/>
    /// </remarks>
    public double GetTau(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the driver's imperfection (dawdling) [0,1]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getImperfection"/>
    /// </remarks>
    public double GetImperfection(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the road speed multiplier for this vehicleId [double]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSpeedFactor"/>
    /// </remarks>
    public double GetSpeedFactor(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the deviation of factor for this vehicleId [double]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSpeedDeviation"/>
    /// </remarks>
    public double GetSpeedDeviation(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_DEVIATION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the permission class of this vehicleId
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getVehicleClass"/>
    /// </remarks>
    public string GetVehicleClass(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the emission class of this vehicleId
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getEmissionClass"/>
    /// </remarks>
    public string GetEmissionClass(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the shape class of this vehicleId
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getShapeClass"/>
    /// </remarks>
    public string GetShapeClass(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the offset (gap to front vehicleId if halting) of this vehicleId [m]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getMinGap"/>
    /// </remarks>
    public double GetMinGap(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the width of this vehicleId [m]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getWidth"/>
    /// </remarks>
    public double GetWidth(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the height of this vehicleId [m]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getHeight"/>
    /// </remarks>
    public double GetHeight(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the total number of persons that can ride in this vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getPersonCapacity"/>
    /// </remarks>
    public int GetPersonCapacity(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PERSON_CAPACITY, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the waiting time [s]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getWaitingTime"/>
    /// </remarks>
    public double GetWaitingTime(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_WAITING_TIME, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the accumulated waiting time [s] within the previous time interval of default length 100 s.
    /// (length is configurable per option --waiting-time-memory given to the main application)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getAccumulatedWaitingTime"/>
    /// </remarks>
    public double GetAccumulatedWaitingTime(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCUMULATED_WAITING_TIME, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns upcoming traffic lights, along with distance and state
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getNextTLS"/>
    /// </remarks>
    public List<UpcomingTrafficLights> GetNextTLS(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NEXT_TLS, vehicleId);
        return (result.Value as TraCICompoundObject).ToUpcomingTrafficLights();
        }

    /// <summary>
    /// Returns the list of persons which includes those defined using attribute 'personNumber' as well as -objects which are riding in this vehicle.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getPersonIDList"/>
    /// </remarks>
    public List<string> GetPersonIdList(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.LAST_STEP_PERSON_ID_LIST, vehicleId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Retrieves how the values set by <see cref="SetSpeed"/> and <see cref="SlowDown"/> shall be treated.
    /// See the <see cref="SetSpeedMode"/> command for details.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public int GetSpeedMode(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEEDSETMODE, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Get information on how lane changing in general and lane changing requests by TraCI are performed
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLaneChangeMode"/>
    /// </remarks>
    public int GetLaneChangeMode(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANECHANGE_MODE, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Retrieves the slope at the current vehicleId position in degrees
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSlope"/>
    /// </remarks>
    public double GetSlope(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SLOPE, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum allowed speed on the current lane regarding speed factor in m/s for this vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getAllowedSpeed"/>
    /// </remarks>
    public double GetAllowedSpeed(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ALLOWED_SPEED, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the line information of this vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLine"/>
    /// </remarks>
    public string GetLine(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LINE, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the total number of persons which includes those defined using attribute 'personNumber' as well as <person>-objects which are riding in this vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getPersonNumber"/>
    /// </remarks>
    public int GetPersonNumber(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PERSON_NUMBER, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of via edges for this vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getVia"/>
    /// </remarks>
    public List<string> GetVia(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_VIA, vehicleId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the speed that the vehicleId would drive if not speed-influencing command such as setSpeed or slowDown was given.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSpeedWithoutTraCI"/>
    /// </remarks>
    public double GetSpeedWithoutTraCI(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_WITHOUT_TRACI, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    // TODO this returns bool: how does that work?
    /// <summary>
    /// Returns whether the current vehicleId route is connected for the vehicleId class of the given vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-isRouteValid"/>
    /// </remarks>
    public bool IsRouteValid(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_VALID, vehicleId);
        return ((TraCIInteger)result.Value).Value != 0;
        }

    /// <summary>
    /// Returns the lateral position of the vehicleId on its current lane measured in m.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLateralLanePosition"/>
    /// </remarks>
    public double GetLateralLanePosition(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANEPOSITION_LAT, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum lateral speed in m/s of this vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getMaxSpeedLat"/>
    /// </remarks>
    public double GetMaxSpeedLat(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the boarding duration of the vehicle in s
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getBoardingDuration"/>
    /// </remarks>
    public double GetBoardingDuration(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_BOARDING_DURATION, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the current [dynamic impatience]
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getImpatience"/>
    /// </remarks>
    public double GetImpatience(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPATIENCE, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the desired lateral gap of this vehicleId at 50km/h in m.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getMinGapLat"/>
    /// </remarks>
    public double GetMinGapLat(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the preferred lateral alignment of the vehicleId.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLateralAlignment"/>
    /// </remarks>
    public string GetLateralAlignment(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the value for the given string parameter
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getParameter"/>
    /// </remarks>
    public string GetParameter(string vehicleId, string key)
        {
        var tmp = new TraCIString { Value = key };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARAMETER, vehicleId, tmp);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the current action step length for the vehicleId in s.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getActionStepLength"/>
    /// </remarks>
    public double GetActionStepLength(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACTIONSTEPLENGTH, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the time of the last action step in s.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLastActionTime"/>
    /// </remarks>
    public double GetLastActionTime(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LASTACTIONTIME, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of the next or last n stops as StopData objects.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getStops"/>
    /// </remarks>
    public List<StopData> GetStops(string vehicleId, int limit = 0)
        {
        // TODO cause there is no discribe fos stop data, we try parse it as StopInfomation
        // used in GetNextStops() command, which has been deprecated.
        var tmp = new TraCIInteger { Value = limit };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NEXT_STOPS2, vehicleId, tmp);
        return ((TraCICompoundObject)result.Value).ToStopDatas();
        }

    /// <summary>
    /// Returns the accumulated timeLoss of the vehicle in s
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getTimeLoss"/>
    /// </remarks>
    public double GetTimesLoss(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TIMELOSS, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of all loaded vehicle ids that have not yet arrived. This includes vehicles that are meant to depart in the future.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLoadedIDList"/>
    /// </remarks>
    public List<string> GetLoadedIdList(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LOADED_LIST, vehicleId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns a list of all vehicles that are currently teleporting/jumping. <para/>
    /// teleporting/jumping see <see href="https://sumo.dlr.de/docs/Simulation/Why_Vehicles_are_teleporting.md"/>
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getTeleportingIDList"/>
    /// </remarks>
    public List<string> GetTeleportingIdList(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TELEPORTING_LIST, vehicleId);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of upcoming links with each compound containing info about(lane, via, priority, opened, foe, state, direction, length)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getNextLinks"/>
    /// </remarks>
    public List<Link> GetNextLinks(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NEXT_LINKS, vehicleId);
        return ((TraCICompoundObject)result.Value).ToLinks();
        }

    /// <summary>
    /// Returns the actual departure time (after possibly queueing for insertion)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getDeparture"/>
    /// </remarks>
    public double GetDeparture(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DEPARTURE, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the time difference between the planned and the actual departure
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getDepartDelay"/>
    /// </remarks>
    public double GetDepartDelay(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DEPART_DELAY, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the id of the segment on which the vehicle is driving (mesosim)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSegmentID"/>
    /// </remarks>
    public string GetSegmentId(string vehicleId)
        {
        // TODO there is no such command in python api, and not discribed as "deprecated" in the doc
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, 0xa1, vehicleId);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the index of the segment on which the vehicle is driving (mesosim)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSegmentIndex"/>
    /// </remarks>
    public int GetSegmentIndex(string vehicleId)
        {
        // TODO there is no such command in python api, and not discribed as "deprecated" in the doc
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, 0xa2, vehicleId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the mass of the vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getMass"/>
    /// </remarks>
    public double GetMass(string vehicleId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MASS, vehicleId);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the edge travel time for the given time as stored in the vehicle's internal container. If such a value does not exist, -1 is returned.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="time"></param>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getAdaptedTraveltime"/>
    /// </remarks>
    public double GetAdaptedTravelTime(string vehicleId, double time, string edgeId)
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIDouble() { Value = time },
            new TraCIString() { Value = edgeId },
        };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGE_TRAVELTIME, vehicleId, tmp);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the edge effort for the given time as stored in the vehicle's internal container. If such a value does not exist, -1 is returned.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="time"></param>
    /// <param name="edgeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getEffort"/>
    /// </remarks>
    public (double RequestTime, string edgeId) GetEffort(string vehicleId, double time, string edgeId)
        {
        TraCICompoundObject tmp = [new TraCIDouble() { Value = time }, new TraCIString() { Value = edgeId }];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGE_EFFORT, vehicleId, tmp);
        var effortInformation = (TraCICompoundObject)result.Value;
        return new(((TraCIDouble)effortInformation[0]).Value, ((TraCIString)effortInformation[1]).Value);
        }

    /// <summary>
    /// Returns the id of the leading vehicle and its distance, if the string is empty, no leader was found within the given range. Only vehicles ahead on the currently list of best lanes are considered (see above). This means, the leader is only valid until the next lane-change maneuver. The returned distance is measured from the ego vehicle front bumper + minGap to the back bumper of the leader vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLeader"/>
    /// </remarks>
    public (string leadingVehilceId, double distance) GetLeader(string vehicleId, double distance = 100.0)
        {
        TraCIDouble tmp = new() { Value = distance };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LEADER, vehicleId, tmp);
        var leaderInformation = (TraCICompoundObject)result.Value;
        return new(((TraCIString)leaderInformation[0]).Value, ((TraCIDouble)leaderInformation[1]).Value);
        }

    /// <summary>
    /// Returns the distance between the current vehicle position and the specified position (for the given distance type)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="edgeId"></param>
    /// <param name="position"></param>
    /// <param name="laneIndex"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getDrivingDistance"/>
    /// </remarks>
    public double GetDrivingDistance(string vehicleId, string edgeId, double position, int laneIndex = 0)
        {
        TraCICompoundObject tmp =
        [
            new RoadMapPosition()
            {
                RoadId = new() { Value = edgeId },
                LaneId = new() { Value = (byte)laneIndex },
                Pos = new() { Value = position },
            },
            new TraCIUByte() { Value = TraCIConstants.REQUEST_DRIVINGDIST },
        ];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.DISTANCE_REQUEST, vehicleId, tmp);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the distance between the current vehicle position and the specified position (for the given distance type)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getDrivingDistance2D"/>
    /// </remarks>

    public double GetDrivingDistance2D(string vehicleId, double x, double y)
        {
        TraCICompoundObject tmp =
        [
            new Position2D()
            {
                X = new() { Value = x },
                Y = new() { Value = y },
            },
            new TraCIUByte() { Value = TraCIConstants.REQUEST_DRIVINGDIST },
        ];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.DISTANCE_REQUEST, vehicleId, tmp);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Return whether the vehicle could change lanes in the specified direction in the previous step (right: -1, left: 1. sublane-change within current lane: 0).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    /// <remarks>
    /// change lane information see <see href="https://sumo.dlr.de/docs/TraCI/Vehicle_Value_Retrieval.html#change_lane_information_0x13"></see><para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLaneChangeState"/>
    /// </remarks>
    public (int Model, int Traci) GetLaneChangeState(string vehicleId, int direction)
        {
        TraCIInteger tmp = new() { Value = direction };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.CMD_CHANGELANE, vehicleId, tmp);
        var item = (TraCICompoundObject)result.Value;
        return new(((TraCIInteger)item[0]).Value, ((TraCIInteger)item[1]).Value);
        }

    /// <summary>
    /// Return whether the vehicle could change lanes in the specified direction in the previous step (right: -1, left: 1. sublane-change within current lane: 0).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    /// <remarks>
    /// change lane information see <see href="https://sumo.dlr.de/docs/TraCI/Vehicle_Value_Retrieval.html#change_lane_information_0x13"></see><para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-wantsAndCouldChangeLane"/>
    /// </remarks>
    public bool WantsAndCouldChangeLane(string vehicleId, int direction, int? state = null)
        {
        if (!state.HasValue)
            {
            (state, var stateTraci) = GetLaneChangeState(vehicleId, direction);
            if (WantsAndCouldChangeLane(vehicleId, direction, stateTraci))
                {
                return false;
                }
            }
        if ((state & TraCIConstants.LCA_BLOCKED) == 0)
            {
            if (direction == -1)
                return (state & TraCIConstants.LCA_RIGHT) != 0;
            if (direction == 1)
                return (state & TraCIConstants.LCA_LEFT) != 0;
            }
        return false;
        }

    /// <summary>
    /// Return whether the vehicle could change lanes in the specified direction in the previous step (right: -1, left: 1. sublane-change within current lane: 0).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    /// <remarks>
    /// change lane information see <see href="https://sumo.dlr.de/docs/TraCI/Vehicle_Value_Retrieval.html#change_lane_information_0x13"></see><para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-couldChangeLane"/>
    /// </remarks>
    public bool CouldChangeLane(string vehicleId, int direction, int? state = null)
        {
        if (!state.HasValue)
            {
            (state, var stateTraci) = GetLaneChangeState(vehicleId, direction);
            if (WantsAndCouldChangeLane(vehicleId, direction, stateTraci))
                {
                return false;
                }
            }
        return (state != TraCIConstants.LCA_UNKNOWN) && ((state & TraCIConstants.LCA_BLOCKED) == 0);
        }

    /// <summary>
    /// Returns a list of IDs for neighboring vehicle relevant to lane changing (>1 elements only possible for sublane model)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="mode">The parameter mode is a bitset (UBYTE), specifying the following:
    /// bit 1: query lateral direction(left:0, right:1)
    ///bit 2: query longitudinal direction(followers:0, leaders:1)
    ///bit 3: blocking(return all:0, return only blockers:1)</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getNeighbors"/>
    /// </remarks>
    public List<(string Id, double Distance)> GetNeighbors(string vehicleId, byte mode)
        {
        TraCIUByte tmp = new() { Value = mode };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NEIGHBORS, vehicleId, tmp);
        return ((TraCICompoundObject)result.Value)
            .Chunk(2)
            .Select(i => (Id: ((TraCIString)i[0]).Value, Distance: ((TraCIDouble)i[1]).Value))
            .ToList();
        }

    /// <summary>
    /// Returns a list of IDs for neighboring vehicle relevant to lane changing (>1 elements only possible for sublane model)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="blockingOnly"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLeftFollowers"/>
    /// </remarks>
    public List<(string Id, double Distance)> GetLeftFollowers(string vehicleId, bool blockingOnly = false)
        {
        return GetNeighbors(vehicleId, blockingOnly ? (byte)4 : (byte)0);
        }

    /// <summary>
    /// Returns a list of IDs for neighboring vehicle relevant to lane changing (>1 elements only possible for sublane model)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="blockingOnly"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getLeftLeaders"/>
    /// </remarks>
    public List<(string Id, double Distance)> GetLeftLeaders(string vehicleId, bool blockingOnly = false)
        {
        return GetNeighbors(vehicleId, blockingOnly ? (byte)6 : (byte)2);
        }

    /// <summary>
    /// Returns a list of IDs for neighboring vehicle relevant to lane changing (>1 elements only possible for sublane model)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="blockingOnly"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRightFollowers"/>
    /// </remarks>
    public List<(string Id, double Distance)> GetRightFollowers(string vehicleId, bool blockingOnly = false)
        {
        return GetNeighbors(vehicleId, blockingOnly ? (byte)5 : (byte)1);
        }

    /// <summary>
    /// Returns a list of IDs for neighboring vehicle relevant to lane changing (>1 elements only possible for sublane model)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="blockingOnly"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getRightLeaders"/>
    /// </remarks>
    public List<(string Id, double Distance)> GetRightLeaders(string vehicleId, bool blockingOnly = false)
        {
        return GetNeighbors(vehicleId, blockingOnly ? (byte)7 : (byte)3);
        }

    /// <summary>
    /// Return the follow speed computed by the carFollowModel of vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <param name="gap"></param>
    /// <param name="leaderSpeed"></param>
    /// <param name="leaderMaxDecel"></param>
    /// <param name="leaderId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getFollowSpeed"/>
    /// </remarks>

    public double GetFollowSpeed(string vehicleId, double speed, double gap, double leaderSpeed, double leaderMaxDecel, string leaderId = "")
        {
        TraCICompoundObject tmp =
        [
            new TraCIDouble() { Value = speed },
            new TraCIDouble() { Value = gap },
            new TraCIDouble() { Value = leaderSpeed },
            new TraCIDouble() { Value = leaderMaxDecel },
            new TraCIString() { Value = leaderId },
        ];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_FOLLOW_SPEED, vehicleId, tmp);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Return the safe speed for stopping at gap computed by the carFollowModel of vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <param name="gap"></param>
    /// <param name="leaderSpeed"></param>
    /// <param name="leaderMaxDecel"></param>
    /// <param name="leaderId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getSecureGap"/>
    /// </remarks>
    public double GetSecureGap(string vehicleId, double speed, double gap, double leaderSpeed, double leaderMaxDecel, string leaderId = "")
        {
        TraCICompoundObject tmp =
        [
            new TraCIDouble() { Value = speed },
            new TraCIDouble() { Value = gap },
            new TraCIDouble() { Value = leaderSpeed },
            new TraCIDouble() { Value = leaderMaxDecel },
            new TraCIString() { Value = leaderId },
        ];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SECURE_GAP, vehicleId, tmp);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Return the safe speed for stopping at gap computed by the carFollowModel of vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <param name="gap"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getStopSpeed"/>
    /// </remarks>
    public double GetStopSpeed(string vehicleId, double speed, double gap)
        {
        TraCICompoundObject tmp = [new TraCIDouble() { Value = speed }, new TraCIDouble() { Value = gap }];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_STOP_SPEED, vehicleId, tmp);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the list of foes within a certain distance of the ego vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-getJunctionFoes"/>
    /// </remarks>
    public object GetJunctionFoes(string vehicleId, double distance = 0.0)
        {
        // TODO there is no discribe for return type in doc
        TraCIDouble tmp = new() { Value = distance };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_FOES, vehicleId, tmp);
        var foes = (TraCICompoundObject)result.Value;
        return foes.ToJunctionFoes();
        }

    /// <summary>
    /// Returns the attribute by the given name for the stop of the given index
    /// (0 is the next stop, -1 is the previous stop etc) for the specified vehicle.
    /// If customParam is set to True (1), the user defined custom parameter will returned instead.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="nextStopIndex"></param>
    /// <param name="param"></param>
    /// <param name="customParam"></param>
    /// <returns></returns>
    public string GetStopParameter(string vehicleId, int nextStopIndex, string param, bool customParam = false)
        {
        TraCICompoundObject tmp =
        [
            new TraCIInteger() { Value = nextStopIndex },
            new TraCIString() { Value = param },
            new TraCIByte() { Value = customParam ? (byte)1 : (byte)0 },
        ];
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_STOP_PARAMETER, vehicleId, tmp);
        return ((TraCIString)result.Value).Value;
        }
    }
