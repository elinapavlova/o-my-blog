using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OMyBlog.Domain.Contracts.Providers;

public interface IDependencyProvider
{
    void Register(IServiceCollection services);
}

public interface IDependencyProviderWithConfig
{
    void Register(IServiceCollection services, IConfiguration configuration);
}