using System.Reflection;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

internal sealed class ApplicationExtensions
{
    public static string GetVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var dateTime = File.GetLastWriteTimeUtc(assembly.Location)
                .ToString()
                .Replace(" ", "-")
                .Replace(":", "")
                .Replace(@"/", "");

        return $"preview 0.1 -{dateTime}";
    }
}
