namespace OMyBlog.Domain.Dtos.Person;

public record PersonResponse(
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

public record PersonAboutResponse(
    string UserName, 
    string? FirstName, 
    string? LastName, 
    string? PhoneNumber, 
    string? Email, 
    string? Description,
    List<string>? Interests)
{
    public string? UserName { get; set; } = UserName;
    public string? FirstName { get; set; } = FirstName;
    public string? LastName { get; set; } = LastName;
    public string? PhoneNumber { get; set; } = PhoneNumber;
    public string? Email { get; set; } = Email;
    public string? Description { get; set; } = Description;

    public List<string>? Interests { get; set; } = Interests;
    // public List<string>? Themes { get; set; } = about.Themes; //TODO
}