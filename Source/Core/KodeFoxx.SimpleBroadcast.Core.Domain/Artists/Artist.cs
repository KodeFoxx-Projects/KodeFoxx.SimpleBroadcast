namespace KodeFoxx.SimpleBroadcast.Core.Domain.Artists;

public sealed class Artist : SimpleBroadcastEntity
{
    public static readonly Artist Empty = new Artist();

    private Artist(
        long? id = null,
        string? principal = null
    )
        : base(id ?? 0)
    {
        Principal = principal ?? String.Empty;
    }
    private Artist() : this(0) { }

    public string Principal { get; }
}