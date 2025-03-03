namespace CodingConnected.TraCI.NET;

public partial class TraciClient
    {
    public void Dispose()
        {
        TcpService.Dispose();
        GC.SuppressFinalize(this);
        }
    }

