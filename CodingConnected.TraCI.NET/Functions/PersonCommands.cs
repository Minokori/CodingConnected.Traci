using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public class PersonCommands(ITCPConnectService tcpService, ICommandService helper) : TraCICommandsBase(tcpService, helper)
    {
    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all persons currently running within the scenario (the given person ID is ignored)
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the number of persons currently running within the scenario (the given person ID is ignored)
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the speed of the named person within the last step [m/s]; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_SPEED, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// /	Returns the position(two doubles) of the named person within the last step [m,m]; error value: [-2^30, -2^30].
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position2D GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_POSITION, id);
        return (Position2D)result.Value;
        }

    /// <summary>
    /// /Returns the 3D-position(three doubles) of the named vehicle (center of the front bumper) within the last step [m,m,m]; error value: [-2^30, -2^30, -2^30].
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position3D GetPosition3D(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_POSITION3D, id);
        return (Position3D)result.Value;
        }

    /// <summary>
    /// Returns the angle of the named person within the last step [°]; error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAngle(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_ANGLE, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the id of the edge the named person was at within the last step; error value: ""
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetRoadID(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_ROAD_ID, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the id of the type of the named person
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetTypeID(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_TYPE, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// 	Returns the person's color.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Color GetColor(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_COLOR, id);
        return (Color)result.Value;
        }

    /// <summary>
    /// The position of the person along the edge (in [m]); error value: -2^30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLanePosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_LANEPOSITION, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the persons [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLength(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_LENGTH, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the offset (gap to front person if halting) of this person [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMinGap(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_MINGAP, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the width of this person [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWidth(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_WIDTH, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the waiting time [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWaitingTime(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_WAITING_TIME, id);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the next edge on the persons route while it is walking. If there is no further edge or the person is in another stage, returns the empty string.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetNextEdge(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_NEXT_EDGE, id);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of remaining stages for the given person including the current stage.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int GetRemainingStages(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_STAGES_REMAINING, id);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the id of the vehicle if the person is in stage driving and has entered a vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetVehicle(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_PERSON_VARIABLE, TraCIConstants.VAR_VEHICLE, id);
        return ((TraCIString)result.Value).Value;
        }

    // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Person_Value_Retrieval

    /// <summary>
    /// 	Inserts a new person to the simulation at the given edge, position and time (in s). This function should be followed by appending Stages or the person will immediately vanish on departure.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="typeId"></param>
    /// <param name="initialEdgeId"></param>
    /// <param name="departTime"></param>
    /// <param name="departPosition"></param>
    /// <returns></returns>
    public bool Add(string id, string typeId, string initialEdgeId, double departTime, double departPosition)
        {
        var tmp = new TraCICompoundObject
        {
            new TraCIString() { Value = typeId },
            new TraCIString() { Value = initialEdgeId },
            new TraCIDouble() { Value = departTime },
            new TraCIDouble() { Value = departPosition },
        };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.ADD, tmp);
        }

    /// <summary>
    /// Appends a stage driving to the plan of the given person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="destination"></param>
    /// <param name="lines"></param>
    /// <param name="stopId"></param>
    /// <returns></returns>
    public bool AppendDrivingStage(string id, string destination, string lines, string stopId)
        {
        var tmp = new TraCICompoundObject
        {
            new TraCIInteger() { Value = 3 },
            new TraCIString() { Value = destination },
            new TraCIString() { Value = lines },
            new TraCIString() { Value = stopId },
        };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.APPEND_STAGE, tmp);
        }

    /// <summary>
    /// 	Appends a stage waiting to the plan of the given person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="duration"></param>
    /// <param name="description"></param>
    /// <param name="stopId"></param>
    /// <returns></returns>
    public bool AppendWaitingStage(string id, int duration, string description, string stopId)
        {
        var tmp = new TraCICompoundObject
        {
            new TraCIInteger() { Value = 1 },
            new TraCIInteger() { Value = duration },
            new TraCIString() { Value = description },
            new TraCIString() { Value = stopId },
        };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.APPEND_STAGE, tmp);
        }

    /// <summary>
    /// 	Appends a stage walking to the plan of the given person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="edges"></param>
    /// <param name="arrivalPosition"></param>
    /// <param name="duration"></param>
    /// <param name="speed"></param>
    /// <param name="stopId"></param>
    /// <returns></returns>
    public bool AppendWalkingStage(string id, List<string> edges, double arrivalPosition, int duration, double speed, string stopId)
        {
        var tmp = new TraCICompoundObject
        {
            new TraCIInteger() { Value = 2 },
            new TraCIStringList() { Value = edges },
            new TraCIDouble() { Value = arrivalPosition },
            new TraCIString() { Value = stopId },
        };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.APPEND_STAGE, tmp);
        }

    /// <summary>
    /// Removes the nth next stage. nextStageIndex must be lower then value of getRemainingStages(personID). nextStageIndex 0 immediately aborts the current stage and proceeds to the next stage. When removing all stages, stage 0 should be removed last
    /// </summary>
    /// <param name="id"></param>
    /// <param name="stageIndex"></param>
    /// <returns></returns>
    public bool RemoveStage(string id, int stageIndex)
        {
        var tmp = new TraCIInteger() { Value = stageIndex };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.ADD, tmp);
        }

    /// <summary>
    /// Computes a new route to the current destination that minimizes travel time. The assumed values for each edge in the network can be customized in various ways.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool RerouteTraveltime(string id)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.CMD_REROUTE_TRAVELTIME);
        }

    /// <summary>
    /// Sets color for person with the given ID. i.e. (255,0,0,255) for the color red.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public bool SetColor(string id, Color color)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the height in m for this person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public bool SetHeight(string id, double height)
        {
        var tmp = new TraCIDouble() { Value = height };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.VAR_HEIGHT, tmp);
        }

    /// <summary>
    /// Sets the length in m for the given person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public bool SetLength(string id, double length)
        {
        var tmp = new TraCIDouble() { Value = length };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.ADD, tmp);
        }

    /// <summary>
    /// Sets the offset (gap to front person if halting) for this vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="minGap"></param>
    /// <returns></returns>
    public bool SetMinGap(string id, double minGap)
        {
        var tmp = new TraCIDouble() { Value = minGap };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.VAR_MINGAP, tmp);
        }

    /// <summary>
    /// Sets the maximum speed in m/s for the named person for subsequent step.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public bool SetSpeed(string id, double speed)
        {
        var tmp = new TraCIDouble() { Value = speed };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR, tmp);
        }

    /// <summary>
    /// Sets the id of the type for the named person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="typeId"></param>
    /// <returns></returns>
    public bool SetType(string id, string typeId)
        {
        var tmp = new TraCIString() { Value = typeId };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.VAR_TYPE, tmp);
        }

    /// <summary>
    /// Sets the width in m for this person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public bool SetWidth(string id, double width)
        {
        var tmp = new TraCIDouble() { Value = width };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_PERSON_VARIABLE, TraCIConstants.VAR_WIDTH, tmp);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_PERSON_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
