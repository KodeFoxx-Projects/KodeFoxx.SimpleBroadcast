internal sealed class NullEquatableValuesObject : ValueObject
{
    protected override IEnumerable<object?> EquatableValues
        => null;
}