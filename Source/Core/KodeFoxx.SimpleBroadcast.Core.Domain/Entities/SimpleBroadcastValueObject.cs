namespace KodeFoxx.SimpleBroadcast.Core.Domain.Entities;

public abstract class SimpleBroadcastValueObject : IEquatable<SimpleBroadcastValueObject>
{
    protected abstract IEnumerable<object> EquatableValues { get; }

    public override bool Equals(object? @object)
    {
        if (@object is null || @object.GetType() != GetType())
            return false;

        if (!(@object is SimpleBroadcastValueObject other))
            return false;

        var thisValues = EquatableValues.GetEnumerator();
        var otherValues = other.EquatableValues.GetEnumerator();

        while (thisValues.MoveNext() && otherValues.MoveNext())
        {
            if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                return false;

            if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                return false;
        }

        return !thisValues.MoveNext() && !otherValues.MoveNext();
    }

    public bool Equals(SimpleBroadcastValueObject? other)
        => Equals(this, other);

    public override int GetHashCode()
        => EquatableValues
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);

    #region Operator Overloads
    public static bool operator ==(
        SimpleBroadcastValueObject a, SimpleBroadcastValueObject b
    )
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(
        SimpleBroadcastValueObject a, SimpleBroadcastValueObject b
    )
        => !(a == b);
    #endregion
}