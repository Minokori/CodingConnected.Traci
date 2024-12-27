using System.Text;
namespace TraCI.Protocol.DataTypes;

public class TraCIByte
    {
    public SByte Value { get; set; }
    }
public class TraCIUByte
    {
    public byte Value { get; set; }

    }
public class TraCIDouble
    {

    public double Value { get; set; }
    public byte[] ToBytes() => BitConverter.GetBytes(Value).Reverse().ToArray();

    }
public class TraCIFloat
    {
    public float Value { get; set; }
    public byte[] ToBytes() => BitConverter.GetBytes(Value).Reverse().ToArray();

    }

public class TraCIInteger
    {
    public int Value { get; set; }
    public byte[] ToBytes() => BitConverter.GetBytes(Value).Reverse().ToArray();

    }
public class TraCIString
    {
    public required string Value { get; set; }
    public byte[] ToBytes() => [.. BitConverter.GetBytes(Value.Length).Reverse(), .. Encoding.ASCII.GetBytes(Value)];
    }
public class TraCIStringList
    {
    public List<string> Value { get; set; } = [];
    }
