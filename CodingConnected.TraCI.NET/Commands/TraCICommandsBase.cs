using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Commands;


/// <summary>
/// Base class for TraCI Command
/// </summary>
/// <param name="client"> reference of a <see cref="TraCIClient"/> </param>
public abstract class TraCICommandsBase(ITcpService tcpService, ICommandHelperService helper)
    {
    #region Fields

    protected ICommandHelperService _helper = helper;
    protected ITcpService _tcpService = tcpService;

    #endregion // Fields

    #region Abstract Methods

    #endregion
    }
