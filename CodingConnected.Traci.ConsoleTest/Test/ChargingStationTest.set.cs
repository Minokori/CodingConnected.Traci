namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class ChargingStationTest
    {
    private static dynamic SetChargingPower(TraciClient client) => client.ChargingStation.SetChargingPower("cs_0", 1000);

    private static dynamic SetEfficiency(TraciClient client) => client.ChargingStation.SetEfficiency("cs_0", 0.9);

    private static dynamic SetChargeInTransit(TraciClient client) => client.ChargingStation.SetChargeInTransit("cs_0", 1);

    private static dynamic SetChargeDelay(TraciClient client) => client.ChargingStation.SetChargeDelay("cs_0", 10);
    }
