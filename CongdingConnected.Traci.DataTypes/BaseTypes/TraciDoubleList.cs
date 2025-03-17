using static System.BitConverter;
namespace CodingConnected.Traci.DataTypes;

public sealed class TraciDoubleList : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.DOUBLELIST;
    public override byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(Count).Reverse()];
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }

    public static new (TraciDoubleList traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        var count = ToInt32(bytes.Take(DataSize.INTEGER_SIZE).Reverse().ToArray());
        bytes = bytes.Skip(DataSize.INTEGER_SIZE);
        TraciDoubleList doubles = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = TraciDouble.FromBytes(bytes);
            doubles.Add(result);
            }
        return new(doubles, bytes);
        }

    public static byte[] AsBytes(List<double> value)
        {
        List<byte> bytes = [.. TraciInteger.AsBytes(value.Count)];
        foreach (var d in value)
            {
            bytes.AddRange(TraciDouble.AsBytes(d));
            }
        return [.. bytes];
        }

    public TraciDoubleList(List<double>? value = null) => value?.ForEach(d => Add(new(d)));

    }
