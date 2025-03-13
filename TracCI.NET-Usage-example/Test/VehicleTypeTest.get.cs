namespace TracCI.NET.UsageExample.Test;
internal partial class VehicleTypeTest
    {

    private static dynamic GetIdList(TraciClient client) => client.VehicleType.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.VehicleType.GetIdCount();


    private static dynamic GetLength(TraciClient client) => client.VehicleType.GetLength("truck");

    private static dynamic GetMaxSpeed(TraciClient client) => client.VehicleType.GetMaxSpeed("truck");

    private static dynamic GetAccel(TraciClient client) => client.VehicleType.GetAccel("truck");

    private static dynamic GetDecel(TraciClient client) => client.VehicleType.GetDecel("truck");

    private static dynamic GetTau(TraciClient client) => client.VehicleType.GetTau("truck");

    private static dynamic GetImperfection(TraciClient client) => client.VehicleType.GetImperfection("truck");

    private static dynamic GetSpeedFactor(TraciClient client) => client.VehicleType.GetSpeedFactor("truck");

    private static dynamic GetSpeedDeviation(TraciClient client) => client.VehicleType.GetSpeedDeviation("truck");

    private static dynamic GetVehicleClass(TraciClient client) => client.VehicleType.GetVehicleClass("truck");

    private static dynamic GetEmissionClass(TraciClient client) => client.VehicleType.GetEmissionClass("truck");

    private static dynamic GetShapeClass(TraciClient client) => client.VehicleType.GetShapeClass("truck");

    private static dynamic GetMinGap(TraciClient client) => client.VehicleType.GetMinGap("truck");


    private static dynamic GetWidth(TraciClient client) => client.VehicleType.GetWidth("truck");


    private static dynamic GetHeight(TraciClient client) => client.VehicleType.GetHeight("truck");

    private static dynamic GetColor(TraciClient client) => client.VehicleType.GetColor("truck");

    private static dynamic GetMaxSpeedLat(TraciClient client) => client.VehicleType.GetMaxSpeedLat("truck");

    private static dynamic GetMinGapLat(TraciClient client) => client.VehicleType.GetMinGapLat("truck");

    private static dynamic GetLateralAlignment(TraciClient client) => client.VehicleType.GetLateralAlignment("truck");

    private static dynamic GetActionStepLength(TraciClient client) => client.VehicleType.GetActionStepLength("truck");

    private static dynamic GetPersonCapacity(TraciClient client) => client.VehicleType.GetPersonCapacity("truck");

    private static dynamic GetScale(TraciClient client) => client.VehicleType.GetScale("truck");

    private static dynamic GetBoardingDuration(TraciClient client) => client.VehicleType.GetBoardingDuration("truck");

    private static dynamic GetImpatience(TraciClient client) => client.VehicleType.GetImpatience("truck");

    private static dynamic GetMass(TraciClient client) => client.VehicleType.GetMass("truck");
    }
