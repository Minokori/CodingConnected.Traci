namespace TracCI.NET.UsageExample.Test;
internal partial class TrafficLightTest
    {
    private static dynamic GetIdList(TraciClient client) => client.TrafficLight.GetIdList();

    private static dynamic GetIdCount(TraciClient client) => client.TrafficLight.GetIdCount();

    private static dynamic GetRedYellowGreenState(TraciClient client) => client.TrafficLight.GetRedYellowGreenState("0");

    private static dynamic GetPhaseDuration(TraciClient client) => client.TrafficLight.GetPhaseDuration("0");

    private static dynamic GetControlledLanes(TraciClient client) => client.TrafficLight.GetControlledLanes("0");


    private static dynamic GetControlledLinks(TraciClient client) => client.TrafficLight.GetControlledLinks("0");

    private static dynamic GetPhase(TraciClient client) => client.TrafficLight.GetPhase("0");

    private static dynamic GetProgram(TraciClient client) => client.TrafficLight.GetProgram("0");


    private static dynamic GetCompleteRedYellowGreenDefinition(TraciClient client) => client.TrafficLight.GetCompleteRedYellowGreenDefinition("0");

    private static dynamic GetNextSwitch(TraciClient client) => client.TrafficLight.GetNextSwitch("0");

    private static dynamic GetSpentDuration(TraciClient client) => client.TrafficLight.GetSpentDuration("0");

    private static dynamic GetBlockingVehicles(TraciClient client) => client.TrafficLight.GetBlockingVehicles("0", 0);

    private static dynamic GetRivalVehicles(TraciClient client) => client.TrafficLight.GetRivalVehicles("0", 0);

    private static dynamic GetPriortyVehicles(TraciClient client) => client.TrafficLight.GetPriorityVehicles("0", 0);
    }
