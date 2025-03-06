namespace TracCI.NET.UsageExample.Test;
public partial class SimulationTest
    {

    private static dynamic ClearPending(TraciClient client) =>
        client.Simulation.ClearPending();
    private static dynamic SaveState(TraciClient client) =>
        client.Simulation.SaveState("test");

    private static dynamic LoadState(TraciClient client) => client.Simulation.LoadState("test");

    private static dynamic SetScale(TraciClient client) => client.Simulation.SetScale(0.5);
    }
