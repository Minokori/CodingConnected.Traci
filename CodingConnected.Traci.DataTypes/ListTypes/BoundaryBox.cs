namespace CodingConnected.Traci.DataTypes;

public sealed class BoundaryBox : TraciListType<TraciDouble, double>, ITraciParserable<BoundaryBox>
    {
    public override DataType TypeIdentifier => DataType.BoundingBox;
    public double LowerLeftX => this[0];
    public double LowerLeftY => this[1];
    public double UpperRightX => this[2];
    public double UpperRightY => this[3];

    public static BoundaryBox Parse(
        ReadOnlySpan<byte> source,
        out ReadOnlySpan<byte> remaining
    )
        {
        var lowerLeftX = TraciDouble.Parse(source, out source);
        var lowerLeftY = TraciDouble.Parse(source, out source);
        var upperRightX = TraciDouble.Parse(source, out source);
        var upperRightY = TraciDouble.Parse(source, out remaining);
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
