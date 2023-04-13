using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OMyBlog.Api.Swagger.SchemaFilters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;
using Unchase.Swashbuckle.AspNetCore.Extensions.Options;

namespace OMyBlog.Api.Swagger.ConfigureOptions;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
        }

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            BearerFormat = "Bearer {authToken}",
            Description = "JSON Web Token to access resources. Example: Bearer {token}",
            Type = SecuritySchemeType.ApiKey
        });
        options.AddSecurityRequirement(
            new OpenApiSecurityRequirement {{
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme, Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }});
                
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);

        options.AddEnumsWithValuesFixFilters(x =>
        {
            x.XEnumNamesAlias = "x-enum-varnames";
            x.XEnumDescriptionsAlias = "x-enum-descriptions";
                
            x.IncludeDescriptions = true;
            x.IncludeXEnumRemarks = true;
            x.DescriptionSource = DescriptionSources.DescriptionAttributesThenXmlComments;
            x.NewLine = "\n";
            x.IncludeXmlCommentsFrom(xmlPath);
        });
            
        options.SchemaFilter<EnumTypesSchemaFilter>();
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    
    private static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = nameof(OMyBlog),
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            info.Description += " Данная версия API устарела. Пожалуйста, используйте одну из актуальных версий API.";
        }

        return info;
    }
}
