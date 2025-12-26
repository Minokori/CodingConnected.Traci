namespace CodingConnected.Traci.ConsoleTest.Test;
public partial class LaneTest
    {
    private static dynamic GetIdList(TraciClient client) => client.Lane.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.Lane.GetIdCount();


    private static dynamic GetLinkNumber(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLinkNumber(laneId);
        }

    private static dynamic GetEdgeId(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetEdgeId(laneId);
        }


    private static dynamic GetLinks(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLinks(laneId);
        }

    private static dynamic GetAllowed(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetAllowed(laneId);
        }

    private static dynamic GetDisallowed(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetDisallowed(laneId);
        }

    private static dynamic GetChangePermissions(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetChangePermissions(laneId, -1);
        }

    private static dynamic GetLength(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLength(laneId);
        }

    private static dynamic GetMaxSpeed(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetMaxSpeed(laneId);
        }

    private static dynamic GetShape(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetShape(laneId);
        }

    private static dynamic GetWidth(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetWidth(laneId);
        }

    private static dynamic GetCO2Emission(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetCO2Emission(laneId);
        }
    private static dynamic GetCOEmission(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetCOEmission(laneId);
        }

    private static dynamic GetHCEmission(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetHCEmission(laneId);
        }
    private static dynamic GetPMxEmission(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetPMxEmission(laneId);
        }

    private static dynamic GetNOxEmission(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetNOxEmission(laneId);
        }

    private static dynamic GetFuelConsumption(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetFuelConsumption(laneId);
        }

    private static dynamic GetNoiseEmission(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetNoiseEmission(laneId);
        }

    private static dynamic GetElectricityConsumption(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetElectricityConsumption(laneId);
        }

    private static dynamic GetLastStepVehicleNumber(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLastStepVehicleNumber(laneId);
        }

    private static dynamic GetLastStepMeanSpeed(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLastStepMeanSpeed(laneId);
        }
    private static dynamic GetLastStepVehicleIds(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLastStepVehicleIds(laneId);
        }
    private static dynamic GetLastStepOccupancy(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLastStepOccupancy(laneId);
        }

    private static dynamic GetLastStepLength(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLastStepLength(laneId);
        }
    private static dynamic GetWaitingTime(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetWaitingTime(laneId);
        }

    private static dynamic GetTravelTime(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetTravelTime(laneId);
        }

    private static dynamic LastStepHaltingNumber(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetLastStepHaltingNumber(laneId);
        }

    private static dynamic GetAngle(TraciClient client)
        {
        var laneId = client.Lane.GetIdList()[0];
        return client.Lane.GetAngle(laneId);
        }

    private static dynamic GetFoes(TraciClient client) => client.Lane.GetFoes("E12D12_0", "D12D13_0");
    }
