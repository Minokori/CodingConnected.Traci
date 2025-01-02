using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;

namespace CodingConnected.TraCI.NET.Commands
    {
    public class RouteCommands(ITcpService tcpService, ICommandHelperService helper)
        : TraCICommandsBase(tcpService, helper)
        {
        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all currently loaded routes
        /// </summary>
        /// <returns></returns>
        public TraCIResponse<List<string>> GetIdList()
            {
            return _helper.ExecuteGetCommand<List<string>>(
                "ignored",
                TraCIConstants.CMD_GET_ROUTE_VARIABLE,
                TraCIConstants.ID_LIST
            );
            }

        /// <summary>
        /// Returns the number of currently loaded routes
        /// </summary>
        /// <returns></returns>
        public TraCIResponse<int> GetIdCount()
            {
            return _helper.ExecuteGetCommand<int>(
                "ignored",
                TraCIConstants.CMD_GET_ROUTE_VARIABLE,
                TraCIConstants.ID_COUNT
            );
            }

        /// <summary>
        /// Returns the ids of the edges this route covers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<List<string>> GetEdges(string id)
            {
            return _helper.ExecuteGetCommand<List<string>>(
                id,
                TraCIConstants.CMD_GET_ROUTE_VARIABLE,
                TraCIConstants.VAR_EDGES
            );
            }

        /// <summary>
        /// Adds a new route; the route gets the given id and follows the given edges.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public bool Add(string id, List<string> edges)
            {
            return _helper.ExecuteSetCommand<object, List<string>>(
                id,
                TraCIConstants.CMD_SET_ROUTE_VARIABLE,
                TraCIConstants.ADD,
                edges
            );
            }

        public void Subscribe(
            string objectId,
            int beginTime,
            int endTime,
            List<byte> ListOfVariablesToSubsribeTo
        )
            {
            _helper.ExecuteSubscribeCommand(
                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_ROUTE_VARIABLE,
                ListOfVariablesToSubsribeTo
            );
            }
        #endregion // Public Methods
        }
    }
