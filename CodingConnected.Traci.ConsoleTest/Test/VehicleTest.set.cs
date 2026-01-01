namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class VehicleTest
    {
    private static bool SetStop(TraciClient client) => client.Vehicle.SetStop("v0", "end");

    private static bool ChangeLane(TraciClient client) => client.Vehicle.ChangeLane("v0", 0, 0.1);

    private static bool ChangeSubLane(TraciClient client) => client.Vehicle.ChangeSubLane("v0", 1);

    private static bool SlowDown(TraciClient client) => client.Vehicle.SlowDown("v0", 10, 1);

    private static bool Resume(TraciClient client) => client.Vehicle.Resume("v0");

    private static bool ChangeTarget(TraciClient client) => client.Vehicle.ChangeTarget("v0", "end");

    private static bool SetSpeed(TraciClient client) => client.Vehicle.SetSpeed("v0", 10);

    private static bool SetAcceleration(TraciClient client) => client.Vehicle.SetAcceleration("v0", 1, 1);


    private static bool SetPreviousSpeed(TraciClient client) => client.Vehicle.SetPreviousSpeed("v0", 10);

    private static bool SetColor(TraciClient client) => client.Vehicle.SetColor("v0", 255, 0, 255, 255);


    private static bool SetRouteId(TraciClient client) => client.Vehicle.SetRouteId("v0", "r");

    private static bool SetRoute(TraciClient client) => client.Vehicle.SetRoute("v0", ["beg", "end"]);

    private static bool RerouteParkingArea(TraciClient client) => client.Vehicle.RerouteParkingArea("v0", "A");

    private static bool DisPatchTaxi(TraciClient client) => client.Vehicle.DisPatchTaxi("v0", [""]);

    private static bool SetAdaptedTravelTime(TraciClient client) => client.Vehicle.SetAdaptedTravelTime("v0", "beg");

    private static bool SetSignals(TraciClient client) => client.Vehicle.SetSignals("v0", VehicleSignalling.EmergencyRed);

    private static bool SetRoutingMode(TraciClient client) => client.Vehicle.SetRoutingMode("v0", RoutingMode.Default);


    private static bool MoveTo(TraciClient client) => client.Vehicle.MoveTo("v0", "end_0", 10);

    private static bool MoveToXY(TraciClient client) => client.Vehicle.MoveToXY("v0", "end", 0, 547, 430);

    private static bool ReplaceStop(TraciClient client) => client.Vehicle.ReplaceStop("v0", 0, "end");

    private static bool InsertStop(TraciClient client) => client.Vehicle.InsertStop("v0", 0, "end");

    private static bool SetStopParameter(TraciClient client) => client.Vehicle.SetStopParameter("v0", 0, "time", "10");

    private static bool RerouteTravelTime(TraciClient client) => client.Vehicle.RerouteTravelTime("v0");

    private static bool RerouteEffort(TraciClient client) => client.Vehicle.RerouteEffort("v0");

    private static bool SetSpeedMode(TraciClient client) => client.Vehicle.SetSpeedMode("v0", SpeedMode.RegardSafeSpeed);

    private static bool SetSpeedFactor(TraciClient client) => client.Vehicle.SetSpeedFactor("v0", 10);

    private static bool SetLaneChangeMode(TraciClient client) => client.Vehicle.SetLaneChangeMode("v0", LaneChangeStrategicMode.ChangeIfNotInConflict, LaneChangeCooperativeMode.ChangeIfNotInConflict, LaneChangeSpeedMode.ChangeIfNotInConflict, LaneChangeRightMode.ChangeIfNotInConflict, LaneChangeRespectMode.NotRespectOther, LaneChangeSubLaneMode.NoSubLaneChanges);


    private static bool UpdateBestLanes(TraciClient client) => client.Vehicle.UpdateBestLanes("v0");

    private static bool Add(TraciClient client) => client.Vehicle.Add("v100", "r");

    private static bool Remove(TraciClient client) => client.Vehicle.Remove("v100", RemoveReason.Teleport);

    private static bool SetLength(TraciClient client) => client.Vehicle.SetLength("v0", 10);

    private static bool SetVehicleClass(TraciClient client) => client.Vehicle.SetVehicleClass("v0", "truck");

    private static bool SetEmissionClass(TraciClient client) => client.Vehicle.SetEmissionClass("v0", "HBEFA3/HDV");

    private static bool SetWidth(TraciClient client) => client.Vehicle.SetWidth("v0", 10);

    private static bool SetHeight(TraciClient client) => client.Vehicle.SetHeight("v0", 10);

    private static bool SetMinGap(TraciClient client) => client.Vehicle.SetMinGap("v0", 10);

    private static bool SetShapeClass(TraciClient client) => client.Vehicle.SetShapeClass("v0", "rail");

    private static bool SetAccel(TraciClient client) => client.Vehicle.SetAccel("v0", 10);

    private static bool SetDecel(TraciClient client) => client.Vehicle.SetDecel("v0", 10);

    private static bool SetImperfection(TraciClient client) => client.Vehicle.SetImperfection("v0", 0.5);

    private static bool SetTau(TraciClient client) => client.Vehicle.SetTau("v0", 10);

    private static bool SetType(TraciClient client) => client.Vehicle.SetType("v0", "car");

    private static bool SetVia(TraciClient client) => client.Vehicle.SetVia("v0", ["beg"]);

    private static bool SetMaxSpeedLat(TraciClient client) => client.Vehicle.SetMaxSpeedLat("v0", 10);

    private static bool SetMinGapLat(TraciClient client) => client.Vehicle.SetMinGapLat("v0", 10);

    private static bool SetLateralAlignment(TraciClient client) => client.Vehicle.SetLateralAlignment("v0", "center");

    private static bool SetBoardingDuration(TraciClient client) => client.Vehicle.SetBoardingDuration("v0", 10);

    private static bool SetImpatience(TraciClient client) => client.Vehicle.SetImpatience("v0", 0.5);

    private static bool SetParameter(TraciClient client) => client.Vehicle.SetParameter("v0", "angle", "288");

    private static bool SetActionStepLength(TraciClient client) => client.Vehicle.SetActionStepLength("v0", 10);

    private static bool Highlight(TraciClient client) => client.Vehicle.Highlight("v0");

    private static bool SetMass(TraciClient client) => client.Vehicle.SetMass("v0", 10);

    private static bool SetMaxSpeed(TraciClient client) => client.Vehicle.SetMaxSpeed("v0", 10);
    }
