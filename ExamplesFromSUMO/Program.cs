

foreach (var tutorial in SumoEnvReader.GetTutorialList())
    {
    if (tutorial.ToLower().Contains("traci"))
        Console.WriteLine(tutorial);
    }

public static class SumoEnvReader
    {
    //D:\Sumo\doc\tutorial
    public static string GetSumoHome() => Environment.GetEnvironmentVariable("SUMO_HOME") ?? string.Empty;

    public static string GetSumoTutorialPath() => Path.Combine(GetSumoHome(), "doc", "tutorial");

    public static string[] GetTutorialList() => Directory.GetDirectories(GetSumoTutorialPath());
    }

