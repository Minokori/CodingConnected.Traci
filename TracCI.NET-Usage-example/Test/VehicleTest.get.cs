namespace TracCI.NET.UsageExample.Test;
internal partial class VehicleTest
    {

    private static dynamic GetIdList(TraciClient client) => client.Vehicle.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.Vehicle.GetIdCount();

    private static dynamic GetSpeed(TraciClient client) => client.Vehicle.GetPosition("v0");

    private static dynamic GetLateralSpeed(TraciClient client) => client.Vehicle.GetLateralSpeed("v0");

    private static dynamic GetAcceleration(TraciClient client) => client.Vehicle.GetAcceleration("v0");

    private static dynamic GetPosition(TraciClient client) => client.Vehicle.GetPosition("v0");

    private static dynamic GetPosition3D(TraciClient client) => client.Vehicle.GetPosition3D("v0");

    private static dynamic GetAngle(TraciClient client) => client.Vehicle.GetAngle("v0");

    private static dynamic GetRoadId(TraciClient client) => client.Vehicle.GetRoadId("v0");

    private static dynamic GetLaneId(TraciClient client) => client.Vehicle.GetLaneId("v0");

    private static dynamic GetLaneIndex(TraciClient client) => client.Vehicle.GetLaneIndex("v0");

    private static dynamic GetTypeId(TraciClient client) => client.Vehicle.GetTypeId("v0");

    private static dynamic GetRouteId(TraciClient client) => client.Vehicle.GetRouteId("v0");

    private static dynamic GetRouteIndex(TraciClient client) => client.Vehicle.GetRouteIndex("v0");

    private static dynamic GetRoute(TraciClient client) => client.Vehicle.GetRoute("v0");
    private static dynamic GetColor(TraciClient client) => client.Vehicle.GetColor("v0");

    private static dynamic GetLanePosition(TraciClient client) => client.Vehicle.GetLanePosition("v0");

    private static dynamic GetDistance(TraciClient client) => client.Vehicle.GetDistance("v0");

    private static dynamic GetSignals(TraciClient client) => client.Vehicle.GetSignals("v0");

    private static dynamic GetRoutingMode(TraciClient client) => client.Vehicle.GetRoutingMode("v0");

    private static dynamic GetTaxiFleet(TraciClient client) => client.Vehicle.GetTaxiFleet();

    private static dynamic GetCO2Emission(TraciClient client) => client.Vehicle.GetCO2Emission("v0");

    private static dynamic GetCOEmission(TraciClient client) => client.Vehicle.GetCOEmission("v0");

    private static dynamic GetHCEmission(TraciClient client) => client.Vehicle.GetHCEmission("v0");

    private static dynamic GetPMxEmission(TraciClient client) => client.Vehicle.GetPMxEmission("v0");

    private static dynamic GetNOxEmission(TraciClient client) => client.Vehicle.GetNOxEmission("v0");

    private static dynamic GetFuelConsumption(TraciClient client) => client.Vehicle.GetFuelConsumption("v0");

    private static dynamic GetNoiseEmission(TraciClient client) => client.Vehicle.GetNoiseEmission("v0");

    private static dynamic GetElectricityConsumption(TraciClient client) => client.Vehicle.GetElectricityConsumption("v0");

    private static dynamic GetBestLanes(TraciClient client) => client.Vehicle.GetBestLanes("v0");

    private static dynamic GetStopState(TraciClient client) => client.Vehicle.GetStopState("v0");

    private static dynamic IsAtBusStop(TraciClient client) => client.Vehicle.IsAtBusStop("v0");

    private static dynamic IsAtContainerStop(TraciClient client) => client.Vehicle.IsAtContainerStop("v0");

    private static dynamic IsStopped(TraciClient client) => client.Vehicle.IsStopped("v0");

    private static dynamic IsStoppedParking(TraciClient client) => client.Vehicle.IsStoppedParking("v0");

    private static dynamic IsStoppedTriggered(TraciClient client) => client.Vehicle.IsStoppedTriggered("v0");

    private static dynamic GetLength(TraciClient client) => client.Vehicle.GetLength("v0");
    private static dynamic GetMaxSpeed(TraciClient client) => client.Vehicle.GetMaxSpeed("v0");

    private static dynamic GetAccel(TraciClient client) => client.Vehicle.GetAccel("v0");

    private static dynamic GetDecel(TraciClient client) => client.Vehicle.GetDecel("v0");

    private static dynamic GetTau(TraciClient client) => client.Vehicle.GetTau("v0");

    private static dynamic GetImperfection(TraciClient client) => client.Vehicle.GetImperfection("v0");

    private static dynamic GetSpeedFactor(TraciClient client) => client.Vehicle.GetSpeedFactor("v0");

    private static dynamic GetSpeedDeviation(TraciClient client) => client.Vehicle.GetSpeedDeviation("v0");

    private static dynamic GetVehicleClass(TraciClient client) => client.Vehicle.GetVehicleClass("v0");

    private static dynamic GetEmissionClass(TraciClient client) => client.Vehicle.GetEmissionClass("v0");

    private static dynamic GetShapeClass(TraciClient client) => client.Vehicle.GetShapeClass("v0");

    private static dynamic GetMinGap(TraciClient client) => client.Vehicle.GetMinGap("v0");

    private static dynamic GetWidth(TraciClient client) => client.Vehicle.GetWidth("v0");

    private static dynamic GetHeight(TraciClient client) => client.Vehicle.GetHeight("v0");

    private static dynamic GetPersonCapacity(TraciClient client) => client.Vehicle.GetPersonCapacity("v0");

    private static dynamic GetWaitingTime(TraciClient client) => client.Vehicle.GetWaitingTime("v0");

    private static dynamic GetAccumulatedWaitingTime(TraciClient client) => client.Vehicle.GetAccumulatedWaitingTime("v0");

    private static dynamic GetNextTLS(TraciClient client) => client.Vehicle.GetNextTLS("v0");

    private static dynamic GetPersonIdList(TraciClient client) => client.Vehicle.GetPersonIdList("v0");

    private static dynamic GetSpeedMode(TraciClient client) => client.Vehicle.GetSpeedMode("v0");

    private static dynamic GetLaneChangeMode(TraciClient client) => client.Vehicle.GetLaneChangeMode("v0");

    private static dynamic GetSlope(TraciClient client) => client.Vehicle.GetSlope("v0");

    private static dynamic GetAllowedSpeed(TraciClient client) => client.Vehicle.GetAllowedSpeed("v0");

    private static dynamic GetLine(TraciClient client) => client.Vehicle.GetLine("v0");

    private static dynamic GetPersonNumber(TraciClient client) => client.Vehicle.GetPersonNumber("v0");

    private static dynamic GetVia(TraciClient client) => client.Vehicle.GetVia("v0");

    private static dynamic GetSpeedWithoutTraci(TraciClient client) => client.Vehicle.GetSpeedWithoutTraci("v0");

    private static dynamic IsRouteValid(TraciClient client) => client.Vehicle.IsRouteValid("v0");

    private static dynamic GetMaxSpeedLat(TraciClient client) => client.Vehicle.GetMaxSpeedLat("v0");

    private static dynamic GetBoardingDuration(TraciClient client) => client.Vehicle.GetBoardingDuration("v0");

    private static dynamic GetImpatience(TraciClient client) => client.Vehicle.GetImpatience("v0");

    private static dynamic GetMinGapLat(TraciClient client) => client.Vehicle.GetMinGapLat("v0");

    private static dynamic GetLateralAlignment(TraciClient client) => client.Vehicle.GetLateralAlignment("v0");

    private static dynamic GetParameter(TraciClient client) => client.Vehicle.GetParameter("", "device.taxi.state");

    private static dynamic GetActionStepLength(TraciClient client) => client.Vehicle.GetActionStepLength("v0");

    private static dynamic GetLastActionTime(TraciClient client) => client.Vehicle.GetLastActionTime("v0");

    private static dynamic GetStops(TraciClient client) => client.Vehicle.GetStops("v0");

    private static dynamic GetTimesLoss(TraciClient client) => client.Vehicle.GetTimesLoss("v0");

    private static dynamic GetLoadedIdList(TraciClient client) => client.Vehicle.GetLoadedIdList("v0");

    private static dynamic GetTeleportingIdList(TraciClient client) => client.Vehicle.GetTeleportingIdList("v0");

    private static dynamic GetNextLinks(TraciClient client) => client.Vehicle.GetNextLinks("v0");
    private static dynamic GetDeparture(TraciClient client) => client.Vehicle.GetDeparture("v0");

    private static dynamic GetDepartDelay(TraciClient client) => client.Vehicle.GetDepartDelay("v0");

    private static dynamic GetSegmentId(TraciClient client) => client.Vehicle.GetSegmentId("v0");
    private static dynamic GetSegmentIndex(TraciClient client) => client.Vehicle.GetSegmentIndex("v0");
    private static dynamic GetMass(TraciClient client) => client.Vehicle.GetMass("v0");

    private static dynamic GetAdaptedTravelTime(TraciClient client) => client.Vehicle.GetAdaptedTravelTime("v0", 10, "beg");
    private static dynamic GetEffort(TraciClient client) => client.Vehicle.GetEffort("v0", 10, "beg");

    private static dynamic GetLeader(TraciClient client) => client.Vehicle.GetLeader("v0");
    private static dynamic GetDrivingDistance(TraciClient client) => client.Vehicle.GetDrivingDistance("v0", "beg", 10);
    private static dynamic GetDrivingDistance2D(TraciClient client) => client.Vehicle.GetDrivingDistance2D("v0", 10, 10);

    private static dynamic GetLaneChangeState(TraciClient client) => client.Vehicle.GetLaneChangeState("v0", -1);


    private static dynamic WantsAndCouldChangeLane(TraciClient client) => client.Vehicle.WantsAndCouldChangeLane("v0", -1);

    private static dynamic CouldChangeLane(TraciClient client) => client.Vehicle.CouldChangeLane("v0", -1);

    //private static dynamic GetNeighbors(TraciClient client) => client.Vehicle.GetNeighbors("v0", 1);
    //private static dynamic GetLeftFollowers(TraciClient client) => client.Vehicle.GetLeftFollowers("v0");
    //private static dynamic GetLeftLeaders(TraciClient client) => client.Vehicle.GetLeftLeaders("v0");
    //private static dynamic GetRightFollowers(TraciClient client) => client.Vehicle.GetRightFollowers("v0");
    //private static dynamic GetRightLeaders(TraciClient client) => client.Vehicle.GetRightLeaders("v0");

    private static dynamic GetFollowSpeed(TraciClient client) => client.Vehicle.GetFollowSpeed("v0", 0, 0, 0, 0);

    private static dynamic GetSecureGap(TraciClient client) => client.Vehicle.GetSecureGap("v0", 0, 0, 0);

    private static dynamic GetStopSpeed(TraciClient client) => client.Vehicle.GetStopSpeed("v0", 0, 0);

    private static dynamic GetJunctionFoes(TraciClient client) => client.Vehicle.GetJunctionFoes("v0");

    // private static dynamic GetStopParameter(TraciClient client) => client.Vehicle.GetStopParameter("v0", 0, "time");



    }
