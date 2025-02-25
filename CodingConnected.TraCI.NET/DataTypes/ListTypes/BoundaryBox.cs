#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using static CodingConnected.TraCI.NET.DataTypes.TraciConstants;

namespace CodingConnected.TraCI.NET.DataTypes;

public class BoundaryBox : TraciListType<TraciDouble, double>
    {
    public override byte TYPE => DataType.BOUNDINGBOX;
    public double LowerLeftX => this[0].Value;
    public double LowerLeftY => this[1].Value;
    public double UpperRightX => this[2].Value;
    public double UpperRightY => this[3].Value;

    public static new (BoundaryBox boundaryBox, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        (var lowerLeftX, bytes) = TraciDouble.FromBytes(bytes);
        (var lowerLeftY, bytes) = TraciDouble.FromBytes(bytes);
        (var upperRightX, bytes) = TraciDouble.FromBytes(bytes);
        (var upperRightY, bytes) = TraciDouble.FromBytes(bytes);
        BoundaryBox result = [lowerLeftX, lowerLeftY, upperRightX, upperRightY];
        return new(result, bytes);
        }

    private BoundaryBox() { }

    public BoundaryBox(double lowerLeftX, double lowerLeftY, double upperLeftX, double upperRightY)
        {
        this[0] = new(lowerLeftX);
        this[1] = new(lowerLeftY);
        this[2] = new(upperLeftX);
        this[3] = new(upperRightY);
        }
    public void Deconstruct(out double lowerLeftX, out double lowerLeftY, out double upperRightX, out double upperRightY)
        {
        lowerLeftX = LowerLeftX; lowerLeftY = LowerLeftY; upperRightX = UpperRightX; upperRightY = UpperRightY;
        }
    }
