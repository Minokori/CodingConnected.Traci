using System.Net.Sockets;
using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.ProtocolTypes;

namespace CodingConnected.TraCI.NET.Services;

public interface ITCPConnectService : IDisposable
    {
    TcpClient? Client { get; }
    NetworkStream? Stream { get; }
    Task ConnectAsync(string hostname, int port);
    bool Connect(string hostname, int port);
    List<TraciResult> SendMessage(TraCICommand command);
    }

public interface ICommandService
    {
    /// <summary>
    /// Execute a get command.<para/>
    /// </summary>
    /// <param name="commandIdentifier">specify which command to execute</param>
    /// <param name="variable">specify which variable to get</param>
    /// <param name="id">specify the object id to work on</param>
    /// <param name="extendParameter">if get command requires extend parameter, put it here.</param>
    /// <returns></returns>
    IAnswerFromSumo ExecuteGetCommand(byte commandIdentifier, byte? variable, string id = "", ITraciType? extendParameter = null);


    /// <summary>
    /// Execute a set command.<para/>
    /// </summary>
    /// <param name="commandIdentifier">specify which command to execute</param>
    /// <param name="variable">specify which variable to set</param>
    /// <param name="id">specify the object id to work on</param>
    /// <param name="value">value to set</param>
    /// <returns>command success or not</returns>
    bool ExecuteSetCommand(byte commandIdentifier, byte variable, string id, ITraciType? value = null);

    /// <summary>
    /// Execute a subscribe command.<para/>
    /// </summary>
    /// <param name="beginTime"></param>
    /// <param name="endTime"></param>
    /// <param name="commandIdentifier">specify which command to execute</param>
    /// <param name="variables">specify which variables to subscribe</param>
    /// <param name="objectId">specify the object id to subscribe</param>
    void ExecuteSubscribeCommand(double beginTime, double endTime, byte commandIdentifier, List<byte> variables, string objectId);

    void ExecuteSubscribeContextCommand(
        double beginTime,
        double endTime,
        byte commandIdentifier,
        List<byte> variables,
        string objectId,
        byte contextDomain,
        double contextRange);

    TraCICommand GenerateCommand(byte commandIdentifier, byte? variable = null, string? id = null, ITraciType? extendParameter = null);
    TraCICommand GenerateSubscribeCommand(
        double beginTime,
        double endTime,
        byte commandIdentifier,
        List<byte> variables,
        string objectId,
        /*below params for context subscribe*/
        byte? contextDomain = null,
        double? contextRange = null
    );
    }

public interface IEventService
    {
    event EventHandler<ContextSubscriptionEventArgs> EdgeContextSubscription;
    event EventHandler<SubscriptionEventArgs> MultiEntryMultiExitDetectorSubscription;
    event EventHandler<SubscriptionEventArgs> EdgeSubscription;
    event EventHandler<SubscriptionEventArgs> GUISubscription;
    event EventHandler<ContextSubscriptionEventArgs> InductionLoopContextSubscription;
    event EventHandler<SubscriptionEventArgs> InductionLoopSubscription;
    event EventHandler<ContextSubscriptionEventArgs> JunctionContextSubscription;
    event EventHandler<SubscriptionEventArgs> JunctionSubscription;
    event EventHandler<SubscriptionEventArgs> LaneAreaSubscription;
    event EventHandler<ContextSubscriptionEventArgs> LaneContextSubscription;
    event EventHandler<SubscriptionEventArgs> LaneSubscription;
    event EventHandler<SubscriptionEventArgs> PersonSubscription;
    event EventHandler<ContextSubscriptionEventArgs> PointOfInterestContextSubscription;
    event EventHandler<SubscriptionEventArgs> PointOfInterestSubscription;
    event EventHandler<ContextSubscriptionEventArgs> PolygonContextSubscription;
    event EventHandler<SubscriptionEventArgs> PolygonSubscription;
    event EventHandler<SubscriptionEventArgs> RouteSubscription;
    event EventHandler<SubscriptionEventArgs> SimulationSubscription;
    event EventHandler<SubscriptionEventArgs> TrafficLightSubscription;
    event EventHandler<ContextSubscriptionEventArgs> VehicleContextSubscription;
    event EventHandler<SubscriptionEventArgs> VehicleSubscription;
    event EventHandler<SubscriptionEventArgs> VehicleTypeSubscription;
    void OnPersonSubscription(SubscriptionEventArgs eventArgs);

    void OnLaneAreaSubscription(SubscriptionEventArgs eventArgs);

    void OnGUISubscription(SubscriptionEventArgs eventArgs);

    void OnSimulationSubscription(SubscriptionEventArgs eventArgs);

    void OnEdgeSubscription(SubscriptionEventArgs eventArgs);

    void OnJunctionSubscription(SubscriptionEventArgs eventArgs);

    void OnPolygonSubscription(SubscriptionEventArgs eventArgs);

    void OnPOISubscription(SubscriptionEventArgs eventArgs);

    void OnRouteSubscription(SubscriptionEventArgs eventArgs);

    void OnVehicleTypeSubscription(SubscriptionEventArgs eventArgs);

    void OnVehicleSubscription(SubscriptionEventArgs eventArgs);

    void OnLaneSubscription(SubscriptionEventArgs eventArgs);

    void OnTrafficLightSubscription(SubscriptionEventArgs eventArgs);

    void OnMultiEntryExitSubscription(SubscriptionEventArgs eventArgs);

    void OnInductionLoopSubscription(SubscriptionEventArgs eventArgs);

    void OnInductionLoopContextSubscription(ContextSubscriptionEventArgs eventArgs);
    void OnLaneContextSubscription(ContextSubscriptionEventArgs eventArgs);

    void OnVehicleContextSubscription(ContextSubscriptionEventArgs eventArgs);

    void OnPOIContextSubscription(ContextSubscriptionEventArgs eventArgs);

    void OnPolygonContextSubscription(ContextSubscriptionEventArgs eventArgs);

    void OnJunctionContextSubscription(ContextSubscriptionEventArgs eventArgs);

    void OnEdgeContextSubscription(ContextSubscriptionEventArgs eventArgs);
    }


public interface IDebugService
    {
    void LogToConsole(string debugMessage);
    }