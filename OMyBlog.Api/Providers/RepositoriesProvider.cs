using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using OMyBlog.Domain.Contracts.Providers;
using OMyBlog.Domain.Contracts.Repositories;
using OMyBlog.Infrastructure.Repositories;

namespace OMyBlog.Api.Providers;

public class RepositoriesProvider : IDependencyProvider
{
    public void Register(IServiceCollection services)
    {
        RegisterGuidSerialization();

        //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IPersonRepository, PersonRepository>();
    }

    private static void RegisterGuidSerialization()
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        #pragma warning disable CS0618
        BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
        #pragma warning restore CS0618
    }
}