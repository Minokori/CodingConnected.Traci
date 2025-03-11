namespace TracCI.NET.UsageExample.Test;
internal partial class PersonTest
    {
    private static dynamic GetIdList(TraciClient client) => client.Person.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.Person.GetIdCount();

    private static dynamic GetSpeed(TraciClient client) => client.Person.GetSpeed("ped0");

    private static dynamic GetPosition(TraciClient client) => client.Person.GetPosition("ped0");


    private static dynamic GetPosition2D(TraciClient client) => client.Person.GetPosition3D("ped0");

    private static dynamic GetAngle(TraciClient client) => client.Person.GetAngle("ped0");

    private static dynamic GetSlope(TraciClient client) => client.Person.GetSlope("ped0");


    private static dynamic GetRoadId(TraciClient client) => client.Person.GetRoadId("ped0");

    private static dynamic GetTypeId(TraciClient client) => client.Person.GetTypeId("ped0");

    private static dynamic GetColor(TraciClient client) => client.Person.GetColor("ped0");

    private static dynamic GetLanePosition(TraciClient client) => client.Person.GetLanePosition("ped0");

    private static dynamic GetLength(TraciClient client) => client.Person.GetLength("ped0");

    private static dynamic GetMinGap(TraciClient client) => client.Person.GetMinGap("ped0");


    private static dynamic GetWidth(TraciClient client) => client.Person.GetWidth("ped0");

    private static dynamic GetWaitingTime(TraciClient client) => client.Person.GetWaitingTime("ped0");

    private static dynamic GetNextEdge(TraciClient client) => client.Person.GetNextEdge("ped0");

    private static dynamic GetRemainingStages(TraciClient client) => client.Person.GetRemainingStages("ped0");

    private static dynamic GetVehicle(TraciClient client) => client.Person.GetVehicle("ped0");

    //private static dynamic GetTaxiReservations(TraciClient client) => throw new NotImplementedException($"{nameof(GetTaxiReservations)} not implemented"); // client.Person.GetTaxiReservations();

    private static dynamic GetStage(TraciClient client) => client.Person.GetStage("ped0");


    private static dynamic GetEdges(TraciClient client) => client.Person.GetEdges("ped0");




    }
