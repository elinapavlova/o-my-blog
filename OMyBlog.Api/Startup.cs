using Microsoft.AspNetCore.Mvc.ApiExplorer;
using OMyBlog.Api.Providers;
using OMyBlog.Domain.Extensions;

namespace OMyBlog.Api;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //LoggerConfiguration.Configure(Configuration);
        //SwaggerConfiguration.Configure(services, Configuration);
        
        //services.Register<LoggerProvider>();
        services.Register<SwaggerProvider>(Configuration);
        services.Register<OptionsProvider>(Configuration);
        services.Register<MongoDbContextProvider>(Configuration);
        services.Register<RepositoriesProvider>();
        services.Register<ServicesProvider>();
        
        services.AddDirectoryBrowser();
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        /*
        services.AddControllers().AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
        });
        
        services.Register<AuthenticationProvider>(Configuration);*/
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(
            opt => {
                foreach (var description in provider.ApiVersionDescriptions) {
                    opt.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
        
       // app.UseAuthentication();
        app.UseHttpsRedirection();
       // app.UseMiddleware<HandleExceptionMiddleware>();
        app.UseRouting();
        //app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}