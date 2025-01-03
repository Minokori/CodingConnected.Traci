using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class JunctionCommands(ITcpService tcpService, ICommandHelperService helper) : TraCIContextSubscribableCommands(tcpService, helper)
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
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the number of junctions within the scenario
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.ID_COUNT);
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the position of the named junction [m,m]
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Position2D GetPosition(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.VAR_POSITION);
        return (Position2D)result.Value;
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of the named junction
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Polygon GetShape(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.VAR_SHAPE);
        return (Polygon)result.Value;
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_JUNCTION_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
