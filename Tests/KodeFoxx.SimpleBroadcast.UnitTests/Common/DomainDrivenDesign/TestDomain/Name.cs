namespace KodeFoxx.SimpleBroadcast.UnitTests.Common.DomainDrivenDesign.TestDomain;

internal sealed class Name : ValueObject
{
    public static readonly Name Empty = new Name();

    public static Name Create(string firstName, string lastName)
        => new Name(firstName, lastName);

    private Name(string firstName, string lastName)
    {
        First = firstName;
        Last = lastName;
    }
    private Name()
    {
        First = null;
        Last = null;
    }

    public string? First { get; }
    public string? Last { get; }

    protected override IEnumerable<object?> EquatableValues
        => new[] { First, Last };
}