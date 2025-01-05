using System.Text;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.Constants.TraCIConstants;

namespace CodingConnected.TraCI.NET.Types;

public class TraCIByte : ITraCIType
    {
    public byte TYPE { get; } = TYPE_BYTE;
    public byte Value { get; set; }
    public byte[] ToBytes() => [Value];

    public static Tuple<TraCIByte, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        return new(new TraCIByte { Value = bytes.First() }, bytes.Skip(1));
        }

    public static byte[] AsBytes(byte value) => [value];
    }
public class TraCIUByte : ITraCIType
    {
    public byte TYPE { get; } = TYPE_UBYTE;
    public byte Value { get; set; }
    public byte[] ToBytes() => [Value];
    public static Tuple<TraCIUByte, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        return new(new TraCIUByte { Value = bytes.First() }, bytes.Skip(1));
        }

    public static byte[] AsBytes(byte value) => [value];
    }
public class TraCIDouble : ITraCIType
    {
    public byte TYPE { get; } = TYPE_DOUBLE;

    public double Value { get; set; }
    public byte[] ToBytes() => GetBytes(Value).Reverse().ToArray();

    public static Tuple<TraCIDouble, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        return new(new TraCIDouble { Value = ToDouble(bytes.Take(DOUBLE_SIZE).Reverse().ToArray()) }, bytes.Skip(DOUBLE_SIZE));
        }

    public static byte[] AsBytes(double value) => GetBytes(value).Reverse().ToArray();
    }
public class TraCIFloat : ITraCIType
    {
    public byte TYPE { get; } = TYPE_FLOAT;
    public float Value { get; set; }
    public byte[] ToBytes() => GetBytes(Value).Reverse().ToArray();

    public static Tuple<TraCIFloat, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        return new(new TraCIFloat { Value = ToSingle(bytes.Take(FLOAT_SIZE).Reverse().ToArray()) }, bytes.Skip(FLOAT_SIZE));
        }

    public static byte[] AsBytes(float value) => GetBytes(value).Reverse().ToArray();
    }

public class TraCIInteger : ITraCIType
    {
    public byte TYPE { get; } = TYPE_INTEGER;
    public int Value { get; set; }
    public byte[] ToBytes() => GetBytes(Value).Reverse().ToArray();

    public static Tuple<TraCIInteger, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        return new(new TraCIInteger { Value = ToInt32(bytes.Take(INTEGER_SIZE).Reverse().ToArray()) }, bytes.Skip(INTEGER_SIZE));
        }
    public static byte[] AsBytes(int value) => GetBytes(value).Reverse().ToArray();
    }
public class TraCIString : ITraCIType
    {
    public byte TYPE { get; } = TYPE_STRING;
    public string Value { get; set; }
    public byte[] ToBytes() => [.. GetBytes(Value.Length).Reverse(), .. Encoding.ASCII.GetBytes(Value)];

    public static Tuple<TraCIString, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var length = ToInt32(bytes.Take(INTEGER_SIZE).Reverse().ToArray());
        return new(new TraCIString { Value = Encoding.ASCII.GetString(bytes.Skip(INTEGER_SIZE).Take(length).ToArray()) }, bytes.Skip(INTEGER_SIZE + length));
        }

    public static byte[] AsBytes(string value) => [.. GetBytes(value.Length).Reverse(), .. Encoding.ASCII.GetBytes(value)];
    }
public class TraCIStringList : List<TraCIString>, ITraCIType
    {
    public byte TYPE { get; } = TYPE_STRINGLIST;
    public List<string> Value
        {
        get => this.Select(i => i.Value).ToList();
        set
            {
            this.Clear();
            foreach (var str in value)
                {
                this.Add(new TraCIString { Value = str });
                }
            }
        }
    public byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(this.Count).Reverse()];
        foreach (var str in this)
            {
            bytes.AddRange(str.ToBytes());
            }
        return [.. bytes];
        }

    public static Tuple<TraCIStringList, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var count = ToInt32(bytes.Take(INTEGER_SIZE).Reverse().ToArray());
        bytes = bytes.Skip(INTEGER_SIZE);
        List<TraCIString> strings = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = TraCIString.FromBytes(bytes);
            strings.Add(result);
            }
        return new(strings as TraCIStringList, bytes);
        }
    public static byte[] AsBytes(List<string> value)
        {
        List<byte> bytes = [.. TraCIInteger.AsBytes(value.Count)];
        foreach (var str in value)
            {
            bytes.AddRange(TraCIString.AsBytes(str));
            }
        return [.. bytes];
        }
    }