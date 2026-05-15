namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class CalibratorTest
    {
    private static dynamic GetBegin(TraciClient client) => client.Calibrator.GetBegin("ca_0");

    private static dynamic GetEdgeId(TraciClient client) => client.Calibrator.GetEdgeId("ca_0");



    private static dynamic GetEnd(TraciClient client) => client.Calibrator.GetEnd("ca_0");

    private static dynamic GetInserted(TraciClient client) => client.Calibrator.GetInserted("ca_0");

    private static dynamic GetLaneId(TraciClient client) => client.Calibrator.GetLaneId("ca_0");

    private static dynamic GetPassed(TraciClient client) => client.Calibrator.GetPassed("ca_0");

    private static dynamic GetRemoved(TraciClient client) => client.Calibrator.GetRemoved("ca_0");

    private static dynamic GetRouteId(TraciClient client) => client.Calibrator.GetRouteId("ca_0");

    private static dynamic GetRouteProbeId(TraciClient client) => client.Calibrator.GetRouteProbeId("ca_0");

    private static dynamic GetSpeed(TraciClient client) => client.Calibrator.GetSpeed("ca_0");

    private static dynamic GetTypeId(TraciClient client) => client.Calibrator.GetTypeId("ca_0");

    private static dynamic GetVTypes(TraciClient client) => client.Calibrator.GetVTypes("ca_0");

    private static dynamic GetVehiclePerHour(TraciClient client) => client.Calibrator.GetVehiclePerHour("ca_0");



    }
