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
    }
}