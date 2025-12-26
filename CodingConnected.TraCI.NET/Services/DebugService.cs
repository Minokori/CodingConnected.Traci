namespace CodingConnected.Traci.Services;

internal sealed class DebugService(bool enableDebug = false) : IDebugService
    {

    private readonly bool _debugMode = enableDebug;

    public void LogToConsole(string debugMessage)
        {
        if (_debugMode)
            {
            Console.WriteLine(debugMessage.ToLower(System.Globalization.CultureInfo.CurrentCulture));
            }
        }
    }
