using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OMyBlog.Domain.Entities;

public class BaseEntity
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; }
    public DateTime? DeletedAt { get; }
}