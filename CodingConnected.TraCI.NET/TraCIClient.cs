using System.Diagnostics;
using CodingConnected.Traci.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodingConnected.Traci;

/// <summary>
/// A simple )and yet incomplete) client-side implementation of TraCI, for using SUMO
/// with .NET applications.
/// </summary>
public partial class TraciClient : IDisposable
    {
    public string SumoFile { get; private set; }
    public int Port { get; private set; }
    private ITCPConnectService TcpService => services.GetRequiredService<ITCPConnectService>();
    private readonly ServiceProvider services;

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
            .ContinueWith(_ => Control.GetVersion())
            .ContinueWith(versionTask => versionTask.Result);

    public bool Connect(string hostname, int port) => TcpService.Connect(hostname, port);

    /// <summary>
    /// provide an easy way to start a sumo instance on local machine.
    /// </summary>
    /// <param name="sumoFile">*.sumocfg file.</param>
    /// <param name="port"></param>
    /// <param name="gui">enable sumo-gui window</param>
    /// <param name="quit">auto quit sumo when simulation end</param>
    /// <param name="hostname">host </param>
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
        Process sumoProcess = new()
            {
            StartInfo = new()
                {
                Arguments = args,
                FileName = sumoExecutable, // The executable for the sumo
                },
            };
        await Task.Run(sumoProcess.Start);
        var (versionId, versionString) = await ConnectAsync("127.0.0.1", Port);
        return (versionId, versionString);
        }

    public List<TraciResult> SendMessage(TraciCommand command) => TcpService.SendMessage(command);
    }
