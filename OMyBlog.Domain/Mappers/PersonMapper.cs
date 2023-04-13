using OMyBlog.Domain.Dtos.Person;
using OMyBlog.Domain.Entities;

namespace OMyBlog.Domain.Mappers;

public static class PersonMapper
{
    public static PersonResponse Map(PersonEntity person)
    {
        return new PersonResponse(person.Id, 
            new PersonAboutResponse(person.About.UserName, person.About.FirstName, person.About.LastName, 
                person.About.PhoneNumber, person.About.Email, person.About.Description, person.About.Interests));
    }
}

public static class PersonUpdateMapper
{
    public static PersonUpdateResponse Map(PersonEntity person)
    {
        return new PersonUpdateResponse(person.Id, 
            new PersonAboutResponse(person.About.UserName, person.About.FirstName, person.About.LastName, 
                person.About.PhoneNumber, person.About.Email, person.About.Description, person.About.Interests));
    }
}