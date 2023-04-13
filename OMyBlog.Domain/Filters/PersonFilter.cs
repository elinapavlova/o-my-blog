using MongoDB.Bson;

namespace OMyBlog.Domain.Filters;

public class PersonFilter
{
    public ObjectId? Id { get; set; }
}