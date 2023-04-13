namespace OMyBlog.Domain.Dtos.Person;

public class PersonInterestsUpdateRequest
{
    public List<string>? Interests { get; set; }
}

public record PersonUpdateResponse(
    Guid Id,
    PersonAboutResponse About, 
    DateTime CreatedAt, 
    DateTime? UpdatedAt, 
    DateTime? DeletedAt, 
    bool IsDeleted)
{
    public Guid Id { get; set; } = Id;
    public PersonAboutResponse About { get; set; } = About;
    
    public DateTime CreatedAt { get; set; } = CreatedAt;
    public DateTime? UpdatedAt { get; set; } = UpdatedAt;
    public DateTime? DeletedAt { get; set; } = DeletedAt;
    public bool IsDeleted { get; set; } = IsDeleted;
}