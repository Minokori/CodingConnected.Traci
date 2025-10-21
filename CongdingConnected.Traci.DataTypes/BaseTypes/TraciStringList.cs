using static System.BitConverter;
namespace CodingConnected.Traci.DataTypes;

/// <summary>
/// <see cref="List{T}"/> of <see cref="string"/> value in traci
/// </summary>
/// <remarks>
/// this class is inherited from <see cref="List{T}"/> of <see cref="TraciString"/>
/// </remarks>
public sealed class TraciStringList : TraciListType<TraciString, string>, ITraciType
    {
    public override DataType TypeIdentifier => DataType.STRINGLIST;


    public override byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(this.Count).Reverse()];
        bytes.AddRange(base.ToBytes());
        return [.. bytes];
        }

    public static new (TraciStringList traciData, IEnumerable<byte> remainingBytes) FromBytes(IEnumerable<byte> bytes)
        {
        var count = ToInt32(bytes.Take(DataSize.INTEGER_SIZE).Reverse().ToArray());
        bytes = bytes.Skip(DataSize.INTEGER_SIZE);
        TraciStringList strings = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = TraciString.FromBytes(bytes);
            strings.Add(result);
            }
        return new(strings, bytes);
        }

    public TraciStringList(List<string>? value = null) => value?.ForEach(str => Add(new(str)));

    }


