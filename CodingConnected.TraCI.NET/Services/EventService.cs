using CodingConnected.TraCI.NET.ProtocolTypes;

namespace CodingConnected.TraCI.NET.Services;

public class EventService : IEventService
    {
    public event EventHandler<ContextSubscriptionEventArgs> EdgeContextSubscription;
    public event EventHandler<SubscriptionEventArgs> EdgeSubscription;
    public event EventHandler<SubscriptionEventArgs> GUISubscription;
    public event EventHandler<ContextSubscriptionEventArgs> InductionLoopContextSubscription;
    public event EventHandler<SubscriptionEventArgs> InductionLoopSubscription;
    public event EventHandler<ContextSubscriptionEventArgs> JunctionContextSubscription;
    public event EventHandler<SubscriptionEventArgs> JunctionSubscription;
    public event EventHandler<SubscriptionEventArgs> LaneAreaSubscription;
    public event EventHandler<ContextSubscriptionEventArgs> LaneContextSubscription;
    public event EventHandler<SubscriptionEventArgs> LaneSubscription;
    public event EventHandler<SubscriptionEventArgs> PersonSubscription;
    public event EventHandler<ContextSubscriptionEventArgs> PointOfInterestContextSubscription;
    public event EventHandler<SubscriptionEventArgs> PointOfIntrestSubscription;
    public event EventHandler<ContextSubscriptionEventArgs> PolygonContextSubscription;
    public event EventHandler<SubscriptionEventArgs> PolygonSubscription;
    public event EventHandler<SubscriptionEventArgs> RouteSubscription;
    public event EventHandler<SubscriptionEventArgs> SimulationSubscription;
    public event EventHandler<SubscriptionEventArgs> TrafficLightSubscription;
    public event EventHandler<ContextSubscriptionEventArgs> VehicleContextSubscription;
    public event EventHandler<SubscriptionEventArgs> VehicleSubscription;
    public event EventHandler<SubscriptionEventArgs> VehicleTypeSubscription;
    public event EventHandler<SubscriptionEventArgs> MultiEntryMultiExitDetectorSubscription;

    // TODO add default event handlers for debug (Debug.WriteLine)
    public void OnEdgeContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        EdgeContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnEdgeSubscription(SubscriptionEventArgs eventArgs)
        {
        EdgeSubscription?.Invoke(this, eventArgs);
        }

    public void OnGUISubscription(SubscriptionEventArgs eventArgs)
        {
        GUISubscription?.Invoke(this, eventArgs);
        }

    public void OnInductionLoopContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        InductionLoopContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnInductionLoopSubscription(SubscriptionEventArgs eventArgs)
        {
        InductionLoopSubscription?.Invoke(this, eventArgs);
        }

    public void OnJunctionContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        JunctionContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnJunctionSubscription(SubscriptionEventArgs eventArgs)
        {
        JunctionSubscription?.Invoke(this, eventArgs);
        }

    public void OnLaneAreaSubscription(SubscriptionEventArgs eventArgs)
        {
        LaneAreaSubscription?.Invoke(this, eventArgs);
        }

    public void OnLaneContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        LaneContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnLaneSubscription(SubscriptionEventArgs eventArgs)
        {
        LaneSubscription?.Invoke(this, eventArgs);
        }

    public void OnMultiEntryExitSubscription(SubscriptionEventArgs eventArgs)
        {
        MultiEntryMultiExitDetectorSubscription?.Invoke(this, eventArgs);
        }

    public void OnPersonSubscription(SubscriptionEventArgs eventArgs)
        {
        PersonSubscription?.Invoke(this, eventArgs);
        }

    public void OnPOIContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        PointOfInterestContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnPOISubscription(SubscriptionEventArgs eventArgs)
        {
        PointOfIntrestSubscription?.Invoke(this, eventArgs);
        }

    public void OnPolygonContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        PolygonContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnPolygonSubscription(SubscriptionEventArgs eventArgs)
        {
        PolygonSubscription?.Invoke(this, eventArgs);
        }

    public void OnRouteSubscription(SubscriptionEventArgs eventArgs)
        {
        RouteSubscription?.Invoke(this, eventArgs);
        }

    public void OnSimulationSubscription(SubscriptionEventArgs eventArgs)
        {
        SimulationSubscription?.Invoke(this, eventArgs);
        }

    public void OnTrafficLightSubscription(SubscriptionEventArgs eventArgs)
        {
        TrafficLightSubscription?.Invoke(this, eventArgs);
        }

    public void OnVehicleContextSubscription(ContextSubscriptionEventArgs eventArgs)
        {
        VehicleContextSubscription?.Invoke(this, eventArgs);
        }

    public void OnVehicleSubscription(SubscriptionEventArgs eventArgs)
        {
        VehicleSubscription?.Invoke(this, eventArgs);
        }

    public void OnVehicleTypeSubscription(SubscriptionEventArgs eventArgs)
        {
        VehicleTypeSubscription?.Invoke(this, eventArgs);
        }
    }
