namespace KodeFoxx.SimpleBroadcast.UnitTests.Infrastructure.Persistence;

public sealed class SqliteDatabaseFileInfoTests
{
    [Fact]
    public void Default_has_sbdb_as_extension()
        => SqliteDatabaseFileInfo.Default.Extension
            .Should().Be(".sbdb");

    [Fact]
    public void Default_has_simplebroadcast_as_filename()
        => SqliteDatabaseFileInfo.Default.FileName
            .Should().Be("simplebroadcast");

    [Fact]
    public void Default_has_simplebroadcast_point_sbdb_as_filename()
        => SqliteDatabaseFileInfo.Default.FileNameWithExtension
            .Should().Be("simplebroadcast.sbdb");

    [Fact]
    public void Default_has_LocalApplicationData_as_folder()
        => SqliteDatabaseFileInfo.Default.Directory
            .Should().Be(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "KodeFoxx",
                    "SimpleBroadcast"
                )
        );
}
