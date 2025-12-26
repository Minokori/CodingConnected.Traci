#region get path methods
using CodingConnected.Traci.ConsoleTest.Test;

Console.WriteLine(TraciClient.GetSumoRootPath());
Console.WriteLine(TraciClient.GetSumoExecutablePath());
Console.WriteLine(TraciClient.GetSumoExampleMapsPath());
#endregion

var sumoFile = Path.Combine(".", "sumo-scenarios", "visualization", "paradeContainers", "test.sumocfg");
Console.WriteLine($"SUMO file path:{sumoFile}");

/* Create a TraciClient for the commands */
using TraciClient client = new(sumoFile, 4321, false);
(var api, var ver) = await client.Start();
Console.WriteLine($"Connected to SUMO version: {api}, Version String:{ver}");

#region Test
client.TestGui(); // all passed
//client.TestEdge(); // all passed
//client.TestJunction(); // all passed
//client.TestLane(); // all passed
//client.TestRoute(); // all passed
//client.TestRouteProbe(); // all passed
//client.TestRerouter(); // all passed
//client.TestSimulation(); // all passed
//client.TestTrafficLight();// all passed
//client.TestBusStop(); // all passed
//client.TestParkingArea(); //all passed
//client.TestCalibrator(); // all passed
//client.TestChargingStation(); // all passed
//client.TestInductionLoop(); // all passed
//client.TestLaneAreaDetector(); // all passed
//client.TestPOI(); // all passed
//client.TestPolygon(); // all passed
//client.TestMultiEntryExitDetector(); // all passed
//client.TestPerson(); // not all passed (taxi)
/*                                        */
client.Control.SimStep();
client.Vehicle.GetStops("v0");

//client.TestVehicle(); // all passed
//client.TestVehicleType(); // all passed


#endregion


Console.WriteLine("Simulation ended. Press any key to quit");
Console.ReadKey();
client.Control.Close();

