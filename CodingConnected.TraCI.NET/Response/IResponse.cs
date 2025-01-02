namespace CodingConnected.TraCI.NET.Response;

public interface IResponse
    {
    string ErrorMessage { get; set; }

    byte Identifier { get; set; }

    byte? ResponseIdentifier { get; set; }

    ResultCode Result { get; set; }

    /// <summary>
    /// The VariableType type
    /// </summary>
    byte? VariableType { get; set; }

    T GetContentAs<T>();
    }
