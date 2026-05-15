using CodingConnected.Traci.Services;

namespace CodingConnected.Traci;

public partial class TraciClient
    {

    public static string GetSumoRootPath()
        {
        var path = Environment.GetEnvironmentVariable("SUMO_HOME");
        return string.IsNullOrEmpty(path)
            ? throw new InvalidOperationException(
                "SUMO_HOME environment variable is not set. Please set it to the root directory of your SUMO installation."
            )
            : path;
        }
    public static string GetSumoExecutablePath(bool gui = true)
        {
        var sumoRoot = GetSumoRootPath();
        var exePath = Path.Combine(sumoRoot, "bin", gui ? "sumo-gui.exe" : "sumo.exe");
        return !File.Exists(exePath)
            ? throw new FileNotFoundException(
                $"SUMO executable not found at path: {exePath}. Please ensure SUMO is installed correctly."
            )
            : exePath;
        }
    public static string GetSumoExampleMapsPath()
        {
        var sumoRoot = GetSumoRootPath();
        var examplePath = Path.Combine(sumoRoot, "doc", "examples", "sumo");
        return !Directory.Exists(examplePath)
            ? throw new FileNotFoundException(
                $"SUMO executable not found at path: {examplePath}. Please ensure SUMO is installed correctly."
            )
            : examplePath;
        }


    public static TraciClient Create(string sumoFilePath, int port)
        {
        ConnectService connectService = new();
        CommandService commandService = new(connectService);
        EventService eventService = new();
        TraciClient traciClient = new(connectService, commandService, eventService)
            {
            SumoFile = sumoFilePath,
            Port = port
            };
        return traciClient;
        }
    }