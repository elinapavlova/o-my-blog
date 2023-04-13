using Microsoft.Extensions.Configuration;

namespace OMyBlog.Domain.Extensions;

public static class ConfigurationExtensions
{
    public static T GetOptions<T>(this IConfiguration configuration, string key)
        where T : new()
    {
        var value = new T();
        configuration.Bind(key, value);
        return value;
    }
}