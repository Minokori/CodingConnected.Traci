namespace CodingConnected.Traci.ConsoleTest.Test;
public partial class EdgeTest
    {

    private static dynamic GetIdList(TraciClient client)
        => client.Edge.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.Edge.GetIdCount();

    private static dynamic GetIdListVariable(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLaneNumber(edge);
        }

    private static dynamic GetStreetName(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetStreetName(edge);
        }

    private static dynamic GetTravelTime(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetTravelTime(edge);
        }

    private static dynamic GetCO2Emission(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetCO2Emission(edge);
        }

    private static dynamic GetCOEmission(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetCOEmission(edge);
        }

    private static dynamic GetHCEmission(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetHCEmission(edge);
        }

    private static dynamic GetPMxEmission(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetPMxEmission(edge);
        }

    private static dynamic GetNOxEmission(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetNOxEmission(edge);
        }
    private static dynamic GetFuelConsumption(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetFuelConsumption(edge);
        }

    private static dynamic GetNoiseEmission(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetNoiseEmission(edge);
        }

    private static dynamic GetElectricityConsumption(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetElectricityConsumption(edge);
        }

    private static dynamic GetLastStepVehicleNumber(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepVehicleNumber(edge);
        }

    private static dynamic GetLastStepMeanSpeed(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepMeanSpeed(edge);
        }

    private static dynamic GetLastStepVehicleIDs(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepVehicleIDs(edge);
        }
    private static dynamic GetLastStepOccupancy(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepOccupancy(edge);
        }

    private static dynamic GetLastStepLength(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepLength(edge);
        }

    private static dynamic GetWaitingTime(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetWaitingTime(edge);
        }

    private static dynamic GetLastStepPersonIds(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepPersonIds(edge);
        }

    private static dynamic GetLastStepHaltingNumber(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetLastStepHaltingNumber(edge);
        }


    private static dynamic GetAngle(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetAngle(edge, 0.0);
        }

    private static dynamic GetFromJunction(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetFromJunction(edge);
        }
    private static dynamic GetToJunction(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetToJunction(edge);
        }

    private static dynamic GetAdaptedTravelTime(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetAdaptedTravelTime(edge, 1.0);
        }

    private static dynamic GetEffort(TraciClient client)
        {
        var edge = client.Edge.GetIdList()[0];
        return client.Edge.GetEffort(edge, 1.0);
        }
    }
