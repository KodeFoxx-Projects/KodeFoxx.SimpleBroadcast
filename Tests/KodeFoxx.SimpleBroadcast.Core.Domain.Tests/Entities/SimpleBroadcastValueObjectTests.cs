namespace KodeFoxx.SimpleBroadcast.Core.Domain.Tests.Entities;

public sealed class SimpleBroadcastValueObjectTests
{
    [Fact]
    public void Equality_is_based_on_properties()
    {
        var firstName = "Yves";
        var lastName = "Schelpe";
        var nameA = Name.Create(firstName, lastName);
        var nameB = Name.Create(firstName, lastName);

        nameA.Equals(nameB).Should().BeTrue();
        (nameA == nameB).Should().BeTrue();
        (nameA != nameB).Should().BeFalse();
    }

    [Fact]
    public void Negative_equality_is_based_on_properties()
    {
        var firstName = "Yves";
        var lastName = "Schelpe";
        var nameA = Name.Create(firstName, lastName);
        var nameB = Name.Create(firstName.ToLower(), lastName);

        nameA.Equals(nameB).Should().BeFalse();
        (nameA == nameB).Should().BeFalse();
        (nameA != nameB).Should().BeTrue();
    }

    [Fact]
    public void When_both_are_null_they_are_equal()
    {
        Name nameA = null;
        Name nameB = null;

        (nameA == nameB).Should().BeTrue();
        (nameA != nameB).Should().BeFalse();
        (nameB == nameA).Should().BeTrue();
        (nameB != nameA).Should().BeFalse();
    }

    [Fact]
    public void When_only_one_is_null_they_are_not_equal()
    {
        Name nameA = null;
        var nameB = Name.Create("Yves", "Schelpe");

        (nameA == nameB).Should().BeFalse();
        (nameA != nameB).Should().BeTrue();
        (nameB == nameA).Should().BeFalse();
        (nameB != nameA).Should().BeTrue();
    }

    [Fact]
    public void HashCode_is_based_on_properties()
    {
        var firstName = "Yves";
        var lastName = "Schelpe";
        var nameA = Name.Create(firstName, lastName);
        var nameB = Name.Create(firstName, lastName);

        nameA.GetHashCode().Should().Be(nameB.GetHashCode());
    }
}
