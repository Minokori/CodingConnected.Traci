using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Types;

public struct BoundaryBox : ITraCIType
    {
    public readonly byte TYPE => TYPE_BOUNDINGBOX;
    public TraCIDouble LowerLeftX { get; set; }
    public TraCIDouble LowerLeftY { get; set; }
    public TraCIDouble UpperRightX { get; set; }
    public TraCIDouble UpperRightY { get; set; }


    public readonly byte[] ToBytes() =>
        [
            .. LowerLeftX.ToBytes(),
            .. LowerLeftY.ToBytes(),
            .. UpperRightX.ToBytes(),
            .. UpperRightY.ToBytes(),
        ];

    public static Tuple<BoundaryBox, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        (var lx, bytes) = TraCIDouble.FromBytes(bytes);
        (var ly, bytes) = TraCIDouble.FromBytes(bytes);
        (var ux, bytes) = TraCIDouble.FromBytes(bytes);
        (var uy, bytes) = TraCIDouble.FromBytes(bytes);
        BoundaryBox result = new()
            {
            LowerLeftX = lx,
            LowerLeftY = ly,
            UpperRightX = ux,
            UpperRightY = uy,
            };

        return new(result, bytes);
        }
    }
