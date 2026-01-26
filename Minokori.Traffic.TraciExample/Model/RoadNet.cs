using System.Text.Json.Serialization;

namespace Minokori.Traffic.TraciExample.Model;

/// <summary>
/// 路网信息
/// </summary>
internal record struct RoadNet
    {
    /// <summary>
    /// 车道编号
    /// </summary>
    [JsonPropertyName("laneId")]
    public string LaneId;
    /// <summary>
    /// 路段编号
    /// </summary>
    [JsonPropertyName("rid")]
    public string EdgeId;
    /// <summary>
    /// 路口编号
    /// </summary>
    [JsonPropertyName("crossId")]
    public string JunctionId;
    }

internal record struct VehicleData
    {
    /// <summary>
    /// 车辆编号
    /// </summary>
    [JsonPropertyName("id")]
    public int Id;

    [JsonPropertyName("roadnet")]
    public RoadNet RoadNet;

    [JsonPropertyName("longitude")]
    public double Longitude;
    [JsonPropertyName("latitude")]
    public double Latitude;

    /// <summary>
    /// 速度, cm/s
    /// </summary>
    [JsonPropertyName("speed")]
    public double Speed;

    [JsonPropertyName("courseAngle")]
    public double CourseAngle;

    [JsonPropertyName("picLicense")]
    public string License;

    [JsonPropertyName("timestamp")]
    public DateTime TimeStamp;
    }

internal record struct InTimeData
    {
    [JsonPropertyName("timestamp")]
    public DateTime TimeStamp;

    [JsonPropertyName("vehicles")]
    public List<VehicleData> VehicleData;

    [JsonPropertyName("unknownVehicles")]
    public List<VehicleData> UnknownVehicles;

    public readonly VehicleData this[string picLicence]
        {
        get
            {
            foreach (var vehicle in VehicleData)
                {
                if (vehicle.License == picLicence)
                    {
                    return vehicle;
                    }
                }
            throw new KeyNotFoundException($"Vehicle with ID {picLicence} not found.");
            }
        }
    }