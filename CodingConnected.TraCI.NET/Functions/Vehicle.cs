using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Vehicle(ITCPConnectService tcpService, ICommandService helper, Simulation simulation)
    : TraCIContextSubscribableCommands(tcpService, helper)
    {
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_VEHICLE_CONTEXT;
    private readonly Simulation _simulation = simulation;

    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all vehicles currently running within the scenario (the given vehicle ID is ignored)
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of vehicles currently running within the scenario (the given vehicle ID is ignored)
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the speed of the named vehicle within the last step [m/s]; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the acceleration in the previous time step [m/s^2]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAcceleration(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCELERATION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the position(two doubles) of the named vehicle (center of the front bumper) within the last step [m,m]; error value: [-2^30, -2^30].
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position2D GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_POSITION, id);
        return (Position2D)result.Value;
        }

    /// <summary>
    /// Returns the 3D-position(three doubles) of the named vehicle (center of the front bumper) within the last step [m,m,m]; error value: [-2^30, -2^30, -2^30].
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position3D GetPosition3D(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_POSITION3D, id);
        return (Position3D)result.Value;
        }

    /// <summary>
    /// Returns the angle of the named vehicle within the last step [°]; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAngle(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ANGLE, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the edge the named vehicle was at within the last step; error value: ""
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetRoadID(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROAD_ID, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the lane the named vehicle was at within the last step; error value: ""
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetLaneID(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANE_ID, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the index of the lane the named vehicle was at within the last step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetLaneIndex(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANE_INDEX, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the type of the named vehicle
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetTypeID(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TYPE, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicleId of the route of the named vehicle
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetRouteID(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the index of the current edge within the vehicles route or -1 if the vehicle has not yet departed
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetRouteIndex(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of the edges the vehicle's route is made of
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetRoute(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGES, id);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the vehicle's color (RGBA).
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Color GetColor(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR, id);
        return (Color)result.Value;
        }

    /// <summary>
    /// The position of the vehicle along the lane (the distance from the front bumper to the start of the lane in [m]); error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLanePosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANEPOSITION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// The distance, the vehicle has already driven [m]); error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetDistance(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DISTANCE, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// An integer encoding the state of a vehicle's signals
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetSignals(string id)
        {
        // TODO: use enum for Vehicle Signalling
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SIGNALS, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Gets the routing speedMode (0: default, 1: aggregated)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetRoutingMode(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTING_MODE, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's CO2 emissions in mg during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetCO2Emission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_CO2EMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's CO emissions in mg during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetCOEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_COEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's HC emissions in mg during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetHCEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_HCEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's PMx emissions in mg during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetPMxEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PMXEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's NOx emissions in mg during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetNOxEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NOXEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's fuel consumption in ml during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetFuelConsumption(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_FUELCONSUMPTION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Noise generated by the vehicle in dBA; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetNoiseEmission(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NOISEEMISSION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Vehicle's electricity consumption in kWh during this time step; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetElectricityConsumption(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ELECTRICITYCONSUMPTION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// For each lane on the current edge, the sequences of lanes that would be followed from that lane without lane-change as well as information regarding lane-change desirability are returned
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<EdgeInformation> GetBestLanes(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_BEST_LANES, id);

        return (result.Value as TraCICompoundObject).ToEdgeInformations();
        }

    /// <summary>
    /// value = 1 * stopped + 2 * parking + 4 * triggered + 8 * containerTriggered + 16 * atBusStop + 32 * atContainerStop + 64 * atChargingStation + 128 * atParkingArea
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public byte GetStopState(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_STOPSTATE, id);
        return ((TraCIByte)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the vehicles [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLength(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum speed of the vehicle [m/s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMaxSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum acceleration possibility of this vehicle [m/s^2]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAccel(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum deceleration possibility of this vehicle [m/s^2]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetDecel(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the driver's desired time headway for this vehicle [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetTau(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the driver's imperfection (dawdling) [0,1]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetImperfection(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the road speed multiplier for this vehicle [double]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeedFactor(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the deviation of factor for this vehicle [double]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeedDeviation(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_DEVIATION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the permission class of this vehicle
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetVehicleClass(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the emission class of this vehicle
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetEmissionClass(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the shape class of this vehicle
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetShapeClass(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the offset (gap to front vehicle if halting) of this vehicle [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMinGap(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the width of this vehicle [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWidth(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the height of this vehicle [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetHeight(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the waiting time [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWaitingTime(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_WAITING_TIME, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the accumulated waiting time [s] within the previous time interval of default length 100 s.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAccumulatedWaitingTime(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCUMULATED_WAITING_TIME, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns upcoming traffic lights, along with distance and state
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<TrafficLightSystem> GetNextTLS(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NEXT_TLS, id);

        return (result.Value as TraCICompoundObject).ToTrafficLightSystems();
        }

    /// <summary>
    /// Retrieves how the values set by speed (0x40) and slowdown (0x14) shall be treated. See the set speedmode command for details.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetSpeedMode(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEEDSETMODE, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Retrieves the slope at the current vehicle position in degrees
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSlope(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SLOPE, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum allowed speed on the current lane regarding speed factor in m/s for this vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAllowedSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ALLOWED_SPEED, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the line information of this vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetLine(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LINE, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the total number of persons which includes those defined using attribute 'personNumber' as well as <person>-objects which are riding in this vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetPersonNumber(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PERSON_NUMBER, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of via edges for this vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetVia(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_VIA, id);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the speed that the vehicle would drive if not speed-influencing command such as setSpeed or slowDown was given.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeedWithoutTraCI(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_WITHOUT_TRACI, id);
        return ((TraCIDouble)result.Value).Value;
        }

    // TODO this returns bool: how does that work?
    /// <summary>
    /// Returns whether the current vehicle route is connected for the vehicle class of the given vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int IsRouteValid(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_VALID, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the lateral position of the vehicle on its current lane measured in m.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLateralLanePosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANEPOSITION_LAT, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum lateral speed in m/s of this vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMaxSpeedLat(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the desired lateral gap of this vehicle at 50km/h in m.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMinGapLat(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the preferred lateral alignment of the vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetLateralAlignment(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the value for the given string parameter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetParameter(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PARAMETER, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the current action step length for the vehicle in s.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetActionStepLength(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
#warning This deviates: constants file is different from website (http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
            0x7d, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the time of the last action step in s.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLastActionTime(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
#warning see above
            0x7f, id);
        return ((TraCIDouble)result.Value).Value;
        }

    // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval

    public void Subscribe(string objectId, double beginTime, double endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_VEHICLE_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
