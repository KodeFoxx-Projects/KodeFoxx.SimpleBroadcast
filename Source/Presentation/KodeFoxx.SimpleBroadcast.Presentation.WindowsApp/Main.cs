namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    public partial class Main : Form
    {
        private AppSettings AppSettings { get; }
        public SimpleBroadcastDatabase Database { get; }
        public string DatabaseName
            => Database.CanGetSqliteDatabaseFileInfo()
                ? Database.GetSqliteDatabaseFileInfo().FullPath
                : "No Database";

        public Main(AppSettings appSettings, SimpleBroadcastDatabase database)
        {
            InitializeComponent();
            AppSettings = appSettings;
            Database = database;

            Text = $"Simple Broadcast [ Version: {ApplicationExtensions.GetVersion()} | Db: {DatabaseName}]";
        }
    }
}
