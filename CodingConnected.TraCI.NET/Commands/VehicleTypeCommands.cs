using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class VehicleTypeCommands(ITcpService tcpService, ICommandHelperService helper) : TraCICommandsBase(tcpService, helper)
    {
    #region Public Methods

    /// <summary>
    /// Returns a list of ids of currently loaded vehicle types
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded vehicle types
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.ID_COUNT);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the length of the vehicles of this type [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetLength(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_LENGTH);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum speed of vehicles of this type [m/s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMaxSpeed(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MAXSPEED);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum acceleration possibility of vehicles of this type [m/s^2]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetAccel(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_ACCEL);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the maximum deceleration possibility of vehicles of this type [m/s^2]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetDecel(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_DECEL);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the driver's desired time headway for vehicles of this type [s]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetTau(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_TAU);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the driver's imperfection (dawdling) [0,1]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetImperfection(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_IMPERFECTION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the road speed multiplier for drivers of this type [double]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeedFactor(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the deviation of speedFactor for drivers of this type [double]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetSpeedDeviation(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SPEED_DEVIATION);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the class of vehicles of this type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetVehicleClass(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the emission class of vehicles of this type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetEmissionClass(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the shape of vehicles of this type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetShapeClass(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_SHAPECLASS);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the offset (gap to front vehicle if halting) of vehicles of this type [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMinGap(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MINGAP);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the width of vehicles of this type [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWidth(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_WIDTH);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the height of vehicles of this type [m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetHeight(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_HEIGHT);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the color of this type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Color GetColor(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_COLOR);
        return (Color)result.Value;
        }

    /// <summary>
    /// Returns the maximum lateral speed in m/s of this type.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMaxSpeedLat(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the desired lateral gap of this type at 50km/h in m.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetMinGapLat(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Returns the preferred lateral alignment of the type.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetLateralAlignment(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT);
        return ((TraCIString)result.Value).Value;
        }

    /// <summary>
    /// Returns the action step length for the vehicle type in s.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetActionStepLength(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
#warning Check this
            TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
        return ((TraCIDouble)result.Value).Value;
        }

    /// <summary>
    /// Sets the vehicle type's length to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public bool SetLength(string id, double length)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH, length);
        }

    /// <summary>
    /// Sets the vehicle type's maximum speed to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public bool SetMaxSpeed(string id, double speed)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED, speed);
        }

    /// <summary>
    /// Sets the vehicle type's vehicle class to the given value
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
    /// Sets the vehicle type's speed factor to the given value
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
    /// Sets the vehicle type's speed deviation to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="speedDeviation"></param>
    /// <returns></returns>
    public bool SetSpeedDeviation(string id, double speedDeviation)
        {
        return _helper.ExecuteSetCommand<object, double>(
            id,
            TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
            TraCIConstants.VAR_SPEED_DEVIATION,
            speedDeviation
        );
        }

    /// <summary>
    /// Sets the vehicle type's emission class to the given value
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
    /// Sets the vehicle type's width to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public bool SetWidth(string id, double width)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH, width);
        }

    /// <summary>
    /// Sets the vehicle type's height to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public bool SetHeight(string id, double height)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT, height);
        }

    /// <summary>
    /// Sets the vehicle type's minimum headway gap to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="minGap"></param>
    /// <returns></returns>
    public bool SetMinGap(string id, double minGap)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP, minGap);
        }

    /// <summary>
    /// Sets the vehicle type's shape class to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="shapeClass"></param>
    /// <returns></returns>
    public bool SetShapeClass(string id, string shapeClass)
        {
        return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, shapeClass);
        }

    /// <summary>
    /// Sets the vehicle type's wished maximum acceleration to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="acceleration"></param>
    /// <returns></returns>
    public bool SetAccel(string id, double acceleration)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL, acceleration);
        }

    /// <summary>
    /// Sets the vehicle type's wished maximum deceleration to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="decceleration"></param>
    /// <returns></returns>
    public bool SetDecel(string id, double decceleration)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL, decceleration);
        }

    /// <summary>
    /// Sets the vehicle type's driver imperfection (sigma) to the given value
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
    /// Sets the vehicle type's wished headway time to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tau"></param>
    /// <returns></returns>
    public bool SetTau(string id, double tau)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU, tau);
        }

    /// <summary>
    /// Sets the vehicle type's color.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public bool SetColor(string id, Color color)
        {
        return _helper.ExecuteSetCommand<object, Color>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the maximum lateral speed in m/s of this type.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="maxSpeed"></param>
    /// <returns></returns>
    public bool SetMaxSpeedLat(string id, double maxSpeed)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, maxSpeed);
        }

    /// <summary>
    /// Sets the minimal lateral gap of this type at 50km/h in m.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="minGap"></param>
    /// <returns></returns>
    public bool SetMinGapLat(string id, double minGap)
        {
        return _helper.ExecuteSetCommand<object, double>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, minGap);
        }

    /// <summary>
    /// Sets the preferred lateral alignment of the type.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public bool SetLateralAlignment(string id, string alignment)
        {
        return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, alignment);
        }

    /// <summary>
    /// Creates a new vehicle type with the given ID as a duplicate of the original type.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newId"></param>
    /// <returns></returns>
    public bool Copy(string id, string newId)
        {
        return _helper.ExecuteSetCommand<object, string>(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.COPY, newId);
        }

    /// <summary>
    /// Sets the current action step length for the vehicle type in s. If the boolean value resetActionOffset is true, an action step is scheduled immediately for all vehicles of the type.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TraCIResult SetActionStepLengt(string id)
        {
        throw new NotImplementedException();
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(
            beginTime,
            endTime,
            objectId,
            TraCIConstants.CMD_SUBSCRIBE_VEHICLETYPE_VARIABLE,
            ListOfVariablesToSubsribeTo
        );
        }

    #endregion // Public Methods
    }

