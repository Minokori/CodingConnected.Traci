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
        var tmp = new TraCIDouble { Value = length };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LENGTH, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's maximum speed to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public bool SetMaxSpeed(string id, double speed)
        {
        var tmp = new TraCIDouble { Value = speed };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's vehicle class to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="vehicleClass"></param>
    /// <returns></returns>
    public bool SetVehicleClass(string id, string vehicleClass)
        {
        var tmp = new TraCIString { Value = vehicleClass };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_VEHICLECLASS, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's speed factor to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="speedFactor"></param>
    /// <returns></returns>
    public bool SetSpeedFactor(string id, double speedFactor)
        {
        var tmp = new TraCIDouble { Value = speedFactor };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_FACTOR, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's speed deviation to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="speedDeviation"></param>
    /// <returns></returns>
    public bool SetSpeedDeviation(string id, double speedDeviation)
        {
        var tmp = new TraCIDouble { Value = speedDeviation };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SPEED_DEVIATION, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's emission class to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="emissionClass"></param>
    /// <returns></returns>
    public bool SetEmissionClass(string id, string emissionClass)
        {
        var tmp = new TraCIString { Value = emissionClass };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_EMISSIONCLASS, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's width to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public bool SetWidth(string id, double width)
        {
        var tmp = new TraCIDouble { Value = width };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_WIDTH, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's height to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public bool SetHeight(string id, double height)
        {
        var tmp = new TraCIDouble { Value = height };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_HEIGHT, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's minimum headway gap to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="minGap"></param>
    /// <returns></returns>
    public bool SetMinGap(string id, double minGap)
        {
        var tmp = new TraCIDouble { Value = minGap };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's shape class to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="shapeClass"></param>
    /// <returns></returns>
    public bool SetShapeClass(string id, string shapeClass)
        {
        var tmp = new TraCIString { Value = shapeClass };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_SHAPECLASS, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's wished maximum acceleration to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="acceleration"></param>
    /// <returns></returns>
    public bool SetAccel(string id, double acceleration)
        {
        var tmp = new TraCIDouble { Value = acceleration };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_ACCEL, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's wished maximum deceleration to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="decceleration"></param>
    /// <returns></returns>
    public bool SetDecel(string id, double decceleration)
        {
        var tmp = new TraCIDouble { Value = decceleration };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_DECEL, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's driver imperfection (sigma) to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="imperfection"></param>
    /// <returns></returns>
    public bool SetImperfection(string id, double imperfection)
        {
        var tmp = new TraCIDouble { Value = imperfection };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_IMPERFECTION, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's wished headway time to the given value
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tau"></param>
    /// <returns></returns>
    public bool SetTau(string id, double tau)
        {
        var tmp = new TraCIDouble { Value = tau };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_TAU, tmp);
        }

    /// <summary>
    /// Sets the vehicle type's color.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public bool SetColor(string id, Color color)
        {
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_COLOR, color);
        }

    /// <summary>
    /// Sets the maximum lateral speed in m/s of this type.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="maxSpeed"></param>
    /// <returns></returns>
    public bool SetMaxSpeedLat(string id, double maxSpeed)
        {
        var tmp = new TraCIDouble { Value = maxSpeed };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MAXSPEED_LAT, tmp);
        }

    /// <summary>
    /// Sets the minimal lateral gap of this type at 50km/h in m.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="minGap"></param>
    /// <returns></returns>
    public bool SetMinGapLat(string id, double minGap)
        {
        var tmp = new TraCIDouble { Value = minGap };

        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_MINGAP_LAT, tmp);
        }

    /// <summary>
    /// Sets the preferred lateral alignment of the type.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    public bool SetLateralAlignment(string id, string alignment)
        {
        var tmp = new TraCIString { Value = alignment };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.VAR_LATALIGNMENT, tmp);
        }

    /// <summary>
    /// Creates a new vehicle type with the given ID as a duplicate of the original type.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newId"></param>
    /// <returns></returns>
    public bool Copy(string id, string newId)
        {
        var tmp = new TraCIString { Value = newId };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_VEHICLE_VARIABLE, TraCIConstants.COPY, tmp);
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
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_VEHICLETYPE_VARIABLE, ListOfVariablesToSubsribeTo);
        }

    #endregion // Public Methods
    }
