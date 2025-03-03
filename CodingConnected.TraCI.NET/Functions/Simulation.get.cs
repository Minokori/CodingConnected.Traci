using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier.Get;
using static CodingConnected.TraCI.NET.Constants.TraciConstants;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Simulation
    {
    /// <summary>
    /// Returns the current simulation time (in s)
    /// </summary>
    /// <returns>the current simulation time in s</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getTime"/>
    /// </remarks>
    public double GetTime()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_TIME, "ignored");
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which were loaded in this time step.
    /// </summary>
    /// <returns>the number of vehicles which were loaded in this time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getLoadedNumber"/>
    /// </remarks>
    public int GetLoadedNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_LOADED_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns a list of ids of vehicles which were loaded in this time step
    /// </summary>
    /// <returns>a list of ids of vehicles which were loaded in this time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getLoadedIDList"/>
    /// </remarks>
    public List<string> GetLoadedIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_LOADED_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which departed (were inserted into the road network) in this time step
    /// </summary>
    /// <returns>the number of vehicles which departed (were inserted into the road network) in this time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getDepartedNumber"/>
    /// </remarks>
    public int GetDepartedNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_DEPARTED_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns a list of ids of vehicles which departed (were inserted into the road network) in this time step
    /// </summary>
    /// <returns>a list of ids of vehicles which departed (were inserted into the road network) in this time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getDepartedIDList"/>
    /// </remarks>
    public List<string> GetDepartedIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_DEPARTED_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which started to teleport in this time step
    /// </summary>
    /// <returns>the number of vehicles which started to teleport in this time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getStartingTeleportNumber"/>
    /// </remarks>

    public int GetStartingTeleportNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_TELEPORT_STARTING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which started to teleport in this time step
    /// </summary>
    /// <returns>the number of vehicles which started to teleport in this time step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getStartingTeleportNumber"/>
    /// </remarks>
    public List<string> GetStartingTeleportIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_TELEPORT_STARTING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which ended to be teleported in this time step.
    /// </summary>
    /// <returns>the number of vehicles which ended to be teleported in this time step.</returns>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getEndingTeleportNumber"/>
    /// </remarks>
    public int GetEndingTeleportNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_TELEPORT_ENDING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns a list of ids of vehicles which ended to be teleported in this time step.
    /// </summary>
    /// <returns>a list of ids of vehicles which ended to be teleported in this time step.</returns>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getEndingTeleportIDList"/>
    /// </remarks>
    public List<string> GetEndingTeleportIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_TELEPORT_ENDING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of vehicles which arrived
    /// (have reached their destination and are removed from the road network) in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getArrivedNumber"/>
    /// </remarks>
    public int GetArrivedNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_ARRIVED_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    ///Returns a list of ids of vehicles which arrived
    ///(have reached their destination and are removed from the road network) in this time step
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getArrivedIDList"/>
    /// </remarks>
    public List<string> GetArrivedIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_ARRIVED_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// The lower left and the upper right corner of the bounding box of the simulation network.
    /// </summary>
    /// <returns>The boundary box of the simulation network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getNetBoundary"/>
    /// </remarks>
    public Tuple<Tuple<double, double>, Tuple<double, double>> GetNetBoundary()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_NET_BOUNDING_BOX);
        var ploygon = (DataTypes.Polygon)result.Data;
        return new(new(ploygon[0].X, ploygon[0].Y), new(ploygon[1].X, ploygon[1].Y));
        }

    /// <summary>
    /// The number of vehicles which are in the net plus the ones still waiting to start.<para/>
    /// This number may be smaller than the actual number of vehicles still to come because of delayed route file parsing.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getMinExpectedNumber"/>
    /// </remarks>
    public int GetMinExpectedNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_MIN_EXPECTED_VEHICLES);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// The number of vehicles that halted on a scheduled stop in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getStopStartingVehiclesNumber"/>
    /// </remarks>
    public int GetStopStartingVehiclesNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_STOP_STARTING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// A list of ids of vehicles that halted on a scheduled stop in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getStopStartingVehiclesIDList"/>
    /// </remarks>

    public List<string> GetStopStartingVehiclesIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_STOP_STARTING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// The number of vehicles that begin to continue their journey, leaving a scheduled stop in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getStopEndingVehiclesNumber"/>
    /// </remarks>
    public int GetStopEndingVehiclesNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_STOP_ENDING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// A list of ids of vehicles that begin to continue their journey, leaving a scheduled stop in this time step
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getStopEndingVehiclesIDList"/>
    /// </remarks>

    public List<string> GetStopEndingVehiclesIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_STOP_ENDING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// The number of vehicles that were involved in a collision in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getCollidingVehiclesNumber"/>
    /// </remarks>
    public int GetCollidingVehiclesNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_COLLIDING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// A list of ids of vehicles that were involved in a collision in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getCollidingVehiclesIDList"/>
    /// </remarks>
    public List<string> GetCollidingVehiclesIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_COLLIDING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// The number of vehicles that enter a parking position in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getParkingStartingVehiclesNumber"/>
    /// </remarks>
    public int GetParkingStartingVehiclesNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_PARKING_STARTING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// 	A list of ids of vehicles that enter a parking position in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getParkingStartingVehiclesIDList"/>
    /// </remarks>
    public List<string> GetParkingStartingVehiclesIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_PARKING_STARTING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// The number of vehicles that begin to continue their journey, leaving a scheduled parking in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getParkingEndingVehiclesNumber"/>
    /// </remarks>
    public int GetParkingEndingVehiclesNumber()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_PARKING_ENDING_VEHICLES_NUMBER);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// A list of ids of vehicles that begin to continue their journey, leaving a scheduled parking in this time step.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getParkingEndingVehiclesIDList"/>
    /// </remarks>
    public List<string> GetParkingEndingVehiclesIDList()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_PARKING_ENDING_VEHICLES_IDS);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Get the total number of waiting persons at the named bus stop
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getBusStopWaiting"/>
    /// </remarks>
    public int GetBusStopWaiting(string stopId)
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_BUS_STOP_WAITING, stopId);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Get the ids of waiting persons at the named bus stop.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    public List<string> GetBusStopWaitingIdList(string stopId)
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_BUS_STOP_WAITING_IDS, stopId);
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the length of one simulation step in seconds.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getDeltaT"/>
    /// </remarks>
    public double GetDeltaT()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_DELTA_T);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the value for the given string parameter.
    /// </summary>
    /// <param name="objectId"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getParameter"/>
    /// </remarks>
    public string GetParameter(string objectId, string key)
        {
        TraciString tmp = new(key);
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_PARAMETER, objectId, tmp);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    /// Returns the traffic scaling factor.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getScale"/>
    /// </remarks>
    public double GetScale()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_SCALE);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the value of one of the global SUMO options.
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getOption"/>
    /// </remarks>
    public string GetOption(string option)
        {
        TraciString tmp = new(option);
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_OPTION, extendParameter: tmp);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    /// convert road,laneIndex,offset to x,y or lon,lat
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="position"></param>
    /// <param name="laneIndex"></param>
    /// <param name="toGeo"></param>
    /// <returns>(x, y) or (lon, lat)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-convert2D"/>
    /// </remarks>
    public Tuple<double, double> Convert2D(string edgeId, double position, int laneIndex = 0, bool toGeo = false)
        {
        var positionType = toGeo ? DataType.LON_LAT : DataType.X_Y;
        var tmp = new TraciCompoundObject()
        {
            new TraciCompoundObject() { new TraciString(edgeId), new TraciDouble(position), new TraciUnsignedByte((byte)laneIndex) },
            new TraciUnsignedByte(positionType.ToByte()),
        };
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.POSITION_CONVERSION, extendParameter: tmp);

        switch (toGeo)
            {
            case true:
                    {
                    var position2D = (LonLatPosition)result.Data;
                    return new(position2D.Longitude, position2D.Latitude);
                    }
            case false:
                    {
                    var position2D = (Position2D)result.Data;
                    return new(position2D.X, position2D.Y);
                    }
            }
        }

    /// <summary>
    /// convert road,laneIndex,offset to x,y,z or lon,lat, alt
    /// </summary>
    /// <param name="edgeId"></param>
    /// <param name="position"></param>
    /// <param name="laneIndex"></param>
    /// <param name="toGeo"></param>
    /// <returns>(x, y, z) or (lon, lat, alt)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-convert3D"/>
    /// </remarks>

    public Tuple<double, double, double> Convert3D(string edgeId, double position, int laneIndex = 0, bool toGeo = false)
        {
        var positionType = toGeo ? DataType.LON_LAT_ALT : DataType.X_Y_Z;
        var tmp = new TraciCompoundObject()
        {
            new TraciCompoundObject() { new TraciString(edgeId), new TraciDouble(position), new TraciUnsignedByte((byte)laneIndex) },
            new TraciUnsignedByte(positionType.ToByte()),
        };
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.POSITION_CONVERSION, extendParameter: tmp);
        switch (toGeo)
            {
            case true:
                    {
                    var position3D = (LonLatAltPosition)result.Data;
                    return new(position3D.Longitude, position3D.Latitude, position3D.Altitude);
                    }
            case false:
                    {
                    var position3D = (Position3D)result.Data;
                    return new(position3D.X, position3D.Y, position3D.Z);
                    }
            }
        }

    /// <summary>
    /// convert (x,y) to (lon,lat) or vice versa
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="fromGeo"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-convertGeo"/>
    /// </remarks>

    public Tuple<double, double> ConvertGeo(double x, double y, bool fromGeo = false)
        {
        DataType positionType;
        ITraciType position;
        switch (fromGeo)
            {
            case true:
                    {
                    positionType = DataType.LON_LAT;
                    position = new LonLatPosition(x, y);
                    break;
                    }
            case false:
                    {
                    positionType = DataType.X_Y;
                    position = new Position2D(x, y);
                    break;
                    }
            }

        TraciCompoundObject tmp = [position, new TraciUnsignedByte(positionType.ToByte())];

        var result = _helper.ExecuteGetCommand(CommandIdentifier.Set.SIM_VARIABLE, TraciConstants.POSITION_CONVERSION, extendParameter: tmp);

        switch (fromGeo)
            {
            case true:
                    {
                    var position2D = (Position2D)result.Data;
                    return new(position2D.X, position2D.Y);
                    }
            case false:
                    {
                    var position2D = (LonLatPosition)result.Data;
                    return new(position2D.Longitude, position2D.Latitude);
                    }
            }
        }

    /// <summary>
    /// convert (x,y) or (lon,lat) to (road,laneInex,offset)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="isGeo"></param>
    /// <param name="vClass"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-convert3D"/>
    /// </remarks>
    public Tuple<string, int, double> ConvertRoad(double x, double y, bool isGeo = false, string vClass = "ignoring")
        {
        ITraciType position = isGeo ? new LonLatPosition(x, y) : new Position2D(x, y);
        TraciCompoundObject tmp = [position, new TraciUnsignedByte(DataType.ROADMAP.ToByte()), new TraciString(vClass)];
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, POSITION_CONVERSION, extendParameter: tmp);
        var roadMapPosition = (RoadMapPosition)result.Data;
        return new(roadMapPosition.RoadId, roadMapPosition.LaneId, roadMapPosition.Position);
        }

    /// <summary>
    /// Reads two positions and an indicator whether the air or the driving distance shall be computed. Returns the according distance.
    /// </summary>
    /// <param name="edgeId1"></param>
    /// <param name="position1"></param>
    /// <param name="edgeId2"></param>
    /// <param name="position2"></param>
    /// <param name="isDriving"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getDistanceRoad"/>
    /// </remarks>
    public double GetDistanceRoad(string edgeId1, double position1, string edgeId2, double position2, bool isDriving = false)
        {
        var distanceType = isDriving ? DistanceType.DRIVINGDIST : DistanceType.AIRDIST;
        RoadMapPosition roadMapPosition1 = new(edgeId1, position1, 0);
        RoadMapPosition roadMapPosition2 = new(edgeId2, position2, 0);

        var tmp = new TraciCompoundObject() { roadMapPosition1, roadMapPosition2, new TraciUnsignedByte((byte)distanceType) };

        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.DISTANCE_REQUEST, extendParameter: tmp);

        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    ///
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="y1"></param>
    /// <param name="x2"></param>
    /// <param name="y2"></param>
    /// <param name="isGeo"></param>
    /// <param name="isDriving"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getDistanceR2D"/>
    /// </remarks>

    public double GetDistance2D(double x1, double y1, double x2, double y2, bool isGeo = false, bool isDriving = false)
        {
        var distanceType = isDriving ? DistanceType.DRIVINGDIST : DistanceType.AIRDIST;

        ITraciType position1 = isGeo ? new LonLatPosition(x1, y1) : new Position2D(x1, y1);

        ITraciType position2 = isGeo ? new LonLatPosition(x2, y2) : new Position2D(x2, y2);

        var tmp = new TraciCompoundObject() { position1, position2, new TraciUnsignedByte((byte)distanceType) };

        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.DISTANCE_REQUEST, extendParameter: tmp);

        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Reads origin and destination edge together with some vehicle parameters and computes the currently fastest driving route for the vehicle
    /// </summary>
    /// <param name="fromEdge"></param>
    /// <param name="toEdge"></param>
    /// <param name="vType"></param>
    /// <param name="depart">When the depart time is not set, the travel times at the current time</param>
    /// <param name="routingMode">may be ROUTING_MODE_DEFAULT (loaded or
    /// deault speeds) and ROUTING_MODE_AGGREGATED(averaged historical speeds)</param>
    /// <returns>(stageType, line, destStop, edges, travelTime, cost)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-findRoute"/>
    /// </remarks>
    public Tuple<string, string, List<string>, double, double> FindRoute(
        string fromEdge,
        string toEdge,
        string vType = "",
        double depart = -1,
        int routingMode = 0
    )
        {
        var tmp = new TraciCompoundObject()
        {
            new TraciString(fromEdge),
            new TraciString(toEdge),
            new TraciString(vType),
            new TraciDouble(depart),
            new TraciInteger(routingMode),
        };
        var result = (TraciCompoundObject)_helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.FIND_ROUTE, extendParameter: tmp);

        return new(
            ((TraciString)result[0]).Value,
            ((TraciString)result[1]).Value,
            ((TraciStringList)result[2]).Value,
            ((TraciDouble)result[3]).Value,
            ((TraciDouble)result[4]).Value
        );
        }

    /// <summary>
    /// Reads origin and destination position together with usable modes and other person parameters and computes the currently fastest route for the person using the available modes.
    /// </summary>
    /// <param name="fromEdge"></param>
    /// <param name="toEdge"></param>
    /// <param name="modes"></param>
    /// <param name="depart">When the depart time is not set, the travel times at the current time will be used.</param>
    /// <param name="routingMode">The routing mode may be ROUTING_MODE_DEFAULT (loaded or
    /// default speeds) and ROUTING_MODE_AGGREGATED(averaged historical speeds)
    /// <param>
    /// <param name="speed"></param>
    /// <param name="walkFactor">a multiplier for the walking speed to account for delays due to intersections and other traffic when
    /// determining the feasibility of using a particular public transport vehicle</param>
    /// <param name="departPos"></param>
    /// <param name="arrivalPos"></param>
    /// <param name="departPosLat"></param>
    /// <param name="pType">the pedestrian type (for walking speed) and defaults to DEFAULT_PEDTYPE</param>
    /// <param name="vType">an optional vehicle type to use for private car routing</param>
    /// <param name="destStop"> an alternative to 'toEdge' to define the edge
    /// and position of the specified public transport stop as the destination</param>
    /// <returns>list of (stageType, line, destStop, edges, travelTime, cost)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-findIntermodalRoute"/>
    /// </remarks>

    public List<Tuple<string, string, List<string>, double, double>> FindIntermodalRoute(
        string fromEdge,
        string toEdge,
        string modes = "",
        double depart = -1.0,
        int routingMode = 0,
        double speed = -1.0,
        double walkFactor = -1.0,
        double departPos = 0.0,
        double arrivalPos = TraciConstants.INVALID_DOUBLE_VALUE,
        double departPosLat = 0.0,
        string pType = "",
        string vType = "",
        string destStop = ""
    )
        {
        var tmp = new TraciCompoundObject()
        {
            new TraciString(fromEdge),
            new TraciString(toEdge),
            new TraciString(modes),
            new TraciDouble(depart),
            new TraciInteger(routingMode),
            new TraciDouble(speed),
            new TraciDouble(walkFactor),
            new TraciDouble(departPos),
            new TraciDouble(arrivalPos),
            new TraciDouble(departPosLat),
            new TraciString(pType),
            new TraciString(vType),
            new TraciDouble(depart),
            new TraciString(destStop),
        };
        var result = (TraciCompoundObject)
            _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.FIND_INTERMODAL_ROUTE, extendParameter: tmp);

        return [.. result
            .Chunk(5)
            .Select(x => new Tuple<string, string, List<string>, double, double>(
                ((TraciString)x[0]).Value,
                ((TraciString)x[1]).Value,
                ((TraciStringList)x[2]).Value,
                ((TraciDouble)x[3]).Value,
                ((TraciDouble)x[4]).Value
            ))];
        }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._simulation.html#SimulationDomain-getCollisions"/>
    /// </remarks>
    public List<Collision> GetCollisions()
        {
        var result = _helper.ExecuteGetCommand(SIM_VARIABLE, TraciConstants.VAR_COLLISIONS);

        return [.. ((TraciCompoundObject)result.Data).Chunk(9).Select(x => (Collision)x.ToList())];
        }
    }
