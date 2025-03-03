using System;
using System.Reflection;
using CodingConnected.TraCI.NET;

namespace TracCI.NET.UsageExample.Test;
public static partial class GuiTest
    {
    public static void TestGui(this TraciClient client)
        {
        var boolMethods = typeof(GuiTest).GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
        foreach (var method in boolMethods)
            {
            Console.Write($"Method: {method.Name}");
            try
                {
                var result = method.Invoke(null, [client]);
                Console.Write($" success result: {result}");
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
