using System.Diagnostics;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="byte"/> value in Traci
/// </summary>
/// <remarks>
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </remarks>
[DebuggerDisplay("byte {Value}")]
public sealed class TraciByte(byte value) : TraciBaseType<byte>(value), ITraciType, ITraciParserable<TraciByte>
    {
    public override DataType TypeIdentifier => DataType.Byte;

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        destination[offset] = Value;
        offset += 1;
        }

    public static TraciByte Parse(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        TraciByte result = new(sourceBytes[0]);
        remainingBytes = sourceBytes[1..];
        return result;
        }
    }
