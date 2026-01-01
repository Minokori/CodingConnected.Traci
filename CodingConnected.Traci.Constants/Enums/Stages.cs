namespace CodingConnected.Traci.Constants;

/// <summary>
/// PERSON/CONTAINER STAGES
/// </summary>
public enum Stages : int
    {
    /// <summary>
    /// person / container stopping
    /// </summary>
    WaitingForDepart = 0x00,
    /// <summary>
    /// person / container stopping
    /// </summary>
    Waiting = 0x01,
    /// <summary>
    /// person walking / container transshipping
    /// </summary>
    Walking = 0x02,
    /// <summary>
    /// person riding / container being transported
    /// </summary>
    Driving = 0x03,
    /// <summary>
    /// person accessing stopping place
    /// </summary>
    Access = 0x04,
    /// <summary>
    /// stage for encoding abstract travel demand
    /// </summary>
    Trip = 0x05,
    /// <summary>
    /// person / container transhiping
    /// </summary>
    Tranship = 0x06
    }
