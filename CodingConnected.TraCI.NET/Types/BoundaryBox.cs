namespace CodingConnected.TraCI.NET.Types;

public struct BoundaryBox : ITraCIType
    {
    public double LowerLeftX { get; set; }
    public double LowerLeftY { get; set; }
    public double UpperRightX { get; set; }
    public double UpperRightY { get; set; }
    }
