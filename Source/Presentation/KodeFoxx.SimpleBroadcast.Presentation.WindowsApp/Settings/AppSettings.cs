using KodeFoxx.SimpleBroadcast.Persistence.Sqlite.Settings;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp.Settings;

public sealed class AppSettings
{
    public IConfiguration Configuration { get; private set; }

    public bool Debug { get; set; }
    public DataSettings Data { get; set; }
    public SerilogSettings SeriLog { get; set; }

    internal void BindConfiguration(IConfigurationRoot configuration)
    {
        Configuration = configuration;
        Configuration.Bind(this);
    }
}