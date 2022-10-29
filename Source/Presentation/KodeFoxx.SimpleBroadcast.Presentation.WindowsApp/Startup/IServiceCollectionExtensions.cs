using System.Reflection;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

internal static class IServiceCollectionExtensions
{
    internal static IServiceCollection AddFormsAsTransient(this IServiceCollection services)
    {
        var formTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass
                        && !t.IsAbstract
                        && !t.IsInterface
            )
            .Where(t => typeof(Form).IsAssignableFrom(t));

        foreach (var formType in formTypes)
            services.AddTransient(formType);

        return services;
    }
}
