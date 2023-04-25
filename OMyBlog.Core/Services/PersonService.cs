#nullable enable

using OMyBlog.Core.Consts;
using OMyBlog.Domain.Contracts.Repositories;
using OMyBlog.Domain.Contracts.Services;
using OMyBlog.Domain.Dtos;
using OMyBlog.Domain.Dtos.Person;
using OMyBlog.Domain.Mappers;

namespace OMyBlog.Core.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IElasticSearchService _elasticSearchService;

    public PersonService(IPersonRepository personRepository, IElasticSearchService elasticSearchService)
    {
        _personRepository = personRepository;
        _elasticSearchService = elasticSearchService;
    }

    public async Task<PersonUpdateResponse> UpdateOne(Guid id, PersonInterestsUpdateRequest request)
    {
        var person = await _personRepository.GetById(id);
        if (person is null)
        {
            //TODO Throw NotFoundException
            return null;
        }

        person.About.Interests = request.Interests;
        person = await _personRepository.UpdateOne(person);

        var type = EntityIndexInfo.Info
            .FirstOrDefault(x => x.Key == person.GetType())
            .Value;

        if (string.IsNullOrEmpty(type))
        {
            return null;
            //TODO
        }
        
        await _elasticSearchService.IndexDocument(new DocumentInfo(type, person));

        var result = PersonUpdateMapper.Map(person);
        return result;
    }

    public async Task<PersonResponse?> GetById(Guid id)
    {
        var person = await _personRepository.GetById(id);
        return person?.About is null
            ? null
            : PersonMapper.Map(person);
    }
}