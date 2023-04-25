using OMyBlog.Domain.Dtos;

namespace OMyBlog.Domain.Contracts.Services;

public interface IElasticSearchService
{
    Task IndexDocument(DocumentInfo document);
}