using OMyBlog.Domain.Dtos.Person;

namespace OMyBlog.Domain.Contracts.Services;

public interface IPersonService
{
    Task<PersonUpdateResponse> UpdateOne(Guid id, PersonInterestsUpdateRequest request);
    Task<PersonResponse?> GetById(Guid id);
}