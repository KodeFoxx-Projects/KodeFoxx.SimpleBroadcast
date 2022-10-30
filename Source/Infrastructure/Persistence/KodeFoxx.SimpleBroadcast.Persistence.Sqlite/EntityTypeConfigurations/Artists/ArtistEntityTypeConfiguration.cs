using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite.EntityTypeConfigurations.Artists;

public sealed class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Principal)
            .IsRequired();

        builder.HasMany(p => p.Songs)
            .WithOne(s => s.Artist);
    }
}
