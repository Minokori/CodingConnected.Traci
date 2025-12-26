using System.Buffers.Binary;
using static System.BitConverter;

namespace CodingConnected.Traci.DataTypes;

public sealed class TraciDoubleList
    : TraciListType<TraciDouble, double>,
        ITraciType,
        IFromTraci<TraciDoubleList>
    {
    public override DataType TypeIdentifier => DataType.DOUBLELIST;

    public override byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(Count).Reverse()];
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }


    public static TraciDoubleList FromSpan(
        ReadOnlySpan<byte> sourceBytes,
        out ReadOnlySpan<byte> remainingBytes
    )
        {
        var count = BinaryPrimitives.ReadInt32BigEndian(sourceBytes);
        var bytes = sourceBytes[DataSize.INTEGER_SIZE..];
        TraciDoubleList doubles = [];
        for (var i = 0; i < count; i++)
            {
            var result = TraciDouble.FromSpan(bytes, out bytes);
            doubles.Add(result);
            }
        remainingBytes = bytes;
        return doubles;
        }

    public TraciDoubleList(IList<double>? value = null)
        {
        foreach (var item in value is null ? [] : value)
            {
            Add(new(item));
            }
        }
    }
