namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigurePersistence(
        this IServiceCollection services, IConfiguration configuration
    )
        => services.AddDbContext<SimpleBroadcastDatabase>();
}
