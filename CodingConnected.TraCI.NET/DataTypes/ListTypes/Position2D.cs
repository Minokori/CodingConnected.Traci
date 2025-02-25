#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配

using static CodingConnected.TraCI.NET.DataTypes.TraciConstants.PositionType;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// A cartesian 2D position within the simulation network,
/// described by two double values (x and y coordinate).
/// </summary>
public class Position2D : TraciListType<TraciDouble, double>, ITraciType
    {
    public override byte TYPE => X_Y;
    public double X => this[0].Value;
    public double Y => this[1].Value;

    public static new (Position2D position2D, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        (var x, bytes) = TraciDouble.FromBytes(bytes);
        (var y, bytes) = TraciDouble.FromBytes(bytes);
        Position2D result = [x, y];
        return new(result, bytes);
        }

    private Position2D() { }

    public Position2D(double x, double y)
        {
        this[0] = new(x);
        this[1] = new(y);
        }
    }
