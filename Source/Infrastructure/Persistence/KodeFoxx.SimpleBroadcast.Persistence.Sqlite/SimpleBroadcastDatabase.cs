namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public sealed class SimpleBroadcastDatabase : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private readonly SqliteDatabaseFileInfo _sqliteDatabaseFile;

    public SimpleBroadcastDatabase(SqliteDatabaseFileInfo? sqliteDatabaseFile = null)
        => _sqliteDatabaseFile = sqliteDatabaseFile ?? SqliteDatabaseFileInfo.Default;


    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
        => optionsBuilder.UseSqlite($"Data Source={_sqliteDatabaseFile.FullPath}");

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
