using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;

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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VARIABLESPEEDSIGN_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result.Value).Value;
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
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_VARIABLESPEEDSIGN_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result.Value).Value;
        }
    }
