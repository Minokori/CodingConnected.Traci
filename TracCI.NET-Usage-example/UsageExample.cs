﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET;
using CodingConnected.TraCI.NET.DataTypes;
using CodingConnected.TraCI.NET.ProtocolTypes;

namespace CodingConnected.TraCI.UsageExample;

internal class UsageExample
    {
    #region Creating SUMO process and serving it

    private static async Task<Process> ServeSumo(string sumoCfgFile, int remotePort,
        bool useSumoGui = true, bool quitOnEnd = true, bool redirectOutputToConsole = false)
        {
        Process sumoProcess;

        /* Serve Sumo Gui or Sumo */
        try
            {
            var args = " -c " + sumoCfgFile +
                " --remote-port " + remotePort.ToString() +
                (useSumoGui ? " --start " : " ") + // this arguments only makes sense if using gui
                (quitOnEnd ? " --quit-on-end  " : " ") + "--num-clients 1";

            // Assumes that bin is in PATHs
            var sumoExecutable = useSumoGui ? @"sumo-gui" : "sumo";

            sumoProcess = new()
                {
                StartInfo = new()
                    {
                    Arguments = args,
                    FileName = sumoExecutable, // The executable for the sumo

                    /* Ignore the rest if you don't care for redirecting the output to console */
                    CreateNoWindow = redirectOutputToConsole,
                    UseShellExecute = !redirectOutputToConsole,
                    ErrorDialog = false,
                    RedirectStandardOutput = redirectOutputToConsole,
                    RedirectStandardError = redirectOutputToConsole,
                    },

                EnableRaisingEvents = redirectOutputToConsole //Not importand if not redirecting output
                };

            if (redirectOutputToConsole)
                {
                sumoProcess.ErrorDataReceived += SumoProcess_ErrorDataReceived;
                sumoProcess.OutputDataReceived += SumoProcess_OutputDataReceived;
                }

            // TODO 加载卡顿
            await Task.Run(() => sumoProcess.Start());

            if (redirectOutputToConsole)
                {
                sumoProcess.BeginErrorReadLine();
                sumoProcess.BeginOutputReadLine();
                }

            Console.WriteLine("Arguments: " + args);
            Console.WriteLine("Sumo Executable used: " + sumoExecutable);
            Console.WriteLine(sumoProcess.ToString());

            }
        catch (Exception e)
            {
            Console.WriteLine("Exception:" + e);
            Console.WriteLine("Please enter a correct path to sumocfg file");
            return null;
            }

        return sumoProcess;
        }

    /// <summary>
    /// Ignore if you don't care about redirecting output
    /// </summary>
    private static void SumoProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
        Console.WriteLine("SUMO stdout : " + e.Data);
        }

    /// <summary>
    /// Ignore if you don't care about redirecting output
    /// </summary>
    private static void SumoProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
        Console.WriteLine("SUMO stderr : " + e.Data);
        }

    #endregion

    #region static variables

    private static readonly string DEFAULT_SUMOCFG =
        Path.Combine(".", "sumo-scenarios", "usage-example", "run.sumocfg");

    /* The Variables used for VariableType and Context Subscription for this example */
    private static readonly List<byte> variablesToSubscribeTo =
    [
        TraCIConstants.VAR_SPEED,
        TraCIConstants.VAR_ANGLE,
        TraCIConstants.VAR_ACCEL,
        TraCIConstants.VAR_ROUTE_ID
    ];

    private static readonly List<byte> globlVariablesToSubscribeTo =
    [
        TraCIConstants.ID_COUNT
    ];

    private static readonly int NumberOfVehcicles;
    private static List<string> vehicleIds;

    #endregion

    private static string ByteToHex(byte? b)
        {
        return $"0x{(byte)b:X2}";
        }

    #region subscription listeners

    private static void Client_VehicleSubscriptionUsingResponses(object sender, SubscriptionEventArgs e)
        {
        var objectID = e.ObjectId;
        Console.WriteLine("*** Vehicle Variable Subscription OLD WAY for compatability. (using Responses) ***");
        Console.WriteLine("Subscription Object Id: " + objectID);
        Console.WriteLine("Variable Count        : " + e.VariableCount); // Prints the number of variables that were subscribed to

        //foreach (var r in e.Responses)
        //    {
        //    /* Responses are object that can be casted to IResponseInfo so we can retrieve 
        //     the variable type. */
        //    var respInfo = r as IResponse;
        //    var variableCode = respInfo.VariableType;

        //    /*We can then cast to TraCIResponse to get the Content
        //     We can also use IResponseInfo.GetContentAs<> ()s*/
        //    // WARNING using TraCIResponse<> we must use the exact type (i.e for speed, accel, angle, is double and not float)
        //    switch (variableCode)
        //        {
        //        case TraCIConstants.ID_COUNT:
        //            NumberOfVehcicles = respInfo.GetContentAs<int>();
        //            break;
        //        case TraCIConstants.VAR_SPEED:
        //            Console.WriteLine(" VAR_SPEED  " + (r as TraCIResponse<double>).Content);
        //            break;
        //        case TraCIConstants.VAR_ANGLE:
        //            Console.WriteLine(" VAR_ANGLE  " + respInfo.GetContentAs<float>());
        //            break;
        //        case TraCIConstants.VAR_ROUTE_ID:
        //            Console.WriteLine(" VAR_ROUTE_ID  " + (r as TraCIResponse<string>).Content);
        //            break;
        //        default:
        //            /* Intentionaly ommit VAR_ACCEL*/
        //            Console.WriteLine($" Variable with code {ByteToHex(variableCode)} not handled ");
        //            break;
        //        }
        //    }

        }

    /// <summary>
    /// Event Args are still SubscriptionEventArgs for backwards compatability but 
    /// can be casted to VariableSubscriptionEventArgs for ResponseByVariableCode support.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void Client_VehicleSubscriptionUsingDictionary(object sender, SubscriptionEventArgs e)
        {
        //Console.WriteLine("*** Vehicle Variable Subscription using dictionary ***");
        ///* Get the subscribed object id */
        //var objectID = e.ObjectId;

        ///* We can cast to VariableSubscriptionEventArgs to use the new features where 
        // we can get the response by the VariableType Type */
        //var eventArgsNew = e as VariableSubscriptionEventArgs;

        //Console.WriteLine("Subscription Object Id: " + objectID);
        //Console.WriteLine("Variable Count        : " + e.VariableCount);

        //var responseInfo = eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_SPEED];
        //Console.WriteLine(" VAR_SPEED  " + responseInfo.GetContentAs<float>());

        //responseInfo = eventArgsNew.ResponseByVariableCode[TraCIConstants.VAR_ACCEL];
        //Console.WriteLine(" VAR_SPEED  " + responseInfo.GetContentAs<float>());

        //// We can Can still retrieve using TraCIResult. 
        //// TraCIResult implements IResponseInfo. 
        //// WARNING using TraCIResponse<> we must use the exact type (i.e for angle is double)
        //var traCIResponse = (TraCIResponse<double>)eventArgsNew.ResponseByVariableCode?[TraCIConstants.VAR_ANGLE];
        //Console.WriteLine(" VAR_ANGLE  " + traCIResponse?.Content);

        //Console.WriteLine(" VAR_ROUTE_ID " + eventArgsNew.ResponseByVariableCode?[TraCIConstants.VAR_ROUTE_ID].GetContentAs<string>());

        }

    private static void Client_VehicleContextSubscriptionUsingDictionary(object sender, ContextSubscriptionEventArgs e)
        {
        Console.WriteLine("*** Vehicle Context Subscription using Dictionaries ***");
        Console.WriteLine("EGO Object id              : " + e.ObjectId);
        Console.WriteLine("Context Domain             : " + ByteToHex(e.ContextDomain));
        Console.WriteLine("Variable Count             : " + e.VariableCount);
        Console.WriteLine("Number of objects in range : " + e.ObjectCount);

        var egoObjectID = e.ObjectId;
        Console.WriteLine("EGO Object " + " id: " + egoObjectID);

        Console.WriteLine("Iterating responses...");
        Console.WriteLine("Objects inside Context Range:");
        //foreach (var r in e.Responses) /* Responses are TraCIVariableSubscriptionResponse */
        //    {
        //    var variableSubscriptionResponse = r as TraCIVariableSubscriptionResponse;
        //    var vehicleID = variableSubscriptionResponse.ObjectId;
        //    Console.WriteLine(" Object id: " + vehicleID);
        //    Console.WriteLine("     VAR_SPEED  " +
        //        variableSubscriptionResponse[TraCIConstants.VAR_SPEED].GetContentAs<float>());
        //    Console.WriteLine("     VAR_ACCEL  " +
        //        variableSubscriptionResponse[TraCIConstants.VAR_ACCEL].GetContentAs<float>());
        //    Console.WriteLine("     VAR_ANGLE  " +
        //        /* We can also use TraCIResult<> (). Warning using TraCIResponse<> we must use the exact type (i.e for angle is double) */
        //        (variableSubscriptionResponse[TraCIConstants.VAR_ANGLE] as TraCIResponse<double>).Content);
        //    Console.WriteLine("     VAR_ROUTE  " +
        //        variableSubscriptionResponse[TraCIConstants.VAR_ROUTE_ID].GetContentAs<string>());
        //    }

        //We can also get TraCIVariableSubscriptionResponse by objectID
        //Console.WriteLine("Iterating objectIds of dictionary with objects inside context range:" +
        //    "\n Printing VAR_SPEED for demonstration");
        //foreach (var id in e.ResponseUnits.Keys)
        //    {
        //    Console.WriteLine(" Object inside ego object range id: " + id);
        //    var varResp = e.ResponseUnits[id];
        //    /* We can handle variable responses like before either iterating responses or
        //     by using value by variable type */
        //    //*Printing VAR_SPEED just for demostration 
        //    Console.WriteLine("     VAR_SPEED" + varResp[TraCIConstants.VAR_SPEED].GetContentAs<float>());
        //    }
        }

    private static void Client_VehicleContextSubscriptionUsingResponses(object sender, ContextSubscriptionEventArgs e)
        {
        Console.WriteLine("*** Vehicle Context Subscription using responses ***");
        Console.WriteLine("EGO Object id              : " + e.ObjectId);
        Console.WriteLine("Context Domain             : " + ByteToHex(e.ContextDomain));
        Console.WriteLine("Variable Count             : " + e.VariableCount);
        Console.WriteLine("Number of objects in range : " + e.ObjectCount);

        Console.WriteLine("Objects inside Context Range:");

        //foreach (var r in e.Responses) /* Responses are TraCIVariableSubscriptionResponse */
        //    {
        //    var variableSubscriptionResponse = r as TraCIVariableSubscriptionResponse;
        //    var vehicleID = variableSubscriptionResponse.ObjectId;

        //    Console.WriteLine(" Object id: " + vehicleID);
        //    foreach (var response in variableSubscriptionResponse.Responses)
        //        {
        //        var variableResponse = (IResponse)response;
        //        var variableCode = variableResponse.VariableType;

        //        switch (variableCode)
        //            {
        //            case TraCIConstants.VAR_SPEED: // Returns the speed of the named vehicle within the last step [m/s]; error value: -2^30
        //                Console.WriteLine("     VAR_SPEED  " + ((TraCIResponse<double>)response).Content);
        //                break;
        //            case TraCIConstants.VAR_ANGLE: // Returns the angle of the named vehicle within the last step [°]; error value: -2^30
        //                Console.WriteLine("     VAR_ANGLE  " + ((TraCIResponse<double>)variableResponse).Content);
        //                break;
        //            case TraCIConstants.VAR_ROUTE_ID:
        //                Console.WriteLine("     VAR_ROUTE_ID " + ((TraCIResponse<string>)variableResponse).Content);
        //                break;
        //            default:
        //                /* Intentionaly ommit VAR_ACCEL*/
        //                Console.WriteLine($"    Variable with code {ByteToHex(variableCode)} not handled ");
        //                break;
        //            }
        //        }
        //    }
        }

    #endregion

    #region Printing vehicle ids methods

    private static void PrintActiveVehicles(TraCIClient client)
        {
        vehicleIds = client.Vehicle.GetIdList();
        Console.Write("Active Vehicles: [");
        foreach (var id in vehicleIds)
            {
            Console.Write($"{id} ,");
            }
        Console.WriteLine("]");
        }

    private static void PrintArrivedVehicles(TraCIClient client)
        {
        vehicleIds = client.Simulation.GetArrivedIDList();
        Console.Write("Arrived Vehicles: [");
        foreach (var id in vehicleIds)
            {
            Console.Write($"{id} ,");
            }
        Console.WriteLine("]");
        }

    private static void PrintLoadedVehicles(TraCIClient client)
        {
        vehicleIds = client.Simulation.GetLoadedIDList();
        Console.Write("Loaded Vehicles: [");
        foreach (var id in vehicleIds)
            {
            Console.Write($"{id} ,");
            }
        Console.WriteLine("]");
        }

    private static void PrintDepartedVehicles(TraCIClient client)
        {
        vehicleIds = client.Simulation.GetDepartedIDList();
        Console.Write("Departed Vehicles: [");
        foreach (var id in vehicleIds)
            {
            Console.Write($"{id} ,");
            }
        Console.WriteLine("]");
        }

    #endregion Printing vehicle ids methods

    private static async Task Main(string[] args)
        {
        /* Create a TraCIClient for the commands */
        var client = new TraCIClient();

        var sumoCfgPath = DEFAULT_SUMOCFG;

        #region handling arguments
        if (args.Length > 0)
            {
            sumoCfgPath = args[0];
            Console.WriteLine("Using sumocfg located at " + sumoCfgPath);
            }
        else
            {
            Console.WriteLine("No sumocfg file provided. Using default sumocfg: " + DEFAULT_SUMOCFG + "]");
            }
        #endregion

        /* Create a new sumo process so the client can connect to it. 
         * This step is optional if a sumo server is already running. */
        var task1 = ServeSumo(sumoCfgPath, 4321, useSumoGui: true, redirectOutputToConsole: false);
        var sumoProcess = await task1;
        if (sumoProcess != null)
            {
            var (versionId, versionString) = await client.ConnectAsync("127.0.0.1", 4321);
            Console.WriteLine($"Connected to SUMO version: {versionId}, Version String:{versionString}");
            }

        /* Connecting to Sumo Server is async but we wait for the task to complete for simplicity */

        //while (!task.IsCompleted) { /*  Wait for task to be completed before using traci commands */ }

        /* Subscribe to VariableType Subscriptions Events 
         * (triggered each step if the vehicle that was subscribed to exists )*/
        Console.WriteLine("Subscribing to Vehicle Variable Subscription");
        client.EventService.VehicleSubscription += Client_VehicleSubscriptionUsingResponses;
        client.EventService.VehicleSubscription += Client_VehicleSubscriptionUsingDictionary;

        /* Subscribe to Context Subscriptions Events*/
        client.EventService.VehicleContextSubscription += Client_VehicleContextSubscriptionUsingDictionary;
        client.EventService.VehicleContextSubscription += Client_VehicleContextSubscriptionUsingResponses;
        Console.WriteLine("Subscribing to Vehicle Context Subscription Complete");

        string id; // id that will be used for subscriptions.
        Console.WriteLine("");
        Console.WriteLine($"Sumo 版本: {client.Control.GetVersion()}");

        var instructions =
            @"
                ************************************************************
                * Press:                                                   *
                *   Enter - to make a Simulation Step                      *
                *   V - to make Variable Subscription                      *
                *   C - to make Context Subscription                       *
                *   U - to unsubscribe context                             *
                *   P - to print Vehicles                                  *
                *   T - to print Simulation Time                           *
                *   ESC - to stop the simulation                           *
                *   H - to print this instruction menu                     *
                ************************************************************";
        Console.WriteLine(instructions);

        var isEscapePressed = false;

        do
            {
            Console.Write("\n>");

            var curTime = client.Simulation.GetTime();

            var keyPressed = Console.ReadKey(false).Key;
            switch (keyPressed)
                {
                case ConsoleKey.Enter:
                    Console.WriteLine("************************************************************");
                    Console.WriteLine($"Current Simulation time: {curTime} ms");
                    client.Control.SimStep();
                    break;
                case ConsoleKey.Escape:
                    isEscapePressed = true;
                    break;
                case ConsoleKey.V:
                    Console.Write(" enter vehicle id for subscription: >");
                    id = Console.ReadLine();
                    Console.WriteLine("Attempted to subscribe to vehicle with id \"" + id + "\" (see SUMO output to know if it failed)");
                    client.Vehicle.Subscribe(id, 0, 1000, variablesToSubscribeTo);
                    break;
                case ConsoleKey.C:
                    Console.Write(" enter vehicle id for subscription: >");
                    id = Console.ReadLine();
                    client.Vehicle.SubscribeContext(id, 0, 1000, TraCIConstants.CMD_GET_VEHICLE_VARIABLE, 1000f, variablesToSubscribeTo);
                    Console.WriteLine("Attempted to subscribe to vehicle with id \"" + id + "\" (see SUMO output to know  if it failed) \n" +
                        "!Warning: Context subscription ends the simulation if it fails!");
                    break;
                case ConsoleKey.P:
                    Console.WriteLine();
                    PrintActiveVehicles(client);
                    PrintDepartedVehicles(client);
                    PrintLoadedVehicles(client);
                    PrintArrivedVehicles(client);
                    break;
                case ConsoleKey.T:
                    Console.WriteLine();
                    Console.WriteLine("Current Simulation time: " + curTime + " ms");
                    break;
                case ConsoleKey.H:
                    Console.WriteLine(instructions);
                    break;
                case ConsoleKey.U:
                    Console.Write(" enter vehicle id to unsubscribe context");
                    id = Console.ReadLine();
                    client.Vehicle.UnsubscribeContext(id, TraCIConstants.CMD_GET_VEHICLE_VARIABLE);
                    Console.WriteLine("Attempted to unsubscribe context to vehicle with id \"" + id + "\" (see SUMO output to know if it failed)");
                    break;
                default:
                    Console.Write("\n        No such command. \n");
                    Console.WriteLine(instructions);
                    break;
                }
            } while (!isEscapePressed);

        client.Control.Close();
        Console.WriteLine("Simulation ended. Press any key to quit");
        Console.ReadKey();
        }
    }



