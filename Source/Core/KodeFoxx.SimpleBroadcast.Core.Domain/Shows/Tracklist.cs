using KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows;

public sealed class Tracklist : SimpleBroadcastEntity
{
    public static readonly Tracklist Empty = new Tracklist();

    private Tracklist(
        long? id = null,
        IEnumerable<Segment>? segments = null
    )
        : base(id ?? 0)
    {
        if (segments == null || !segments.Any())
            _segments = new List<Segment>();
        else
            _segments = segments.ToList();
    }
    private Tracklist() : this(0) { }

    private readonly List<Segment> _segments;
    public IReadOnlyCollection<Segment> Segments => _segments;

    public Tracklist AddSong(SongSegment songSegment)
        => AddSegment(songSegment);

    private Tracklist AddSegment(Segment segment)
    {
        if (segment.Equals(Segment.Empty))
            throw new ArgumentException(
                message: $"Can not add an empty '{typeof(Segment).Name}'",
                paramName: nameof(segment)
            );

        _segments.Add(segment);

        return this;
    }
}
