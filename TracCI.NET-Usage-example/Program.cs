using CodingConnected.TraCI.NET.Constants;

#region static variables

var sumoFile =
    args.Length > 0 ? args[0] : Path.Combine(".", "sumo-scenarios", "simple-intersection", "test.sumocfg");

/* The Variables used for VariableType and Context Subscription for this example */
List<byte> variablesToSubscribeTo =
[
    TraciConstants.VAR_SPEED,
    TraciConstants.VAR_ANGLE,
    TraciConstants.VAR_ACCEL,
    TraciConstants.VAR_ROUTE_ID,
];
var isEscapePressed = false;

var instructions =
    @"
                ************************************************************
                * Press:                                                   *
                *   Enter - to make a Simulation Step                      *
                *   V     - to make Variable Subscription                  *
                *   C     - to make Context Subscription                   *
                *   U     - to unsubscribe context                         *
                *   P     - to print Vehicles                              *
                *   T     - to print Simulation Time                       *
                *   ESC   - to stop the simulation                         *
                *   H     - to print this instruction menu                 *
                ************************************************************";
#endregion



Console.WriteLine($"SUMO file path:{sumoFile}");

/* Create a TraciClient for the commands */
using TraciClient client = new(sumoFile, 4321, false);
(var api, var ver) = await client.Start();
Console.WriteLine($"Connected to SUMO version: {api}, Version String:{ver}");

#region Test
//client.TestGui(); // all passed
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

/*                                        */

//client.TestVehicle(); // all passed
//client.TestVehicleType(); // all passed
//client.TestPerson(); // all passed
//client.TestPolygon(); // all passed
//client.TestMultiEntryExitDetector(); // all passed

#endregion



#region main loop
//Console.WriteLine(instructions);
//do
//    {
//    Console.Write("\n>");
//    var curTime = client.Simulation.GetTime();
//    var keyPressed = Console.ReadKey(false).Key;
//    switch (keyPressed)
//        {
//        case ConsoleKey.Enter:
//                {
//                Console.WriteLine("************************************************************");
//                Console.WriteLine($"Current Simulation time: {curTime} ms");
//                client.Control.SimStep();
//                break;
//                }
//        case ConsoleKey.Escape:
//                {
//                isEscapePressed = true;
//                break;
//                }
//        case ConsoleKey.V:
//                {
//                Console.Write(" enter vehicle id for subscription: >");
//                var id = Console.ReadLine();
//                Console.WriteLine(
//                    "Attempted to subscribe to vehicle with id \""
//                        + id
//                        + "\" (see SUMO output to know if it failed)"
//                );
//                client.Vehicle.Subscribe(id, 0, 1000, variablesToSubscribeTo);
//                break;
//                }
//        case ConsoleKey.C:
//                {
//                Console.Write(" enter vehicle id for subscription: >");
//                var id = Console.ReadLine();
//                client.Vehicle.SubscribeContext(
//                    id,
//                    0,
//                    1000,
//                    CommandIdentifier.Get.VEHICLE_VARIABLE,
//                    1000f,
//                    variablesToSubscribeTo
//                );
//                Console.WriteLine(
//                    "Attempted to subscribe to vehicle with id \""
//                        + id
//                        + "\" (see SUMO output to know  if it failed) \n"
//                        + "!Warning: Context subscription ends the simulation if it fails!"
//                );
//                break;
//                }
//        case ConsoleKey.P:
//                {
//                Console.WriteLine();
//                PrintActiveVehicles();
//                PrintDepartedVehicles();
//                PrintLoadedVehicles();
//                PrintArrivedVehicles();
//                break;
//                }
//        case ConsoleKey.T:
//                {
//                Console.WriteLine();
//                Console.WriteLine("Current Simulation time: " + curTime + " ms");
//                break;
//                }
//        case ConsoleKey.H:
//                {
//                Console.WriteLine(instructions);
//                break;
//                }
//        case ConsoleKey.U:
//                {
//                Console.Write(" enter vehicle id to unsubscribe context");
//                var id = Console.ReadLine();
//                client.Vehicle.UnsubscribeContext(id, CommandIdentifier.Get.VEHICLE_VARIABLE);
//                Console.WriteLine(
//                    "Attempted to unsubscribe context to vehicle with id \""
//                        + id
//                        + "\" (see SUMO output to know if it failed)"
//                );
//                break;
//                }
//        default:
//                {
//                Console.Write("\n        No such command. \n");
//                Console.WriteLine(instructions);
//                break;
//                }
//        }
//    } while (!isEscapePressed);
#endregion


Console.WriteLine("Simulation ended. Press any key to quit");
Console.ReadKey();
client.Control.Close();

#region Printing vehicle ids methods

void PrintActiveVehicles()
    {
    var vehicleIds = client.Vehicle.GetIdList();
    Console.Write("Active Vehicles: [");
    foreach (var id in vehicleIds)
        {
        Console.Write($"{id} ,");
        }
    Console.WriteLine("]");
    }

void PrintArrivedVehicles()
    {
    var vehicleIds = client.Simulation.GetArrivedIdList();
    Console.Write("Arrived Vehicles: [");
    foreach (var id in vehicleIds)
        {
        Console.Write($"{id} ,");
        }
    Console.WriteLine("]");
    }

void PrintLoadedVehicles()
    {
    var vehicleIds = client.Simulation.GetLoadedIdList();
    Console.Write("Loaded Vehicles: [");
    foreach (var id in vehicleIds)
        {
        Console.Write($"{id} ,");
        }
    Console.WriteLine("]");
    }

void PrintDepartedVehicles()
    {
    var vehicleIds = client.Simulation.GetDepartedIdList();
    Console.Write("Departed Vehicles: [");
    foreach (var id in vehicleIds)
        {
        Console.Write($"{id} ,");
        }
    Console.WriteLine("]");
    }

#endregion Printing vehicle ids methods
