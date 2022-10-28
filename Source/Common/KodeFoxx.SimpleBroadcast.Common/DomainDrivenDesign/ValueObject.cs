namespace KodeFoxx.SimpleBroadcast.Common.DomainDrivenDesign;

/// <summary>
/// Represents a value object.
/// Inspiration taken from https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the fields to be taken into consideration when comparing two <see cref="ValueObject"/>s of the same type.
    /// </summary>
    protected abstract IEnumerable<object?> EquatableValues { get; }

    /// <inheritdoc/>
    public override bool Equals(object? @object)
    {
        if (@object is null || @object.GetType() != GetType())
            return false;

        var other = (ValueObject)@object;

        return GetEquatableValues().SequenceEqual(other.GetEquatableValues());
    }

    /// <inheritdoc cref="IEquatable{T}.Equals(T?)"/>
    public bool Equals(ValueObject? other)
        => Equals(this, other);

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        if (EquatableValues is null)
            return GetType().GetHashCode();

        return GetEquatableValues()
            .Select(x => x is null ? 0 : x.GetHashCode())
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Gets the equatable values or an empty object array if null.
    /// </summary>    
    private IEnumerable<object?> GetEquatableValues()
        => (EquatableValues ?? new object[] { });

    /// <inheritdoc/>
    public override string ToString()
        => GetIdentityString();

    /// <summary>
    /// Generates an identity string for debugging.
    /// </summary>    
    private string GetIdentityString()
    {
        var identityStringTypePart = $"{GetType().Name}";
        var equatableValuesList = String.Join(", ", GetEquatableValues()
            .Select(x => x is null ? "(null)" : x));

        return $"{identityStringTypePart}: {{{equatableValuesList}}}";
    }

    /// <inheritdoc/>
    public static bool operator ==(ValueObject a, ValueObject b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    /// <inheritdoc/>
    public static bool operator !=(ValueObject a, ValueObject b)
        => !(a == b);
}
