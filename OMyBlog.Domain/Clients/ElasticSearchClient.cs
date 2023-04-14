using Elasticsearch.Net;
using Nest;
using OMyBlog.Domain.Contracts.Clients;
using OMyBlog.Domain.Options;

namespace OMyBlog.Domain.Clients;

public class ElasticSearchClient : IElasticSearchClient
{
    private readonly ElasticSearchOptions _options;
    
    public ElasticSearchClient(ElasticSearchOptions options)
    {
        _options = options;
    }

    public ElasticClient CreateClient()
    {
        var pool = new SingleNodeConnectionPool(new Uri(_options.ConnectionPool));
        var settings = new ConnectionSettings(pool)
            .CertificateFingerprint(_options.CertificateFingerPrint)
            .BasicAuthentication(_options.Authentication.Username, _options.Authentication.Password);

        settings.EnableApiVersioningHeader();
        return new ElasticClient(settings);
    }
}