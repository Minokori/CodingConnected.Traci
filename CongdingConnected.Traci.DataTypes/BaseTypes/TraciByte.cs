using System.Diagnostics;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="byte"/> value in Traci
/// </summary>
/// <remarks>
/// TODO it may should use <see cref="sbyte"/> instead of <see cref="byte"/>
/// </remarks>
[DebuggerDisplay("byte {Value}")]
public sealed class TraciByte(byte value) : TraciBaseType<byte>(value), ITraciType, IFromTraci<TraciByte>
    {
    public override DataType TypeIdentifier => DataType.BYTE;

    public override byte[] ToBytes() => [Value];

    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        destination[offset] = Value;
        offset += 1;
        }

    public static TraciByte FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        TraciByte result = new(sourceBytes[0]);
        remainingBytes = sourceBytes[1..];
        return result;
        }
    }
