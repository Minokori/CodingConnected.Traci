namespace CodingConnected.TraCI.NET.Services;
internal class DebugService(bool enableDebug = false) : IDebugService
    {

    private readonly bool _debugMode = enableDebug;

    public void LogToConsole(string debugMessage)
        {
        if (_debugMode)
            {
            Console.WriteLine(debugMessage);
            }
        }
    }
