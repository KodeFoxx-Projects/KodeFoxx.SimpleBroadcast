namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows;

public sealed class Show : SimpleBroadcastEntity
{
    public static readonly Show Empty = new Show();

    public static Show CreateShowEpisode(string title, int episodeNumber)
        => new Show(title: title, episodeNumber: episodeNumber);
    public static Show CreateShow(string title)
        => new Show(title: title);

    private Show(
        long? id = null,
        string? title = null,
        int? episodeNumber = null,
        Tracklist? trackList = null
    )
        : base(id ?? 0)
    {
        if (episodeNumber.HasValue && episodeNumber <= 0)
            throw new ArgumentException(
                message: $"Can not add a show when '{nameof(episodeNumber)}' is lower or equal to '0'.",
                paramName: nameof(episodeNumber)
            );

        EpisodeNumber = episodeNumber;
        Title = title ?? String.Empty;
        Tracklist = Tracklist ?? Tracklist.Empty;
    }
    public Show() : this(0) { }

    public int? EpisodeNumber { get; }
    public bool IsNumbered => EpisodeNumber != null;
    public string Title { get; }
    public Tracklist Tracklist { get; }
}
