namespace CodingConnected.Traci.ConsoleTest.Test;

public static partial class SimulationTest
    {
    public static void TestSimulation(this TraciClient client)
        {
        Console.WriteLine();
        Console.WriteLine("Simulation Test");
        var boolMethods = typeof(SimulationTest).GetMethods(
            BindingFlags.NonPublic | BindingFlags.Static
        );
        foreach (var method in boolMethods)
            {
            Console.Write($"Method: {method.Name}");
            try
                {
                var result = method.Invoke(null, [client]);

                if (result is System.Collections.IEnumerable enumerable and not string)
                    {
                    Console.Write(" success result: ");

                    foreach (var item in enumerable)
                        {
                        Console.Write($"{item} ");
                        }
                    }
                else
                    {
                    Console.Write($" success result: {result}");
                    }
                Console.WriteLine();
                }
            catch
                {
                Console.Write(" fail");
                Console.WriteLine();
                }
            }
        }
    }
