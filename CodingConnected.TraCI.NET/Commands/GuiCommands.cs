using System.Collections.Generic;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Response;
using CodingConnected.TraCI.NET.Services;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
    {
    public class GuiCommands(ITcpService tcpService, ICommandHelperService helper) : TraCICommandsBase(tcpService, helper)
        {
        #region Public Methods

        /// <summary>
        /// determines whether graphical capabilities exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<bool> HasView(string id)
            {
            return
                _helper.ExecuteGetCommand<bool>(

                    id,
                    TraCIConstants.CMD_GET_GUI_VARIABLE,
                    TraCIConstants.VAR_HAS_VIEW);
            }

        /// <summary>
        /// the current zoom level (in %)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TraCIResponse<double> GetZoom(string id)
            {
            return
                _helper.ExecuteGetCommand<double>(

                    id,
                    TraCIConstants.CMD_GET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_ZOOM);
            }

        /// <summary>
        /// the center of the currently visible part of the net
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public TraCIResponse<Position2D> GetOffset(string id)
            {
            return
                _helper.ExecuteGetCommand<Position2D>(

                id,
                TraCIConstants.CMD_GET_GUI_VARIABLE,
                TraCIConstants.VAR_VIEW_OFFSET);
            }

        /// <summary>
        /// the visualization scheme used (e.g. "standard" or "real world")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public TraCIResponse<string> GetSchema(string id)
            {
            return
                _helper.ExecuteGetCommand<string>(

                    id,
                    TraCIConstants.CMD_GET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_SCHEMA);
            }

        /// <summary>
        /// the lower left and the upper right corner of the visible network
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public TraCIResponse<Polygon> GetBoundary(string id)
            {
            return
                _helper.ExecuteGetCommand<Polygon>(

                id,
                TraCIConstants.CMD_GET_GUI_VARIABLE,
                TraCIConstants.VAR_VIEW_BOUNDARY);
            }

        /// <summary>
        /// 	Sets the current zoom level in %
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        public TraCIResponse<object> SetZoom(string id, double zoom)
            {
            return _helper.ExecuteSetCommand<object, double>(

                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_ZOOM,
                    zoom
                    );
            }

        /// <summary>
        /// Moves the center of the visible network to the given position
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public TraCIResponse<object> SetOffset(string id, Position2D position)
            {
            return _helper.ExecuteSetCommand<object, Position2D>(

                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_OFFSET,
                    position
                    );
            }

        /// <summary>
        /// Sets the visualization scheme (e.g. "standard")
        /// </summary>
        /// <param name="id"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public TraCIResponse<object> SetSchema(string id, string schema)
            {
            return _helper.ExecuteSetCommand<object, string>(

                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_SCHEMA,
                    schema
                    );
            }

        /// <summary>
        /// Moves the center of the visible network to the given position
        /// </summary>
        /// <param name="id"></param>
        /// <param name="boundaryBox"></param>
        /// <returns></returns>
        public TraCIResponse<object> SetBoundary(string id, Polygon boundaryBox)
            {
            return _helper.ExecuteSetCommand<object, Polygon>(

                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_BOUNDARY,
                    boundaryBox
                    );
            }

        /// <summary>
        /// Save a screenshot to the given file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public TraCIResponse<object> Screenshot(string id, string filename)
            {
            return _helper.ExecuteSetCommand<object, string>(

                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_SCREENSHOT,
                    filename
                    );
            }

        /// <summary>
        /// tracks the given vehicle in the GUI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public TraCIResponse<object> TrackVehicle(string id, string vehicleId)
            {
            return _helper.ExecuteSetCommand<object, string>(

                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_TRACK_VEHICLE,
                    vehicleId
                    );
            }

        public void Subscribe(string objectId, int beginTime, int endTime, List<byte> ListOfVariablesToSubsribeTo)
            {
            _helper.ExecuteSubscribeCommand(

                beginTime,
                endTime,
                objectId,
                TraCIConstants.CMD_SUBSCRIBE_GUI_VARIABLE,
                ListOfVariablesToSubsribeTo);
            }

        #endregion // Public Methods
        }
    }

