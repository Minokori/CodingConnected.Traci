using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public struct BoundaryBox : ITraCIType
    {
    public readonly byte TYPE => TraCIConstants.TYPE_BOUNDINGBOX;
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
    }
