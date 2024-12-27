using System.Text;
using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

public class TraCIByte : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_BYTE;
    public byte Value { get; set; }
    public byte[] ToBytes() => [(byte)Value];
    }
public class TraCIUByte : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_UBYTE;
    public byte Value { get; set; }
    public byte[] ToBytes() => [Value];

    }
public class TraCIDouble : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_DOUBLE;

    public double Value { get; set; }
    public byte[] ToBytes() => BitConverter.GetBytes(Value).Reverse().ToArray();

    }
public class TraCIFloat : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_FLOAT;
    public float Value { get; set; }
    public byte[] ToBytes() => BitConverter.GetBytes(Value).Reverse().ToArray();

    }

public class TraCIInteger : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_INTEGER;
    public int Value { get; set; }
    public byte[] ToBytes() => BitConverter.GetBytes(Value).Reverse().ToArray();

    }
public class TraCIString : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_STRING;
    public string Value { get; set; }
    public byte[] ToBytes() => [.. BitConverter.GetBytes((Value).Length).Reverse(), .. Encoding.ASCII.GetBytes(Value)];
    }
public class TraCIStringList : ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_STRINGLIST;
    public List<string> Value { get; set; } = [];
    public byte[] ToBytes()
        {
        List<byte> bytes = [.. BitConverter.GetBytes(Value.Count).Reverse()];
        foreach (string str in Value)
            {
            bytes.AddRange(str.ToTraCIBytes());
            }
        return [.. bytes];
        }
    }