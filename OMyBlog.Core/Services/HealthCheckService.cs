using MongoDB.Bson;
using MongoDB.Driver;
using Nest;
using OMyBlog.Domain.Contracts.Clients;
using OMyBlog.Domain.Contracts.Services;

namespace OMyBlog.Core.Services;

public class HealthCheckService : IHealthCheckService
{
    private readonly IMongoDatabase _database;
    private readonly ElasticClient _elasticClient;

    public HealthCheckService(IMongoDbClient client, IElasticSearchClient elasticSearchClient)
    {
        _elasticClient = elasticSearchClient.CreateClient();
        _database = client.GetDatabase();
    }

    //TODO Log
    public async Task<bool> PingDb()
    {
        try
        {
            await _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
        }
 
        catch (Exception)
        {
            return false;
        }
 
        return true;
    }

    public async Task<bool> PingElasticSearch()
    {
        return (await _elasticClient.Cluster.HealthAsync()).IsValid;
    }
}