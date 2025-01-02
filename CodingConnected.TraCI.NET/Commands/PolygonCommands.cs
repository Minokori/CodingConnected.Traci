using System.Collections.Generic;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
    {
    public class PolygonCommands(ITcpService tcpService, ICommandHelperService helper)
        : TraCIContextSubscribableCommands(tcpService, helper)
        {
        #region Protected Override Methods
        protected override byte ContextSubscribeCommand =>
            TraCIConstants.CMD_SUBSCRIBE_POLYGON_CONTEXT;

        #endregion Protected Override Methods

        #region Public Methods

        /// <summary>
        /// Returns a list of ids of all polygons
        /// </summary>
        /// <returns></returns>
        public TraCIResponse<List<string>> GetIdList()
            {
            return _helper.ExecuteGetCommand<List<string>>(
                "ignored",
                TraCIConstants.CMD_GET_POLYGON_VARIABLE,
                TraCIConstants.ID_LIST
            );
            }

        /// <summary>
        /// Returns the number of polygons
        /// </summary>
        /// <returns></returns>
        public TraCIResponse<int> GetIdCount()
            {
            return _helper.ExecuteGetCommand<int>(
                "ignored",
                TraCIConstants.CMD_GET_POLYGON_VARIABLE,
                TraCIConstants.ID_COUNT
            );
            }

        /// <summary>
        /// Returns the (abstract) type of the polygon
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<string> GetType(string id)
            {
            return _helper.ExecuteGetCommand<string>(
                id,
                TraCIConstants.CMD_GET_POLYGON_VARIABLE,
                TraCIConstants.VAR_TYPE
            );
            }

        /// <summary>
        /// Returns the color of this polygon
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<Color> GetColor(string id)
            {
            return _helper.ExecuteGetCommand<Color>(
                id,
                TraCIConstants.CMD_GET_POLYGON_VARIABLE,
                TraCIConstants.VAR_COLOR
            );
            }

        /// <summary>
        /// Returns the shape (list of 2D-positions) of this polygon
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<Polygon> GetShape(string id)
            {
            return _helper.ExecuteGetCommand<Polygon>(
                id,
                TraCIConstants.CMD_GET_POLYGON_VARIABLE,
                TraCIConstants.VAR_SHAPE
            );
            }

        /// <summary>
        /// Returns whether this polygon is filled (1) or not (0)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<byte> GetFilled(string id)
            {
            return _helper.ExecuteGetCommand<byte>(
                id,
                TraCIConstants.CMD_GET_POLYGON_VARIABLE,
                TraCIConstants.VAR_FILL
            );
            }

        /// <summary>
        /// Sets the polygon's type to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public bool SetType(string id, string typeId)
            {
            return _helper.ExecuteSetCommand<object, string>(
                id,
                TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                TraCIConstants.VAR_TYPE,
                typeId
            );
            }

        /// <summary>
        /// Sets the polygon's color to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool SetColor(string id, Color color)
            {
            return _helper.ExecuteSetCommand<object, Color>(
                id,
                TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                TraCIConstants.VAR_COLOR,
                color
            );
            }

        /// <summary>
        /// Sets the polygon's shape to the given value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public bool SetShape(string id, Polygon polygon)
            {
            return _helper.ExecuteSetCommand<object, Polygon>(
                id,
                TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                TraCIConstants.VAR_SHAPE,
                polygon
            );
            }

        /// <summary>
        /// Marks that the polygon shall be filled if the value is !=0.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filled"></param>
        /// <returns></returns>
        public bool SetFilled(string id, byte filled)
            {
            return _helper.ExecuteSetCommand<object, byte>(
                id,
                TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                TraCIConstants.VAR_FILL,
                filled
            );
            }

        /// <summary>
        /// Adds the defined Polygon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="filled"></param>
        /// <param name="layer"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool Add(
            string id,
            string name,
            Color color,
            bool filled,
            int layer,
            Polygon shape
        )
            {
            var tmp = new TraCIObjects
                {
                new TraCIString() { Value = name },
                color,
                new TraCIUByte() { Value = filled == false ? (byte)0 : (byte)1 },
                new TraCIInteger() { Value = layer },
                shape
                };

            return _helper.ExecuteSetCommand<object, TraCIObjects>(
                id,
                TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                TraCIConstants.ADD,
                tmp
            );
            }

        /// <summary>
        /// Removes the defined Polygon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public bool Remove(string id, int layer)
            {
            return _helper.ExecuteSetCommand<object, int>(
                id,
                TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                TraCIConstants.REMOVE,
                layer
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
                TraCIConstants.CMD_SUBSCRIBE_POLYGON_VARIABLE,
                ListOfVariablesToSubsribeTo
            );
            }
        #endregion // Public Methods
        }
    }
