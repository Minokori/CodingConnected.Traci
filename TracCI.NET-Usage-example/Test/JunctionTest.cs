namespace TracCI.NET.UsageExample.Test;
public static partial class JunctionTest
    {
    public static void TestJunction(this TraciClient client)
        {
        Console.WriteLine();
        Console.WriteLine("Junction Test");
        var boolMethods = typeof(JunctionTest).GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
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
