using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

internal static class Program
{
    private static IServiceProvider _serviceProvider;
    private static Form _splashScreen;
    private static Thread _splashThread;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();

        _splashScreen = new Splash();
        _splashScreen.Show();
        _splashScreen.Activate();
        _splashScreen.Refresh();
        _splashScreen.TopMost = true;
        Thread.Sleep(750);

        var host = CreateHostBuilder().Build();
        _serviceProvider = host.Services;

        var mainScreen = _serviceProvider.GetRequiredService<Main>();
        mainScreen.Load += (s, e) =>
            {
                if (_splashScreen != null
                    && !_splashScreen.Disposing
                    && !_splashScreen.IsDisposed
                )
                {
                    _splashScreen.Invoke(() =>
                    {
                        _splashScreen.Close();
                    });
                }

                mainScreen.TopMost = true;
                mainScreen.Activate();
                mainScreen.TopMost = false;
            };

        Application.Run(mainScreen);
    }

    private static IHostBuilder CreateHostBuilder()
        => Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<Splash>();
                services.AddTransient<Main>();
            });
}