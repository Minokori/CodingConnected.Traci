using static CodingConnected.TraCI.NET.Constants.TraCIConstants;
using CodingConnected.TraCI.NET.Helpers;
using static System.BitConverter;

namespace CodingConnected.TraCI.NET.Types;

public struct BoundaryBox : ITraCIType
    {
    public readonly byte TYPE => TYPE_BOUNDINGBOX;
    public double LowerLeftX { get; set; }
    public double LowerLeftY { get; set; }
    public double UpperRightX { get; set; }
    public double UpperRightY { get; set; }


    public readonly byte[] ToBytes() =>
        [
            .. LowerLeftX.ToTraCIBytes(),
            .. LowerLeftY.ToTraCIBytes(),
            .. UpperRightX.ToTraCIBytes(),
            .. UpperRightY.ToTraCIBytes(),
        ];

    public static Tuple<BoundaryBox, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        BoundaryBox result = new()
            {
            LowerLeftX = ToDouble(bytes.Take(DOUBLE_SIZE).Reverse().ToArray()),
            LowerLeftY = ToDouble(bytes.Skip(DOUBLE_SIZE).Take(DOUBLE_SIZE).Reverse().ToArray()),
            UpperRightX = ToDouble(bytes.Skip(DOUBLE_SIZE * 2).Take(DOUBLE_SIZE).Reverse().ToArray()),
            UpperRightY = ToDouble(bytes.Skip(DOUBLE_SIZE * 3).Take(DOUBLE_SIZE).Reverse().ToArray())
            };

        return new(result, bytes.Skip(DOUBLE_SIZE * 4));
        }
    }
