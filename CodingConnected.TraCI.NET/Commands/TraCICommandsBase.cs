namespace CodingConnected.TraCI.NET.Commands;


/// <summary>
/// Base class for TraCI Command
/// </summary>
/// <param name="client"> reference of a <see cref="TraCIClient"/> </param>
public abstract class TraCICommandsBase(TraCIClient client)
    {
    #region Fields

    protected readonly TraCIClient Client = client;

    #endregion // Fields

    #region Abstract Methods

    #endregion
    }
