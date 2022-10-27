namespace KodeFoxx.SimpleBroadcast.Core.Domain;

public static class DependencyRegistrations
{
    public static IServiceCollection AddAndConfigureDomain(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services;
    }
}