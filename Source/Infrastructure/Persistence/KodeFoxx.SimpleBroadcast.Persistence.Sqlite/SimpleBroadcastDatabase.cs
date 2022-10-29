using KodeFoxx.SimpleBroadcast.Core.Domain.Artists;

namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public sealed class SimpleBroadcastDatabase : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
}