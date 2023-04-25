using OMyBlog.Domain.Entities;

namespace OMyBlog.Domain.Dtos;

public record DocumentInfo(string IndexName, BaseEntity Entity)
{
    public readonly string IndexName = IndexName;
    
    public readonly BaseEntity Entity = Entity;
}