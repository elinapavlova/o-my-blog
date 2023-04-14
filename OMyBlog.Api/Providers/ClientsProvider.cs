using OMyBlog.Domain.Clients;
using OMyBlog.Domain.Contracts.Clients;
using OMyBlog.Domain.Contracts.Providers;

namespace OMyBlog.Api.Providers;

public class ClientsProvider : IDependencyProvider
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<IMongoDbClient, MongoDbClient>();
        services.AddScoped<IElasticSearchClient, ElasticSearchClient>();
    }
}