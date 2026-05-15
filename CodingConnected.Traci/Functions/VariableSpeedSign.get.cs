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
        var result = Helper.ExecuteGetCommand(
            GetVariable.VariableSpeedSign,
            TraciConstants.IdList,
            "ignored"
        );
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
        var result = Helper.ExecuteGetCommand(
            GetVariable.VariableSpeedSign,
            TraciConstants.IdCount,
            "ignored"
        );
        return (TraciInteger)result.Data;
        }
    }
