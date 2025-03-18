namespace CodingConnected.Traci.DataTypes;

public sealed class BoundaryBox : TraciListType<TraciDouble, double>
    {
    public override DataType TypeIdentifier => DataType.BOUNDINGBOX;
    public double LowerLeftX => this[0];
    public double LowerLeftY => this[1];
    public double UpperRightX => this[2];
    public double UpperRightY => this[3];

    public static new (BoundaryBox boundaryBox, IEnumerable<byte> remainingBytes) FromBytes(
        IEnumerable<byte> bytes
    )
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
        Clear();
        Add(new(lowerLeftX));
        Add(new(lowerLeftY));
        Add(new(upperLeftX));
        Add(new(upperRightY));
        }

    public void Deconstruct(
        out double lowerLeftX,
        out double lowerLeftY,
        out double upperRightX,
        out double upperRightY
    )
        {
        lowerLeftX = LowerLeftX;
        lowerLeftY = LowerLeftY;
        upperRightX = UpperRightX;
        upperRightY = UpperRightY;
        }
    }
