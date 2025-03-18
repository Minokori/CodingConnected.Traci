namespace CodingConnected.Traci.Functions;

public partial class VehicleType
    {
    /// <summary>
    /// Sets the vehicle type's length to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="length">length to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setLength"/>
    /// </remarks>
    public bool SetLength(string typeId, double length)
        {
        TraciDouble tmp = new(length);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_LENGTH,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's maximum speed to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="speed">max speed (m/s)</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setMaxSpeed"/>
    /// </remarks>
    public bool SetMaxSpeed(string typeId, double speed)
        {
        TraciDouble tmp = new(speed);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_MAXSPEED,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's vehicle class to the given value
    /// </summary>
    /// <param name="typeId">vehile type ID</param>
    /// <param name="vehicleClass">class to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setVehicleClass"/>
    /// </remarks>
    public bool SetVehicleClass(string typeId, string vehicleClass)
        {
        TraciString tmp = new(vehicleClass);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_VEHICLECLASS,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's speed factor to the given value.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="speedFactor">speed factor to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setSpeedFactor"/>
    /// </remarks>
    public bool SetSpeedFactor(string typeId, double speedFactor)
        {
        TraciDouble tmp = new(speedFactor);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_SPEED_FACTOR,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's speed deviation to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="speedDeviation">the maximum speed deviation to set.</param>
    /// <returns>ssuccess or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setSpeedDeviation"/>
    /// </remarks>
    public bool SetSpeedDeviation(string typeId, double speedDeviation)
        {
        TraciDouble tmp = new(speedDeviation);

        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_SPEED_DEVIATION,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's emission class to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="emissionClass">emission class to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setEmissionClass"/>
    /// </remarks>
    public bool SetEmissionClass(string typeId, string emissionClass)
        {
        TraciString tmp = new(emissionClass);

        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_EMISSIONCLASS,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's width to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="width">width (m) to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setWidth"/>
    /// </remarks>
    public bool SetWidth(string typeId, double width)
        {
        TraciDouble tmp = new(width);

        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_WIDTH,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's height to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="height">height (m) to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setHeight"/>
    /// </remarks>
    public bool SetHeight(string typeId, double height)
        {
        TraciDouble tmp = new(height);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_HEIGHT,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's minimum headway gap to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="minGap">the offset (gap to front vehicle if halting, m) </param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setMinGap"/>
    /// </remarks>
    public bool SetMinGap(string typeId, double minGap)
        {
        TraciDouble tmp = new(minGap);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_MINGAP,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's shape class to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="shapeClass">shape class to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setShapeClass"/>
    /// </remarks>
    public bool SetShapeClass(string typeId, string shapeClass)
        {
        TraciString tmp = new(shapeClass);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_SHAPECLASS,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's wished maximum accel to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="accel"> the maximum acceleration in m/s^2</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setAccel"/>
    /// </remarks>
    public bool SetAccel(string typeId, double accel)
        {
        TraciDouble tmp = new(accel);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_ACCEL,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's wished maximum deceleration to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="decel"> the maximal comfortable deceleration in m/s^2</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setDecel"/>
    /// </remarks>
    public bool SetDecel(string typeId, double decel)
        {
        TraciDouble tmp = new(decel);

        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_DECEL,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's driver imperfection (sigma) to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="imperfection"> the driver imperfection to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setImperfection"/>
    /// </remarks>
    public bool SetImperfection(string typeId, double imperfection)
        {
        TraciDouble tmp = new(imperfection);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_IMPERFECTION,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's wished headway time to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="tau"> the driver's tau-parameter (reaction time or anticipation time depending on the car-following model, s)</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setTau"/>
    /// </remarks>
    public bool SetTau(string typeId, double tau)
        {
        TraciDouble tmp = new(tau);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_TAU,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the vehicle type's color.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="color">color to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setColor"/>
    /// </remarks>
    public bool SetColor(string typeId, int r, int g, int b, int a = 255) =>
        _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_COLOR,
            typeId,
            new Color(r, g, b, a)
        );

    /// <summary>
    /// Sets the maximum lateral speed in m/s of this type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="maxSpeed">max lateral speed (m/s) to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setMaxSpeedLat"/>
    /// </remarks>
    public bool SetMaxSpeedLat(string typeId, double maxSpeed)
        {
        TraciDouble tmp = new(maxSpeed);

        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_MAXSPEED_LAT,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the minimal lateral gap of this type at 50km/h in m.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="minGapLat">the minimal lateral gap of this type at 50km/h in m</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setMinGapLat"/>
    /// </remarks>
    public bool SetMinGapLat(string typeId, double minGapLat)
        {
        TraciDouble tmp = new(minGapLat);

        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_MINGAP_LAT,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the preferred lateral latAlignment of the type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="latAlignment">the preferred lateral alignment to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setLateralAlignment"/>
    /// </remarks>
    public bool SetLateralAlignment(string typeId, string latAlignment)
        {
        TraciString tmp = new(latAlignment);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_LATALIGNMENT,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the boarding duration for passengers entering/leaving this vehicle.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="boardingDuration">the boarding duration to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setBoardingDuration"/>
    /// </remarks>
    public bool SetBoardingDuration(string typeId, double boardingDuration)
        {
        TraciDouble tmp = new(boardingDuration);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_BOARDING_DURATION,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the current base impatience of this vehicle.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="impatience">the impatience to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// impatience : <see href="https://sumo.dlr.de/docs/Definition_of_Vehicles%2C_Vehicle_Types%2C_and_Routes.html#impatience"/><para/>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setBoardingDuration"/>
    /// </remarks>
    public bool SetImpatience(string typeId, double impatience)
        {
        TraciDouble tmp = new(impatience);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_IMPATIENCE,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Creates a new vehicle type with the given ID as a duplicate of the original type.
    /// </summary>
    /// <param name="origTypeId">original type ID</param>
    /// <param name="newTypeId">new type ID</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-copy"/>
    /// </remarks>
    public bool Copy(string origTypeId, string newTypeId)
        {
        TraciString tmp = new(newTypeId);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.COPY,
            origTypeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the current action step length for the vehicle type in s.<para/>
    /// If the boolean value <paramref name="resetActionOffset"/> is true,
    /// an action step is scheduled immediately for all vehicles of the type.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="actionStepLength">the action step length  (s) to set</param>
    /// <param name="resetActionOffset">an action step is scheduled immediately or not</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setBoardingDuration"/>
    /// </remarks>

    public bool SetActionStepLength(
        string typeId,
        double actionStepLength,
        bool resetActionOffset = true
    )
        {
        actionStepLength = resetActionOffset ? actionStepLength : actionStepLength * -1;
        TraciDouble tmp = new(actionStepLength);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_ACTIONSTEPLENGTH,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the traffic scaling factor for vehicles of this type
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="scale">the traffic scaling factor to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setScale"/>
    /// </remarks>
    public bool SetScale(string typeId, double scale)
        {
        TraciDouble tmp = new(scale);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_SCALE,
            typeId,
            tmp
        );
        }

    /// <summary>
    /// Sets the mass of the vehicle type to the given value
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="mass">the mass (kg) to set</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VTypeDomain-setMass"/>
    /// </remarks>
    public bool SetMass(string typeId, double mass)
        {
        TraciDouble tmp = new(mass);
        return _helper.ExecuteSetCommand(
            Set.VEHICLETYPE_VARIABLE,
            TraciConstants.VAR_MASS,
            typeId,
            tmp
        );
        }
    }
