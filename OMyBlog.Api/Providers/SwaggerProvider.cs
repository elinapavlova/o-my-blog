using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using OMyBlog.Api.Swagger.ConfigureOptions;
using OMyBlog.Core.Consts;
using OMyBlog.Domain.Contracts.Providers;
using OMyBlog.Domain.Extensions;
using OMyBlog.Domain.Options;

namespace OMyBlog.Api.Providers;

public class SwaggerProvider : IDependencyProviderWithConfig
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        ConfigureVersioning(services, configuration);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }

    private void ConfigureVersioning(IServiceCollection services, IConfiguration configuration)
    {
        var appOptions = configuration.GetOptions<AppOptions>(OptionKeys.AppOptions);
        if (appOptions?.DefaultApiVersion is null)
        {
            // TODO throw exception
            throw new ArgumentNullException();
        }

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(appOptions.DefaultApiVersion.MajorVersion, appOptions.DefaultApiVersion.MinorVersion);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}