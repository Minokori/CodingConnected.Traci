namespace CodingConnected.Traci.DataTypes;

public sealed class BoundaryBox : TraciListType<TraciDouble, double>
    {
    public override DataType TypeIdentifier => DataType.BOUNDINGBOX;
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
