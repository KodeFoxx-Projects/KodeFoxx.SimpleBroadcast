namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public static class SimpleBroadcastDatabaseExtensions
{
    public static SqliteDatabaseFileInfo? GetSqliteDatabaseFileInfo(
        this SimpleBroadcastDatabase simpleBroadcastDatabase
    )
        => SqliteDatabaseFileInfo.CreateFromDatabase(simpleBroadcastDatabase);

    public static bool CanGetSqliteDatabaseFileInfo(
        this SimpleBroadcastDatabase simpleBroadcastDatabase
    )
        => simpleBroadcastDatabase.GetSqliteDatabaseFileInfo() != null;
}
