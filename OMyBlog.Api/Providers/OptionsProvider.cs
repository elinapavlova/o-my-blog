using OMyBlog.Core.Consts;
using OMyBlog.Domain.Contracts.Providers;
using OMyBlog.Domain.Extensions;
using OMyBlog.Domain.Options;

namespace OMyBlog.Api.Providers;

public class OptionsProvider : IDependencyProviderWithConfig
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        var dbOptions = configuration.GetOptions<DbOptions>(OptionKeys.DbOptions);
        services.AddSingleton(dbOptions);

        var elasticSearchOptions = configuration.GetOptions<ElasticSearchOptions>(OptionKeys.ElasticSearchOptions);
        services.AddSingleton(elasticSearchOptions);

        var rabbitMqOptions = configuration.GetOptions<RabbitMqOptions>(OptionKeys.RabbitMqOptions);
        services.AddSingleton(rabbitMqOptions);
    }
}