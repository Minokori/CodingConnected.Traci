using System.Text;
using static System.BitConverter;
using static CodingConnected.TraCI.NET.DataTypes.TraCIConstants;

namespace CodingConnected.TraCI.NET.DataTypes;

/// <summary>
/// Implementing this interface indicates that the class is a traci data type.
/// </summary>
/// <remarks>
/// the class inplement this interface also has:
/// <list type="bullet">
/// <item> a static method: Frombytes(bytes), whitch returns a tuple of the class and the remaining bytes.</item>
/// <item> a public property: Value, whitch returns the value of the traci type with its really class (int,string,etc).</item>
/// </list>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#data_types"/>
/// </remarks>
public interface ITraciType
    {
    /// <summary>
    /// The type identifer of the Traci data type.
    /// </summary>
    /// <remarks>
    /// see <see href="https://sumo.dlr.de/pydoc/traci.constants.html"/>
    /// </remarks>
    public byte TYPE { get; }

    /// <summary>
    /// convert the data to bytes for TCP.
    /// </summary>
    /// <returns>bytes that send to TCP port</returns>
    byte[] ToBytes()
        {
        return [];
        }
    }

/// <summary>
/// <see cref="byte"/> value in Traci
/// </summary>
public class TraCIByte : ITraciType
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

/// <summary>
/// unsigned <see cref="byte"/> value in traci
/// </summary>
public class TraCIUByte : ITraciType
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

/// <summary>
/// <see cref="double"/> value in traci
/// </summary>
public class TraCIDouble : ITraciType
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

/// <summary>
/// <see cref="float"/> value in traci
/// </summary>
public class TraCIFloat : ITraciType
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

/// <summary>
/// <see cref="int"/> value in traci
/// </summary>
public class TraCIInteger : ITraciType
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

/// <summary>
/// <see cref="string"/> value in traci
/// </summary>
public class TraCIString : ITraciType
    {
    public byte TYPE { get; } = TYPE_STRING;
    public string Value { get; set; }

    public byte[] ToBytes() => [.. GetBytes(Value.Length).Reverse(), .. Encoding.ASCII.GetBytes(Value)];

    public static Tuple<TraCIString, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var length = ToInt32(bytes.Take(INTEGER_SIZE).Reverse().ToArray());
        return new(
            new TraCIString { Value = Encoding.ASCII.GetString(bytes.Skip(INTEGER_SIZE).Take(length).ToArray()) },
            bytes.Skip(INTEGER_SIZE + length)
        );
        }

    public static byte[] AsBytes(string value) => [.. GetBytes(value.Length).Reverse(), .. Encoding.ASCII.GetBytes(value)];
    }

/// <summary>
/// <see cref="List{T}"/> of <see cref="string"/> value in traci
/// </summary>
/// <remarks>
/// this class is inherited from <see cref="List{T}"/> of <see cref="TraCIString"/>
/// </remarks>
public class TraCIStringList : List<TraCIString>, ITraciType
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
        TraCIStringList strings = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = TraCIString.FromBytes(bytes);
            strings.Add(result);
            }
        return new(strings, bytes);
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

public class TraCIDoubleList : List<TraCIDouble>, ITraciType
    {
    public byte TYPE => TYPE_DOUBLELIST;

    public List<double> Value
        {
        get => this.Select(i => i.Value).ToList();
        set
            {
            this.Clear();
            foreach (var str in value)
                {
                this.Add(new TraCIDouble { Value = str });
                }
            }
        }

    public byte[] ToBytes()
        {
        List<byte> bytes = [.. GetBytes(this.Count).Reverse()];
        foreach (var d in this)
            {
            bytes.AddRange(d.ToBytes());
            }
        return [.. bytes];
        }

    public static Tuple<TraCIDoubleList, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        var count = ToInt32(bytes.Take(INTEGER_SIZE).Reverse().ToArray());
        bytes = bytes.Skip(INTEGER_SIZE);
        TraCIDoubleList doubles = [];
        for (var i = 0; i < count; i++)
            {
            (var result, bytes) = TraCIDouble.FromBytes(bytes);
            doubles.Add(result);
            }
        return new(doubles, bytes);
        }

    public static byte[] AsBytes(List<double> value)
        {
        List<byte> bytes = [.. TraCIInteger.AsBytes(value.Count)];
        foreach (var d in value)
            {
            bytes.AddRange(TraCIDouble.AsBytes(d));
            }
        return [.. bytes];
        }

    }

/// <summary>
/// a <see cref="List{T}"/> of <see cref="ITraciType"/> values
/// </summary>
/// <remarks>
/// Compound object, internal structure depends on inner object.
/// </remarks>
public class TraCICompoundObject : List<ITraciType>, ITraciType
    {
    /// <summary>
    /// only in completed TLS define is true
    /// </summary>
    protected virtual bool IsCountEqualsZero => false;


    /// <summary>
    /// when <see cref="ToBytes"/>, add count or not
    /// </summary>
    /// <remarks>
    /// If a class inherited from <see cref="TraCICompoundObject"/> is a subList of other class inherited from <see cref="TraCICompoundObject"/>,
    /// may be the count shouldn't be added.
    /// In theses cases, ovverride this property to false.
    /// </remarks>
    protected virtual bool ShouldAddCountToBytes => true;
    public byte TYPE { get; } = TYPE_COMPOUND;

    public byte[] ToBytes()
        {
        List<byte> bytes = [];
        bytes.AddRange(ShouldAddCountToBytes ? new TraCIInteger() { Value = IsCountEqualsZero ? 0 : Count }.ToBytes() : []);
        foreach (var item in this)
            {
            bytes.Add(item.TYPE);
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }

    public static Tuple<TraCICompoundObject, IEnumerable<byte>> FromBytes(IEnumerable<byte> bytes)
        {
        throw new NotImplementedException($"{nameof(TraCICompoundObject)} cannot frombytes directly cause the class inner it is uncertained");
        }

    public static byte[] AsBytes(List<ValueType> value)
        {
        throw new NotImplementedException($"{nameof(TraCICompoundObject)} cannot asbytes directly cause the class inner it is uncertained");
        }
    }
