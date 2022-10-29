namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

public sealed class IntroSegment : SegmentWithNotes
{
    public static readonly new Segment Empty = new IntroSegment();

    private IntroSegment(
        long? id = null,
        string? notes = null,
        TimeSpan? start = null
    )
        : base(id ?? 0, SegmentType.Song, notes, start)
    {
    }
    private IntroSegment() : this(0) { }
}