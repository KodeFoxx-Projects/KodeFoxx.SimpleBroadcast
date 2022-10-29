namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

public abstract class SegmentWithNotes : Segment
{
    protected SegmentWithNotes(
        long? id = null,
        SegmentType? segmentType = null,
        string? notes = null,
        TimeSpan? start = null
    )
        : base(id ?? 0, segmentType, start)
    {
        Notes = notes;
    }
    protected SegmentWithNotes() : this(0) { }

    public string? Notes { get; }
    public bool HasNotes => String.IsNullOrWhiteSpace(Notes);
}