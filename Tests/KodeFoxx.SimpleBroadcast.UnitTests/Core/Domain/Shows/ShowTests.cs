namespace KodeFoxx.SimpleBroadcast.UnitTests.Core.Domain.Shows;

public sealed class ShowTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Can_not_create_show_with_number_lower_or_equal_to_0(int episodeNumber)
    {
        Action act = () => Show.CreateShowEpisode("Show title", episodeNumber);

        act.Should().Throw<ArgumentException>().WithParameterName("episodeNumber");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(999)]
    public void Can_create_show_with_number_higher_than_0(int episodeNumber)
    {
        var sut = Show.CreateShowEpisode("Show title", episodeNumber);

        sut.Should().NotBeNull();
        sut.EpisodeNumber.Should().Be(episodeNumber);
    }

    [Fact]
    public void Show_without_number_should_be_marked_as_not_numbered()
    {
        var sut = Show.CreateShow("Show title");

        sut.Should().NotBeNull();
        sut.EpisodeNumber.Should().BeNull();
        sut.IsNumbered.Should().BeFalse();
    }

    [Fact]
    public void Show_with_number_should_be_marked_as_numbered()
    {
        var sut = Show.CreateShowEpisode("Show title", 15);

        sut.Should().NotBeNull();
        sut.EpisodeNumber.Should().Be(15);
        sut.IsNumbered.Should().BeTrue();
    }
}