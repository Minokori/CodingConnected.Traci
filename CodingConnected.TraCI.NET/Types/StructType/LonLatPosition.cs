using CodingConnected.TraCI.NET.Helpers;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
namespace CodingConnected.TraCI.NET.Types;

public struct LonLatPosition : ITraCIType
    {
    public readonly byte TYPE => POSITION_LON_LAT;
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public readonly byte[] ToBytes() => [.. Longitude.ToTraCIBytes(), .. Latitude.ToTraCIBytes()];

    public static Tuple<LonLatPosition, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var result = new LonLatPosition()
            {
            Longitude = ToDouble(bytes.Take(DOUBLE_SIZE).Reverse().ToArray()),
            Latitude = ToDouble(bytes.Skip(DOUBLE_SIZE).Take(DOUBLE_SIZE).Reverse().ToArray()),
            };
        return new(result, bytes.Skip(DOUBLE_SIZE * 2));
        }
    }
