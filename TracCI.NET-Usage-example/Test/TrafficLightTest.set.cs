namespace TracCI.NET.UsageExample.Test;
internal partial class TrafficLightTest
    {
    private static bool SetRedYellowGreenState(TraciClient client)
        {
        string state = new('r', 16);

        return client.TrafficLight.SetRedYellowGreenState("0", state.ToString());
        }

    private static bool SetLinkState(TraciClient client) => client.TrafficLight.SetLinkState("0", 0, "y");

    private static bool SetPhase(TraciClient client) => client.TrafficLight.SetPhase("0", 0);

    private static bool SetProgram(TraciClient client) => client.TrafficLight.SetProgram("0", "0");

    private static bool SetPhaseDuration(TraciClient client) => client.TrafficLight.SetPhaseDuration("0", 100);

    private static bool SetProgramLogic(TraciClient client)
        {
        var logic = client.TrafficLight.GetCompleteRedYellowGreenDefinition("0");
        return client.TrafficLight.SetProgramLogic("0", logic[0]);
        }
    }
