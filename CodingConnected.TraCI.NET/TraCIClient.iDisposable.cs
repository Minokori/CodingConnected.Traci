namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public void Dispose()
        {
        TcpService.Dispose();
        GC.SuppressFinalize(this);
        }
    }

