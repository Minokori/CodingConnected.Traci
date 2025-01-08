using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Functions;


/// <summary>
/// Base class for TraCI Command
/// </summary>
/// <param name="client"> reference of a <see cref="TraCIClient"/> </param>
public abstract class TraCICommandsBase(ITCPConnectService tcpService, ICommandService helper)
    {
    protected ICommandService _helper = helper;
    protected ITCPConnectService _tcpService = tcpService;
    }
