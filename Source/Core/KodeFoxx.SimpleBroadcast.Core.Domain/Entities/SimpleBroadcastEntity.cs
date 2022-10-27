namespace KodeFoxx.SimpleBroadcast.Core.Domain.Entities;

public abstract class SimpleBroadcastEntity : IEquatable<SimpleBroadcastEntity>
{
    public long Id { get; private set; }

    protected SimpleBroadcastEntity(long id)
        => Id = id;

    protected SimpleBroadcastEntity()
        => Id = 0;

    public override bool Equals(object? @object)
    {
        if (@object == null) return false;
        if (@object is SimpleBroadcastEntity entity) return Equals(entity);
        return false;
    }

    public bool Equals(SimpleBroadcastEntity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
            => $"{GetType()}{Id}".GetHashCode();

    #region Operator Overloads
    public static bool operator ==(
        SimpleBroadcastEntity a, SimpleBroadcastEntity b
    )
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }
    public static bool operator !=(
        SimpleBroadcastEntity a, SimpleBroadcastEntity b
    )
        => !(a == b);
    #endregion
}
