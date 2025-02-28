using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.DataTypes;
using static CodingConnected.TraCI.NET.Constants.CommandIdentifier.Get;
namespace CodingConnected.TraCI.NET.Functions;

public partial class Person
    {
    /// <summary>
    /// Returns a list of ids of all persons currently running within the scenario
    /// (the given person ID is ignored)
    /// </summary>
    /// <returns>a list of all objects in the network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return ((TraciStringList)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of persons currently running within the scenario
    /// (the given person ID is ignored)
    /// </summary>
    /// <returns>the number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.ID_COUNT, "ignored");
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns the speed of the named person within the last step [m/s];<para/>
    /// error value: -2^30
    /// </summary>
    /// <param name="personId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public double GetSpeed(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_SPEED, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// /Returns the position(two doubles) of the named person within the last step [m,m];<para/>
    /// error value: [-2^30, -2^30].
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the position of the named person within the last step [m,m]</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getPosition"/>
    /// </remarks>
    public Tuple<double, double> GetPosition(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_POSITION, personId);
        var position = (Position2D)result.Data;
        return new(position.X, position.Y);
        }

    /// <summary>
    /// /Returns the 3D-position(three doubles) of the named vehicle (center of the front bumper) within the last step [m,m,m];<para/>
    /// error value: [-2^30, -2^30, -2^30].
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the position of the named person within the last step [m,m,m]</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getPosition3D"/>
    /// </remarks>
    public Tuple<double, double, double> GetPosition3D(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_POSITION3D, personId);
        var position = (Position3D)result.Data;
        return new(position.X, position.Y, position.Z);
        }

    /// <summary>
    /// Returns the angle of the named person within the last step [°];<para/>
    /// error value: -2^30
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the angle in degrees of the named person within the last step</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getAngle"/>
    /// </remarks>
    public double GetAngle(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_ANGLE, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Retrieves the slope at the current person position in degrees
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the slope at the current position of the person in degrees</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getSlope"/>
    /// </remarks>
    public double GetSlope(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_SLOPE, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the personId of the edge the named person was at within the last step;<para/>
    /// error value: ""
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the id of the edge the named person was at within the last step.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getRoadID"/>
    /// </remarks>
    public string GetRoadID(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_ROAD_ID, personId);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    /// Returns the typeId of the type of the named person
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the id of the type of the named person</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getTypeID"/>
    /// </remarks>
    public string GetTypeID(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_TYPE, personId);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    /// Returns the person's color(RGBA).
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the color of this person</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getColor"/>
    /// </remarks>
    public Tuple<int, int, int, int> GetColor(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_COLOR, personId);
        var color = (Color)result.Data;
        return new(color.R, color.G, color.B, color.A);
        }

    /// <summary>
    /// The position of the person along the edge (in [m]);<para/>
    /// error value: -2^30
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the position of the person along the lane measured in m</returns>
    /// <remarks>
    /// see <see cref="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getLanePosition"/>
    /// </remarks>
    public double GetLanePosition(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_LANEPOSITION, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the length of the persons [m]
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the length in m of this person</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getLength"/>
    /// </remarks>
    public double GetLength(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_LENGTH, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the offset (gap to front person if halting) of this person [m]
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the offset (gap to front vehicle if halting) of this person</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getMinGap"/>
    /// </remarks>
    public double GetMinGap(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_MINGAP, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the width of this person [m]
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the width in m of this person</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getWidth"/>
    /// </remarks>
    public double GetWidth(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_WIDTH, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the waiting time [s]<para/>
    /// The waiting time of a person is defined as the time (in seconds) spent with a speed below 0.1m/s since the last time it was faster than 0.1m/s.
    ///(basically, the waiting time of a person is reset to 0 every time it moves).
    /// </summary>
    /// <param name="personId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getWaitingTime"/>
    /// </remarks>
    public double GetWaitingTime(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_WAITING_TIME, personId);
        return ((TraciDouble)result.Data).Value;
        }

    /// <summary>
    /// Returns the next edge on the persons route while it is walking.<para/>
    /// If there is no further edge or the person is in another stage, returns the empty string.
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>If the person is walking, returns the next edge on the persons route(including crossing and walkingareas).
    /// If there is no further edge or the person is in another stage, returns the empty string.
    /// </returns>
    /// <param name="personId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getNextEdge"/>
    /// </remarks>
    public string GetNextEdge(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_NEXT_EDGE, personId);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    /// Returns the number of remaining stages for the given person including the current stage.
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the number of remaining stages (at least 1)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getStage"/>
    /// </remarks>
    public int GetRemainingStages(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_STAGES_REMAINING, personId);
        return ((TraciInteger)result.Data).Value;
        }

    /// <summary>
    /// Returns the personId of the vehicle if the person is in stage driving and has entered a vehicle.
    /// </summary>
    /// <param name="personId"></param>
    /// <returns>the id of the current vehicle if the person is in stage driving and has entered a vehicle. Return the empty string otherwise
    /// </returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getVehicle"/>
    /// </remarks>
    public string GetVehicle(string personId)
        {
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_VEHICLE, personId);
        return ((TraciString)result.Data).Value;
        }

    /// <summary>
    ///
    /// </summary>
    /// <param name="personId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._person.html#PersonDomain-getTaxiReservations"/>
    /// </remarks>
    public List<TaxiReservations> GetTaxiReservations(int onlyNew = 0)
        {
        // TODO documents has a poor describe of this method. we should check it.
        TraciInteger tmp = new(onlyNew);
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_TAXI_RESERVATIONS, "", tmp);
        var reservations = ((TraciCompoundObject)result.Data).Chunk(8).Select(i => (TaxiReservations)i.ToList()).ToList();
        return reservations;
        }

    /// <summary>
    /// Returns the a compound object that describes nth next stage.<para/>
    /// Index 0 retrieves the value for the current stage. The given index must be lower than the value of <see cref="GetRemainingStages"/>
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="nextStageIndex"></param>
    /// <returns>
    /// Returns the nth stage object <para/>
    /// Attribute type of this object has the following meaning:<para/>
    ///    0 for not-yet-departed<para/>
    ///    1 for waiting<para/>
    ///    2 for walking<para/>
    ///    3 for driving<para/>
    ///    4 for access to busStop or trainStop<para/>
    ///    5 for personTrip<para/>
    ///<paramref name="nextStageIndex"/> 0 retrieves value for the current stage.
    ///nextStageIndex must be lower then value of <see cref="GetRemainingStages"/>
    /// </returns>
    public Stage GetStage(string personId, int nextStageIndex = 0)
        {
        TraciInteger tmp = new(nextStageIndex);
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_STAGE, personId, tmp);
        return (Stage)(TraciCompoundObject)result.Data;
        }

    /// <summary>
    /// Returns the edges of the nth next stage.<para/>
    /// Index 0 retrieves the value for the current stage.
    /// The given index must be lower than the value of <see cref="GetRemainingStages"/>.
    /// For driving stages only origin and destination edge are returned.
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="nextStageIndex"></param>
    /// <returns>
    /// Returns a list of all edges in the nth next stage.<para/>
    /// For waiting stages this is a single edge<para/>
    /// For walking stages this is the complete route<para/>
    /// For driving stages this is [origin, destination]<para/>
    /// <paramref name="nextStageIndex"/> 0 retrieves value for the current stage.
    /// <paramref name="nextStageIndex"/> must be lower then value of <see cref="GetRemainingStages"/>
    /// </returns>
    public List<string> GetEdges(string personId, int nextStageIndex = 0)
        {
        TraciInteger tmp = new(nextStageIndex);
        var result = _helper.ExecuteGetCommand(PERSON_VARIABLE, TraciConstants.VAR_EDGES, personId, tmp);
        return ((TraciStringList)result.Data).Value;
        }
    }
