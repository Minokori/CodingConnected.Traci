using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

public class JunctionCommands(ITCPConnectService tcpService, ICommandService helper) : TraCIContextSubscribableCommands(tcpService, helper)
    {
    #region Protected Override Methods
    protected override byte ContextSubscribeCommand => TraCIConstants.CMD_SUBSCRIBE_JUNCTION_CONTEXT;

    #endregion Protected Override Methods

    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all junctions within the scenario
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the number of junctions within the scenario
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the position of the named junction [m,m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position2D GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.VAR_POSITION, id);
        return (Position2D)result.Value;
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of the named junction
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Polygon GetShape(string id)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.VAR_SHAPE, id);
        return (Polygon)result.Value;
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_JUNCTION_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
