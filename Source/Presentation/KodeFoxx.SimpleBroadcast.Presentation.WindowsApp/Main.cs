namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    public partial class Main : Form
    {
        private AppSettings AppSettings { get; }

        public Main(AppSettings appSettings)
        {
            InitializeComponent();
            AppSettings = appSettings;
        }
    }
}
