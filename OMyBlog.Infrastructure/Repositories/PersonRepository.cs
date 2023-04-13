using MongoDB.Driver;
using OMyBlog.Domain.Contracts.Repositories;
using OMyBlog.Domain.Entities;
using OMyBlog.Domain.Options;

namespace OMyBlog.Infrastructure.Repositories;

public class PersonRepository : BaseRepository<PersonEntity>, IPersonRepository
{
    private readonly IMongoCollection<PersonEntity> _collection;
    
    public PersonRepository(DbOptions options) : base(options)
    {
        var database = new MongoClient(options.ConnectionString).GetDatabase(options.DatabaseName);
        _collection = database.GetCollection<PersonEntity>(GetCollectionName(typeof(PersonEntity)));
    }
    
    public async Task<PersonEntity?> UpdateOne(PersonEntity entity)
    {
        var filter = Builders<PersonEntity>.Filter.Eq(x => x.Id, entity.Id);
        var update = Builders<PersonEntity>.Update.Set(x => x.About.Interests, entity.About.Interests);

        return await UpdateOne(filter, update);
    }
}