using System.Diagnostics;
using CodingConnected.Traci.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.Traci;

/// <summary>
/// A simple )and yet incomplete) client-side implementation of TraCI, for using SUMO
/// with .NET applications.
/// </summary>
public sealed partial class TraciClient : IDisposable
    {
    public string SumoFile { get; private set; }
    public int Port { get; private set; }
    private ISumoConnectService TcpService => Services.GetRequiredService<ISumoConnectService>();
    private ServiceProvider Services { get; set; }

    /// <summary>
    /// Connects to the SUMO server instance
    /// </summary>
    /// <param name="hostname">Hostname or ip address where SUMO is running</param>
    /// <param name="port">Port at which SUMO exposes the API</param>
    public async Task<(int traciApiVersion, string sumoVersion)> ConnectAsync(
        string hostname,
        int port
    ) =>
        await TcpService
            .ConnectAsync(hostname, port)
            .ContinueWith(
                _ => Control.GetVersion(),
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default
            )
            .ContinueWith(
                versionTask => versionTask.Result,
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default
            )
            .ConfigureAwait(false);

    public bool Connect(string hostname, int port) => TcpService.Connect(hostname, port);

    /// <summary>
    /// provide an easy way to start a sumo instance on local machine.
    /// </summary>
    /// <param name="sumoFile">*.sumocfg file.</param>
    /// <param name="port"></param>
    /// <param name="gui">enable sumo-gui window</param>
    /// <param name="quit">auto quit sumo when simulation end</param>
    /// <returns></returns>
    public async Task<(int traciApiVersion, string sumoVersion)> Start(
        string? sumoFile = null,
        int? port = null,
        bool gui = true,
        bool quit = true
    )
        {
        SumoFile = sumoFile ?? SumoFile;
        Port = port ?? Port;

        var args =
            $"-c {SumoFile}"
            + $" --remote-port {Port}"
            + $" {(gui ? " --start " : " ")}"
            + $" {(quit ? " --quit-on-end " : " ")}"
            + $" --num-clients 1";
        var sumoExecutable = gui ? "sumo-gui" : "sumo";
        using Process sumoProcess = new()
            {
            StartInfo = new()
                {
                Arguments = args,
                FileName = sumoExecutable, // The executable for the sumo
                UseShellExecute = true,

                },
            };
        _ = sumoProcess.Start();
        var (versionId, versionString) = await ConnectAsync("127.0.0.1", Port)
            .ConfigureAwait(false);
        return (versionId, versionString);
        }

    /// <summary>
    /// low level method to send a command to the sumo server.<para/>
    /// <b>NOT </b>recommended to use this method directly.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public IList<TraciResult> SendMessage(TraciCommand command) => TcpService.SendMessage(command);
    }
