using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands;

public class RouteCommands(ITcpService tcpService, ICommandHelperService helper) : TraCICommandsBase(tcpService, helper)
    {
    #region Public Methods

    /// <summary>
    /// Returns a list of ids of all currently loaded routes
    /// </summary>
    /// <returns></returns>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_ROUTE_VARIABLE, TraCIConstants.ID_LIST);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Returns the number of currently loaded routes
    /// </summary>
    /// <returns></returns>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand("ignored", TraCIConstants.CMD_GET_ROUTE_VARIABLE, TraCIConstants.ID_COUNT);
        return ((TraCIInteger)result.Value).Value;
        }

    /// <summary>
    /// Returns the ids of the edges this route covers
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<string> GetEdges(string id)
        {
        var result = _helper.ExecuteGetCommand(id, TraCIConstants.CMD_GET_ROUTE_VARIABLE, TraCIConstants.VAR_EDGES);
        return ((TraCIStringList)result.Value).Value;
        }

    /// <summary>
    /// Adds a new route; the route gets the given id and follows the given edges.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="edges"></param>
    /// <returns></returns>
    public bool Add(string id, List<string> edges)
        {
        var tmp = new TraCIStringList { Value = edges };
        return _helper.ExecuteSetCommand(id, TraCIConstants.CMD_SET_ROUTE_VARIABLE, TraCIConstants.ADD, tmp);
        }

    public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
        {
        _helper.ExecuteSubscribeCommand(beginTime, endTime, objectId, TraCIConstants.CMD_SUBSCRIBE_ROUTE_VARIABLE, ListOfVariablesToSubsribeTo);
        }
    #endregion // Public Methods
    }
