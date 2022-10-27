namespace KodeFoxx.SimpleBroadcast.Core.Domain.Tests;

public sealed class SimpleBroadcastEntityTests
{
    [Fact]
    public void Equality_is_based_on_id()
    {
        var nameA = Name.Create("Yves", "Schelpe");
        var nameB = Name.Create("John", "Doe");
        var personA = CreatePersonWith(id: 1, name: nameA);
        var personB = CreatePersonWith(id: 1, name: nameB);

        personA.Equals(personB).Should().BeTrue();
        (personA == personB).Should().BeTrue();
        (personA != personB).Should().BeFalse();
    }

    [Fact]
    public void Negative_equality_is_based_on_id()
    {
        var name = Name.Create("Yves", "Schelpe");
        var personA = CreatePersonWith(id: 1, name);
        var personB = CreatePersonWith(id: 2, name);

        personA.Equals(personB).Should().BeFalse();
        (personA == personB).Should().BeFalse();
        (personA != personB).Should().BeTrue();
    }

    [Fact]
    public void When_both_are_null_they_are_equal()
    {
        Person personA = null;
        Person personB = null;

        (personA == personB).Should().BeTrue();
        (personA != personB).Should().BeFalse();
        (personB == personA).Should().BeTrue();
        (personB != personA).Should().BeFalse();
    }

    [Fact]
    public void When_only_one_is_null_they_are_not_equal()
    {
        Person personA = null;
        var personB = CreatePersonYvesSchelpe();

        (personA == personB).Should().BeFalse();
        (personA != personB).Should().BeTrue();
        (personB == personA).Should().BeFalse();
        (personB != personA).Should().BeTrue();
    }

    [Fact]
    public void HashCode_is_the_same_when_the_ids_are_the_same()
    {
        var id = 1;
        var personA = Person.Create(id, Name.Create("Yves", "Schelpe"));
        var personB = Person.Create(id, Name.Create("John", "Doe"));

        personA.GetHashCode().Should().Be(personB.GetHashCode());
    }

    private static Person CreatePersonWith(long id = 1, Name name = null)
        => Person.Create(id, name);
    private static Person CreatePersonYvesSchelpe(long id = 1)
        => CreatePersonWith(id, Name.Create("Yves", "Schelpe"));
}