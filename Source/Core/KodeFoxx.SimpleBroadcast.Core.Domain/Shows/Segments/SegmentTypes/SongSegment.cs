namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

public sealed class SongSegment : SegmentWithNotes
{
    public static readonly new Segment Empty = new SongSegment();

    private SongSegment(
        long? id = null,
        SegmentType? type = null,
        string? notes = null,
        TimeSpan? start = null,

        Song? song = null
    )
        : base(id ?? 0, SegmentType.Song, notes, start)
    {
        Song = song ?? Song.Empty;
    }
    private SongSegment() : this(0) { }

    public Song Song { get; }
    public Artist Artist => Song.Artist;
}