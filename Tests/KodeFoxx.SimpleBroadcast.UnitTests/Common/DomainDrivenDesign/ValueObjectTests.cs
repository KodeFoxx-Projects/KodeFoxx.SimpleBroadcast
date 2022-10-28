using KodeFoxx.SimpleBroadcast.UnitTests.Common.DomainDrivenDesign.TestDomain;

namespace KodeFoxx.SimpleBroadcast.UnitTests.Common.DomainDrivenDesign;

public sealed class ValueObjectTests
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

    [Fact]
    public void HashCode_is_calculated_on_type_when_equatable_values_returns_null()
    {
        var sut = new NullEquatableValuesObject();

        sut.GetHashCode().Should().Be(sut.GetType().GetHashCode());
    }

    [Fact]
    public void ToString_returns_type_and_property_values_by_default()
    {
        var firstName = "Yves";
        var lastName = "Schelpe";
        var name = Name.Create(firstName, lastName);

        name.ToString().Should().Be($"Name: {{Yves, Schelpe}}");
    }

    [Fact]
    public void ToString_returns_nullstring_when_property_is_null()
    {
        var lastName = "Schelpe";
        var name = Name.Create(null, lastName);

        name.ToString().Should().Be($"Name: {{(null), Schelpe}}");
    }
}
