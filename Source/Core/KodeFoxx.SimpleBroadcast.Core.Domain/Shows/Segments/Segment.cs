namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

public class Segment : SimpleBroadcastEntity
{
    public static readonly Segment Empty = new Segment();

    protected Segment(
        long? id = null,
        SegmentType? type = null,
        TimeSpan? start = null
    )
        : base(id ?? 0)
    {
        Type = type ?? SegmentType.Empty;
        Start = start ?? TimeSpan.MaxValue;
    }
    protected Segment() : this(0) { }

    public SegmentType Type { get; }
    public TimeSpan Start { get; }
}