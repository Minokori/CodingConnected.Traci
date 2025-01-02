using CodingConnected.TraCI.NET.Helpers;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Types;

public struct LonLatAltPosition : ITraCIType
    {
    public readonly byte TYPE => POSITION_LON_LAT_ALT;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Altitude { get; set; }

    public readonly byte[] ToBytes() => [.. Longitude.ToTraCIBytes(), .. Latitude.ToTraCIBytes(), .. Altitude.ToTraCIBytes()];

    public static Tuple<LonLatAltPosition, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var result = new LonLatAltPosition()
            {
            Longitude = ToDouble(bytes.Take(DOUBLE_SIZE).Reverse().ToArray()),
            Latitude = ToDouble(bytes.Skip(DOUBLE_SIZE).Take(DOUBLE_SIZE).Reverse().ToArray()),
            Altitude = ToDouble(bytes.Skip(DOUBLE_SIZE * 2).Take(DOUBLE_SIZE).Reverse().ToArray())
            };
        return new(result, bytes.Skip(DOUBLE_SIZE * 3));
        }
    }
