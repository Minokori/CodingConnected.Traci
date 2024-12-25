namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public void Dispose()
        {
        _tcpserivce.Client.Close();
        _tcpserivce.Stream.Dispose();
        GC.SuppressFinalize(this);
        }
    }

