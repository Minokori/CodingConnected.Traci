namespace TracCI.NET.UsageExample.Test;
internal partial class ChargingStationTest
    {
    private static dynamic GetEndPosition(TraciClient client) => client.ChargingStation.GetEndPosition("cs_0");

    private static dynamic GetLaneId(TraciClient client) => client.ChargingStation.GetLaneId("cs_0");

    private static dynamic GetName(TraciClient client) => client.ChargingStation.GetName("cs_0");

    private static dynamic GetStartPosition(TraciClient client) => client.ChargingStation.GetStartPosition("cs_0");

    private static dynamic GetVehicleCount(TraciClient client) => client.ChargingStation.GetVehicleCount("cs_0");

    private static dynamic GetVehicleIds(TraciClient client) => client.ChargingStation.GetVehicleIds("cs_0");

    private static dynamic GetChargingPower(TraciClient client) => client.ChargingStation.GetChargingPower("cs_0");

    private static dynamic GetEfficiency(TraciClient client) => client.ChargingStation.GetEfficiency("cs_0");

    private static dynamic GetChargeInTransit(TraciClient client) => client.ChargingStation.GetChargeInTransit("cs_0");

    private static dynamic GetChargeDelay(TraciClient client) => client.ChargingStation.GetChargeDelay("cs_0");
    }
