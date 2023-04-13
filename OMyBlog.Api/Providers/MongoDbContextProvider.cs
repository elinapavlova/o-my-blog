using MongoDB.Driver;
using OMyBlog.Core.Consts;
using OMyBlog.Domain.Contracts.Providers;
using OMyBlog.Domain.Options;

namespace OMyBlog.Api.Providers;

public class MongoDbContextProvider : IDependencyProviderWithConfig
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetValue<DbOptions>(OptionKeys.DbOptions);
        services.AddSingleton(x => new MongoClient(options?.ConnectionString ?? "mongodb://localhost:27017"));
    }
}