namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

public sealed class OutroSegment : SegmentWithNotes
{
    public static readonly new Segment Empty = new OutroSegment();

    private OutroSegment(
        long? id = null,
        string? notes = null,
        TimeSpan? start = null
    )
        : base(id ?? 0, SegmentType.Song, notes, start)
    {
    }
    private OutroSegment() : this(0) { }
}