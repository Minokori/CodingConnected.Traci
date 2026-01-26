using System.Reactive.Subjects;
using Minokori.Traffic.TraciExample.Model;

namespace Minokori.Traffic.TraciExample;

internal sealed class TrafficDataProvider : IObservable<InTimeData>
    {
    public TrafficDataProvider(string dataSourceFilePath) => DataSourceFilePath = dataSourceFilePath;

    private string DataSourceFilePath { get; init; }

    private Subject<InTimeData> Subject { get; } = new();

    public IDisposable Subscribe(IObserver<InTimeData> observer) => Subject.SubscribeSafe(observer);


    public void Start()
        {
        using var reader = new StreamReader(DataSourceFilePath);
        string? line;
        while ((line = reader.ReadLine()) != null)
            {
            var data = System.Text.Json.JsonSerializer.Deserialize<InTimeData>(line);
            if (data != null)
                {
                Subject.OnNext(data);
                }
            }
        Subject.OnCompleted();
        }
    }
