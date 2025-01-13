using CodingConnected.TraCI.NET.DataTypes;

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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TIME);
        return ((TraCIDouble)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_LOADED_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_LOADED_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_DEPARTED_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_DEPARTED_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_ARRIVED_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_ARRIVED_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_NET_BOUNDING_BOX);
        var ploygon = (Polygon)result.Value;
        return new(new(ploygon[0].X.Value, ploygon[0].Y.Value), new(ploygon[1].X.Value, ploygon[1].Y.Value));
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_STARTING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_ENDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_STOP_ENDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_COLLIDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_COLLIDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_STARTING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_STARTING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_ENDING_VEHICLES_NUMBER);
        return ((TraCIInteger)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARKING_ENDING_VEHICLES_IDS);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_BUS_STOP_WAITING, stopId);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Get the ids of waiting persons at the named bus stop.
    /// </summary>
    /// <param name="stopId"></param>
    /// <returns></returns>
    public List<string> GetBusStopWaitingIdList(string stopId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_BUS_STOP_WAITING_IDS, stopId);
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_DELTA_T);
        return ((TraCIDouble)result.Value).Value;
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
        var tmp = new TraCIString { Value = key };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_PARAMETER, objectId, tmp);
        return ((TraCIString)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_SCALE);
        return ((TraCIDouble)result.Value).Value;
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
        var tmp = new TraCIString { Value = option };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_OPTION, null, tmp);
        return ((TraCIString)result.Value).Value;
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
        var positionType = toGeo ? TraCIConstants.POSITION_LON_LAT : TraCIConstants.POSITION_2D;
        var tmp = new TraCICompoundObject()
        {
            new TraCICompoundObject()
            {
                new TraCIString { Value = edgeId },
                new TraCIDouble { Value = position },
                new TraCIUByte { Value = (byte)laneIndex },
            },
            new TraCIUByte { Value = positionType },
        };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.POSITION_CONVERSION, null, tmp);

        switch (toGeo)
            {
            case true:
                    {
                    var position2D = (LonLatPosition)result.Value;
                    return new(position2D.Longitude.Value, position2D.Latitude.Value);
                    }
            case false:
                    {
                    var position2D = (Position2D)result.Value;
                    return new(position2D.X.Value, position2D.Y.Value);
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
        var positionType = toGeo ? TraCIConstants.POSITION_LON_LAT_ALT : TraCIConstants.POSITION_3D;
        var tmp = new TraCICompoundObject()
        {
            new TraCICompoundObject()
            {
                new TraCIString { Value = edgeId },
                new TraCIDouble { Value = position },
                new TraCIUByte { Value = (byte)laneIndex },
            },
            new TraCIUByte { Value = positionType },
        };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.POSITION_CONVERSION, null, tmp);
        switch (toGeo)
            {
            case true:
                    {
                    var position3D = (LonLatAltPosition)result.Value;
                    return new(position3D.Longitude.Value, position3D.Latitude.Value, position3D.Altitude.Value);
                    }
            case false:
                    {
                    var position3D = (Position3D)result.Value;
                    return new(position3D.X.Value, position3D.Y.Value, position3D.Z.Value);
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
        byte positionType;
        ITraciType position;
        switch (fromGeo)
            {
            case true:
                    {
                    positionType = TraCIConstants.POSITION_LON_LAT;
                    position = new LonLatPosition()
                        {
                        Longitude = new TraCIDouble { Value = x },
                        Latitude = new TraCIDouble { Value = y },
                        };
                    break;
                    }
            case false:
                    {
                    positionType = TraCIConstants.POSITION_2D;
                    position = new Position2D()
                        {
                        X = new TraCIDouble { Value = x },
                        Y = new TraCIDouble { Value = y },
                        };
                    break;
                    }
            }

        var tmp = new TraCICompoundObject()
        {
            position,
            new TraCIUByte { Value = positionType },
        };

        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_SET_SIM_VARIABLE, TraCIConstants.POSITION_CONVERSION, null, tmp);

        switch (fromGeo)
            {
            case true:
                    {
                    var position2D = (Position2D)result.Value;
                    return new(position2D.X.Value, position2D.Y.Value);
                    }
            case false:
                    {
                    var position2D = (LonLatPosition)result.Value;
                    return new(position2D.Longitude.Value, position2D.Latitude.Value);
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
        ITraciType position = isGeo
            ? new LonLatPosition()
                {
                Longitude = new TraCIDouble { Value = x },
                Latitude = new TraCIDouble { Value = y },
                }
            : new Position2D()
                {
                X = new TraCIDouble { Value = x },
                Y = new TraCIDouble { Value = y },
                };
        var tmp = new TraCICompoundObject()
        {
            position,
            new TraCIUByte { Value = TraCIConstants.POSITION_ROADMAP },
            new TraCIString { Value = vClass },
        };
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.POSITION_CONVERSION, null, tmp);
        var roadMapPosition = (RoadMapPosition)result.Value;
        return new(roadMapPosition.RoadId.Value, roadMapPosition.LaneId.Value, roadMapPosition.Pos.Value);
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
        var distanceType = isDriving ? TraCIConstants.REQUEST_DRIVINGDIST : TraCIConstants.REQUEST_AIRDIST;
        var roadMapPosition1 = new RoadMapPosition()
            {
            RoadId = new TraCIString { Value = edgeId1 },
            Pos = new TraCIDouble { Value = position1 },
            LaneId = new TraCIByte { Value = 0 },
            };
        var roadMapPosition2 = new RoadMapPosition()
            {
            RoadId = new TraCIString { Value = edgeId2 },
            Pos = new TraCIDouble { Value = position2 },
            LaneId = new TraCIByte { Value = 0 },
            };

        var tmp = new TraCICompoundObject()
        {
            roadMapPosition1,
            roadMapPosition2,
            new TraCIUByte { Value = distanceType },
        };

        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.DISTANCE_REQUEST, null, tmp);

        return ((TraCIDouble)result.Value).Value;
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
        var distanceType = isDriving ? TraCIConstants.REQUEST_DRIVINGDIST : TraCIConstants.REQUEST_AIRDIST;

        ITraciType position1 = isGeo
            ? new LonLatPosition()
                {
                Longitude = new TraCIDouble { Value = x1 },
                Latitude = new TraCIDouble { Value = y1 },
                }
            : new Position2D()
                {
                X = new TraCIDouble { Value = x1 },
                Y = new TraCIDouble { Value = y1 },
                };

        ITraciType position2 = isGeo
            ? new LonLatPosition()
                {
                Longitude = new TraCIDouble { Value = x2 },
                Latitude = new TraCIDouble { Value = y2 },
                }
            : new Position2D()
                {
                X = new TraCIDouble { Value = x2 },
                Y = new TraCIDouble { Value = y2 },
                };

        var tmp = new TraCICompoundObject()
        {
            position1,
            position2,
            new TraCIUByte { Value = distanceType },
        };

        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.DISTANCE_REQUEST, null, tmp);

        return ((TraCIDouble)result.Value).Value;
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
        var tmp = new TraCICompoundObject()
        {
            new TraCIString { Value = fromEdge },
            new TraCIString { Value = toEdge },
            new TraCIString { Value = vType },
            new TraCIDouble { Value = depart },
            new TraCIInteger { Value = routingMode },
        };
        var result = (TraCICompoundObject)_helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.FIND_ROUTE, null, tmp);

        return new(
            ((TraCIString)result[0]).Value,
            ((TraCIString)result[1]).Value,
            ((TraCIStringList)result[2]).Value,
            ((TraCIDouble)result[3]).Value,
            ((TraCIDouble)result[4]).Value
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
        double arrivalPos = TraCIConstants.INVALID_DOUBLE_VALUE,
        double departPosLat = 0.0,
        string pType = "",
        string vType = "",
        string destStop = ""
    )
        {
        var tmp = new TraCICompoundObject()
        {
            new TraCIString { Value = fromEdge },
            new TraCIString { Value = toEdge },
            new TraCIString { Value = modes },
            new TraCIDouble { Value = depart },
            new TraCIInteger { Value = routingMode},
            new TraCIDouble { Value = speed },
            new TraCIDouble { Value = walkFactor },
            new TraCIDouble { Value = departPos },
            new TraCIDouble { Value = arrivalPos },
            new TraCIDouble { Value = departPosLat },
            new TraCIString { Value = pType },
            new TraCIString { Value = vType },
            new TraCIDouble { Value = depart },
            new TraCIString { Value = destStop },
        };
        var result = (TraCICompoundObject)_helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.FIND_INTERMODAL_ROUTE, null, tmp);

        return result.Chunk(5).Select(x => new Tuple<string, string, List<string>, double, double>(
            ((TraCIString)x[0]).Value,
            ((TraCIString)x[1]).Value,
            ((TraCIStringList)x[2]).Value,
            ((TraCIDouble)x[3]).Value,
            ((TraCIDouble)x[4]).Value
        )).ToList();

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

        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_SIM_VARIABLE, TraCIConstants.VAR_COLLISIONS);

        return ((TraCICompoundObject)result.Value)
            .Chunk(9).
            Select(x => (Collision)x.ToList()).ToList();
        }
    }
