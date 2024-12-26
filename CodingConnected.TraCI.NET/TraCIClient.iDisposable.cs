namespace CodingConnected.TraCI.NET;

public partial class TraCIClient
    {
    public void Dispose()
        {
        TcpSerivce.Client.Close();
        TcpSerivce.Stream.Dispose();
        GC.SuppressFinalize(this);
        }
    }

