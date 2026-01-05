namespace CodingConnected.Traci.ConsoleTest.Test;

public static partial class GuiTest
    {
    public static void TestGui(this TraciClient client)
        {
        Console.WriteLine();
        Console.WriteLine("Gui Test");
        var boolMethods = typeof(GuiTest).GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
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
