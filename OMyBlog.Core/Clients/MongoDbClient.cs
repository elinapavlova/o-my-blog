using MongoDB.Driver;
using OMyBlog.Domain.Contracts.Clients;
using OMyBlog.Domain.Options;

namespace OMyBlog.Core.Clients;

public class MongoDbClient : IMongoDbClient
{
    private readonly DbOptions _options;
    
    public MongoDbClient(DbOptions options)
    {
        _options = options; //TODO throw NullException
    }
    
    public IMongoClient CreateClient()
    {
        return new MongoClient(_options.ConnectionString);
    }

    public IMongoDatabase GetDatabase()
    {
        var client = CreateClient();
        return client.GetDatabase(_options.DatabaseName);
    }
}