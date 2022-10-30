using MediatR;

namespace KodeFoxx.SimpleBroadcast.Core.Application;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAndConfigureApplication(
        this IServiceCollection services, IConfiguration configuration
    )
        => services.AddMediatR(typeof(IServiceCollectionExtensions).Assembly);
}