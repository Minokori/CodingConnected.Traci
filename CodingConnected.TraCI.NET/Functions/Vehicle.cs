using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;

public partial class Vehicle(ITCPConnectService tcpService, ICommandService helper, Simulation simulation)
    : TraCIContextSubscribableCommands(tcpService, helper)
    {
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_VEHICLE_CONTEXT;
    private readonly Simulation _simulation = simulation;

    /// <summary>
    /// subscribe to a list of variables of a vehicle
    /// </summary>
    /// <param name="vehicleId">vehicle type ID</param>
    /// <param name="beginTime">the subscription is executed only in time steps &gt;= this value; in ms</param>
    /// <param name="endTime">the subscription is executed in time steps &lt;= this value; the subscription is removed if the simulation has reached a higher time step; in ms</param>
    /// <param name="ListOfVariablesToSubsribeTo">The list of variables to return. please refer to <see cref="TraCIConstants"/></param>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/docs/TraCI/Object_Variable_Subscription.html#command_0xdx_subscribe_variable"/>
    /// </remarks>
    public void Subscribe(string vehicleId, double beginTime, double endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, vehicleId, TraCIConstants.CMD_SUBSCRIBE_VEHICLE_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    }
