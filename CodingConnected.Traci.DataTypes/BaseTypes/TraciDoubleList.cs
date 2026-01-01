using System.Buffers.Binary;

namespace CodingConnected.Traci.DataTypes;

public sealed class TraciDoubleList
    : TraciListType<TraciDouble, double>,
        ITraciType,
        ITraciParserable<TraciDoubleList>
    {
    public override DataType TypeIdentifier => DataType.DoubleList;


    public static TraciDoubleList Parse(
        ReadOnlySpan<byte> source,
        out ReadOnlySpan<byte> remaining
    )
        {
        var count = BinaryPrimitives.ReadInt32BigEndian(source);
        var bytes = source[DataSize.IntegerSize..];
        TraciDoubleList doubles = [];
        for (var i = 0; i < count; i++)
            {
            var result = TraciDouble.Parse(bytes, out bytes);
            doubles.Add(result);
            }
        remaining = bytes;
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
