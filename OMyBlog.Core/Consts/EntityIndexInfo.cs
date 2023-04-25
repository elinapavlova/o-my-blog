using System.Reflection;
using OMyBlog.Domain.Attributes;
using OMyBlog.Domain.Entities;

namespace OMyBlog.Core.Consts;

public static class EntityIndexInfo
{
    private static readonly IEnumerable<Type>? EntityTypes = Assembly
        .GetAssembly(typeof(BaseEntity))?
        .GetTypes()
        .Where(x =>
            x.IsSubclassOf(typeof(BaseEntity)));

    public static readonly Dictionary<Type, string> Info = GetEntityIndexInfo();

    private static Dictionary<Type, string> GetEntityIndexInfo()
    {
        var info = new Dictionary<Type, string>();

        if (EntityTypes == null)
        {
            return info;
        }
        
        foreach (var type in EntityTypes)
        {
            var indexName = ((BsonCollectionAttribute) type
                    .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                    .FirstOrDefault())
                ?.CollectionName;

            if (string.IsNullOrEmpty(indexName) is false)
            {
                info.Add(type, indexName);
            }
        }

        return info;
    }
}