namespace KodeFoxx.SimpleBroadcast.Core.Domain.Shows.Segments;

public enum SegmentType
{
    Empty
        = 0,
    Undefinied
        = 10000,
    Start
        = 100000,
    Intro
        = 110000,
    End
        = 900000,
    Outro
        = 910000,
    Talk
        = 200000,
    Music
        = 300000,
    Song
        = 310000
}