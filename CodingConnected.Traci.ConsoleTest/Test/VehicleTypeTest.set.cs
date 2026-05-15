namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class VehicleTypeTest
    {

    private static bool SetLength(TraciClient client) => client.VehicleType.SetLength("truck", 10);

    private static bool SetMaxSpeed(TraciClient client) => client.VehicleType.SetMaxSpeed("truck", 10);

    private static bool SetVehicleClass(TraciClient client) => client.VehicleType.SetVehicleClass("truck", "truck");

    private static bool SetSpeedFactor(TraciClient client) => client.VehicleType.SetSpeedFactor("truck", 10);

    private static bool SetSpeedDeviation(TraciClient client) => client.VehicleType.SetSpeedDeviation("truck", 10);

    private static bool SetEmissionClass(TraciClient client) => client.VehicleType.SetEmissionClass("truck", "HBEFA3/HDV");



    private static bool SetWidth(TraciClient client) => client.VehicleType.SetWidth("truck", 10);

    private static bool SetHeight(TraciClient client) => client.VehicleType.SetHeight("truck", 10);

    private static bool SetMinGap(TraciClient client) => client.VehicleType.SetMinGap("truck", 10);


    private static bool SetShapeClass(TraciClient client) => client.VehicleType.SetShapeClass("truck", "truck");
    private static bool SetAccel(TraciClient client) => client.VehicleType.SetAccel("truck", 10);

    private static bool SetDecel(TraciClient client) => client.VehicleType.SetDecel("truck", 10);

    private static bool SetImperfection(TraciClient client) => client.VehicleType.SetImperfection("truck", 10);

    private static bool SetTau(TraciClient client) => client.VehicleType.SetTau("truck", 10);

    private static bool SetColor(TraciClient client) => client.VehicleType.SetColor("truck", 255, 255, 0);

    private static bool SetMaxSpeedLat(TraciClient client) => client.VehicleType.SetMaxSpeedLat("truck", 10);

    private static bool SetMinGapLat(TraciClient client) => client.VehicleType.SetMinGapLat("truck", 10);

    private static bool SetLateralAlignment(TraciClient client) => client.VehicleType.SetLateralAlignment("truck", "center");

    private static bool SetBoardingDuration(TraciClient client) => client.VehicleType.SetBoardingDuration("truck", 10);

    private static bool SetImpatience(TraciClient client) => client.VehicleType.SetImpatience("truck", 10);

    private static bool Copy(TraciClient client) => client.VehicleType.Copy("truck", "car");

    private static bool SetActionStepLength(TraciClient client) => client.VehicleType.SetActionStepLength("truck", 10);

    private static bool SetScale(TraciClient client) => client.VehicleType.SetScale("truck", 10);

    private static bool SetMass(TraciClient client) => client.VehicleType.SetMass("truck", 10);

    }
