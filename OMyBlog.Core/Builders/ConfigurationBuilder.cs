using Microsoft.Extensions.Configuration;

namespace OMyBlog.Core.Builders;

public static class ConfigurationBuilder
{
    private static readonly IConfigurationRoot Builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
        .SetBasePath(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))
        .AddJsonFile("appsettings.json", false)
        .AddJsonFile("appsettings.Development.json", true)
        .Build();

    public static IConfigurationRoot Build()
        => Builder;
}