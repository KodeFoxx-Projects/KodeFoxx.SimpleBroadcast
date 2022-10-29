namespace KodeFoxx.SimpleBroadcast.Core.Domain.Artists;

public sealed class Artist : SimpleBroadcastEntity
{
    public static readonly Artist Empty = new Artist();

    private Artist(
        long? id = null,
        string? principal = null,
        IEnumerable<Song>? songs = null
    )
        : base(id ?? 0)
    {
        Principal = principal ?? String.Empty;

        if (songs == null || !songs.Any())
            _songs = new List<Song>();
        else
            _songs = songs.ToList();
    }
    private Artist() : this(0) { }

    public string Principal { get; }

    private readonly List<Song> _songs;
    public IReadOnlyCollection<Song> Songs => _songs;

    public Artist AddSong(Song song)
    {
        if (song.Equals(Song.Empty))
            throw new ArgumentException(
                message: $"Can not add an empty '{typeof(Song).Name}'",
                paramName: nameof(song)
            );

        _songs.Add(song);

        return this;
    }
}