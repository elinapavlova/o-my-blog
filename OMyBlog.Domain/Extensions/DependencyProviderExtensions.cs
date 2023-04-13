using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OMyBlog.Domain.Contracts.Providers;

namespace OMyBlog.Domain.Extensions;

public static class DependencyProviderExtensions
{
    public static void Register<T>(this IServiceCollection services)
        where T : IDependencyProvider, new()
    {
        new T().Register(services);
    }

    public static void Register<T>(this IServiceCollection services, IConfiguration configuration)
        where T : IDependencyProviderWithConfig, new()
    {
        new T().Register(services, configuration);
    }
}
