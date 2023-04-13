namespace OMyBlog.Domain.Dtos.Person;

public record PersonUpdateRequest
    (Guid Id, string? UserName, string? FirstName, string? LastName, string? PhoneNumber,
        string? Email, string? Description, List<string>? Interests, List<string>? Themes)
{
    public Guid Id { get; set; } = Id;
    public string? UserName { get; set; } = UserName;
    public string? FirstName { get; set; } = FirstName;
    public string? LastName { get; set; } = LastName;
    public string? PhoneNumber { get; set; } = PhoneNumber;
    public string? Email { get; set; } = Email;
    public string? Description { get; set; } = Description;

    public List<string>? Interests { get; set; } = Interests;
    public List<string>? Themes { get; set; } = Themes;
}

public class PersonInterestsUpdateRequest
{
    public List<string>? Interests { get; set; }
}

public record PersonUpdateResponse(Guid Id, PersonAboutResponse About)
{
    public Guid Id { get; set; } = Id;
    public PersonAboutResponse About { get; set; } = About;
}