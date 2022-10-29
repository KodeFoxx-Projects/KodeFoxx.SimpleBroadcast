using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

internal static class Program
{
    private static IServiceProvider _serviceProvider;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var host = CreateHostBuilder().Build();
        _serviceProvider = host.Services;

        ApplicationConfiguration.Initialize();
        Application.Run(_serviceProvider.GetRequiredService<Splash>());
    }

    private static IHostBuilder CreateHostBuilder()
        => Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<Splash>();
            });
}