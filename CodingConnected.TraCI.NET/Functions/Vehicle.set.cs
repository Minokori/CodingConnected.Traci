using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Vehicle
    {
    /// <summary>
    /// Lets the vehicle stop at the given edge, at the given position and lane.<para/>
    /// The vehicle will stop for the given duration. Re-issuing a stop command with the same lane and position allows changing the duration.
    /// Setting the duration to 0 cancels an existing stop.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="edgeId"></param>
    /// <param name="endPosition"></param>
    /// <param name="laneIndex"></param>
    /// <param name="duration">in ms</param>
    /// <param name="flags"></param>
    /// <param name="startPosition"></param>
    /// <param name="until"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setStop"/>
    /// </remarks>
    public bool SetStop(
        string vehicleId,
        string edgeId,
        double endPosition = 1.0,
        byte laneIndex = 0,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_DEFAULT,
        double startPosition = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE
    )
        {
        TraCICompoundObject tmp =
        [
            new TraCIString() { Value = edgeId },
            new TraCIDouble() { Value = endPosition },
            new TraCIByte() { Value = laneIndex },
            new TraCIDouble() { Value = duration },
            new TraCIByte() { Value = (byte)flags },
            new TraCIDouble() { Value = startPosition },
            new TraCIDouble() { Value = until },
        ];

        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_STOP, tmp);
        }

    /// <summary>
    /// Lets the vehicle stop at the given edge, at the given position and lane.<para/>
    /// The vehicle will stop for the given duration. Re-issuing a stop command with the same lane and position allows changing the duration.
    /// Setting the duration to 0 cancels an existing stop.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="stopId"></param>
    /// <param name="duration"></param>
    /// <param name="until"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setBusStop"/>
    /// </remarks>
    public bool SetBusStop(
        string vehicleId,
        string stopId,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_DEFAULT
    )
        {
        return SetStop(vehicleId, stopId, duration: duration, until: until, flags: flags | StopFlag.STOP_BUS_STOP);
        }

    /// <summary>
    /// Lets the vehicle stop at the given edge, at the given position and lane.<para/>
    /// The vehicle will stop for the given duration. Re-issuing a stop command with the same lane and position allows changing the duration.
    /// Setting the duration to 0 cancels an existing stop.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="stopId"></param>
    /// <param name="duration"></param>
    /// <param name="until"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setContainerStop"/>
    /// </remarks>
    public bool SetContainerStop(
        string vehicleId,
        string stopId,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_DEFAULT
    )
        {
        return SetStop(vehicleId, stopId, duration: duration, until: until, flags: flags | StopFlag.STOP_CONTAINER_STOP);
        }

    /// <summary>
    /// Lets the vehicle stop at the given edge, at the given position and lane.<para/>
    /// The vehicle will stop for the given duration. Re-issuing a stop command with the same lane and position allows changing the duration.
    /// Setting the duration to 0 cancels an existing stop.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="stopId"></param>
    /// <param name="duration"></param>
    /// <param name="until"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setChargingStationStop"/>
    /// </remarks>
    public bool SetChargingStationStop(
        string vehicleId,
        string stopId,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_DEFAULT
    )
        {
        return SetStop(vehicleId, stopId, duration: duration, until: until, flags: flags | StopFlag.STOP_CHARGING_STATION);
        }

    /// <summary>
    /// Lets the vehicle stop at the given edge, at the given position and lane.<para/>
    /// The vehicle will stop for the given duration. Re-issuing a stop command with the same lane and position allows changing the duration.
    /// Setting the duration to 0 cancels an existing stop.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="stopId"></param>
    /// <param name="duration"></param>
    /// <param name="until"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setParkingAreaStop"/>
    /// </remarks>
    public bool SetParkingAreaStop(
        string vehicleId,
        string stopId,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_PARKING
    )
        {
        return SetStop(vehicleId, stopId, duration: duration, until: until, flags: flags | StopFlag.STOP_PARKING_AREA);
        }

    /// <summary>
    /// Forces a lane change to the lane with the given index; if successful, the lane will be chosen for the given amount of time (in seconds).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="laneIndex"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-changeLane"/>
    /// </remarks>
    public bool ChangeLane(string vehicleId, int laneIndex, double duration)
        {
        TraCICompoundObject tmp = [new TraCIByte() { Value = (byte)laneIndex }, new TraCIDouble() { Value = duration }];
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_CHANGELANE, tmp);
        }

    /// <summary>
    /// 	Forces a lateral change by the given amount (negative values indicate changing to the right, positive to the left).<para/>
    /// 	This will override any other lane change motivations but conform to safety-constraints as configured by laneChangeMode.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="lateralDistance"></param>
    /// <returns></returns>
    public bool ChangeSublane(string vehicleId, double lateralDistance)
        {
        var tmp = new TraCIDouble() { Value = lateralDistance };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_CHANGESUBLANE, tmp);
        }

    /// <summary>
    /// Changes the speed smoothly to the given value over the given amount of time in seconds (can also be used to increase speed).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-slowDown"/>
    /// </remarks>
    public bool SlowDown(string vehicleId, double speed, double duration)
        {
        TraCICompoundObject tmp = [new TraCIDouble() { Value = speed }, new TraCIDouble() { Value = duration }];
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_SLOWDOWN, tmp);
        }

    /// <summary>
    /// Resumes from a stop
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-resume"/>
    /// </remarks>
    public bool Resume(string vehicleId)
        {
        TraCICompoundObject tmp = [];
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_RESUME, tmp);
        }

    /// <summary>
    /// The vehicle's destination edge is set to the given. The route is rebuilt.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="desitinationEdgeId"></param>
    /// <returns></returns>
    /// <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-changeTarget"/>
    public bool ChangeTarget(string vehicleId, string desitinationEdgeId)
        {
        var tmp = new TraCIString() { Value = desitinationEdgeId };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_CHANGETARGET, tmp);
        }

    /// <summary>
    /// 	Sets the vehicle speed to the given value.<para/>
    /// 	The speed will be followed according to the current <see cref="SpeedMode"/>.
    /// 	By default the vehicle may drive slower than the set speed according to the safety rules of the car-follow model.
    /// 	When sending a value of -1 the vehicle will revert to its original behavior (using the maxSpeed of its vehicle type and following all safety rules).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public bool SetSpeed(string vehicleId, double speed)
        {
        var tmp = new TraCIDouble() { Value = speed };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED, tmp);
        }

    /// <summary>
    /// Changes the acceleration to the given value for the given amount of time in seconds.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="acceleration"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setAcceleration"/>
    /// </remarks>
    public bool SetAcceleration(string vehicleId, double acceleration, double duration)
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIDouble() { Value = acceleration },
            new TraCIDouble() { Value = duration },
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCELERATION, tmp);
        }

    /// <summary>
    /// Retroactively sets the vehicle speed for the previous simulation step to the given value and also updates the previous acceleration.<para/>
    /// This speed value will be used when computing ballistic position updates. <see href="https://sumo.dlr.de/docs/Simulation/Basic_Definition.html#defining_the_integration_method"/>
    /// Also, other vehicles will react to ego in the current step as if it had driven with the given speed in the previous step.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <param name="acceleration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setPreviousSpeed"/>
    /// </remarks>
    public bool SetPreviousSpeed(string vehicleId, double speed, double acceleration = TraCIConstants.INVALID_DOUBLE_VALUE)
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIDouble() { Value = speed },
            new TraCIDouble() { Value = acceleration },
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_PREV_SPEED, tmp);
        }

    /// <summary>
    /// Sets the vehicle's color.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setColor"/>
    /// </remarks>
    public bool SetColor(string vehicleId, int r, int g, int b, int a)
        {
        var color = new Color()
            {
            R = new() { Value = (byte)r },
            G = new() { Value = (byte)g },
            B = new() { Value = (byte)b },
            A = new() { Value = (byte)a },
            };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Assigns the named route to the vehicle, assuming a) the named route exists, and b) it starts on the edge the vehicle is currently at
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="routeId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setRouteID"/>
    /// </remarks>
    public bool SetRoutID(string vehicleId, string routeId)
        {
        var tmp = new TraCIString() { Value = routeId };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE_ID, tmp);
        }

    /// <summary>
    /// Assigns the list of edgeList as the vehicle's new route assuming the first edge given is the one the vehicle is curently at
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="edgeList"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setRoute"/>
    /// </remarks>
    public bool SetRoute(string vehicleId, List<string> edgeList)
        {
        var tmp = new TraCIStringList() { Value = edgeList };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE, tmp);
        }

    /// <summary>
    /// Changes the next parking area in parkingAreaID, updates the vehicle route, and preserve consistency in case of passengers/containers on board
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="parkingAreaId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-rerouteParkingArea"/>
    /// </remarks>
    public bool RerouteParkingArea(string vehicleId, string parkingAreaId)
        {
        // TODO: check if this is correct string or compound object
        var tmp = new TraCICompoundObject { new TraCIString() { Value = parkingAreaId } };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_REROUTE_TO_PARKING, tmp);
        }

    /// <summary>
    /// dispatches the taxi with the given vehicleId to service the given reservations.<para/>
    /// If only a single reservation is given, this implies pickup and drop-off.
    /// If multiple reservations are given, each reservation vehicleId must occur twice (once for pickup and once for drop-off) and the list encodes ride sharing of passengers (in pickup and drop-off order)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="reservations"></param>
    /// <returns></returns>
    public bool DisPatchTaxi(string vehicleId, List<string> reservations)
        {
        var tmp = new TraCIStringList() { Value = reservations };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_TAXI_DISPATCH, tmp);
        }

    /// <summary>
    /// Inserts the information about the travel time (in seconds) of edge "edgeID" valid from begin time to end time (in seconds) into the vehicle's internal edge weights container.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="edgeId"></param>
    /// <param name="time"></param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setAdaptedTraveltime"/>
    /// </remarks>
    public bool SetAdaptedTraveltime(string vehicleId, string edgeId, double? time = null, double? beginTime = null, double? endTime = null)
        {
        TraCICompoundObject tmp = (time, beginTime) switch
        //switch (time, beginTime)
            {
                (null, _) => [new TraCIString() { Value = edgeId }],
                (not null, null) => [new TraCIString() { Value = edgeId }, new TraCIDouble() { Value = time.Value }],
                (not null, not null) =>
                [
                    new TraCIDouble() { Value = beginTime.Value },
                new TraCIDouble() { Value = endTime.Value },
                new TraCIString() { Value = edgeId },
                new TraCIDouble() { Value = time.Value },
            ],
                };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGE_TRAVELTIME, tmp);
        }

    /// <summary>
    /// Inserts the information about the effort of edge "edgeID" valid from begin time to end time (in seconds) into the vehicle's internal edge weights container.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="edgeId"></param>
    /// <param name="effort"></param>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <returns></returns>
    ///
    public bool SetEffort(string vehicleId, string edgeId, double? effort = null, double? beginTime = null, double? endTime = null)
        {
        TraCICompoundObject tmp = (effort, beginTime) switch
            {
                (null, _) => [new TraCIString() { Value = edgeId }],
                (not null, null) => [new TraCIString() { Value = edgeId }, new TraCIDouble() { Value = effort.Value }],
                (not null, not null) =>
                [
                    new TraCIDouble() { Value = beginTime.Value },
                new TraCIDouble() { Value = endTime.Value },
                new TraCIString() { Value = edgeId },
                new TraCIDouble() { Value = effort.Value },
            ],
                };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_EDGE_EFFORT, tmp);
        }

    /// <summary>
    /// Sets a new state of signals. See TraCI/Vehicle Signalling <see href="https://sumo.dlr.de/docs/TraCI/Vehicle_Signalling.html"/> for more information.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="signals"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setSignals"/>
    /// </remarks>
    public bool SetSignals(string vehicleId, VehicleSignalling signals)
        {
        var tmp = new TraCIInteger() { Value = (int)signals };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTE, tmp);
        }

    /// <summary>
    /// Sets the mew routing mode (0: default, 1: aggregated)
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="routingMode"></param>
    /// <returns></returns>
    public bool SetRoutingMode(string vehicleId, RoutingMode routingMode)
        {
        var tmp = new TraCIInteger() { Value = (int)routingMode };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ROUTING_MODE, tmp);
        }

    /// <summary>
    /// 	Moves the vehicle to a new position along the current route
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="laneId"></param>
    /// <param name="position"></param>
    /// <param name="reason"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-moveTo"/>
    /// </remarks>
    public bool MoveTo(string vehicleId, string laneId, double position, MoveReason reason = MoveReason.MoveAutomatic)
        {
        TraCICompoundObject tmp =
        [
            new TraCIString() { Value = laneId },
            new TraCIDouble() { Value = position },
            new TraCIInteger() { Value = (int)reason },
        ];
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MOVE_TO, tmp);
        }

    /// <summary>
    /// Moves the vehicle to a new position after normal vehicle movements have taken place.<para/>
    /// Also forces the angle of the vehicle to the given value (navigational angle in degree).
    /// </summary>
    /// <param name="id"></param>
    /// <param name="edgeId"></param>
    /// <param name="lane"></param>
    /// <param name="xPosition"></param>
    /// <param name="yPosition"></param>
    /// <param name="angle"></param>
    /// <param name="keepRoute"><see href="https://sumo.dlr.de/docs/TraCI/Change_Vehicle_State.html#move_to_xy_0xb4"/></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-moveToXY"/>
    /// </remarks>
    public bool MoveToXY(
        string id,
        string edgeId,
        int lane,
        double xPosition,
        double yPosition,
        double angle = TraCIConstants.INVALID_DOUBLE_VALUE,
        int keepRoute = 1,
        double matchThreshould = 100.0
    )
        {
        TraCICompoundObject tmp =
        [
            new TraCIString() { Value = edgeId },
            new TraCIInteger() { Value = lane },
            new TraCIDouble() { Value = xPosition },
            new TraCIDouble() { Value = yPosition },
            new TraCIDouble() { Value = angle },
            new TraCIByte() { Value = (byte)keepRoute },
            new TraCIDouble() { Value = matchThreshould },
        ];
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.MOVE_TO_XY, tmp);
        }

    /// <summary>
    /// Replaces stop at the given index with a new stop. Automatically modifies the route if the replacement stop is at another location
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="nextStopIndex">If stopIndex is 0 the gap will be between the current edge and the new stop.Otherwise the gap will be between the stop edge for nextStopIndex - 1 and the new stop.</param>
    /// <param name="edgeId">For edgeID a stopping place id may be given if the flag marks this stop as stopping on busStop, parkingArea, containerStop etc.If edgeID is "", the stop at the given index will be removed without replacement and the route will not be modified.</param>
    /// <param name="position"></param>
    /// <param name="laneIndex"></param>
    /// <param name="duration"></param>
    /// <param name="flags"></param>
    /// <param name="startPosition"></param>
    /// <param name="until"></param>
    /// <param name="teleport">if teleport is set to 2, the vehicle will rerouting in the section of the removed stop (i.e. from the previous to the successive stop). If teleport is set to 1, the route to the replacement stop will be disconnected (forcing a teleport).
    /// </param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-replaceStop"/>
    /// </remarks>
    public bool ReplaceStop(
        string vehicleId,
        int nextStopIndex,
        string edgeId,
        double position = 1.0,
        int laneIndex = 0,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_DEFAULT,
        double startPosition = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE,
        int teleport = 0
    )
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIString() { Value = edgeId },
            new TraCIDouble() { Value = position },
            new TraCIInteger() { Value = laneIndex },
            new TraCIDouble() { Value = duration },
            new TraCIInteger() { Value = (int)flags },
            new TraCIDouble() { Value = startPosition },
            new TraCIDouble() { Value = until },
            new TraCIInteger() { Value = nextStopIndex },
            new TraCIByte() { Value = (byte)teleport },
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_REPLACE_STOP, tmp);
        }

    /// <summary>
    /// inserts stop at the given index. Automatically modifies the route to accommodate the new stop
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="nextStopIndex">if nextStopIndex is equal to the number of upcoming stops, the new stop will be added after all other stops</param>
    /// <param name="edgeId">For edgeID a stopping place id may be given if the flag marks this stop as stopping on busStop, parkingArea, containerStop etc.</param>
    /// <param name="position"></param>
    /// <param name="laneIndex"></param>
    /// <param name="duration"></param>
    /// <param name="flags"></param>
    /// <param name="startPosition"></param>
    /// <param name="until"></param>
    /// <param name="teleport">If teleport is set to 1, the route to the new stop will be disconnected (forcing a teleport).
    /// If stopIndex is 0 the gap will be between the current edge and the new stop.
    /// Otherwise the gap will be between the stop edge for nextStopIndex - 1 and the new stop.
    /// It is recommended to also set sumo option --time-to-teleport.disconnected when using this
    /// </param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-insertStop"/>
    /// </remarks>
    public bool InsertStop(
        string vehicleId,
        int nextStopIndex,
        string edgeId,
        double position = 1.0,
        int laneIndex = 0,
        double duration = TraCIConstants.INVALID_DOUBLE_VALUE,
        StopFlag flags = StopFlag.STOP_DEFAULT,
        double startPosition = TraCIConstants.INVALID_DOUBLE_VALUE,
        double until = TraCIConstants.INVALID_DOUBLE_VALUE,
        int teleport = 0
    )
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIString() { Value = edgeId },
            new TraCIDouble() { Value = position },
            new TraCIInteger() { Value = laneIndex },
            new TraCIDouble() { Value = duration },
            new TraCIInteger() { Value = (int)flags },
            new TraCIDouble() { Value = startPosition },
            new TraCIDouble() { Value = until },
            new TraCIInteger() { Value = nextStopIndex },
            new TraCIByte() { Value = (byte)teleport },
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_INSERT_STOP, tmp);
        }

    /// <summary>
    /// modifies attribute of stop at the given index. Changing location ('edge', 'busStop', etc.) behave like replaceRoute. If customParam is set to 1, modifies a user defined param instead
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="nextStopIndex"></param>
    /// <param name="param"></param>
    /// <param name="value"></param>
    /// <param name="customParam"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setStopParameter"/>
    /// </remarks>
    public bool SetStopParameter(string vehicleId, int nextStopIndex, string param, string value, bool customParam = false)
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIInteger() { Value = nextStopIndex },
            new TraCIString() { Value = param },
            new TraCIString() { Value = value },
            new TraCIByte() { Value = customParam ? (byte)1 : (byte)0 },
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_STOP_PARAMETER, tmp);
        }

    /// <summary>
    /// Computes a new route to the current destination that minimizes travel time. The assumed values for each edge in the network can be customized in various ways. See Simulation/Routing#Travel-time_values_for_routing. Replaces the current route by the found
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="currentTravelTimes"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-rerouteTraveltime"/>
    /// </remarks>
    public bool RerouteTravelTime(string vehicleId, bool currentTravelTimes = true)
        {
        var routingMode = GetRoutingMode(vehicleId);
        if (currentTravelTimes && routingMode == (int)RoutingMode.Default)
            {
            SetRoutingMode(vehicleId, RoutingMode.AggregatedCustom);
            }
        TraCICompoundObject tmp = [];
        var result = _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_REROUTE_TRAVELTIME, tmp);
        if (currentTravelTimes && routingMode == (int)RoutingMode.Default)
            {
            SetRoutingMode(vehicleId, (RoutingMode)routingMode);
            }
        return result;
        }

    /// <summary>
    /// Computes a new route using the vehicle's internal and the global edge effort information. Replaces the current route by the found
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-rerouteEffort"/>
    /// </remarks>
    public bool RerouteEffort(string vehicleId)
        {
        TraCICompoundObject tmp = [];
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.CMD_REROUTE_EFFORT, tmp);
        }

    /// <summary>
    /// Sets how the values set by <see cref="SetSpeed"/> and <see cref="SlowDown"/> (0x14) shall be treated. Also allows to configure the behavior at junctions.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speedMode"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setSpeedMode"/>
    /// </remarks>
    public bool SetSpeedMode(string vehicleId, SpeedMode speedMode)
        {
        var tmp = new TraCIInteger() { Value = (int)speedMode };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEEDSETMODE, tmp);
        }

    /// <summary>
    /// Sets the vehicle's speed factor to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="factor"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setSpeedFactor"/>
    /// </remarks>
    public bool SetSpeedFactor(string vehicleId, double factor)
        {
        var tmp = new TraCIDouble() { Value = factor };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR, tmp);
        }

    /// <summary>
    /// Sets the vehicle's maximum speed to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    /// <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setMaxSpeed"/>
    public bool SetMaxSpeed(string vehicleId, double speed)
        {
        var tmp = new TraCIDouble() { Value = speed };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED, tmp);
        }

    /// <summary>
    /// TODO: 简化函数签名
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
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setLaneChangeMode"/>
    /// </remarks>
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
        var tmp = ((int)stragic * 1) + ((int)cooperative * 4) + ((int)speed * 16) + ((int)right * 32) + ((int)respect * 64) + ((int)sublane * 128);
        return _helper.ExecuteSetCommand(
            id,
            TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
            TraCIConstants.VAR_LANECHANGE_MODE,
            new TraCIInteger() { Value = tmp }
        );
        }

    /// <summary>
    /// updates internal data structures for strategic lane choice. (e.g. after modifying access permissions)<para/>
    /// Note: This happens automatically when changing the route or moving to a new edge
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-updateBestLanes"/>
    /// </remarks>
    public bool UpdateBestLanes(string vehicleId)
        {
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_UPDATE_BESTLANES);
        }

    /// <summary>
    /// Adds the defined vehicle.<para/>
    /// Note <para/>
    /// Please note that the values are not checked in a very elaborated way.Make sure they are correct before sending.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="routeId">If an empty routeID is given, the vehicle will be placed on an route that consists of a single arbitrary edge (with suitable vClass permissions). This can be used to simply the initialization of remote controlled vehicle (<see cref="MoveToXY"/>)
    /// if routeID is "", the vehicle will be inserted on a random network edge. This may be useful when intending the vehicle with moveToXY (and now route information is available)
    /// if the route consists of 2 disconnected edges, the vehicle will be treated like a &lt;trip&gt; and use the fastest route between the two edges
    /// </param>
    /// <param name="vehicleTypeId"></param>
    /// <param name="depart"></param>
    /// <param name="departLane"></param>
    /// <param name="departPosition"></param>
    /// <param name="departSpeed"></param>
    /// <param name="arrivalLane"></param>
    /// <param name="arrivalPosition"></param>
    /// <param name="arrivalSpeed"></param>
    /// <param name="fromTaz"></param>
    /// <param name="toTaz"></param>
    /// <param name="line"></param>
    /// <param name="personCapacity"></param>
    /// <param name="personNumber"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-add"/>
    /// </remarks>
    public bool Add(
        string vehicleId,
        string routeId,
        string vehicleTypeId = "DEFAULT_VEHTYPE",
        string depart = "now",
        string departLane = "first",
        string departPosition = "base",
        string departSpeed = "0",
        string arrivalLane = "current",
        string arrivalPosition = "max",
        string arrivalSpeed = "current",
        string fromTaz = "",
        string toTaz = "",
        string line = "",
        int personCapacity = 0,
        int personNumber = 0
    )
        {
        depart = depart is null ? _simulation.GetTime().ToString() : depart;
        var tmp = new TraCICompoundObject()
        {
            new TraCIString() { Value = routeId },
            new TraCIString() { Value = vehicleTypeId },
            new TraCIString() { Value = depart },
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
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.ADD_FULL, tmp);
        }

    /// <summary>
    /// Removes the defined vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="reason"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-remove"/>
    /// </remarks>
    public bool Remove(string vehicleId, RemoveReason reason)
        {
        var tmp = new TraCIByte() { Value = (byte)reason };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.REMOVE, tmp);
        }

    /// <summary>
    /// Sets the vehicle's length to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setLength"/>
    /// </remarks>
    public bool SetLength(string vehicleId, double length)
        {
        var tmp = new TraCIDouble() { Value = length };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH, tmp);
        }

    /// <summary>
    /// Sets the vehicle's vehicle class to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="vehicleClass"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setVehicleClass"/>
    /// </remarks>

    public bool SetVehicleClass(string vehicleId, string vehicleClass)
        {
        var tmp = new TraCIString() { Value = vehicleClass };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS, tmp);
        }

    /// <summary>
    /// 	Sets the vehicle's emission class to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="emissionClass"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setEmissionClass"/>
    /// </remarks>
    public bool SetEmissionClass(string vehicleId, string emissionClass)
        {
        var tmp = new TraCIString() { Value = emissionClass };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS, tmp);
        }

    /// <summary>
    /// 	Sets the vehicle's width to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setWidth"/>
    /// </remarks>
    public bool SetWidth(string vehicleId, double width)
        {
        var tmp = new TraCIDouble() { Value = width };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH, tmp);
        }

    /// <summary>
    /// Sets the vehicle's height to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setHeight"/>
    /// </remarks>
    public bool SetHeight(string vehicleId, double height)
        {
        var tmp = new TraCIDouble() { Value = height };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT, tmp);
        }

    /// <summary>
    /// Sets the vehicle's minimum headway gap to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="minGap"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setMinGap"/>
    /// </remarks>
    public bool SetMinGap(string vehicleId, double minGap)
        {
        var tmp = new TraCIDouble() { Value = minGap };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP, tmp);
        }

    /// <summary>
    /// Sets the vehicle's shape class to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="shapeClass"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setShapeClass"/>
    /// </remarks>
    public bool SetShapeClass(string vehicleId, string shapeClass)
        {
        var tmp = new TraCIString() { Value = shapeClass };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, tmp);
        }

    /// <summary>
    /// Sets the vehicle's wished maximum acceleration to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="acceleration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setAccel"/>
    /// </remarks>
    public bool SetAccel(string vehicleId, double acceleration)
        {
        var tmp = new TraCIDouble() { Value = acceleration };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL, tmp);
        }

    /// <summary>
    /// Sets the vehicle's wished maximum deceleration to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="deceleration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setDecel"/>
    /// </remarks>
    public bool SetDecel(string vehicleId, double deceleration)
        {
        var tmp = new TraCIDouble() { Value = deceleration };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL, tmp);
        }

    /// <summary>
    /// Sets the vehicle's driver imperfection (sigma) to the given value
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="imperfection"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setImperfection"/>
    /// </remarks>
    public bool SetImperfection(string vehicleId, double imperfection)
        {
        var tmp = new TraCIDouble() { Value = imperfection };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, tmp);
        }

    /// <summary>
    /// Sets the vehicle's wished headway time to the given value.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="tau"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setTau"/>
    /// </remarks>
    public bool SetTau(string vehicleId, double tau)
        {
        var tmp = new TraCIDouble() { Value = tau };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU, tmp);
        }

    /// <summary>
    /// Sets the vehicleId of the type for the named vehicle.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setType"/>
    /// </remarks>
    public bool SetType(string vehicleId, string type)
        {
        var tmp = new TraCIString() { Value = type };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, tmp);
        }

    /// <summary>
    /// Changes the via edges to the given edges list (to be used during subsequent rerouting calls).
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="via"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setVia"/>
    /// </remarks>
    public bool SetVia(string vehicleId, List<string> via)
        {
        var tmp = new TraCIStringList() { Value = via };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_VIA, tmp);
        }

    /// <summary>
    /// Sets the maximum lateral speed in m/s for this vehicle.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="maxSpeed"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setMaxSpeedLat"/>
    /// </remarks>
    public bool SetMaxSpeedLat(string vehicleId, double maxSpeed)
        {
        var tmp = new TraCIDouble() { Value = maxSpeed };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, tmp);
        }

    /// <summary>
    /// Sets the minimum lateral gap of the vehicle at 50km/h in m.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="gap"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setMinGapLat"/>
    /// </remarks>
    public bool SetMinGapLat(string vehicleId, double gap)
        {
        var tmp = new TraCIDouble() { Value = gap };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, tmp);
        }

    /// <summary>
    /// Sets the preferred lateral alignment for this vehicle.
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setLateralAlignment"/>
    /// </remarks>
    public bool SetLateralAlignment(string vehicleId, string alignment)
        {
        var tmp = new TraCIString() { Value = alignment };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, tmp);
        }

    /// <summary>
    ///
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setBoardingDuration"/>
    /// </remarks>
    public bool SetBoardingDuration(string vehicleId, double duration)
        {
        var tmp = new TraCIDouble() { Value = duration };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_BOARDING_DURATION, tmp);
        }

    /// <summary>
    ///
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="impatience"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setImpatience"/>
    /// </remarks>
    public bool SetImpatience(string vehicleId, double impatience)
        {
        var tmp = new TraCIDouble() { Value = impatience };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPATIENCE, tmp);
        }

    /// <summary>
    /// Sets the string value for the given string parameter
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-setParameter"/>
    /// </remarks>
    public bool SetParamater(string vehicleId, string key, string value)
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIString() { Value = key },
            new TraCIString() { Value = value },
        };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_PARAMETER, tmp);
        }

    /// <summary>
    /// Sets the current action step length for the vehicle in s. If the boolean value resetActionOffset is true, an action step is scheduled immediately for the vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="actionStepLength">the action step length  (s) to set</param>
    /// <param name="resetActionOffset">an action step is scheduled immediately or not</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setScale"/>
    /// </remarks>
    public bool SetActionStepLength(string vehicleId, double actionStepLength, bool resetActionOffset = true)
        {
        actionStepLength = resetActionOffset ? actionStepLength : actionStepLength * -1;
        var tmp = new TraCIDouble { Value = actionStepLength };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACTIONSTEPLENGTH, tmp);
        }

    /// <summary>
    /// Adds a highlight to the vehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <param name="size"></param>
    /// <param name="alphaMax"></param>
    /// <param name="duration"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicle.html#VehicleDomain-highlight"/>
    /// </remarks>
    public bool Highlight(
        string vehicleId,
        int r = 255,
        int g = 0,
        int b = 0,
        int a = 255,
        double size = -1.0,
        int alphaMax = -1,
        int duration = -1,
        byte type = 0
    )
        {
        if (type > 255)
            throw new ArgumentOutOfRangeException(nameof(type), "vehicle.highlight(): maximal value for type is 255");
        if (alphaMax > 255)
            throw new ArgumentOutOfRangeException(nameof(alphaMax), "vehicle.highlight(): maximal value for alphaMax is 255");
        if (alphaMax < 0 && duration > 0)
            throw new ArgumentOutOfRangeException(nameof(alphaMax), "vehicle.highlight(): duration>0 requires alphaMax>0");
        if (alphaMax > 0 && duration < 0)
            throw new ArgumentOutOfRangeException(nameof(duration), "vehicle.highlight(): alphaMax>0 requires duration>0");

        var color = new Color
            {
            R = new TraCIByte() { Value = (byte)r },
            G = new TraCIByte() { Value = (byte)g },
            B = new TraCIByte() { Value = (byte)b },
            A = new TraCIByte() { Value = (byte)a },
            };
        TraCICompoundObject tmp;
        if (alphaMax > 0)
            {
            tmp =
            [
                color,
                new TraCIDouble() { Value = size },
                new TraCIInteger() { Value = alphaMax },
                new TraCIInteger() { Value = duration },
                new TraCIUByte() { Value = type },
            ];
            }
        else
            {
            tmp =
            [
                color,
                new TraCIDouble() { Value = size },
            ];
            }

        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_HIGHLIGHT, tmp);
        }


    /// <summary>
    /// Sets the mass of the vehicle to the given value
    /// </summary>
    /// <param name="vehicleId">vehicle type ID</param>
    /// <param name="mass">the mass (kg) to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VTypeDomain-setMass"/>
    /// </remarks>
    public bool SetMass(string vehicleId, double mass)
        {
        var tmp = new TraCIDouble { Value = mass };
        return _helper.ExecuteSetCommand(vehicleId, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MASS, tmp);
        }
    }
