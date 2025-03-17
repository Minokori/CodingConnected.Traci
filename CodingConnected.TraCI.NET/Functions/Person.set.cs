using static CodingConnected.Traci.Constants.CommandIdentifier.Set;
namespace CodingConnected.Traci.Functions;

public partial class Person
    {
    /// <summary>
    /// Inserts a new person to the simulation at the given edge, position and time (in s).<para/>
    /// This function should be followed by: <list type="bullet">
    /// <item><see cref="AppendStage"/></item>
    /// <item> <see cref="AppendWalkingStage"/></item>
    /// <item><see cref="AppendDrivingStage"/></item>
    /// <item><see cref="AppendWaitingStage"/></item>
    /// </list>
    /// or the person will immediately vanish on departure.
    /// </summary>
    /// <param name="personId"> person ID to add</param>
    /// <param name="edgeId">which edge to add </param>
    /// <param name="position">where to add (relative to the length of edge)</param>
    /// <param name="depart">depart time<para/>A depart time value of -3 is interpreted as immediate departure</param>
    /// <param name="typeId">type of person to add</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-add"/>
    /// </remarks>
    public bool Add(string personId, string edgeId, double position, double depart = -3, string typeId = "DEFAULT_PEDTYPE")
        {
        TraciCompoundObject tmp = [new TraciString(typeId), new TraciString(edgeId), new TraciDouble(depart), new TraciDouble(position)];
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.ADD, personId, tmp);
        }

    /// <summary>
    /// Appends a stage (stageObject, waiting, walking or driving)
    /// to the plan of the given person.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="stage">stage to add</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-appendStage"/>
    /// </remarks>
    public bool AppendStage(string personId, Stage stage) =>
        _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.APPEND_STAGE, personId, stage);

    /// <summary>
    /// Appends a driving stage to the plan of the given person.<para/>
    /// The lines parameter should be a space-separated list of line ids
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="toEdge">destination edge</param>
    /// <param name="lines">space-separated list of line ids</param>
    /// <param name="stopId"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-appendDrivingStage"/>
    /// </remarks>
    public bool AppendDrivingStage(string personId, string toEdge, string lines, string stopId = "")
        {
        DrivingStage stage = new(toEdge, lines, stopId);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.APPEND_STAGE, personId, stage);
        }

    /// <summary>
    /// 	Appends a stage waiting to the plan of the given person.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="duration"> waiting duration</param>
    /// <param name="description"></param>
    /// <param name="stopId"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-appendWaitingStage"/>
    /// </remarks>
    public bool AppendWaitingStage(string personId, double duration, string description = "waiting", string stopId = "")
        {
        // TODO: in document, duration is int, but in python document, it is float. we should check it.
        WaitingStage stage = new(duration, description, stopId);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.APPEND_STAGE, personId, stage);
        }

    /// <summary>
    /// Appends a walking stage to the plan of the given person.<para/>
    /// The walking speed can either be specified,
    /// computed from the duration parameter(in s),
    /// or taken from the type of the person
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="edges"></param>
    /// <param name="arrivalPosition"></param>
    /// <param name="duration"></param>
    /// <param name="speed"></param>
    /// <param name="stopId"></param>
    /// <returns></returns>
    public bool AppendWalkingStage(
        string personId,
        List<string> edges,
        double arrivalPosition,
        int duration = -1,
        double speed = 1,
        string stopId = ""
    )
        {
        // duration & speed are optional parameters
        WalkingStage stage = new(edges, arrivalPosition, duration, speed, stopId);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.APPEND_STAGE, personId, stage);
        }

    /// <summary>
    /// Replaces the nth subsequent stage with the given <see cref="Stage"/> object. Such an object is obtainable using <see cref="GetStage"/>
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="stageIndex"></param>
    /// <param name="stage"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public bool ReplaceStage(string personId, int stageIndex, Stage stage)
        {
        var tmp = new TraciCompoundObject { new TraciInteger(stageIndex), stage };
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.REPLACE_STAGE, personId, tmp);
        }

    /// <summary>
    /// Removes the nth next stage. <paramref name="nextStageIndex"/> must be lower then value of <see cref="GetRemainingStages(string)"/>.<para/>
    /// <paramref name="nextStageIndex"/> 0 immediately aborts the current stage and proceeds to the next stage.<para/>
    /// When removing all stages, stage 0 should be removed last
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="nextStageIndex"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-removeStage"/>
    /// </remarks>
    public bool RemoveStage(string personId, int nextStageIndex)
        {
        TraciInteger tmp = new(nextStageIndex);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.REMOVE_STAGE, personId, tmp);
        }

    /// <summary>
    /// Removes all stages of the person.<para/>
    /// If no new phases are appended, the person will be removed from the simulation in the next <see cref="Control.SimStep(double)"/>.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-removeStages"/>
    /// </remarks>
    public bool RemoveStages(string personId)
        {
        var tmp = new TraciInteger(1);
        while (GetRemainingStages(personId) > 1)
            {
            _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.REMOVE_STAGE, personId, tmp);
            }
        tmp = new TraciInteger(0);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.REMOVE_STAGE, personId, tmp);
        }

    /// <summary>
    /// Removes the person from the simulation instantly.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-remove"/>
    /// </remarks>
    public bool Remove(string personId, RemoveReason reason = RemoveReason.VAPORIZED) =>
        _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.REMOVE, personId, new TraciByte((byte)reason));

    /// <summary>
    /// Computes a new route to the current destination that minimizes travel time.<para/>
    /// The assumed values for each edge in the network can be customized in various ways.
    ///  See <see href="https://sumo.dlr.de/docs/Simulation/Routing.html#travel-time_values_for_routing"/>. Replaces the current route by the found route.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-rerouteTraveltime"/>
    /// </remarks>
    public bool RerouteTravelTime(string personId) =>
        _helper.ExecuteSetCommand(PERSON_VARIABLE, CommandIdentifier.REROUTE_TRAVELTIME, personId, new TraciCompoundObject());

    /// <summary>
    /// Moves the person to a new position after normal movements have taken place.<para/>
    /// Also forces the angle of the person to the given value (navigational angle in degree).
    /// See <see href="https://sumo.dlr.de/docs/TraCI/Change_Person_State.html#move_to_xy_0xb4"/> for more information.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="edgeId"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="angle"></param>
    /// <param name="keepRoute"></param>
    /// <param name="matchThreshold"></param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-moveToXY"/>
    /// </remarks>
    public bool MoveToXY(
        string personId,
        string edgeId,
        double x,
        double y,
        double angle = TraciConstants.INVALID_DOUBLE_VALUE,
        int keepRoute = 1,
        double matchThreshold = 100
    )
        {
        // TODO document description doesn't include matchThreshold, but python codes include. we should check it.
        var tmp = new TraciCompoundObject
        {
            new TraciString(edgeId),
            new TraciDouble(x),
            new TraciDouble(y),
            new TraciDouble(angle),
            new TraciByte((byte)keepRoute),
            new TraciDouble(matchThreshold),
        };
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.MOVE_TO_XY, personId, tmp);
        }

    /// <summary>
    /// Sets color for person with the given ID. i.e. (255,0,0,255) for the color red.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="r">red value of the color to set</param>
    /// <param name="g">green value of the color to set</param>
    /// <param name="b">blue value of the color to set</param>
    /// <param name="a">alpha value of the color to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setColor"/>
    /// </remarks>
    public bool SetColor(string personId, int r, int g, int b, int a)
        {
        Color color = new(r, g, b, a);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_COLOR, personId, color);
        }

    /// <summary>
    /// Sets the height in m for the given person.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="height"></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setHeight"/>
    /// </remarks>
    public bool SetHeight(string personId, double height)
        {
        TraciDouble tmp = new(height);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_HEIGHT, personId, tmp);
        }

    /// <summary>
    /// Sets the length in m for the given person.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="length"></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setLength"/>
    /// </remarks>
    public bool SetLength(string personId, double length)
        {
        TraciDouble tmp = new(length);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_LENGTH, personId, tmp);
        }

    /// <summary>
    /// Sets the offset (gap to front person if halting) for this vehicle.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="minGap"></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setMinGap"/>
    /// </remarks>
    public bool SetMinGap(string personId, double minGap)
        {
        TraciDouble tmp = new(minGap);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_MINGAP, personId, tmp);
        }

    /// <summary>
    /// Sets the maximum speed in m/s for the named person for subsequent step.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="speed"></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setSpeed"/>
    /// </remarks>
    public bool SetSpeed(string personId, double speed)
        {
        TraciDouble tmp = new(speed);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_SPEED_FACTOR, personId, tmp);
        }

    /// <summary>
    /// Sets the typeId of the type for the named person.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="typeId"></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setType"/>
    /// </remarks>
    public bool SetType(string personId, string typeId)
        {
        TraciString tmp = new(typeId);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_TYPE, personId, tmp);
        }

    /// <summary>
    /// Sets the width in m for this person.
    /// </summary>
    /// <param name="personId">person ID</param>
    /// <param name="width"></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-setWidth"/>
    /// </remarks>
    public bool SetWidth(string personId, double width)
        {
        TraciDouble tmp = new(width);
        return _helper.ExecuteSetCommand(PERSON_VARIABLE, TraciConstants.VAR_WIDTH, personId, tmp);
        }
    }
