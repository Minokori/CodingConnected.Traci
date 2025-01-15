using CodingConnected.TraCI.NET.DataTypes;

namespace CodingConnected.TraCI.NET.Functions;
public partial class Junction
    {
    /// <summary>
    /// Returns a list of ids of all junctions within the scenario
    /// (the given Junction ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public List<string> GetIdList()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.ID_LIST, "ignored");
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the number of junctions within the scenario
    /// (the given Junction ID is ignored)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// see <see href=""/>
    /// </remarks>
    public int GetIdCount()
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.ID_COUNT, "ignored");
        return ((TraCIInteger)result).Value;
        }

    /// <summary>
    /// Returns the position of the named junction [m,m] or[m,m,m]
    /// </summary>
    /// <param name="junctionId"></param>
    /// <param name="includeZ"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getPosition"/>
    /// </remarks>
    public Tuple<double, double, double> GetPosition(string junctionId, bool includeZ = false)
        {
        var result = _helper.ExecuteGetCommand(
            TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
            includeZ ? TraCIConstants.VAR_POSITION3D : TraCIConstants.VAR_POSITION,
            junctionId
        );

        switch (includeZ)
            {
            case true:
                    {
                    var position3D = (Position3D)result.Value;
                    return new(position3D.X.Value, position3D.Y.Value, position3D.Z.Value);
                    }
            case false:
                    {
                    var position2D = (Position2D)result.Value;
                    return new(position2D.X.Value, position2D.Y.Value, TraCIConstants.INVALID_DOUBLE_VALUE);
                    }
            }
        }

    /// <summary>
    /// Returns the shape (list of 2D-positions) of the named junction
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getShape"/>
    /// </remarks>
    public List<Tuple<double, double>> GetShape(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.VAR_SHAPE, junctionId);
        var polygon = (Polygon)result.Value;

        return polygon.Select(i => new Tuple<double, double>(i.X.Value, i.Y.Value)).ToList();
        }

    /// <summary>
    /// Returns the ids of all incoming edges
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getIncomingEdges"/>
    /// </remarks>
    public List<string> GetIncomingEdges(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.INCOMING_EDGES, junctionId);
        return ((TraCIStringList)result).Value;
        }

    /// <summary>
    /// Returns the ids of all outgoing edges
    /// </summary>
    /// <param name="junctionId"></param>
    /// <returns></returns>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci._junction.html#JunctionDomain-getOutgoinggEdges"/>
    /// </remarks>
    public List<string> GetOutgoingEdges(string junctionId)
        {
        var result = _helper.ExecuteGetCommand(TraCIConstants.CMD_GET_JUNCTION_VARIABLE, TraCIConstants.OUTGOING_EDGES, junctionId);
        return ((TraCIStringList)result).Value;
        }
    }
