using System.Buffers.Binary;
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="List{T}"/> of <see cref="string"/> value in traci
/// </summary>
/// <remarks>
/// this class is inherited from <see cref="List{T}"/> of <see cref="TraciString"/>
/// </remarks>
public sealed class TraciStringList : TraciListType<TraciString, string>, ITraciType, ITraciParserable<TraciStringList>
    {
    public override DataType TypeIdentifier => DataType.StringList;



    public static TraciStringList Parse(ReadOnlySpan<byte> source, out ReadOnlySpan<byte> remaining)
        {
        var count = BinaryPrimitives.ReadInt32BigEndian(source);
        ReadOnlySpan<byte> bytes = source[DataSize.IntegerSize..];
        TraciStringList strings = [];
        for (var i = 0; i < count; i++)
            {
            TraciString result = TraciString.Parse(bytes, out bytes);
            strings.Add(result);
            }
        remaining = bytes;
        return strings;
        }

    public TraciStringList(IList<string>? value = null)
        {
        foreach (var str in value is null ? [] : value)
            {
            Add(new(str));
            }
        }


    }


