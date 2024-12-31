namespace CodingConnected.TraCI.NET.Response;

public enum ResultCode : byte
    {
    Success = 0x00,
    Failed = 0xff,
    NotImplemented = 0x01
    }

public class TraCIResponse<T> : IResponse
    {
    public byte Identifier { get; set; }

    public byte? ResponseIdentifier { get; set; }

    public ResultCode Result { get; set; }

    public T Content { get; set; }

    public string ErrorMessage { get; set; }

    public byte? VariableType { get; set; }

    public U GetContentAs<U>()
        {
        return (U)Convert.ChangeType(Content, typeof(U));
        }
    }

