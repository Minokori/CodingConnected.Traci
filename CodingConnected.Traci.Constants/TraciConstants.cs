namespace CodingConnected.Traci.Constants;

/// <summary>
/// Based on TraCIConst
/// </summary>
public static partial class TraciConstants
    {
    /// <summary>
    /// Traci API version
    /// </summary>
    public static int TRACI_VERSION => 21;

    // return value for invalid queries (especially vehicle is not on the road), see Position::INVALID
    public const double INVALID_DOUBLE_VALUE = -1073741824;

    // return value for invalid queries (especially vehicle is not on the road), see Position::INVALID
    public const double INVALID_INT_VALUE = -1073741824;

    // maximum value for client ordering (2 ^ 30)
    public const double MAX_ORDER = 1073741824;

    // ****************************************
    // VARIABLE TYPES (for GET_*_VARIABLE)
    // ****************************************
    // list of instances' ids (get: all)
    public const byte ID_LIST = 0x00;

    // count of instances (get: all)
    public const byte ID_COUNT = 0x01;

    // subscribe object variables (get: all)
    public const byte AUTOMATIC_VARIABLES_SUBSCRIPTION = 0x02;

    // subscribe context variables (get: all)
    public const byte AUTOMATIC_CONTEXT_SUBSCRIPTION = 0x03;

    // generic attributes (get/set: all)
    public const byte GENERIC_ATTRIBUTE = 0x03;

    // last step vehicle number (get: induction loops, multi-entry/multi-exit detector, lanes, edges)
    public const byte LAST_STEP_VEHICLE_NUMBER = 0x10;

    // last step vehicle number (get: induction loops, multi-entry/multi-exit detector, lanes, edges)
    public const byte LAST_STEP_MEAN_SPEED = 0x11;

    // last step vehicle list (get: induction loops, multi-entry/multi-exit detector, lanes, edges)
    public const byte LAST_STEP_VEHICLE_ID_LIST = 0x12;

    // last step occupancy (get: induction loops, lanes, edges)
    public const byte LAST_STEP_OCCUPANCY = 0x13;

    // last step vehicle halting number (get: multi-entry/multi-exit detector, lanes, edges)
    public const byte LAST_STEP_VEHICLE_HALTING_NUMBER = 0x14;

    // last step mean vehicle length (get: induction loops, lanes, edges)
    public const byte LAST_STEP_LENGTH = 0x15;

    // last step time since last detection (get: induction loops)
    public const byte LAST_STEP_TIME_SINCE_DETECTION = 0x16;

    // entry times
    public const byte LAST_STEP_VEHICLE_DATA = 0x17;

    // last step jam length in vehicles
    public const byte JAM_LENGTH_VEHICLE = 0x18;

    // last step jam length in meters
    public const byte JAM_LENGTH_METERS = 0x19;

    // last step person list (get: edges, vehicles)
    public const byte LAST_STEP_PERSON_ID_LIST = 0x1a;

    // street name of given edge
    public const byte VAR_STREET_NAME = 0x1b;

    // traffic light states, encoded as rRgGyYoO tuple (get: traffic lights)
    public const byte TL_RED_YELLOW_GREEN_STATE = 0x20;

    // index of the phase (set: traffic lights)
    public const byte TL_PHASE_INDEX = 0x22;

    // vehicle number (set: lane area detector)
    public const byte VAR_VEHICLE_NUMBER = 0x22;

    /// <summary>
    /// get aggregated occupancy (get: induction loop, e2)
    /// </summary>
    public const byte VAR_INTERVAL_OCCUPANCY = 0x23;

    /// <summary>
    /// get aggregated speed (get: induction loop, e2)
    /// </summary>
    public const byte VAR_INTERVAL_SPEED = 0x24;

    /// <summary>
    /// get aggregated vehicle count (get: induction loop, e2)
    /// </summary>
    public const byte VAR_INTERVAL_NUMBER = 0x25;

    /// <summary>
    /// get aggregated vehicle ids (get: induction loop)
    /// </summary>
    public const byte VAR_INTERVAL_IDS = 0x26;

    public const byte VAR_INTERVAL_MAX_JAM_LENGTH_METERS = 0x32;

    /// <summary>
    /// get aggregated speed of last written interval (get: induction loop, e2)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_OCCUPANCY = 0x27;

    /// <summary>
    /// get aggregated occupancy of last written interval (get: induction loop, e2)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_SPEED = 0x28;

    /// <summary>
    /// get aggregated vehicle count of last written interval (get: induction loop, e2)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_NUMBER = 0x29;

    /// <summary>
    /// get aggregated vehicle ids of last written interval (get: induction loop)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_IDS = 0x2a;

    /// <summary>
    /// lanes (get: variable speed sign, multi-entry/multi-exit detector)
    /// </summary>
    public const byte VAR_LANES = 0x30;

    /// <summary>
    /// lateral speed (get: vehicle)
    /// </summary>
    public const byte VAR_SPEED_LAT = 0x32;

    /// <summary>
    /// exit lanes (get: multi-entry/multi-exit detector)
    /// </summary>
    public const byte VAR_EXIT_LANES = 0x31;

    /// <summary>
    /// position (2D) (get: multi-entry/multi-exit detector)
    /// </summary>
    public const byte VAR_EXIT_POSITIONS = 0x43;

    /// <summary>
    /// last interval travel time (get: e3)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_TRAVELTIME = 0x58;

    /// <summary>
    /// command: retrieve information about the current taxi fleet and their status
    /// </summary>
    public const byte VAR_TAXI_FLEET = 0x20;

    /// <summary>
    /// retrieve taxi reservation (person)
    /// </summary>
    public const byte VAR_TAXI_RESERVATIONS = 0xc6;

    /// <summary>
    /// last step vehicle halting number (get: e3)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_MEAN_HALTING_NUMBER = 0x20;

    /// <summary>
    /// collected timeLoss since departure (get: vehicle, e3)
    /// </summary>
    public const byte VAR_TIMELOSS = 0x8c;

    /// <summary>
    /// last interval vehicle count(get: e3)
    /// </summary>
    public const byte VAR_LAST_INTERVAL_VEHICLE_NUMBER = 0x21;

    /// <summary>
    /// last interval vehicle count(set, get: e1, e2)
    /// </summary>
    public const byte VAR_VIRTUAL_DETECTION = 0x22;

    public const byte VAR_LAST_INTERVAL_MAX_JAM_LENGTH_METERS = 0x33;

    /// <summary>
    /// get/set image file (poi, poly, vehicle, person, simulation)
    /// </summary>
    public const byte VAR_IMAGEFILE = 0x93;

    // traffic light program (set: traffic lights)
    public const byte TL_PROGRAM = 0x23;

    // phase duration (set: traffic lights)
    public const byte TL_PHASE_DURATION = 0x24;

    /// <summary>
    /// vehicles that block passing the given signal (get: traffic lights)
    /// </summary>
    public const byte TL_BLOCKING_VEHICLES = 0x25;

    // controlled lanes (get: traffic lights)
    public const byte TL_CONTROLLED_LANES = 0x26;

    // controlled links (get: traffic lights)
    public const byte TL_CONTROLLED_LINKS = 0x27;

    // index of the current phase (get: traffic lights)
    public const byte TL_CURRENT_PHASE = 0x28;

    // name of the current program (get: traffic lights)
    public const byte TL_CURRENT_PROGRAM = 0x29;

    // controlled junctions (get: traffic lights)
    public const byte TL_CONTROLLED_JUNCTIONS = 0x2a;

    // complete definition (get: traffic lights)
    public const byte TL_COMPLETE_DEFINITION_RYG = 0x2b;

    // complete program (set: traffic lights)
    public const byte TL_COMPLETE_PROGRAM_RYG = 0x2c;

    // assumed time to next switch (get: traffic lights)
    public const byte TL_NEXT_SWITCH = 0x2d;

    // current state, using external signal names (get: traffic lights)
    public const byte TL_EXTERNAL_STATE = 0x2e;

    /// <summary>
    /// vehicles that also wish to pass the given signal (get: traffic lights)
    /// </summary>
    public const byte TL_RIVAL_VEHICLES = 0x30;

    /// <summary>
    /// vehicles that also wish to pass the given signal and have higher priority (get: traffic lights)
    /// </summary>
    public const byte TL_PRIORITY_VEHICLES = 0x31;

    /// <summary>
    /// retrieve duration spent in the current phase (get: traffic lights)
    /// </summary>
    public const byte TL_SPENT_DURATION = 0x38;

    // get/set impatience
    public const byte VAR_IMPATIENCE = 0x26;

    //get/set boarding duration
    public const byte VAR_BOARDING_DURATION = 0x2f;

    // outgoing link number (get: lanes)
    public const byte LANE_LINK_NUMBER = 0x30;

    // id of parent edge (get: lanes)
    public const byte LANE_EDGE_ID = 0x31;

    // outgoing link definitions (get: lanes)
    public const byte LANE_LINKS = 0x33;

    // list of allowed vehicle classes (get&set: lanes)
    public const byte LANE_ALLOWED = 0x34;

    // list of not allowed vehicle classes (get&set: lanes)
    public const byte LANE_DISALLOWED = 0x35;

    /// <summary>
    /// list of allowed vehicle classes for lane changes (get/set: lanes)
    /// </summary>
    public const byte LANE_CHANGES = 0x3c;

    // list of foe lanes (get: lanes)
    public const byte VAR_FOES = 0x37;

    // slope (get: edge, lane, vehicle, person)
    public const byte VAR_SLOPE = 0x36;

    // person capacity (get: vehicle)
    public const byte VAR_PERSON_CAPACITY = 0x38;

    /// <summary>
    /// departure time (vehicle, person)
    /// </summary>
    public const byte VAR_DEPARTURE = 0x3a;

    /// <summary>
    /// departure delay (vehicle, person)
    /// </summary>
    public const byte VAR_DEPART_DELAY = 0x3b;

    /// <summary>
    /// previous speed (set: vehicle)
    /// </summary>
    public const byte VAR_PREV_SPEED = 0x3c;

    // speed (get: vehicle)
    public const byte VAR_SPEED = 0x40;

    // maximum allowed/possible speed (get: vehicle types, lanes, set: edges, lanes)
    public const byte VAR_MAXSPEED = 0x41;

    // position (2D) (get: vehicle, poi, induction loop, area detector; set: poi)
    public const byte VAR_POSITION = 0x42;

    // position (3D) (get: vehicle, poi, set: poi)
    public const byte VAR_POSITION3D = 0x39;

    // angle (get: vehicle)
    public const byte VAR_ANGLE = 0x43;

    // angle (get: vehicle types, lanes, area detector, set: lanes)
    public const byte VAR_LENGTH = 0x44;

    // color (get: vehicles, vehicle types, polygons, pois)
    public const byte VAR_COLOR = 0x45;

    // max. acceleration (get: vehicles, vehicle types)
    public const byte VAR_ACCEL = 0x46;

    // max. comfortable deceleration (get: vehicles, vehicle types)
    public const byte VAR_DECEL = 0x47;

    /// <summary>
    /// upstream junction (edges)
    /// </summary>
    public const byte FROM_JUNCTION = 0x7b;

    /// <summary>
    /// downstream junction (edges)
    /// </summary>
    public const byte TO_JUNCTION = 0x7c;

    /// <summary>
    /// incoming edges (junction)
    /// </summary>
    public const byte INCOMING_EDGES = 0x7b;

    /// <summary>
    /// outgoing edges (junction)
    /// </summary>
    public const byte OUTGOING_EDGES = 0x7c;

    /// <summary>
    /// carFollowModel function followSpeed (get: vehicle)
    /// </summary>
    public const byte VAR_FOLLOW_SPEED = 0x1c;

    /// <summary>
    ///  carFollowModel function stopSpeed (get: vehicle)
    /// </summary>
    public const byte VAR_STOP_SPEED = 0x1d;

    /// <summary>
    /// carFollowModel function getSecureGap (get: vehicle)
    /// </summary>
    public const byte VAR_SECURE_GAP = 0x1e;

    // max. (physically possible) deceleration (get: vehicles, vehicle types)
    public const byte VAR_EMERGENCY_DECEL = 0x7b;

    // apparent deceleration (get: vehicles, vehicle types)
    public const byte VAR_APPARENT_DECEL = 0x7c;

    // action step length (get: vehicles, vehicle types)
    public const byte VAR_ACTIONSTEPLENGTH = 0x7d;

    // last action time (get: vehicles)
    public const byte VAR_LASTACTIONTIME = 0x7f;

    // driver's desired headway (get: vehicle types)
    public const byte VAR_TAU = 0x48;

    // vehicle class (get: vehicle types)
    public const byte VAR_VEHICLECLASS = 0x49;

    // emission class (get: vehicle types)
    public const byte VAR_EMISSIONCLASS = 0x4a;

    // shape class (get: vehicle types)
    public const byte VAR_SHAPECLASS = 0x4b;

    // minimum gap (get: vehicle types)
    public const byte VAR_MINGAP = 0x4c;

    // width (get: vehicle types, lanes)
    public const byte VAR_WIDTH = 0x4d;

    // shape (get: polygons)
    public const byte VAR_SHAPE = 0x4e;

    // type id (get: vehicles, polygons, pois)
    public const byte VAR_TYPE = 0x4f;

    // road id (get: vehicles)
    public const byte VAR_ROAD_ID = 0x50;

    // lane id (get: vehicles, induction loop, area detector)
    public const byte VAR_LANE_ID = 0x51;

    // lane index (get: vehicle, edge)
    public const byte VAR_LANE_INDEX = 0x52;

    // route id (get & set: vehicles)
    public const byte VAR_ROUTE_ID = 0x53;

    // edges (get: routes, vehicles)
    public const byte VAR_EDGES = 0x54;

    /// <summary>
    /// filled? (set: vehicles)
    /// </summary>
    public const byte VAR_STOP_PARAMETER = 0x55;

    // update bestLanes (set: vehicle)
    public const byte VAR_UPDATE_BESTLANES = 0x6a;

    // filled? (get: polygons)
    public const byte VAR_FILL = 0x55;

    // position (1D along lane) (get: vehicle)
    public const byte VAR_LANEPOSITION = 0x56;

    // route (set: vehicles)
    public const byte VAR_ROUTE = 0x57;

    // travel time information (get&set: vehicle)
    public const byte VAR_EDGE_TRAVELTIME = 0x58;

    // effort information (get&set: vehicle)
    public const byte VAR_EDGE_EFFORT = 0x59;

    // last step travel time (get: edge, lane)
    public const byte VAR_CURRENT_TRAVELTIME = 0x5a;

    // signals state (get/set: vehicle)
    public const byte VAR_SIGNALS = 0x5b;

    /// <summary>
    /// polygon: add dynamics (set: polygon)
    /// </summary>
    public const byte VAR_ADD_DYNAMICS = 0x5c;

    // new lane/position along (set: vehicle)
    public const byte VAR_MOVE_TO = 0x5c;

    // driver imperfection (set: vehicle)
    public const byte VAR_IMPERFECTION = 0x5d;

    // speed factor (set: vehicle)
    public const byte VAR_SPEED_FACTOR = 0x5e;

    // speed deviation (set: vehicle)
    public const byte VAR_SPEED_DEVIATION = 0x5f;

    // routing mode (get/set: vehicle)
    public const byte VAR_ROUTING_MODE = 0x89;

    // traffic scale factor (get/set: vehicle)
    public const byte VAR_SCALE = 0x8e;

    // speed without TraCI influence (get: vehicle)
    public const byte VAR_SPEED_WITHOUT_TRACI = 0xb1;

    // best lanes (get: vehicle)
    public const byte VAR_BEST_LANES = 0xb2;

    // how speed is set (set: vehicle)
    public const byte VAR_SPEEDSETMODE = 0xb3;

    // move vehicle to explicit (remote controlled) position (set: vehicle)
    public const byte MOVE_TO_XY = 0xb4;

    // is the vehicle stopped, and if so parked and/or triggered?
    // value = stopped + 2 * parking + 4 * triggered
    public const byte VAR_STOPSTATE = 0xb5;

    // how lane changing is performed (get/set: vehicle)
    public const byte VAR_LANECHANGE_MODE = 0xb6;

    // maximum speed regarding max speed on the current lane and speed factor (get: vehicle)
    public const byte VAR_ALLOWED_SPEED = 0xb7;

    // position (1D lateral position relative to center of the current lane) (get: vehicle)
    public const byte VAR_LANEPOSITION_LAT = 0xb8;

    // get/set preferred lateral alignment within the lane (vehicle)
    public const byte VAR_LATALIGNMENT = 0xb9;

    // get/set maximum lateral speed (vehicle, vehicle types)
    public const byte VAR_MAXSPEED_LAT = 0xba;

    // get/set minimum lateral gap (vehicle, vehicle types)
    public const byte VAR_MINGAP_LAT = 0xbb;

    // get/set vehicle height (vehicle, vehicle types)
    public const byte VAR_HEIGHT = 0xbc;

    // get/set vehicle line
    public const byte VAR_LINE = 0xbd;

    // get/set vehicle via
    public const byte VAR_VIA = 0xbe;

    /// <summary>
    ///  get (lane change relevant) neighboring vehicles (vehicles)
    /// </summary>
    public const byte VAR_NEIGHBORS = 0xbf;

    // current CO2 emission of a node (get: vehicle, lane, edge)
    public const byte VAR_CO2EMISSION = 0x60;

    // current CO emission of a node (get: vehicle, lane, edge)
    public const byte VAR_COEMISSION = 0x61;

    // current HC emission of a node (get: vehicle, lane, edge)
    public const byte VAR_HCEMISSION = 0x62;

    // current PMx emission of a node (get: vehicle, lane, edge)
    public const byte VAR_PMXEMISSION = 0x63;

    // current NOx emission of a node (get: vehicle, lane, edge)
    public const byte VAR_NOXEMISSION = 0x64;

    // current fuel consumption of a node (get: vehicle, lane, edge)
    public const byte VAR_FUELCONSUMPTION = 0x65;

    // current noise emission of a node (get: vehicle, lane, edge)
    public const byte VAR_NOISEEMISSION = 0x66;

    // current person number (get: vehicle)
    public const byte VAR_PERSON_NUMBER = 0x67;

    // number of persons waiting at a defined bus stop (get: simulation)
    public const byte VAR_BUS_STOP_WAITING = 0x67;

    /// <summary>
    /// vehicle: highlight (set: vehicle, poi)
    /// </summary>
    public const byte VAR_HIGHLIGHT = 0x6c;

    /// <summary>
    /// ids of persons waiting at a defined bus stop (get: simulation)
    /// </summary>
    public const byte VAR_BUS_STOP_WAITING_IDS = 0xef;

    /// <summary>
    /// retrieve global option value (get: simulation)
    /// </summary>
    public const byte VAR_OPTION = 0x32;

    // current leader together with gap (get: vehicle)
    public const byte VAR_LEADER = 0x68;

    // edge index in current route (get: vehicle)
    public const byte VAR_ROUTE_INDEX = 0x69;

    // current waiting time (get: vehicle, lane)
    public const byte VAR_WAITING_TIME = 0x7a;

    // current waiting time (get: vehicle)
    public const byte VAR_ACCUMULATED_WAITING_TIME = 0x87;

    // upcoming traffic lights (get: vehicle)
    public const byte VAR_NEXT_TLS = 0x70;

    // upcoming stops (get: vehicle)
    public const byte VAR_NEXT_STOPS = 0x73;

    /// <summary>
    /// upcoming stops with selection (get: vehicle)
    /// </summary>
    public const byte VAR_NEXT_STOPS2 = 0x74;

    // current acceleration (get: vehicle)
    public const byte VAR_ACCELERATION = 0x72;

    // current time in seconds (get: simulation)
    public const byte VAR_TIME = 0x66;

    // current time step (get: simulation)
    public const byte VAR_TIME_STEP = 0x70;

    // current electricity consumption of a node (get: vehicle, lane, edge)
    public const byte VAR_ELECTRICITYCONSUMPTION = 0x71;

    // number of loaded vehicles (get: simulation)
    public const byte VAR_LOADED_VEHICLES_NUMBER = 0x71;

    // loaded vehicle ids (get: simulation)
    public const byte VAR_LOADED_VEHICLES_IDS = 0x72;

    // number of departed vehicle (get: simulation)
    public const byte VAR_DEPARTED_VEHICLES_NUMBER = 0x73;

    // departed vehicle ids (get: simulation)
    public const byte VAR_DEPARTED_VEHICLES_IDS = 0x74;

    // number of vehicles starting to teleport (get: simulation)
    public const byte VAR_TELEPORT_STARTING_VEHICLES_NUMBER = 0x75;

    // ids of vehicles starting to teleport (get: simulation)
    public const byte VAR_TELEPORT_STARTING_VEHICLES_IDS = 0x76;

    // number of vehicles ending to teleport (get: simulation)
    public const byte VAR_TELEPORT_ENDING_VEHICLES_NUMBER = 0x77;

    // ids of vehicles ending to teleport (get: simulation)
    public const byte VAR_TELEPORT_ENDING_VEHICLES_IDS = 0x78;

    // number of arrived vehicles (get: simulation)
    public const byte VAR_ARRIVED_VEHICLES_NUMBER = 0x79;

    // ids of arrived vehicles (get: simulation)
    public const byte VAR_ARRIVED_VEHICLES_IDS = 0x7a;

    // delta t (get: simulation)
    public const byte VAR_DELTA_T = 0x7b;

    // bounding box (get: simulation)
    public const byte VAR_NET_BOUNDING_BOX = 0x7c;

    // minimum number of expected vehicles (get: simulation)
    public const byte VAR_MIN_EXPECTED_VEHICLES = 0x7d;

    // number of vehicles starting to park (get: simulation)
    public const byte VAR_STOP_STARTING_VEHICLES_NUMBER = 0x68;

    // ids of vehicles starting to park (get: simulation)
    public const byte VAR_STOP_STARTING_VEHICLES_IDS = 0x69;

    // number of vehicles ending to park (get: simulation)
    public const byte VAR_STOP_ENDING_VEHICLES_NUMBER = 0x6a;

    // ids of vehicles ending to park (get: simulation)
    public const byte VAR_STOP_ENDING_VEHICLES_IDS = 0x6b;

    // number of vehicles starting to park (get: simulation)
    public const byte VAR_PARKING_STARTING_VEHICLES_NUMBER = 0x6c;

    // ids of vehicles starting to park (get: simulation)
    public const byte VAR_PARKING_STARTING_VEHICLES_IDS = 0x6d;

    // number of vehicles ending to park (get: simulation)
    public const byte VAR_PARKING_ENDING_VEHICLES_NUMBER = 0x6e;

    // ids of vehicles ending to park (get: simulation)
    public const byte VAR_PARKING_ENDING_VEHICLES_IDS = 0x6f;

    /// <summary>
    /// retrieve detail data for each collision
    /// </summary>
    public const byte VAR_COLLISIONS = 0x23;

    /// <summary>
    /// return loaded vehicles regardless of visibility (excluding arrived)
    /// </summary>
    public const byte VAR_LOADED_LIST = 0x24;

    /// <summary>
    /// return teleporting vehicles
    /// </summary>
    public const byte VAR_TELEPORTING_LIST = 0x25;

    /// <summary>
    /// upcoming links(get: vehicle)
    /// </summary>
    public const byte VAR_NEXT_LINKS = 0x33;

    // number of vehicles involved in a collision (get: simulation)
    public const byte VAR_COLLIDING_VEHICLES_NUMBER = 0x80;

    // ids of vehicles involved in a collision (get: simulation)
    public const byte VAR_COLLIDING_VEHICLES_IDS = 0x81;

    // number of vehicles involved in a collision (get: simulation)
    public const byte VAR_EMERGENCYSTOPPING_VEHICLES_NUMBER = 0x89;

    // ids of vehicles involved in a collision (get: simulation)
    public const byte VAR_EMERGENCYSTOPPING_VEHICLES_IDS = 0x8a;

    // sets/retrieves abstract parameter
    public const byte VAR_PARAMETER = 0x7e;

    // add an instance (poi, polygon, vehicle, person, route)
    public const byte ADD = 0x80;

    // remove an instance (poi, polygon, vehicle, person)
    public const byte REMOVE = 0x81;

    // copy an instance (vehicle type, other TBD.)
    public const byte COPY = 0x88;

    // convert coordinates
    public const byte POSITION_CONVERSION = 0x82;

    // distance between points or vehicles
    public const byte DISTANCE_REQUEST = 0x83;

    // the current driving distance
    public const byte VAR_DISTANCE = 0x84;

    // add a fully specified instance (vehicle)
    public const byte ADD_FULL = 0x85;

    // find a car based route
    public const byte FIND_ROUTE = 0x86;

    // find an intermodal route
    public const byte FIND_INTERMODAL_ROUTE = 0x87;

    // validates current route (vehicles)
    public const byte VAR_ROUTE_VALID = 0x92;

    // retrieve information regarding the current person/container stage
    public const byte VAR_STAGE = 0xc0;

    // retrieve information regarding the next edge including crossings and walkingAreas (pedestrians only)
    public const byte VAR_NEXT_EDGE = 0xc1;

    // retrieve information regarding the number of remaining stages
    public const byte VAR_STAGES_REMAINING = 0xc2;

    // retrieve the current vehicle id for the driving stage (person, container)
    public const byte VAR_VEHICLE = 0xc3;

    // append a person stage (person)
    public const byte APPEND_STAGE = 0xc4;

    // append a person stage (person)
    public const byte REMOVE_STAGE = 0xc5;

    /// <summary>
    /// replace a person stage (person)
    /// </summary>
    public const byte REPLACE_STAGE = 0xcd;

    // the mass (vehicle)
    public const byte VAR_MASS = 0xc8;

    // zoom
    public const byte VAR_VIEW_ZOOM = 0xa0;

    // view position
    public const byte VAR_VIEW_OFFSET = 0xa1;

    // view schema
    public const byte VAR_VIEW_SCHEMA = 0xa2;

    // view by boundary
    public const byte VAR_VIEW_BOUNDARY = 0xa3;

    // screenshot
    public const byte VAR_SCREENSHOT = 0xa5;

    // track vehicle
    public const byte VAR_TRACK_VEHICLE = 0xa6;

    // presence of view
    public const byte VAR_HAS_VIEW = 0xa7;

    // TODO: LCA definitions should use flag
    public const int LCA_RIGHT = 4;
    public const int LCA_LEFT = 2;
    public const int LCA_BLOCKED = 268459520;
    public const int LCA_UNKNOWN = 1073741824;

    /// <summary>
    /// full name (get: edges, simulation, traffic light)
    /// </summary>
    public const byte VAR_NAME = 0x1b;

    /// <summary>
    /// begin time(get: calibrator)
    /// </summary>
    public const byte VAR_BEGIN = 0x1c;

    /// <summary>
    /// end time(get: calibrator, simulation)
    /// </summary>
    public const byte VAR_END = 0x1d;

    /// <summary>
    /// inserted vehicle count (get: calibrator)
    /// </summary>
    public const byte VAR_INSERTED = 0x15;

    /// <summary>
    /// passed vehicle count (get: calibrator)
    /// </summary>
    public const byte VAR_PASSED = 0x14;

    /// <summary>
    /// removed vehicle count (get: calibrator)
    /// </summary>
    public const byte VAR_REMOVED = 0x16;

    /// <summary>
    /// routeProbe id (get: calibrator)
    /// </summary>
    public const byte VAR_ROUTE_PROBE = 0x17;

    /// <summary>
    /// vehicle type list (get: calibrator)
    /// </summary>
    public const byte VAR_VTYPES = 0x1e;

    /// <summary>
    /// vehicles per hour (get: calibrator)
    /// </summary>
    public const byte VAR_VEHSPERHOUR = 0x13;

    // below 4 not found in python source code,their name may not right
    public const byte VAR_CHARGING_POWER = 0x97;
    public const byte VAR_CHARGING_EFFICIENCY = 0x98;
    public const byte VAR_CHARGING_TRANSIT = 0x99;
    public const byte VAR_CHARGING_DELAY = 0x9a;

    public const byte VAR_BADGES = 0x9b;
    }
