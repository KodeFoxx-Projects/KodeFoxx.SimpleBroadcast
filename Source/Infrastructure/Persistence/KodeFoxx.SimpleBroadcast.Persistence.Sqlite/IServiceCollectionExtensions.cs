using KodeFoxx.SimpleBroadcast.Persistence.Sqlite.Settings;

namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigurePersistence(
        this IServiceCollection services, IConfiguration configuration
    )
        => services.AddDbContext<SimpleBroadcastDatabase>();

    public static IServiceCollection AddAndConfigurePersistence(
        this IServiceCollection services, IConfiguration configuration,
        DataSettings? dataSettings
    )
    {
        var sqliteDatabaseFile = dataSettings is null
            ? SqliteDatabaseFileInfo.Default
            : SqliteDatabaseFileInfo.Create(
                fileName: dataSettings.FileName,
                directory: dataSettings.DirectoryPath,
                extension: dataSettings.Extension);

        services.AddDbContext<SimpleBroadcastDatabase>(options =>
        {
            options.UseSqlite($"Data Source={sqliteDatabaseFile.FullPath}");
        });

        return services;
    }
}
