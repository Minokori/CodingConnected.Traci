using static CodingConnected.Traci.Constants.CommandIdentifier.Get;
namespace CodingConnected.Traci.Functions;

public partial class VariableSpeedSign
    {
    /// <summary>
    /// Returns a list of ids of all current VariableSpeedSign
    /// </summary>
    /// <returns>a list of all objects in the network</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._variablespeedsign.html#VariableSpeedSignDomain-getIDList"/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(VARIABLESPEEDSIGN_VARIABLE, TraciConstants.ID_LIST, "ignored");
        return (TraciStringList)result.Data;
        }

    /// <summary>
    /// Returns a list of ids of all current VariableSpeedSign
    /// </summary>
    /// <returns>the number of currently loaded objects</returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._variablespeedsign.html#VariableSpeedSignDomain-getLanes"/>
    /// </remarks>

    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(VARIABLESPEEDSIGN_VARIABLE, TraciConstants.ID_COUNT, "ignored");
        return (TraciInteger)result.Data;
        }
    }
