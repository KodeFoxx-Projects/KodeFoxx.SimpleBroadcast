using KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    public partial class Main : Form
    {
        private AppSettings AppSettings { get; }
        public SimpleBroadcastDatabase Database { get; }

        public Main(AppSettings appSettings, SimpleBroadcastDatabase database)
        {
            InitializeComponent();
            AppSettings = appSettings;
            Database = database;
        }
    }
}
