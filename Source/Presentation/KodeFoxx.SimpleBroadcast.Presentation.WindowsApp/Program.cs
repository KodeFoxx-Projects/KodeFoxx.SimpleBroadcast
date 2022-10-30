namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

internal static class Program
{
    private static AppSettings _appSettings;
    private static string[] _commandLineArguments;

    private static IServiceProvider _serviceProvider;
    private static IHost _host;

    private static Form _splashScreen;
    private static Form _mainScreen;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        InitializeWindowsFormsSettings();
        InitializeAndShowSplashScreen();

        InitializeConfigurationAndAppLoadSettings();
        InitializeAndCreateHost();

        LoadOrCreateDatabase();

        InitializeMainScreenAndCloseSplashScreen();
    }

    private static IHostBuilder CreateHostBuilder()
    => Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton(_appSettings);
            services.AddSingleton(_appSettings.Configuration);

            services.AddAndConfigurePersistence(_appSettings.Configuration, _appSettings.Data);

            services.AddFormsAsTransient();
        });

    private static void InitializeConfigurationAndAppLoadSettings()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        _appSettings = configuration.Get<AppSettings>();
        _appSettings.BindConfiguration(configuration);
    }

    private static void LoadOrCreateDatabase()
    {
        var database = _serviceProvider.GetService<SimpleBroadcastDatabase>();
        var created = database?.Database.EnsureCreated();
    }

    private static void InitializeWindowsFormsSettings()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();
    }
    private static void InitializeAndShowSplashScreen()
    {
        _splashScreen = new Splash();
        _splashScreen.Show();
        _splashScreen.Activate();
        _splashScreen.Refresh();
        _splashScreen.TopMost = true;
        Thread.Sleep(750);
    }
    private static void InitializeAndCreateHost()
    {
        _host = CreateHostBuilder().Build();
        _serviceProvider = _host.Services;
    }
    private static void InitializeMainScreenAndCloseSplashScreen()
    {
        _mainScreen = _serviceProvider.GetRequiredService<Main>();
        _mainScreen.Load += (s, e) =>
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

            _mainScreen.TopMost = true;
            _mainScreen.Activate();
            _mainScreen.TopMost = false;
            _mainScreen.ShowInTaskbar = true;
        };

        Application.Run(_mainScreen);
    }
}