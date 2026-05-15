namespace CodingConnected.Traci.ConsoleTest.Test;
internal partial class PersonTest
    {
    private static bool Add(TraciClient client) => client.Person.Add("ped100", "NC", 0);

    private static bool AppendStage(TraciClient client)
        {
        var stage = client.Person.GetStage("ped0");
        return client.Person.AppendStage("ped100", stage);
        }

    private static bool AppendDrivingStage(TraciClient client) => client.Person.AppendDrivingStage("ped100", "NC", "NC");
    private static bool AppendWaitingStage(TraciClient client) => client.Person.AppendWaitingStage("ped100", 10);
    private static bool AppendWalkingStage(TraciClient client) => client.Person.AppendWalkingStage("ped100", ["NC"], 0);

    private static bool ReplaceStage(TraciClient client)
        {
        var stage = client.Person.GetStage("ped0");
        return client.Person.ReplaceStage("ped100", 1, stage);
        }
    private static bool RemoveStage(TraciClient client) => client.Person.RemoveStage("ped100", 1);

    private static bool RemoveStages(TraciClient client) => client.Person.RemoveStages("ped100");

    private static bool Remove(TraciClient client) => client.Person.Remove("ped100");

    private static bool RerouteTravelTime(TraciClient client) => client.Person.RerouteTravelTime("ped0");

    private static bool MoveToXY(TraciClient client) => client.Person.MoveToXY("ped0", "NC", 100, 60);

    private static bool SetColor(TraciClient client) => client.Person.SetColor("ped0", 255, 0, 0, 255);

    private static bool SetHeight(TraciClient client) => client.Person.SetHeight("ped0", 1.7);

    private static bool SetLength(TraciClient client) => client.Person.SetLength("ped0", 2);

    private static bool SetMinGap(TraciClient client) => client.Person.SetMinGap("ped0", 0.5);
    private static bool SetSpeed(TraciClient client) => client.Person.SetSpeed("ped0", 3);

    private static bool SetType(TraciClient client) => client.Person.SetType("ped0", "DEFAULT_PEDTYPE");

    private static bool SetWidth(TraciClient client) => client.Person.SetWidth("ped0", 0.5);




    }
