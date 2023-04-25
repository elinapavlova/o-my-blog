using Newtonsoft.Json;
using OMyBlog.Domain.Contracts.Clients;
using OMyBlog.Domain.Contracts.Services;
using OMyBlog.Domain.Dtos;

namespace OMyBlog.Core.Services;

public class ElasticSearchService : IElasticSearchService
{
    private readonly IRabbitMqClient _rabbitMqClient;

    public ElasticSearchService(IRabbitMqClient rabbitMqClient)
    {
        _rabbitMqClient = rabbitMqClient;
    }

    //TODO Log
    public async Task IndexDocument(DocumentInfo document)
    {
        _rabbitMqClient.SendMessage(new MessageInfo( JsonConvert.SerializeObject(document), "documents.new", "documents"));
    }
}
/*
    //TODO перенести в Person
    public async Task Search<T>(string query, string indexName)
        where T : class
    {
        return _client.SearchAsync<T>(x => x
            .Index(indexName)
            //.Highlight()
            .Query(q => q.MultiMatch(m => m
                .Query(query)
                .Type(TextQueryType.BoolPrefix)
                .Fields(f => f
                    .Field(x => x.)))));
    }

    public async Task GetById<T>(Guid id)
        where T : class
    {
        return _client.GetAsync<T>(id, x => x.Index(_indexName));
    }
}
*/