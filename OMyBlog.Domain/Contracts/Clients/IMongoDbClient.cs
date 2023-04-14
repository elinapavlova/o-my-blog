using MongoDB.Driver;

namespace OMyBlog.Domain.Contracts.Clients;

public interface IMongoDbClient
{
    IMongoClient CreateClient();
    IMongoDatabase GetDatabase();
}