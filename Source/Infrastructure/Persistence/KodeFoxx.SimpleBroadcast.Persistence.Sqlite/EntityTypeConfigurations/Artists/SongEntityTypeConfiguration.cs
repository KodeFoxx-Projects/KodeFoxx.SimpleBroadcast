using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite.EntityTypeConfigurations.Artists;

public sealed class SongEntityTypeConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Songs");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
            .IsRequired();

        builder.HasOne(p => p.Artist)
            .WithMany(a => a.Songs)
            .IsRequired();
    }
}
