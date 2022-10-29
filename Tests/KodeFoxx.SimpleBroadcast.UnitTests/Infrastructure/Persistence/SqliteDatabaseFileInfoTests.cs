namespace KodeFoxx.SimpleBroadcast.UnitTests.Infrastructure.Persistence;

public sealed class SqliteDatabaseFileInfoTests
{
    [Fact]
    public void Default_has_sbdb_as_extension()
        => SqliteDatabaseFileInfo.Default.Extension
            .Should().Be(".sbdb");

    [Fact]
    public void Defaults_extension_is_point_sbdb()
        => SqliteDatabaseFileInfo
            .Create(
                fileName: "data",
                directory: @"x:\folder\"
            )
            .Extension
            .Should().Be(".sbdb");

    [Theory]
    [InlineData("eclectriCAST.data", ".data-file", "eclectriCAST-data.datafile")]
    [InlineData("eclectriCAST.data", ".data.file", "eclectriCAST-data.datafile")]
    [InlineData("eclectriCAST.data", "..sqlite", "eclectriCAST-data.sqlite")]
    [InlineData("eclectriCAST.data", "data", "eclectriCAST-data.data")]
    public void No_double_points_in_a_file_name(
        string fileName, string extension,
        string expected
    )
    {
        var sut = SqliteDatabaseFileInfo
            .Create(
                fileName: fileName,
                directory: @"x:\folder\",
                extension: extension
            );

        sut.FileNameWithExtension.Should().Be(expected);
    }

    [Theory]
    [InlineData("eclectriCAST", null, "eclectriCAST.sbdb")]
    [InlineData("eclectriCAST", "", "eclectriCAST.sbdb")]
    [InlineData("eclectriCAST", "sqlitedb", "eclectriCAST.sqlitedb")]
    public void Make_sure_a_point_is_in_extension(
        string? fileName, string? extension,
        string expected
    )
    {
        var sut = SqliteDatabaseFileInfo
            .Create(
                fileName: fileName,
                directory: @"x:\folder\",
                extension: extension
            );

        sut.FileNameWithExtension.Should().Be(expected);
    }

    [Theory]
    [InlineData("eclectriCAST", "SqliteDb", "eclectriCAST.sqlitedb")]
    [InlineData("eclectriCAST", "AzDDD", "eclectriCAST.azddd")]
    public void Extension_is_lowercase(
        string? fileName, string? extension,
        string expected
    )
    {
        var sut = SqliteDatabaseFileInfo
            .Create(
                fileName: fileName,
                directory: @"x:\folder\",
                extension: extension
            );

        sut.FileNameWithExtension.Should().Be(expected);
    }

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
