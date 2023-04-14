using Nest;

namespace OMyBlog.Domain.Contracts.Clients;

public interface IElasticSearchClient
{
    ElasticClient CreateClient();
}