using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Extensions;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
    {
    public class VehicleCommands(ITcpService tcpService, ICommandHelperService helper) : TraCIContextSubscribableCommands(tcpService, helper)
        {
        #region Protected Override Methods
        protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_VEHICLE_CONTEXT;

        #endregion Protected Override Methods

        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all vehicles currently running within the scenario (the given vehicle ID is ignored)
        /// </summary>
        /// <returns></returns>
        public List<string> GetIdList()
            {
            var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.ID_LIST);
            return ((TraCIStringList)result.Value).Value;
            }

        /// <summary>
        /// Returns the number of vehicles currently running within the scenario (the given vehicle ID is ignored)
        /// </summary>
        /// <returns></returns>
        public int GetIdCount()
            {
            var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.ID_COUNT);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Returns the speed of the named vehicle within the last step [m/s]; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetSpeed(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the acceleration in the previous time step [m/s^2]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetAcceleration(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCELERATION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the position(two doubles) of the named vehicle (center of the front bumper) within the last step [m,m]; error value: [-2^30, -2^30].
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Position2D GetPosition(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_POSITION);
            return (Position2D)result.Value;
            }

        /// <summary>
        /// Returns the 3D-position(three doubles) of the named vehicle (center of the front bumper) within the last step [m,m,m]; error value: [-2^30, -2^30, -2^30].
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Position3D GetPosition3D(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_POSITION3D);
            return (Position3D)result.Value;
            }

        /// <summary>
        /// Returns the angle of the named vehicle within the last step [°]; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetAngle(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ANGLE);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the id of the edge the named vehicle was at within the last step; error value: ""
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRoadID(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROAD_ID);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the id of the lane the named vehicle was at within the last step; error value: ""
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLaneID(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANE_ID);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the index of the lane the named vehicle was at within the last step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetLaneIndex(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANE_INDEX);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Returns the id of the type of the named vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTypeID(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TYPE);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the id of the route of the named vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRouteID(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the index of the current edge within the vehicles route or -1 if the vehicle has not yet departed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetRouteIndex(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Returns the ids of the edges the vehicle's route is made of
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetRoute(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGES);
            return ((TraCIStringList)result.Value).Value;
            }

        /// <summary>
        /// Returns the vehicle's color (RGBA).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Color GetColor(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR);
            return (Color)result.Value;
            }

        /// <summary>
        /// The position of the vehicle along the lane (the distance from the front bumper to the start of the lane in [m]); error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetLanePosition(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANEPOSITION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// The distance, the vehicle has already driven [m]); error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetDistance(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DISTANCE);
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
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SIGNALS);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Gets the routing mode (0: default, 1: aggregated)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetRoutingMode(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTING_MODE);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's CO2 emissions in mg during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetCO2Emission(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_CO2EMISSION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's CO emissions in mg during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetCOEmission(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_COEMISSION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's HC emissions in mg during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetHCEmission(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_HCEMISSION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's PMx emissions in mg during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetPMxEmission(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PMXEMISSION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's NOx emissions in mg during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetNOxEmission(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NOXEMISSION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's fuel consumption in ml during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetFuelConsumption(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_FUELCONSUMPTION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Noise generated by the vehicle in dBA; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetNoiseEmission(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NOISEEMISSION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Vehicle's electricity consumption in kWh during this time step; error value: -2^30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetElectricityConsumption(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// For each lane on the current edge, the sequences of lanes that would be followed from that lane without lane-change as well as information regarding lane-change desirability are returned
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EdgeInformation> GetBestLanes(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_BEST_LANES);

            return (result.Value as TraCICompoundObject).ToEdgeInformations();
            }

        /// <summary>
        /// value = 1 * stopped + 2 * parking + 4 * triggered + 8 * containerTriggered + 16 * atBusStop + 32 * atContainerStop + 64 * atChargingStation + 128 * atParkingArea
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte GetStopState(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_STOPSTATE);
            return ((TraCIByte)result.Value).Value;
            }

        /// <summary>
        /// Returns the length of the vehicles [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetLength(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the maximum speed of the vehicle [m/s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetMaxSpeed(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the maximum acceleration possibility of this vehicle [m/s^2]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetAccel(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the maximum deceleration possibility of this vehicle [m/s^2]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetDecel(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the driver's desired time headway for this vehicle [s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetTau(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the driver's imperfection (dawdling) [0,1]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetImperfection(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the road speed multiplier for this vehicle [double]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetSpeedFactor(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the deviation of speedFactor for this vehicle [double]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetSpeedDeviation(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_DEVIATION);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the permission class of this vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetVehicleClass(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the emission class of this vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetEmissionClass(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the shape class of this vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetShapeClass(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the offset (gap to front vehicle if halting) of this vehicle [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetMinGap(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the width of this vehicle [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetWidth(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the height of this vehicle [m]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetHeight(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the waiting time [s]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetWaitingTime(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_WAITING_TIME);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the accumulated waiting time [s] within the previous time interval of default length 100 s.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetAccumulatedWaitingTime(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCUMULATED_WAITING_TIME);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns upcoming traffic lights, along with distance and state
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TrafficLightSystem> GetNextTLS(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_NEXT_TLS);

            return (result.Value as TraCICompoundObject).ToTrafficLightSystems();
            }

        /// <summary>
        /// Retrieves how the values set by speed (0x40) and slowdown (0x14) shall be treated. See the set speedmode command for details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetSpeedMode(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEEDSETMODE);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Retrieves the slope at the current vehicle position in degrees
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetSlope(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SLOPE);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the maximum allowed speed on the current lane regarding speed factor in m/s for this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetAllowedSpeed(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ALLOWED_SPEED);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the line information of this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLine(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LINE);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the total number of persons which includes those defined using attribute 'personNumber' as well as <person>-objects which are riding in this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetPersonNumber(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PERSON_NUMBER);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Returns the ids of via edges for this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetVia(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_VIA);
            return ((TraCIStringList)result.Value).Value;
            }

        /// <summary>
        /// Returns the speed that the vehicle would drive if not speed-influencing command such as setSpeed or slowDown was given.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetSpeedWithoutTraCI(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_WITHOUT_TRACI);
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
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_VALID);
            return ((TraCIInteger)result.Value).Value;
            }

        /// <summary>
        /// Returns the lateral position of the vehicle on its current lane measured in m.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetLateralLanePosition(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANEPOSITION_LAT);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the maximum lateral speed in m/s of this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetMaxSpeedLat(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the desired lateral gap of this vehicle at 50km/h in m.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetMinGapLat(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the preferred lateral alignment of the vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLateralAlignment(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the value for the given string parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetParameter(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, TraCIConstants.VAR_PARAMETER);
            return ((TraCIString)result.Value).Value;
            }

        /// <summary>
        /// Returns the current action step length for the vehicle in s.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetActionStepLength(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
