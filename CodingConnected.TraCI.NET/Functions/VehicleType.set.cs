using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

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
        var tmp = new TraCIDouble { Value = length };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_LENGTH, tmp);
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
        var tmp = new TraCIDouble { Value = speed };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MAXSPEED, tmp);
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
        var tmp = new TraCIString { Value = vehicleClass };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS, tmp);
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
        var tmp = new TraCIDouble { Value = speedFactor };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR, tmp);
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
        var tmp = new TraCIDouble { Value = speedDeviation };

        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SPEED_DEVIATION, tmp);
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
        var tmp = new TraCIString { Value = emissionClass };

        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS, tmp);
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
        var tmp = new TraCIDouble { Value = width };

        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_WIDTH, tmp);
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
        var tmp = new TraCIDouble { Value = height };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_HEIGHT, tmp);
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
        var tmp = new TraCIDouble { Value = minGap };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MINGAP, tmp);
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
        var tmp = new TraCIString { Value = shapeClass };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, tmp);
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
        var tmp = new TraCIDouble { Value = accel };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_ACCEL, tmp);
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
        var tmp = new TraCIDouble { Value = decel };

        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_DECEL, tmp);
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
        var tmp = new TraCIDouble { Value = imperfection };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, tmp);
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
        var tmp = new TraCIDouble { Value = tau };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_TAU, tmp);
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
    public bool SetColor(string typeId, Color color)
        {
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the vehicle type's color.
    /// </summary>
    /// <param name="typeId">vehicle type ID</param>
    /// <param name="r">red value</param>
    /// <param name="g">green value</param>
    /// <param name="b">blue value</param>
    /// <param name="a">alpha value</param>
    /// <returns>success or not</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._vehicletype.html#VehicleTypeDomain-setColor"/>
    /// </remarks>
    public bool SetColor(string typeId, int r, int g, int b, int a)
        {
        var tmp = new Color
            {
            R = new TraCIByte { Value = (byte)r },
            G = new TraCIByte { Value = (byte)g },
            B = new TraCIByte { Value = (byte)b },
            A = new TraCIByte { Value = (byte)a },
            };
        return SetColor(typeId, tmp);
        }

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
        var tmp = new TraCIDouble { Value = maxSpeed };

        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, tmp);
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
        var tmp = new TraCIDouble { Value = minGapLat };

        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, tmp);
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
        var tmp = new TraCIString { Value = latAlignment };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, tmp);
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
        var tmp = new TraCIDouble { Value = boardingDuration };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_BOARDING_DURATION, tmp);
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
        var tmp = new TraCIDouble { Value = impatience };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_IMPATIENCE, tmp);
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
        var tmp = new TraCIString { Value = newTypeId };
        return _helper.ExecuteSetCommand(origTypeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.COPY, tmp);
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

    public bool SetActionStepLength(string typeId, double actionStepLength, bool resetActionOffset = true)
        {
        actionStepLength = resetActionOffset ? actionStepLength : actionStepLength * -1;
        var tmp = new TraCIDouble { Value = actionStepLength };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_ACTIONSTEPLENGTH, tmp);
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
        var tmp = new TraCIDouble { Value = scale };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SCALE, tmp);
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
        var tmp = new TraCIDouble { Value = mass };
        return _helper.ExecuteSetCommand(typeId, TraCIConstants.CMD_SET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MASS, tmp);
        }
    }
