using System.Reflection;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            ShowSplashImage();
            ShowSplashText();
        }

        private void ShowSplashImage()
        {
            BackgroundImage = Image.FromFile(Path.Combine("Resources", "Images", "Splash.png"));
            BackgroundImageLayout = ImageLayout.Stretch;
            Width = 800;
            Height = 400;
            CenterToScreen();
        }

        private void ShowSplashText()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var dateTime = File.GetLastWriteTimeUtc(assembly.Location)
                .ToString()
                .Replace(" ", "-")
                .Replace(":", "")
                .Replace(@"/", "");
            applicationNameAndVersionLabel.Text = $"preview version 0.1-{dateTime}";
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
    }
}