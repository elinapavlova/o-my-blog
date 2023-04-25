using OMyBlog.Core.Services;
using OMyBlog.Domain.Contracts.Providers;
using OMyBlog.Domain.Contracts.Services;

namespace OMyBlog.Api.Providers;

public class ServicesProvider : IDependencyProvider
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IHealthCheckService, HealthCheckService>();
        services.AddScoped<IElasticSearchService, ElasticSearchService>();
    }
}