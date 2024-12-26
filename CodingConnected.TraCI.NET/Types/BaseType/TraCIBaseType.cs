namespace CodingConnected.TraCI.NET.Types;

public class TraCIByte : ITraCIType
    {
    public byte Value { get; set; }
    }
public class TraCIUByte : ITraCIType
    {
    public byte Value { get; set; }
    }
public class TraCIDouble : ITraCIType
    {
    public double Value { get; set; }
    }
public class TraCIFloat : ITraCIType
    {
    public float Value { get; set; }
    }

public class TraCIInteger : ITraCIType
    {
    public int Value { get; set; }
    }
public class TraCIString : ITraCIType
    {
    public string Value { get; set; }
    }
public class TraCIStringList : ITraCIType
    {
    public List<string> Value { get; set; } = [];
    }