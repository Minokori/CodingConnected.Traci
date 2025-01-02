namespace CodingConnected.TraCI.NET;

public class TraCICommandException(byte commandType, byte variableType, string message = null) : Exception(message)
    {
    public byte CommandType { get; } = commandType;
    public byte VariableType { get; } = variableType;
    }
