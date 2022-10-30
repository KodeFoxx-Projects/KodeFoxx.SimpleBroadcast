namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public sealed class SimpleBroadcastDatabase : DbContext
{
    public SimpleBroadcastDatabase() { }

    public SimpleBroadcastDatabase(DbContextOptions<SimpleBroadcastDatabase> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={SqliteDatabaseFileInfo.Default.FullPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Song> Songs => Set<Song>();
}
