namespace KodeFoxx.SimpleBroadcast.Core.Domain.Tests.Entities;

internal sealed class Name : SimpleBroadcastValueObject
{
    public static Name Empty
        => new Name();

    public static Name Create(string firstName, string lastName)
        => new Name(firstName, lastName);

    private Name(string firstName, string lastName)
        => (First, Last)
         = (firstName, lastName);

    private Name()
        : this(String.Empty, String.Empty)
    { }

    public string First { get; }
    public string Last { get; }

    protected override IEnumerable<object> EquatableValues
        => new[] { First, Last };
}