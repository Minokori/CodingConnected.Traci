using System.Buffers.Binary;
using System.Diagnostics;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="double"/> value in traci
/// </summary>
[DebuggerDisplay("double {Value}")]
public sealed class TraciDouble(double value, bool raw = false)
    : TraciBaseType<double>(value), ITraciType, ITraciParserable<TraciDouble>
    {
    public override DataType TypeIdentifier => raw ? DataType.Null : DataType.Double;


    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteDoubleBigEndian(destination.Slice(offset, DataSize.DoubleSize), Value);
        offset += DataSize.DoubleSize;
        }

    public static TraciDouble Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        TraciDouble result = new(BinaryPrimitives.ReadDoubleBigEndian(source));
        remaining = source[DataSize.DoubleSize..];
        return result;
        }

    }