#warning This deviates: constants file is different from website (http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
                0x7d);
            return ((TraCIDouble)result.Value).Value;
            }

        /// <summary>
        /// Returns the time of the last action step in s.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double GetLastActionTime(string id)
            {
            var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
#warning see above
                0x7f);
            return ((TraCIDouble)result.Value).Value;
            }

        // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval

        /// <summary>
        /// Lets the vehicle stop at the given edge, at the given position and lane. The vehicle will stop for the given duration. Re-issuing a stop command with the same lane and position allows changing the duration. Setting the duration to 0 cancels an existing stop.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edgeId"></param>
        /// <param name="endPosition"></param>
        /// <param name="laneIndex"></param>
        /// <param name="Duration">in ms</param>
        /// <param name="stopFlag"></param>
        /// <param name="startPosition"></param>
        /// <param name="until"></param>
        /// <returns></returns>
        public bool SetStop(
            string id,
            string edgeId,
            double endPosition,
            byte laneIndex,
            double Duration,
            StopFlag stopFlag = StopFlag.STOP_DEFAULT,
            double startPosition = 0d,
            double until = 0
        )
            {
            TraCICompoundObject tmp =
            [
                //result.Value.Add(new TraCIInteger() { Value = itemNumber });
                new TraCIString() { Value = edgeId },
                new TraCIDouble() { Value = endPosition },
                new TraCIByte() { Value = laneIndex },
                new TraCIDouble() { Value = Duration },
                new TraCIByte() { Value = (byte)stopFlag },
                new TraCIDouble() { Value = startPosition },
                new TraCIDouble() { Value = until },
            ];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_STOP, tmp);
            }

        /// <summary>
        /// Forces a lane change to the lane with the given index; if successful, the lane will be chosen for the given amount of time (in seconds).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="laneIndex"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public bool ChangeLane(string id, byte laneIndex, double duration)
            {
            TraCICompoundObject tmp = [new TraCIByte() { Value = laneIndex }, new TraCIDouble() { Value = duration }];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_CHANGELANE,
                tmp
            );
            }

        /// <summary>
        /// 	Forces a lateral change by the given amount (negative values indicate changing to the right, positive to the left). This will override any other lane change motivations but conform to safety-constraints as configured by laneChangeMode.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lateralDistance"></param>
        /// <returns></returns>
        public bool ChangeSublane(string id, double lateralDistance)
            {
            return _helper.ExecuteSetCommand<object, double>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_CHANGESUBLANE,
                lateralDistance
            );
            }

        /// <summary>
        /// Forces a lane change to the lane with the given index; if successful, the lane will be chosen for the given amount of time (in seconds).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="laneIndex"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public bool UpdateBestLanes(string id)
            {
            TraCICompoundObject tmp = [];

            // TODO: fill compound object with data

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_UPDATE_BESTLANES,
                tmp
            );
            }

        /// <summary>
        /// Changes the speed smoothly to the given value over the given amount of time in seconds (can also be used to increase speed).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speed"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public bool SlowDown(string id, double speed, double duration)
            {
            TraCICompoundObject tmp = [new TraCIDouble() { Value = speed }, new TraCIDouble() { Value = duration }];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_SLOWDOWN,
                tmp
            );
            }

        /// <summary>
        /// Resumes from a stop
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Resume(string id)
            {
            TraCICompoundObject tmp = [];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_RESUME,
                tmp
            );
            }

        /// <summary>
        /// The vehicle's destination edge is set to the given. The route is rebuilt.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desitinationEdgeId"></param>
        /// <returns></returns>
        public bool ChangeTarget(string id, string desitinationEdgeId)
            {
            return _helper.ExecuteSetCommand<object, string>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_CHANGETARGET,
                desitinationEdgeId
            );
            }

        /// <summary>
        /// 	Sets the vehicle speed to the given value. The speed will be followed according to the current speed mode. By default the vehicle may drive slower than the set speed according to the safety rules of the car-follow model. When sending a value of -1 the vehicle will revert to its original behavior (using the maxSpeed of its vehicle type and following all safety rules).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public bool SetSpeed(string id, double speed)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED, speed);
            }

        /// <summary>
        /// Sets the vehicle's color.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool SetColor(string id, Color color)
            {
            return _helper.ExecuteSetCommand<object, Color>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR, color);
            }

        /// <summary>
        /// Assigns the named route to the vehicle, assuming a) the named route exists, and b) it starts on the edge the vehicle is currently at
        /// </summary>
        /// <param name="id"></param>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public bool SetRoutID(string id, string routeId)
            {
            return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID, routeId);
            }

        /// <summary>
        /// Assigns the list of edges as the vehicle's new route assuming the first edge given is the one the vehicle is curently at
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool SetRoute(string id, List<string> edges)
            {
            return _helper.ExecuteSetCommand<object, List<string>>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE, edges);
            }

        /// <summary>
        /// Inserts the information about the effort of edge "edgeID" valid from begin time to end time (in seconds) into the vehicle's internal edge weights container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numberOfElements"></param>
        /// <param name="edgeId"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="effortValue"></param>
        /// <returns></returns>
        public bool SetEffort(string id, int numberOfElements, string edgeId, double beginTime = 0, double endTime = 0, double effortValue = 0)
            {
            TraCICompoundObject co = numberOfElements switch
                {
                    4 =>
                    [
                        new TraCIDouble() { Value = beginTime },
                    new TraCIDouble() { Value = endTime },
                    new TraCIString() { Value = edgeId },
                    new TraCIDouble() { Value = effortValue },
                ],
                    2 => [new TraCIString() { Value = edgeId }, new TraCIDouble() { Value = effortValue }],
                    1 => [new TraCIString() { Value = edgeId }],
                    _ => throw new ArgumentOutOfRangeException("numberOfElements", "Only 1, 2 or 4, is allowed as value for numberOfElements"),
                    };
            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_EDGE_EFFORT,
                co
            );
            }

        /// <summary>
        /// Inserts the information about the travel time (in seconds) of edge "edgeID" valid from begin time to end time (in seconds) into the vehicle's internal edge weights container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numberOfElements"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="edgeId"></param>
        /// <param name="travelTimeValue"></param>
        /// <returns></returns>
        public bool SetAdaptedTraveltime(string id, int numberOfElements, double beginTime, double endTime, string edgeId, double travelTimeValue)
            {
            TraCICompoundObject co;
            switch (numberOfElements)
                {
                case 4:
                    co =
                    [
                        new TraCIDouble() { Value = beginTime },
                        new TraCIDouble() { Value = endTime },
                        new TraCIString() { Value = edgeId },
                        new TraCIDouble() { Value = travelTimeValue },
                    ];
                    break;
                case 2:

                    co = [new TraCIString() { Value = edgeId }, new TraCIDouble() { Value = travelTimeValue }];
                    break;
                case 1:
                    co = [];
                    co.Add(new TraCIString() { Value = edgeId });
                    break;
                default:
                    throw new ArgumentOutOfRangeException("numberOfElements", "Only 1, 2 or 4, is allowed as value for numberOfElements");
                }
            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_EDGE_TRAVELTIME,
                co
            );
            }

        /// <summary>
        /// Sets a new state of signal. See TraCI/Vehicle Signalling for more information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="signal"></param>
        /// <returns></returns>
        public bool SetSignals(string id, VehicleSignalling signal)
            {
            return _helper.ExecuteSetCommand<object, int>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE, (int)signal);
            }

        /// <summary>
        /// Sets the mew routing mode (0: default, 1: aggregated)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="routingMode"></param>
        /// <returns></returns>
        public bool SetRoutingMode(string id, RoutingMode routingMode)
            {
            return _helper.ExecuteSetCommand<object, int>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_ROUTING_MODE,
                (int)routingMode
            );
            }

        /// <summary>
        /// 	Moves the vehicle to a new position along the current route
        /// </summary>
        /// <param name="id"></param>
        /// <param name="laneId"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool MoveTo(string id, string laneId, double position)
            {
            TraCICompoundObject tmp = [new TraCIString() { Value = laneId }, new TraCIDouble() { Value = position }];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_MOVE_TO,
                tmp
            );
            }

        /// <summary>
        /// Moves the vehicle to a new position after normal vehicle movements have taken place. Also forces the angle of the vehicle to the given value (navigational angle in degree).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edgeId"></param>
        /// <param name="laneIndex"></param>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <param name="angle"></param>
        /// <param name="keepRoute"></param>
        /// <returns></returns>
        public bool MoveToXY(string id, string edgeId, int laneIndex, double xPosition, double yPosition, double angle, int keepRoute = -1)
            {
            TraCICompoundObject tmp =
            [
                new TraCIString() { Value = edgeId },
                new TraCIInteger() { Value = laneIndex },
                new TraCIDouble() { Value = xPosition },
                new TraCIDouble() { Value = yPosition },
                new TraCIDouble() { Value = angle },
            ];
            if (keepRoute == 0 || keepRoute == 1 || keepRoute == 2)
                {
                tmp.Add(new TraCIByte() { Value = (byte)keepRoute });
                }

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.MOVE_TO_XY,
                tmp
            );
            }

        /// <summary>
        /// Computes a new route to the current destination that minimizes travel time. The assumed values for each edge in the network can be customized in various ways. See Simulation/Routing#Travel-time_values_for_routing. Replaces the current route by the found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RerouteTraveltime(string id)
            {
            TraCICompoundObject tmp = [];
            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_REROUTE_TRAVELTIME,
                tmp
            );
            }

        /// <summary>
        /// Computes a new route using the vehicle's internal and the global edge effort information. Replaces the current route by the found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RerouteEffort(string id)
            {
            TraCICompoundObject tmp = [];
            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.CMD_REROUTE_EFFORT,
                tmp
            );
            }

        /// <summary>
        /// Sets how the values set by speed (0x40) and slowdown (0x14) shall be treated. Also allows to configure the behavior at junctions.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool SetSpeedMode(string id, SpeedMode mode)
            {
            return _helper.ExecuteSetCommand<object, int>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEEDSETMODE, (int)mode);
            }

        /// <summary>
        /// Sets the vehicle's speed factor to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="speedFactor"></param>
        /// <returns></returns>
        public bool SetSpeedFactor(string id, double speedFactor)
            {
            return _helper.ExecuteSetCommand<object, double>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_SPEED_FACTOR,
                speedFactor
            );
            }

        /// <summary>
        /// Sets the vehicle's maximum speed to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        public bool SetMaxSpeed(string id, double maxSpeed)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED, maxSpeed);
            }

        /// <summary>
        /// Sets how lane changing in general and lane changing requests by TraCI are performed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stragic"></param>
        /// <param name="cooperative"></param>
        /// <param name="speed"></param>
        /// <param name="right"></param>
        /// <param name="respect"></param>
        /// <param name="sublane"></param>
        /// <returns></returns>
        public bool SetLaneChangeMode(
            string id,
            LaneChangeStrategicMode stragic,
            LaneChangeCooperativeMode cooperative,
            LaneChangeSpeedMode speed,
            LaneChangeRightMode right,
            LaneChangeRespectMode respect,
            LaneChangeSublaneMode sublane
        )
            {
            int tmp;

            tmp = (int)stragic * 1 + (int)cooperative * 4 + (int)speed * 16 + (int)right * 32 + (int)respect * 64 + (int)sublane * 128;
            return _helper.ExecuteSetCommand<object, int>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LANECHANGE_MODE, tmp);
            }

        /// <summary>
        /// Adds the defined vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleTypeId"></param>
        /// <param name="routeId"></param>
        /// <param name="departTime"></param>
        /// <param name="departPosition"></param>
        /// <param name="departSpeed"></param>
        /// <param name="departLane"></param>
        /// <returns></returns>
        public bool Add(string id, string vehicleTypeId, string routeId, int departTime, double departPosition, double departSpeed, byte departLane)
            {
            TraCICompoundObject tmp =
            [
                new TraCIString() { Value = vehicleTypeId },
                new TraCIString() { Value = routeId },
                new TraCIInteger() { Value = departTime },
                new TraCIDouble() { Value = departPosition },
                new TraCIDouble() { Value = departSpeed },
                new TraCIByte() { Value = departLane },
            ];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.ADD, tmp);
            }

        /// <summary>
        /// Adds the defined vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="routeId"></param>
        /// <param name="vehicleTypeId"></param>
        /// <param name="departTime"></param>
        /// <param name="departLane"></param>
        /// <param name="departPosition"></param>
        /// <param name="departSpeed"></param>
        /// <param name="arrivalPosition"></param>
        /// <param name="arrivalSpeed"></param>
        /// <param name="fromTaz"></param>
        /// <param name="toTaz"></param>
        /// <param name="line"></param>
        /// <param name="personCapacity"></param>
        /// <param name="personNumber"></param>
        /// <returns></returns>
        public bool AddFull(
            string id,
            string routeId,
            string vehicleTypeId,
            string departTime,
            string departLane,
            string departPosition,
            string departSpeed,
            string arrivalLane,
            string arrivalPosition,
            string arrivalSpeed,
            string fromTaz,
            string toTaz,
            string line,
            int personCapacity,
            int personNumber
        )
            {
            TraCICompoundObject tmp =
            [
                new TraCIString() { Value = routeId },
                new TraCIString() { Value = vehicleTypeId },
                new TraCIString() { Value = departTime },
                new TraCIString() { Value = departLane },
                new TraCIString() { Value = departPosition },
                new TraCIString() { Value = departSpeed },
                new TraCIString() { Value = arrivalLane },
                new TraCIString() { Value = arrivalPosition },
                new TraCIString() { Value = arrivalSpeed },
                new TraCIString() { Value = fromTaz },
                new TraCIString() { Value = toTaz },
                new TraCIString() { Value = line },
                new TraCIInteger() { Value = personCapacity },
                new TraCIInteger() { Value = personNumber },
            ];

            return _helper.ExecuteSetCommand<object, TraCICompoundObject>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.ADD_FULL, tmp);
            }

        /// <summary>
        /// Removes the defined vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool Remove(string id, byte reason)
            {
            return _helper.ExecuteSetCommand<object, byte>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.REMOVE, reason);
            }

        /// <summary>
        /// Sets the vehicle's length to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool SetLength(string id, double length)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH, length);
            }

        /// <summary>
        /// Sets the vehicle's vehicle class to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleClass"></param>
        /// <returns></returns>
        public bool SetVehicleClass(string id, string vehicleClass)
            {
            return _helper.ExecuteSetCommand<object, string>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_VEHICLECLASS,
                vehicleClass
            );
            }

        /// <summary>
        /// 	Sets the vehicle's emission class to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="emissionClass"></param>
        /// <returns></returns>
        public bool SetEmissionClass(string id, string emissionClass)
            {
            return _helper.ExecuteSetCommand<object, string>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_EMISSIONCLASS,
                emissionClass
            );
            }

        /// <summary>
        /// 	Sets the vehicle's width to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool SetWidth(string id, double width)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH, width);
            }

        /// <summary>
        /// Sets the vehicle's height to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public bool SetHeight(string id, double height)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT, height);
            }

        /// <summary>
        /// Sets the vehicle's minimum headway gap to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="minGap"></param>
        /// <returns></returns>
        public bool SetMinGap(string id, double minGap)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP, minGap);
            }

        /// <summary>
        /// Sets the vehicle's shape class to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shapeClass"></param>
        /// <returns></returns>
        public bool SetShapeClass(string id, string shapeClass)
            {
            return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, shapeClass);
            }

        /// <summary>
        /// Sets the vehicle's wished maximum acceleration to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acceleration"></param>
        /// <returns></returns>
        public bool SetAccel(string id, double acceleration)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL, acceleration);
            }

        /// <summary>
        /// Sets the vehicle's wished maximum deceleration to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deceleration"></param>
        /// <returns></returns>
        public bool SetDecel(string id, double deceleration)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL, deceleration);
            }

        /// <summary>
        /// Sets the vehicle's driver imperfection (sigma) to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imperfection"></param>
        /// <returns></returns>
        public bool SetImperfection(string id, double imperfection)
            {
            return _helper.ExecuteSetCommand<object, double>(
                id,
                TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                TraCIConstants.VAR_IMPERFECTION,
                imperfection
            );
            }

        /// <summary>
        /// Sets the vehicle's wished headway time to the given value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tau"></param>
        /// <returns></returns>
        public bool SetTau(string id, double tau)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU, tau);
            }

        /// <summary>
        /// Sets the id of the type for the named vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool SetType(string id, string type)
            {
            return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, type);
            }

        /// <summary>
        /// Changes the via edges to the given edges list (to be used during subsequent rerouting calls).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="via"></param>
        /// <returns></returns>
        public bool SetVia(string id, List<string> via)
            {
            return _helper.ExecuteSetCommand<object, List<string>>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_VIA, via);
            }

        /// <summary>
        /// Sets the maximum lateral speed in m/s for this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        public bool SetMaxSpeedLat(string id, double maxSpeed)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, maxSpeed);
            }

        /// <summary>
        /// Sets the minimum lateral gap of the vehicle at 50km/h in m.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gap"></param>
        /// <returns></returns>
        public bool SetMinGapLat(string id, double gap)
            {
            return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, gap);
            }

        /// <summary>
        /// Sets the preferred lateral alignment for this vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public bool SetLateralAlignment(string id, string alignment)
            {
            return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, alignment);
            }

        /// <summary>
        /// Sets the string value for the given string parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResult SetParamater(string id)
            {
            throw new NotImplementedException();
            // see: http://sumo.dlr.de/wiki/TraCI/Change_Vehicle_State#Setting_Device_and_LaneChangeModel_Parameters_.280x7e.29
            }

        /// <summary>
        /// Sets the current action step length for the vehicle in s. If the boolean value resetActionOffset is true, an action step is scheduled immediately for the vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResult SetActionStepLength(string id)
            {
            throw new NotImplementedException();
            }

        public void Subscribe(string objectId, double beginTime, double endTime, List<byte> ListOfVariablesToSubsribeTo)
            {
            _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_VEHICLE_VARIABLE, ListOfVariablesToSubsribeTo);
            }
        #endregion // Public Methods
        }

    public enum StopFlag : Byte
        {
        STOP_DEFAULT = 0x00,
        STOP_PARKING = 0x01,
        STOP_TRIGGERED = 0x02,
        STOP_CONTAINER_TRIGGERED = 0x04,
        STOP_BUS_STOP = 0x08,
        STOP_CONTAINER_STOP = 0x10,
        STOP_CHARGING_STATION = 0x20,
        STOP_PARKING_AREA = 0x40,
        }

    /// <summary>
    /// see http://sumo.dlr.de/wiki/TraCI/Vehicle_Signalling
    /// </summary>
    public enum VehicleSignalling : int
        {
        VEH_SIGNAL_BLINKER_RIGHT = 0,
        VEH_SIGNAL_BLINKER_LEFT = 1,
        VEH_SIGNAL_BLINKER_EMERGENCY = 2,
        VEH_SIGNAL_BRAKELIGHT = 3,
        VEH_SIGNAL_FRONTLIGHT = 4,
        VEH_SIGNAL_FOGLIGHT = 5,
        VEH_SIGNAL_HIGHBEAM = 6,
        VEH_SIGNAL_BACKDRIVE = 7,
        VEH_SIGNAL_WIPER = 8,
        VEH_SIGNAL_DOOR_OPEN_LEFT = 9,
        VEH_SIGNAL_DOOR_OPEN_RIGHT = 10,
        VEH_SIGNAL_EMERGENCY_BLUE = 11,
        VEH_SIGNAL_EMERGENCY_RED = 12,
        VEH_SIGNAL_EMERGENCY_YELLOW = 13,
        }

    public enum RoutingMode : int
        {
        Default = 0,
        Aggregated = 1,
        }

    [Flags]
    public enum SpeedMode : int
        {
        RegardSafeSpeed = 1,
        RegardMaximumAcceleration = 2,
        RegardMaximumDeceleration = 4,
        RegardRightOfWayAtIntersections = 8,
        BrakeHardToAvoidPassingARedLight = 16,
        }

    public enum LaneChangeStrategicMode
        {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2,
        }

    public enum LaneChangeCooperativeMode
        {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2,
        }

    public enum LaneChangeSpeedMode
        {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2,
        }

    public enum LaneChangeRightMode
        {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2,
        }

    public enum LaneChangeRespectMode
        {
        NotRespectOther = 0,
        AvoidImmediateCollisions = 1,
        RespectOthersAdaptSpeed = 2,
        RespectOthersNoSpeedAdaption = 3,
        }

    public enum LaneChangeSublaneMode
        {
        NoSublaneChanges = 0,
        DoSublaneChangesIfNotInConflict = 1,
        DoSublaneChangeEvenIfOverriding = 2,
        }
    }
