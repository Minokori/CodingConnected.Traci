namespace CodingConnected.Traci.Functions;

public partial class VehicleType
    {
    /// <summary>
    /// Returns a list of ids of currently loaded vehicle types (the given vehicle type ID is ignored)
    /// </summary>
    /// <returns>a list of ids of currently loaded vehicle types</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.IdList,
            "ignored"
        );
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// Returns the number of currently loaded vehicle types (the given vehicle type ID is ignored)
    /// </summary>
    /// <returns>the number of currently loaded vehicle types</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getIDCount"/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.IdCount,
            "ignored"
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the length of the vehicles of this type [m]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the length (m) of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getLength"/>
    /// </remarks>
    public double GetLength(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_LENGTH,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the maximum speed of vehicles of this type [m/s]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the maximum speed in m/s of this type.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getMaxSpeed"/>
    /// </remarks>
    public double GetMaxSpeed(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_MAXSPEED,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the maximum acceleration possibility of vehicles of this type [m/s^2]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the maximum acceleration in m/s^2 of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getAccel"/>
    /// </remarks>
    public double GetAccel(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_ACCEL,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the maximum deceleration possibility of vehicles of this type [m/s^2]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the maximal comfortable deceleration in m/s^2 of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getDecel"/>
    /// </remarks>
    public double GetDecel(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_DECEL,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the driver's desired time headway for vehicles of this type [s]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the driver's desired headway in s for this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getTau"/>
    /// </remarks>
    public double GetTau(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_TAU,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the driver's imperfection (dawdling) [0,1]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the driver's imperfection for this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getTau"/>
    /// </remarks>
    public double GetImperfection(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_IMPERFECTION,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the road speed multiplier for drivers of this type [double]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the speed factor of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getSpeedFactor"/>
    /// </remarks>
    public double GetSpeedFactor(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_SPEED_FACTOR,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the deviation of speedFactor for drivers of this type [double]
    /// </summary>
    /// <param name="id"></param>
    /// <returns>he maximum speed deviation of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getSpeedDeviation"/>
    /// </remarks>
    public double GetSpeedDeviation(string id)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_SPEED_DEVIATION,
            id
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the class of vehicles of this type
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the class of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getVehicleClass"/>
    /// </remarks>
    public string GetVehicleClass(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_VEHICLECLASS,
            typeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the emission class of vehicles of this type
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the emission class of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getEmissionClass"/>
    /// </remarks>

    public string GetEmissionClass(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_EMISSIONCLASS,
            typeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the shape of vehicles of this type
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the shape of vehicles of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getShapeClass"/>
    /// </remarks>

    public string GetShapeClass(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_SHAPECLASS,
            typeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the offset (gap to front vehicle if halting) of vehicles of this type [m]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the offset (gap to front vehicle if halting) of vehicles of this type [m]</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getMinGap"/>
    /// </remarks>
    public double GetMinGap(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_MINGAP,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the width of vehicles of this type [m]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the width of vehicles of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getWidth"/>
    /// </remarks>

    public double GetWidth(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_WIDTH,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the height of vehicles of this type [m]
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getHeight"/>
    /// </remarks>
    public double GetHeight(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_HEIGHT,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the color of this type
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the color of this type (r,g,b,a)</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getColor"/>
    /// </remarks>
    public (int r, int g, int b, int a) GetColor(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_COLOR,
            typeId
        );
        return (Color)result.Data;
        }

    /// <summary>
    /// Returns the maximum lateral speed in m/s of this type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the maximum lateral speed in m/s of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getMaxSpeedLat"/>
    /// </remarks>
    public double GetMaxSpeedLat(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_MAXSPEED_LAT,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the desired lateral gap of this type at 50km/h in m.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the desired lateral gap of this type at 50km/h in m</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getMinGapLat"/>
    /// </remarks>
    public double GetMinGapLat(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_MINGAP_LAT,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the preferred lateral alignment of the type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the preferred lateral alignment of the type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getLateralAlignment"/>
    /// </remarks>
    public string GetLateralAlignment(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_LATALIGNMENT,
            typeId
        );
        return (TraciString)result.Data;
        }

    /// <summary>
    /// Returns the action step length for the vehicle type in s.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the action step length for this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getActionStepLength"/>
    /// </remarks>
    public double GetActionStepLength(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_ACTIONSTEPLENGTH,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the total number of persons that can ride in a vehicle of this type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the person capacity of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getPersonCapacity"/>
    /// </remarks>
    public int GetPersonCapacity(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_PERSON_CAPACITY,
            typeId
        );
        return (TraciInteger)result.Data;
        }

    /// <summary>
    /// Returns the traffic scaling factor for vehicles of this type
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the traffic scaling factor of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getScale"/>
    /// </remarks>
    public double GetScale(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_SCALE,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the boarding duration for passengers entering/leaving this vehicle.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the boarding duration of this type</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VTypeDomain-getBoardingDuration"/>
    /// </remarks>
    public double GetBoardingDuration(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_BOARDING_DURATION,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the current base impatience of this vehicle.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the driver's imperfection for this type</returns>
    /// <remarks>
    /// base impatience see <see href="https://sumo.dlr.de/docs/Definition_of_Vehicles%2C_Vehicle_Types%2C_and_Routes.html#impatience"/><para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-getImpatience"/>
    /// </remarks>
    public double GetImpatience(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_IMPATIENCE,
            typeId
        );
        return (TraciDouble)result.Data;
        }

    /// <summary>
    /// Returns the current mass of this vehicle type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <returns>the mass in kg of this type.</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VTypeDomain-getMass"/>
    /// </remarks>
    public double GetMass(string typeId)
        {
        var result = Helper.ExecuteGetCommand(
            GetVariable.VehicleType,
            TraciConstants.VAR_MASS,
            typeId
        );
        return (TraciDouble)result.Data;
        }
    }
