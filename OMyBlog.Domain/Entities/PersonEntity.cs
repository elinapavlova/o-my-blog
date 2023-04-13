using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OMyBlog.Domain.Attributes;

namespace OMyBlog.Domain.Entities;

[BsonCollection("people")]
public class PersonEntity : BaseEntity
{
    public About About { get; set; }
}

public class About
{
    [BsonIgnoreIfNull]
    public string? UserName { get; set; }
    [BsonIgnoreIfNull]
    public string? FirstName { get; set; }
    [BsonIgnoreIfNull]
    public string? LastName { get; set; }
    [BsonIgnoreIfNull]
    public string? PhoneNumber { get; set; }
    [BsonIgnoreIfNull]
    public string? Email { get; set; }
    [BsonIgnoreIfNull]
    public string? Description { get; set; }
    [BsonIgnoreIfNull]
    public List<string>? Interests { get; set; }
    [BsonIgnoreIfNull]
    public List<ThemeEntity>? Themes { get; set; }
}