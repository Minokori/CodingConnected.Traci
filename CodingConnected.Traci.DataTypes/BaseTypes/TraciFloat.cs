using System.Buffers.Binary;

namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="float"/> value in traci
/// </summary>
public sealed class TraciFloat(float value) : TraciBaseType<float>(value), ITraciType, ITraciParserable<TraciFloat>
    {
    public override DataType TypeIdentifier => DataType.Float;


    public override void WriteToSpan(Span<byte> destination, ref int offset)
        {
        BinaryPrimitives.WriteSingleBigEndian(destination[offset..], Value);
        offset += DataSize.FloatSize;
        }


    public static TraciFloat Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        TraciFloat result = new(BinaryPrimitives.ReadSingleBigEndian(source[..DataSize.FloatSize]));
        remaining = source[DataSize.FloatSize..];
        return result;
        }
    }
