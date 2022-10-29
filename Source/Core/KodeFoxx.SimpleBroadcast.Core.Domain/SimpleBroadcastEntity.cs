namespace KodeFoxx.SimpleBroadcast.Core.Domain;

public abstract class SimpleBroadcastEntity : Entity<long>
{
    protected SimpleBroadcastEntity(long id) : base(id) { }
}
