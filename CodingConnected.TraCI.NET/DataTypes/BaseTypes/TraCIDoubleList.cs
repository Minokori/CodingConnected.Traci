using CodingConnected.TraCI.NET.Constants;
using static System.BitConverter;
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;

public sealed class TraCIDoubleList : TraciListType<TraciDouble, double>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.DOUBLELIST;
    public override byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(Count).Reverse()];
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }

    public static new (TraCIDoubleList traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        var count = ToInt32(bytes.Take(DataSize.INTEGER_SIZE).Reverse().ToArray());
        bytes = bytes.Skip(DataSize.INTEGER_SIZE);
        TraCIDoubleList doubles = [];
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

    public TraCIDoubleList(List<double>? value = null) => value?.ForEach(d => Add(new(d)));

    }
