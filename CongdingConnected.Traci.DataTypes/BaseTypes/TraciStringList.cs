using System.Buffers.Binary;
using static System.BitConverter;
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="List{T}"/> of <see cref="string"/> value in traci
/// </summary>
/// <remarks>
/// this class is inherited from <see cref="List{T}"/> of <see cref="TraciString"/>
/// </remarks>
public sealed class TraciStringList : TraciListType<TraciString, string>, ITraciType, IFromTraci<TraciStringList>
    {
    public override DataType TypeIdentifier => DataType.STRINGLIST;


    public override byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(Count).Reverse()];
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }


    public static TraciStringList FromSpan(ReadOnlySpan<byte> sourceBytes, out ReadOnlySpan<byte> remainingBytes)
        {
        var count = BinaryPrimitives.ReadInt32BigEndian(sourceBytes);
        ReadOnlySpan<byte> bytes = sourceBytes[DataSize.INTEGER_SIZE..];
        TraciStringList strings = [];
        for (var i = 0; i < count; i++)
            {
            TraciString result = TraciString.FromSpan(bytes, out bytes);
            strings.Add(result);
            }
        remainingBytes = bytes;
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


