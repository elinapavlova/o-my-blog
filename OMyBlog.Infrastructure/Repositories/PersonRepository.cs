using MongoDB.Driver;
using OMyBlog.Domain.Contracts.Repositories;
using OMyBlog.Domain.Entities;
using OMyBlog.Domain.Options;

namespace OMyBlog.Infrastructure.Repositories;

public class PersonRepository : BaseRepository<PersonEntity>, IPersonRepository
{
    public PersonRepository(DbOptions options) : base(options)
    {
    }
    
    public async Task<PersonEntity?> UpdateOne(PersonEntity entity)
    {
        var filter = Builders<PersonEntity>.Filter.Eq(x => x.Id, entity.Id);
        var update = Builders<PersonEntity>.Update.Set(x => x.About.Interests, entity.About.Interests);

        return await UpdateOne(filter, update);
    }
}