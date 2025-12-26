namespace CodingConnected.Traci.DataTypes;

public sealed class BoundaryBox : TraciListType<TraciDouble, double>, IFromTraci<BoundaryBox>
    {
    public override DataType TypeIdentifier => DataType.BOUNDINGBOX;
    public double LowerLeftX => this[0];
    public double LowerLeftY => this[1];
    public double UpperRightX => this[2];
    public double UpperRightY => this[3];

    public static BoundaryBox FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var lowerLeftX = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var lowerLeftY = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var upperRightX = TraciDouble.FromSpan(sourceBytes, out sourceBytes);
        var upperRightY = TraciDouble.FromSpan(sourceBytes, out remainingBytes);
        return [lowerLeftX, lowerLeftY, upperRightX, upperRightY];
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
